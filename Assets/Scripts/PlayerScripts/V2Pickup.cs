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
    
    
    private float pickUpDistance = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check if in item is in range to be picked up and display text
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit hit2, pickUpDistance)) {
            if (hit2.transform.gameObject.tag == "canPickUp" || hit2.transform.gameObject.tag == "Throwable") {
                if (objectPickup == null) { 
                    pickUpText.SetActive(true);
                    throwableText.SetActive(false);
                    buttonText.SetActive(false);
                }
            }
            else if (hit2.transform.gameObject.tag == "Button") {
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
            if (objectPickup == null) {
                //Not holding object
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance)) {
                    //Debug.Log(raycastHit.transform);
                    if (raycastHit.transform.TryGetComponent(out objectPickup)) {
                        objectPickup.Grab(objectGrabPointTransform);
                        pickUpText.SetActive(false);

                        if (objectPickup.gameObject.tag == "Throwable") {
                            buttonText.SetActive(false);
                            throwableText.SetActive(true);
                            StartCoroutine(HideText(throwableText));
                        }
                    }
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
                if (objectPickup.gameObject.tag == "Throwable") {
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
