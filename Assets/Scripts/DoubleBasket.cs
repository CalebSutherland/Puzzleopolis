using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePlateController : MonoBehaviour
{
    public PlateNoElavator plate1;
    public PlateNoElavator plate2;
    public GameObject targetObject;

    void Update()
    {
        if (plate1.isActivated && plate2.isActivated)
        {
            targetObject.SetActive(false);
        }
        else
        {
            targetObject.SetActive(true); // Optionally reactivate the object if any plate is empty
        }
    }
}
