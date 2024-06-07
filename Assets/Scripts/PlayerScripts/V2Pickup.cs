using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class V2Pickup : MonoBehaviour
{

    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private GameObject pickUpText;
    [SerializeField] private GameObject throwableText;
    [SerializeField] private GameObject buttonText;


    private ObjectPickup objectPickup;
    private SpawnBall spawnBall;    
    private float pickUpDistance = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        
        //Check if in item is in range to be picked up and display text
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out hit, pickUpDistance)) {
            if (hit.transform.gameObject.CompareTag("canPickUp") || hit.transform.gameObject.CompareTag("Throwable")) {
                if (objectPickup == null) { 
                    pickUpText.SetActive(true);
                    throwableText.SetActive(false);
                    buttonText.SetActive(false);
                }
            }
            else if (hit.transform.gameObject.CompareTag("Button")) {
                buttonText.SetActive(true);
                throwableText.SetActive(false);
                pickUpText.SetActive(false);
            }
        }
        else
        {
            pickUpText.SetActive(false);
            buttonText.SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.E)) {
            if (objectPickup == null) { //Not holding object
                Debug.Log(hit);
                if (hit.transform.TryGetComponent(out objectPickup)) {
                    //Debug.Log(hit);
                    objectPickup.Grab(objectGrabPointTransform);
                    pickUpText.SetActive(false);

                    if (objectPickup.gameObject.CompareTag("Throwable")) {
                        buttonText.SetActive(false);
                        throwableText.SetActive(true);
                        StartCoroutine(HideText(throwableText));
                    }
                }
                else if (hit.transform.TryGetComponent(out spawnBall)) {
                    spawnBall.Spawn();
                    buttonText.SetActive(false);
                }
            } else {
                //Holding object
                objectPickup.Drop();
                objectPickup = null;
                throwableText.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            if (objectPickup != null) {
                if (objectPickup.gameObject.CompareTag("Throwable")) {
                    objectPickup.Throw();
                    objectPickup = null;
                    throwableText.SetActive(false);
                }
                
            }
        }

    }

    private IEnumerator HideText(GameObject text) 
    {
        yield return new WaitForSeconds(5.0f);
        text.SetActive(false);
    }
}
