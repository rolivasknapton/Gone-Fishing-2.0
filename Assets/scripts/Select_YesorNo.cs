using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_YesorNo : MonoBehaviour
{
    [SerializeField] private GameObject yesSelected;
    [SerializeField] private GameObject noSelected;
    // Start is called before the first frame update

    private bool canPress = true;
    private void OnEnable()
    {
        noSelected.SetActive(false);
        yesSelected.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) && canPress)
        {
            canPress = false;
            if (YesSelected())
            {

                yesSelected.SetActive(false);
                noSelected.SetActive(true);
                return;
            }
            else
            {
                noSelected.SetActive(false);
                yesSelected.SetActive(true);
            }
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            canPress = true;
        }
        
    }
    public bool YesSelected()
    {
        if (yesSelected.activeSelf)
        {
            return true;
        }
        else return false;
    }
}
