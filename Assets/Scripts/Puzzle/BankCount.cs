using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BankCount : MonoBehaviour
{
    private int numObjectsIn;
    public GameObject youWinText;

    void Start()
    {
        youWinText.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        numObjectsIn++;
        if(numObjectsIn == 5)
        {
            youWinText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        numObjectsIn--;
    }
}
