using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HauntedHouse : MonoBehaviour
{
    [SerializeField]
    private GameObject openDoubleDoors;
    [SerializeField]
    private GameObject shutDoubleDoors;

    public GameObject dirtspawner;
    public GameObject Dirt;
    private GameObject activeDirt;
    // Start is called before the first frame update
    
    public void ShutDoors()
    {
        shutDoubleDoors.SetActive(true);
        openDoubleDoors.SetActive(false);
    }
    public void UpstairsSteps()
    {

        activeDirt = Instantiate(Dirt, dirtspawner.transform.position, dirtspawner.transform.rotation);
        StartCoroutine(StopDirtAnimation());

    }
    IEnumerator StopDirtAnimation()
    {

        yield return new WaitForSeconds(2);
        StopActiveParticles(activeDirt);
    }
    private void StopActiveParticles(GameObject obj)
    {
        var particles = obj.GetComponent<ParticleSystem>();
        var emission = particles.emission;
        emission.rateOverTime = 0f;
        ObjDestroyer.Instance.DestroyAfterFiveSeconds(obj);

    }
}
