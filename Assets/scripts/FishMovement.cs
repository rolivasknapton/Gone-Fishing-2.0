using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour
{
    [SerializeField]
    private Mesh waterMesh;
    private MeshCollider waterCollider;
    private GameObject water;
    //private float fishSpeed= 5;
    private Vector3 fishDirection;

    
    // Start is called before the first frame update
    private void Start()
    {
        water = GameObject.FindWithTag("Water");
        waterCollider = water.GetComponent<MeshCollider>();

        fishDirection = GetRandomPointInMeshFilter(waterCollider);

        transform.position = fishDirection;        
    }

    
   
    private Vector3 GetRandomPointInMeshFilter(MeshCollider water)
    {
        
        Bounds filterBounds = water.bounds;
        Vector3 minBounds = new Vector3(filterBounds.min.x, filterBounds.min.y, filterBounds.min.z);
        Vector3 maxBounds = new Vector3(filterBounds.max.x, filterBounds.max.y, filterBounds.max.z);

        float randomX = Random.Range(minBounds.x, maxBounds.x);
        float randomZ = Random.Range(minBounds.z, maxBounds.z);

        Debug.Log(randomZ);
        Debug.Log(randomX);
        return new Vector3(randomX, 0.11f, randomZ);

    }
    


}
