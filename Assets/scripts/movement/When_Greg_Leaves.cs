using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class When_Greg_Leaves : MonoBehaviour
{
    public GregMovement gregMovement;
    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<GregMovement>() != null)
        {
            gregMovement.ChangePosition();
        }
    }
}
