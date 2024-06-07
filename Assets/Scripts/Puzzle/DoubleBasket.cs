using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPlateController : MonoBehaviour
{
    public List<PlateNoElavator> plates; // List to store references to multiple plates
    public GameObject targetObject;

    void Update()
    {
        bool allActivated = true;

        // Iterate through all plates to check if they are activated
        foreach (PlateNoElavator plate in plates)
        {
            if (!plate.isActivated)
            {
                allActivated = false;
                break;
            }
        }

        // Activate or deactivate the target object based on the plates' status
        targetObject.SetActive(!allActivated);
    }
}