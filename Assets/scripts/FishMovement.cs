using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    [SerializeField]
    private Mesh waterMesh;
    private CapsuleCollider waterCollider;
    private GameObject water;
    //private float fishSpeed= 5;
    private Vector3 fishDirection;
    private Vector3 newDirection;
    private Vector3 currentPosition;

    public bool FishNearHook = false;

    public bool isMovingTowardsPlayer;
    private GameObject player;
    private PlayerController playercontroller;

    private float yPosition = 0.019f;
    public float duration = 1.0f;
    private float elapsedTime = 0.0f; // Time elapsed since the interpolation started

    public GameObject Bubbles;
    private GameObject activeBubbles;
    private bool bubbleActive;
    // Start is called before the first frame update
    private void Start()
    {
        currentPosition = transform.position;

        water = GameObject.FindWithTag("Water");
        player = GameObject.FindWithTag("Player");
        playercontroller = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        waterCollider = water.GetComponent<CapsuleCollider>();

        fishDirection = GetRandomPointInCollider(waterCollider);
         
        StartFishWander();


        //transform.position = fishDirection;  

    }
    private void Update()
    {


        elapsedTime += Time.deltaTime * .1f;
        float t = Mathf.Clamp01(elapsedTime / duration);
        transform.position = Vector3.Lerp(currentPosition, fishDirection, t);

        if (t >= 1.0f)
        {
            currentPosition = transform.position;
            elapsedTime = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //ChangeFishDestination();
        }

        //checks if fish is moving towards player and if the player moves then change direction
        if (isMovingTowardsPlayer && player.GetComponent<Rigidbody>().velocity != Vector3.zero)
        {
            //Debug.Log("player moved");
            StartFishWander();

            isMovingTowardsPlayer = false;
        }
        if (isMovingTowardsPlayer && Input.GetKeyDown("space") && !playercontroller.fishButtonDown)
        {
            StartFishWander();
        }


        if (FishNearHook && Input.GetKeyDown("space"))
        {
            Destroy(gameObject);
            StopActiveParticles(activeBubbles);
            
            //adds item to inventory
            playercontroller.inventory.AddItem(new Item { itemType = Item.ItemType.Fish, amount = 1 });
            
            
            water.GetComponent<Pond>().fishInPond = RemoveGameObjectFromArray(water.GetComponent<Pond>().fishInPond, gameObject);

        }

    }
    private GameObject[] RemoveGameObjectFromArray(GameObject[] array, GameObject obj)
    {
        List<GameObject> tempList = new List<GameObject>(array);
        tempList.Remove(obj);
        return tempList.ToArray();
    }

    private void OnTriggerStay(Collider other)
    {   
        //test bool
        //bool touching = false;

        if (other.gameObject.name == "FishingRodTip")
        {
            
            FishNearHook = true;

            
            if (!bubbleActive)
            {
                activeBubbles = Instantiate(Bubbles, transform.position, transform.rotation);
                bubbleActive = true;
            }
            
            //touching = true;
            //Debug.Log(touching);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "FishingRodTip")
        {
            FishNearHook = false;
            
            //Debug.Log("no longer touching");
        }

    }

    public void MoveTowardPlayer()
    {
        Debug.Log("fisgh");
        //stop random fish movement
        CancelInvoke(); 

        //set current position
        currentPosition = transform.position;

        //set lerp time
        elapsedTime = 0.0f;

        //find hook
        Vector3 fishingRodHook = GameObject.FindWithTag("FishingRodHook").transform.position;

        //move fish toward hook
        fishDirection = fishingRodHook;

        //adjusts state of movement
        isMovingTowardsPlayer = true;

        //find player
        //Vector3 playerLocation = GameObject.FindWithTag("Player").transform.position;

        //adjust to fishing rod location
        //Vector3 fishingRod = new Vector3(playerLocation.x, yPosition, playerLocation.z);

        //move fish towards foot of player
        //fishDirection = fishingRod;

        //Debug.Log(fishDirection);

    }
    private void StartFishWander()
    {
        InvokeRepeating("ChangeFishDestination", 0f, Random.Range(4, 10.0f));
        isMovingTowardsPlayer = false;
    }
    private void ChangeFishDestination()
    {
        currentPosition = transform.position;
        elapsedTime = 0.0f;
        fishDirection = GetRandomPointInCollider(waterCollider);
    }

    private Vector3 GetRandomPointInCollider(CapsuleCollider water)
    {
        float offset= 0f;
        
        Bounds filterBounds = water.bounds;
        Vector3 minBounds = new Vector3(filterBounds.min.x + offset, filterBounds.min.y, filterBounds.min.z + offset);
        Vector3 maxBounds = new Vector3(filterBounds.max.x - offset, filterBounds.max.y, filterBounds.max.z-offset);

        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomZ = Random.Range(minBounds.z, maxBounds.z);
        /*
        Debug.Log(randomZ);
        Debug.Log(randomX);
        */
        return new Vector3(randomX, yPosition, randomZ);

    }
    private void StopActiveParticles(GameObject obj)
    {
        var particles = obj.GetComponent<ParticleSystem>();
        var emission = particles.emission;
        emission.rateOverTime = 0f;
        ObjDestroyer.Instance.DestroyAfterFiveSeconds(obj);

    }
    



}
