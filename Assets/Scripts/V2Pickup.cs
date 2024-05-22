using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V2Pickup : MonoBehaviour
{

    [SerializeField] private Transform playerCameraTransform;
    [SerializeField] private Transform objectGrabPointTransform;
    [SerializeField] private LayerMask pickUpLayerMask;
    [SerializeField] private GameObject pickUpText;

    private ObjectPickup objectPickup;
    
    
    private float pickUpDistance = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit hit2, pickUpDistance))
        {
            if (hit2.transform.gameObject.tag == "canPickUp")
            {
                pickUpText.SetActive(true);
            }
        }
        else
        {
            pickUpText.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            if (objectPickup == null) {
                //Not holding object
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance)) {
                    //Debug.Log(raycastHit.transform);
                    if (raycastHit.transform.TryGetComponent(out objectPickup)) {
                        objectPickup.Grab(objectGrabPointTransform);
                        //Debug.Log(objectPickup);
                    }
                }
            } else {
                //Holding object
                objectPickup.Drop();
                objectPickup = null;
            }
        }
    }
}
