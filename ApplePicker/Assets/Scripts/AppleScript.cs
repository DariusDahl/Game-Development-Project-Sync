using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{

    public static float bottomY = -20f;
    public int points = 100;

    void Start() {
        // Start rigidbody objects (apples) as already in freefall so there is no pause when they spawn in
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = new Vector3(0, -10f, 0); // Adjust speed (-10 is a good start)
        }

        // Check if this is a Golden Apple and update points accordingly
        if (gameObject.CompareTag("GoldenApple")) {
            points = 300; // Golden Apples are worth 300 points
        } else if (gameObject.CompareTag("PoisonApple")) {
            points = 0; // Poison Apples are worth 0 points, instead they take away a life when caught in the basket
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

            // If the apple is not poisonous then the player will lose a life
            if (!gameObject.CompareTag("PoisonApple")) {
                // Get a reference to the ApplePicker component of Main Camera
                ApplePickerScript apScript = Camera.main.GetComponent<ApplePickerScript>();
                // Call the public AppleMissed() method of apScript
                apScript.AppleMissed();
            }
        }
    }
}
