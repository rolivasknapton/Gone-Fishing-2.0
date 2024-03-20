using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GregMovement : MonoBehaviour
{

    float speed = 1f;
    public float yValue = 0f; // You can adjust the y value as per your requirement
    public Vector3 direction; // Variable to store the generated direction

    private void Start()
    {
        // Invoke the GenerateDirection method every few seconds starting after 0 seconds
        InvokeRepeating("GenerateDirection", 0f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void GenerateDirection()
    {
        // Generate random values for x and z
        float randomX = Random.Range(-10f, 10f); // Adjust the range as needed
        float randomZ = Random.Range(-10f, 10f); // Adjust the range as needed

        // Create a new Vector3 with the random x and z values, and the consistent y value
        direction = new Vector3(randomX, yValue, randomZ);
        direction.Normalize();

        // Debug.Log to see the generated direction in the console (optional)
        //Debug.Log("New Direction: " + direction);
    }
}
