using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GregMovement : MonoBehaviour
{
    public GameObject poof;
    float speed = 1f;
    public float yValue = 0f; // You can adjust the y value as per your requirement
    public Vector3 direction; // Variable to store the generated direction
    private bool isTalking;
    public bool isVisible;
    private void Start()
    {
        // Invoke the GenerateDirection method every few seconds starting after 0 seconds
        InvokeRepeating("GenerateDirection", 0f, 4f);

        isVisible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanMove())
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
        
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
    private bool CanMove()
    {
        if (isTalking)
        {
            return false;
        }
        else
        {
            return true;
        }
               
    }
    public void StartConversation()
    {
        isTalking = true;
    }
    public void EndConversation()
    {
        //every time the conversation ends greg converation, hes "poofs away"
        GregPoof();

        isTalking = false;

    }
    private void GregPoof()
    {
        Vector3 currentPosition = transform.position;
        Instantiate(poof, currentPosition, Quaternion.identity);
        SpriteRenderer spriteRenderer;
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Check if the SpriteRenderer component exists
        if (spriteRenderer != null)
        {
            //make uninteractable
            isVisible = false;

            // Disable the SpriteRenderer
            spriteRenderer.enabled = false;

            //in 1 second enable the sprite rendera again
            StartCoroutine(EnableSpriteRendererAfterDelay(spriteRenderer));
        }
        
    }
    private IEnumerator EnableSpriteRendererAfterDelay(SpriteRenderer renderer)
    {
        // Wait for 10 second
        yield return new WaitForSeconds(3f);

        // Enable the SpriteRenderer component
        renderer.enabled = true;

        //make interactable again
        isVisible = true;

        //make another poof
        Vector3 currentPosition = transform.position;
        Instantiate(poof, currentPosition, Quaternion.identity);
    }
    public void ChangePosition()
    {
        // Set the new position
        transform.position = new Vector3(0f, 0.51f, 0f);

        //make another poof
        Vector3 currentPosition = transform.position;
        Instantiate(poof, currentPosition, Quaternion.identity);
    }
}
