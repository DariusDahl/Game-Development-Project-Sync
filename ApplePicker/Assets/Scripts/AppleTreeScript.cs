using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTreeScript : MonoBehaviour
{
    [Header("Inscribed")]

    // Prefab for instantiating Apples
    public GameObject applePrefab;

    // Prefab for instantiating Golden Apples
    public GameObject goldenApplePrefab;

    // Speed at which the AppleTree moves
    public float speed = 2f;

    // Distance where AppleTree turns around
    public float leftAndRightEdge = 10f;

    // Chance that the AppleTree will change directions
    public float changeDirChance = 0.1f;

    // Seconds between Apple instantiations
    public float appleDropDelay = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        if (goldenApplePrefab == null) {
            Debug.LogError("No Golden Apple prefab assigned!", this);
        }

        // Start dropping apples
        Invoke("DropApple", 1f);
    }

    void DropApple()
    {    
        // 1 in 5 chance to spawn a golden apple
        if (Random.Range(0, 5) == 0) {
            GameObject applePrefabToSpawn = Instantiate<GameObject>(goldenApplePrefab); // Instantiate the Golden Apple prefab
            applePrefabToSpawn.transform.position = transform.position;
        } else{
            GameObject applePrefabToSpawn = Instantiate<GameObject>(applePrefab); // Instantiate the Apple prefab
            applePrefabToSpawn.transform.position = transform.position;
        }

        // GameObject apple = Instantiate<GameObject>(applePrefabToSpawn);
        // apple.transform.position = transform.position;

        Invoke("DropApple", appleDropDelay);
    }

    // Update is called once per frame
    void Update()
    {
        // Basic movement
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        // Changing directions
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed); // Move right
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed); // Move left
        } 
    }

    void FixedUpdate()
    {
        // Random direction changes are now time-based due to FixedUpdate()
        if (Random.value < changeDirChance)
        {
            speed *= -1; // Change direction
        }
    }
}
