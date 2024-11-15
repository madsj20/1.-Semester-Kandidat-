using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectVisibility : MonoBehaviour
{
    //bool isVisible = true;
    //public GameObject childObject; // Add a reference to the child object

    public void MakeVisible()
    {
        //childObject.SetActive(true); // Activates child
        gameObject.transform.GetChild(0).gameObject.SetActive(true); // Activates first child
    }

    public void MakeInvisible()
    {
        //childObject.SetActive(false); // Deactivates child
        gameObject.transform.GetChild(0).gameObject.SetActive(false); // Deactivates first child
    }
}
