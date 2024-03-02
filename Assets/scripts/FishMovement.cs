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


    private float yPosition = 0.019f;
    public float duration = 1.0f;
    private float elapsedTime = 0.0f; // Time elapsed since the interpolation started
    // Start is called before the first frame update
    private void Start()
    {
        currentPosition = transform.position;

        water = GameObject.FindWithTag("Water");
        waterCollider = water.GetComponent<CapsuleCollider>();

        fishDirection = GetRandomPointInMeshFilter(waterCollider);
         
        StartFishWander();


        //transform.position = fishDirection;  

    }
    private void Update()
    {

        elapsedTime += Time.deltaTime*.1f;
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

    }
    public void MoveTowardPlayer()
    {
        CancelInvoke(); 
        currentPosition = transform.position;
        elapsedTime = 0.0f;

        fishDirection = GameObject.FindWithTag("Player").transform.position;
        Debug.Log(fishDirection);

    }
    private void StartFishWander()
    {
        InvokeRepeating("ChangeFishDestination", 0f, Random.Range(4, 10.0f));
    }
    private void ChangeFishDestination()
    {
        currentPosition = transform.position;
        elapsedTime = 0.0f;
        fishDirection = GetRandomPointInMeshFilter(waterCollider);
    }

    private Vector3 GetRandomPointInMeshFilter(CapsuleCollider water)
    {
        
        Bounds filterBounds = water.bounds;
        Vector3 minBounds = new Vector3(filterBounds.min.x, filterBounds.min.y, filterBounds.min.z);
        Vector3 maxBounds = new Vector3(filterBounds.max.x, filterBounds.max.y, filterBounds.max.z);

        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomZ = Random.Range(minBounds.z, maxBounds.z);
        /*
        Debug.Log(randomZ);
        Debug.Log(randomX);
        */
        return new Vector3(randomX, yPosition, randomZ);

    }
    


}
