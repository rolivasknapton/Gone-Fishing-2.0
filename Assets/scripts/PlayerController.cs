using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player movement

    private Rigidbody rb;
    [SerializeField] private UI_Inventory uiInventory;

    private Inventory inventory;
    private void Awake()
    {

        //add item to inventory
        inventory = new Inventory();
        
    }
    void Start()
    {
        uiInventory.SetInventory(inventory);
        //idk why but this is the only way to get fish

        ItemWorld.SpawnItemWorld(new Vector3(-1.23f, 0.14f, -1.60f), new Item { itemType = Item.ItemType.Fish, amount = 1 });
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the player
    }
    private void OnTriggerEnter(Collider other)
    {
        ItemWorld itemWorld = other.GetComponent<ItemWorld>();
        if (itemWorld != null)
        {
            //touching item
            inventory.AddItem(itemWorld.GetItem());
            itemWorld.DestroySelf();
        }
    }

    void Update()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed;

        // Move the player
        rb.velocity = movement;

        // Move the camera along with the player
        //MoveCamera(horizontalInput, verticalInput);

        //pick up item on space key
        
    }
    

    void MoveCamera(float horizontalInput, float verticalInput)
    {
        // Get the main camera
        Camera mainCamera = Camera.main;

        // Calculate camera movement direction
        Vector3 cameraMovement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;

        // Move the camera
        mainCamera.transform.position += cameraMovement;
    }
}


