using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Ballroom_Event : MonoBehaviour
{
    [SerializeField]
    private HauntedHouse hauntedHouse;

    private CinemachineImpulseSource impulseSource;
    private bool animationTriggered = false;

    private void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !animationTriggered)
        {
            FootstepsAnimation();
        }
    }

    public void FootstepsAnimation()
    {
        if (animationTriggered)
            return;

        animationTriggered = true;

        Debug.Log("Hi");
        hauntedHouse.UpstairsSteps();

        // Trigger CameraShake three times with delays
        StartCoroutine(TriggerCameraShakeSequence());
    }

    private IEnumerator TriggerCameraShakeSequence()
    {
        for (int i = 0; i < 3; i++)
        {
            CameraShakeManager.instance.CameraShake(impulseSource);
            yield return new WaitForSeconds(0.7f); // Adjust the delay as needed
        }
    }
}
