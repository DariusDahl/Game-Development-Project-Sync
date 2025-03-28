using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour {
    // fields set in the Unity Inspector pane
    [Header("Inscribed")]
    public GameObject prefabProjectile;
    public float velocityMult = 10f;
    public GameObject projLinePrefab;

    // fields set dynamically
    [Header("Dynamic")]
    public GameObject launchPoint;
    public Vector3 launchPosition;
    public GameObject projectile;
    public bool aimingMode;

    void Awake() {
        Transform launchPointTransform = transform.Find("LaunchPoint");
        launchPoint = launchPointTransform.gameObject;
        launchPoint.SetActive( false );
        launchPosition = launchPointTransform.position;
    }

    void OnMouseEnter() {
        // print( "Slingshot:onMouseEnter()" );
        launchPoint.SetActive( true );
    }

    void OnMouseExit() {
        // print( "Slingshot:onMouseExit()" );
        launchPoint.SetActive( false );
    }

    void OnMouseDown() {
        // the player has pressed the mouse button while over Slingshot
        aimingMode = true;
        // instantiate a projectile
        projectile = Instantiate( prefabProjectile ) as GameObject;
        // start it at the launchPoint
        projectile.transform.position = launchPosition;
        // set it to isKinematic for now
        projectile.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Update() {
        // If Slingshot is not in aimingMode, don't run this code
        if (!aimingMode) return;

        // Get the current mouse position in 2D screen coordinates
        Vector3 mousePosition2D = Input.mousePosition;
        mousePosition2D.z = -Camera.main.transform.position.z;
        Vector3 mousePosition3D = Camera.main.ScreenToWorldPoint( mousePosition2D );

        // Find the delta from the launchPosition to the mousePos3D
        Vector3 mouseDelta = mousePosition3D - launchPosition;

        // Limit mouseDelta to the radius of the Slingshot SphereCollider
        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if (mouseDelta.magnitude > maxMagnitude) {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        // Move the projectile to this new position
        Vector3 projectilePosition = launchPosition + mouseDelta;
        projectile.transform.position = projectilePosition;

        if ( Input.GetMouseButtonUp(0) ) {
            // the mouse has been released
            aimingMode = false;
            Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
            projectileRigidbody.isKinematic = false;
            projectileRigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
            projectileRigidbody.velocity = -mouseDelta * velocityMult;

            // switch to slingshot view immediately before setting POI
            FollowCam.SWITCH_VIEW(FollowCam.eView.slingshot);

            FollowCam.POI = projectile; // Set the _MainCamera POI

            // Add a ProjectileLine to the Projectile
            Instantiate<GameObject>(projLinePrefab, projectileRigidbody.transform);

            projectile = null;
            MissionDemolition.SHOT_FIRED();
        }
    }

}
