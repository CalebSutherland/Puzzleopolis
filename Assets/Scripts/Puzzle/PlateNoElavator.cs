using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateNoElavator : MonoBehaviour
{
    public GameObject obstacle;
    public bool isActivated = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Throwable")) {
            obstacle.SetActive(false);
            isActivated = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Throwable")) {
            obstacle.SetActive(true);
            isActivated = false;
        }
    }
}
