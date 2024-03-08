using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player movement

    public GameObject fishingRod;
    private bool canFish;
    public bool currentlyFishing;

    private GameObject pond;

    private Vector3 playerPosition;
    private Rigidbody rb;
    [SerializeField] private UI_Inventory uiInventory;

    private Inventory inventory;
    private void Awake()
    {
        //set reference to pond
        pond = GameObject.FindGameObjectWithTag("Water");
        
        //add item to inventory
        inventory = new Inventory();
        
    }
    void Start()
    {
        
        playerPosition = transform.position;
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

        if(other.gameObject.tag == "Water")
        {
            //Debug.Log("hit the water");
            canFish = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            canFish = false;
        }
    }
    

    void Update()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed;

        //rotation of player
        if (movement != Vector3.zero)
        {
            // Create a rotation to look at the target
            Quaternion targetRotation = Quaternion.LookRotation(movement);

            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
            

        // Move the player
        rb.velocity = movement;

        //sets currently fishing to false and deactivates the fishing rod if the polayer is currently fishing and moves
        if(rb.velocity != Vector3.zero && currentlyFishing)
        {
            currentlyFishing = false;
            fishingRod.SetActive(false);
        }

        //current player posistion
        playerPosition = transform.position;

        // Move the camera along with the player
        MoveCamera();

        //pick up item on space key


        //check if yo ucan fish and if you are pressing the fish button
        if (CanFish() && Input.GetKeyUp("space"))
        {
          
                PlayerFish();
            
        }

        //check if you are currently fishing and a fish is overlapping the collision attached tothe hook
        //destroy the fish that is overlapping the hook and remove it from the pond array fishinpond[]
    }
    
    private void PlayerFish()
    {
        //Debug.Log("fish!");
        fishingRod.SetActive(true);
        currentlyFishing = true;
        
        
        IFishable fishable;

        fishable = pond.GetComponent<IFishable>();
        fishable.Fish();

    }
    void MoveCamera()
    {
        // Get the main camera
        Camera mainCamera = Camera.main;

        // Calculate camera movement direction
        Vector3 cameraMovement = new Vector3(playerPosition.x, 3.87f, playerPosition.z - 7.24f);

        // Move the camera
        mainCamera.transform.position = cameraMovement;
    }
    private bool CanFish()
    {
        if (canFish && currentlyFishing!=true)
        {
            return true;
        }
        else return false;
    }
}


