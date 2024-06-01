using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDestroyer : MonoBehaviour
{

    public static ObjDestroyer Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void DestroyAfterFiveSeconds(GameObject obj)
    {
        StartCoroutine(DestroyObjectCoroutine(obj));
    }
    public IEnumerator DestroyObjectCoroutine(GameObject obj)
    {
        yield return new WaitForSeconds(5);
        Destroy(obj);
    }
}
