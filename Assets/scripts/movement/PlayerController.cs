using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed; // Speed of the player movement


    [SerializeField]
    private BoxCollider interactHitbox;


    public GameObject fishingRod;
    public GameObject shovel;
    private bool canFish;
    
    public bool currentlyFishing;
    public bool currentlySpeaking = false;

    private GameObject pond;

    public Vector3 playerPosition;
    private Rigidbody rb;
    [SerializeField] private UI_Inventory uiInventory;

    public GameObject nearbyObject = null;


    public bool fishButtonDown;
    public Inventory inventory;

    public Vector3 CurrentNPCCameraPosition;
    public CameraMover cameraMover;

    private void Awake()
    {
        playerPosition = transform.position;

        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to the player

        //set reference to pond
        pond = GameObject.FindGameObjectWithTag("Water");
        
        //instatntiating inventory
        inventory = new Inventory();
        
    }
    void Start()
    {
        
        
        uiInventory.SetInventory(inventory);
        //idk why but this is the only way to get fish

        //ItemWorld.SpawnItemWorld(new Vector3(-1.23f, 0.14f, -1.60f), new Item { itemType = Item.ItemType.Key, amount = 1 });
        
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
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput);
        direction.Normalize();

        //store direction and move speed in movement vector
        Vector3 movement =  direction * moveSpeed;
        

        //rotation of player
        if (movement != Vector3.zero && CanMove())
        {
            // Create a rotation to look at the target
            Quaternion targetRotation = Quaternion.LookRotation(movement);

            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        }


        // Move the player if can move
        if (CanMove())
        {
            rb.velocity = movement;
        }
        

        //sets currently fishing to false and deactivates the fishing rod if the polayer is currently fishing and moves
        if(rb.velocity != Vector3.zero && currentlyFishing)
        {
            CancelFishing();
        }

        //current player posistion
        playerPosition = transform.position;

        // Move the camera along with the player
        MoveCamera();


        //check if you are near an interactable entity && space pressed
        OnSpaceActivateNearbyObject();

        
        
        //Interact button
        if (Input.GetKeyDown("space"))
        {
            //check if yo ucan fish and if you are pressing the fish button
            if (currentlyFishing)
            {
                CancelFishing();
            }
            else if (CanFish())
            {
                PlayerFish();
                fishButtonDown = true;
                
            }
        }
        if (Input.GetKeyUp("space") && fishButtonDown)
        {
            fishButtonDown = false;
        }
        

        
        //check if you are currently fishing

        //and if the fish that is currently moveing toward the hook is overlapping the collision attached to the hook

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

        //get first virtual camera
        CinemachineVirtualCamera vcam = CinemachineVirtualCamera.FindObjectOfType<CinemachineVirtualCamera>();

        
        // Calculate camera movement direction

        Vector3 cameraMovement = new Vector3(playerPosition.x, 3.87f, playerPosition.z - 12f);

       

        if (!currentlySpeaking&& (IsAnyWASDPressed() || rb.velocity != Vector3.zero))
        { // Move the camera
            if (cameraMover != null)
            {
                cameraMover.enabled = false;
            }
            
            //move the cam
            mainCamera.transform.position = cameraMovement;

            //if the virtual camera is present, move the vcamera
            if(vcam != null)
            {
                vcam.transform.position = mainCamera.transform.position;
            }
            
            
            //mainCamera.transform.position = CurrentNPCCameraPosition;
        }
    }
    private bool CanFish()
    {
        if (canFish && currentlyFishing!=true)
        {
            return true;
        }
        else return false;
    }
    private bool CanMove()
    {
        if (currentlySpeaking)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void CancelFishing()
    {
        currentlyFishing = false;
        fishingRod.SetActive(false);
    }
    public void StoreNearestGameObject(GameObject obj)
    {
        nearbyObject = obj;
        //Debug.Log(obj);
    }
    
    //interacts with the nearby object if there is one and if the player pressed space
    private void OnSpaceActivateNearbyObject()
    {

        if (nearbyObject == null)
        {
            return;
        }
        if (Input.GetKeyDown("space"))
        {
            if (nearbyObject.GetComponent<IDiggable>() != null)
            {
                shovel.SetActive(true);
            }

            nearbyObject.GetComponent<IInteractable>().Interact();
            if (nearbyObject != null && nearbyObject.GetComponent<ITalkable>() != null)
            {
                

                //Camera mainCamera = Camera.main;
                //mainCamera.transform.position = CurrentNPCCameraPosition;
                if (cameraMover.targetPosition != CurrentNPCCameraPosition)
                {
                    //Debug.Log("Gay");
                    cameraMover.enabled = true;
                    cameraMover.LerpToPosition(CurrentNPCCameraPosition);
                }
                else if (!currentlySpeaking)
                {
                    cameraMover.enabled = true;
                    cameraMover.LerpToPosition(new Vector3(playerPosition.x, 3.87f, playerPosition.z - 12f));
                }

                

            }
            
        }
    }
    public void DialogueStarted()
    {
        currentlySpeaking = true;
    }
    public void DialogueEnded()
    {
        currentlySpeaking = false;
    }
    public void SetCameraPosition(GameObject obj)
    {

       CurrentNPCCameraPosition = obj.transform.position;
    }
    public bool IsAnyWASDPressed()
    {
        // Check if any of the WASD keys are currently held down
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            return true; // Return true if any of the WASD keys are pressed
        }
        else
        {
            return false; // Return false if none of the WASD keys are pressed
        }
    }

}


