using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;
    private Collider objectCollider;

    public Transform cam;
    public Collider playerCollider;

    private float lerpSpeed = 10f;
    public float throwForce;
    public float throwUpwardForce;

    private void Awake()
    {
        objectRigidbody = GetComponent<Rigidbody>();
        objectCollider = GetComponent<Collider>();
    }

    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRigidbody.useGravity = false;
        objectRigidbody.isKinematic = true;
        //StartCoroutine(DelayedDisableCollider())

        // Ignore collisions between the player and the grabbed object
        if (playerCollider != null && objectCollider != null)
        {
            Physics.IgnoreCollision(playerCollider, objectCollider, true);
        }
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objectRigidbody.useGravity = true;
        objectRigidbody.isKinematic = false;
        //objectCollider.enabled = true;

        // Re-enable collisions between the player and the dropped object
        if (playerCollider != null && objectCollider != null)
        {
            Physics.IgnoreCollision(playerCollider, objectCollider, false);
        }
    }

    public void Throw() 
    {
        Vector3 forceToAdd = cam.transform.forward * throwForce + transform.up * throwUpwardForce;
        this.objectGrabPointTransform = null;
        objectRigidbody.isKinematic = false;
        objectRigidbody.useGravity = true;
        
        objectRigidbody.AddForce(forceToAdd, ForceMode.Impulse);

        if (playerCollider != null && objectCollider != null)
        {
            Physics.IgnoreCollision(playerCollider, objectCollider, false);
        }
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRigidbody.MovePosition(newPosition);
        }
    }

    /*
    private IEnumerator DelayedDisableCollider()
    {
        yield return new WaitForSeconds(0.1f); // Delay of 0.1 second
        objectCollider.enabled = false;
    }
    */

    /* Potential for future versions but it feels to clunky to try not to drop the box while platforming.
    private void OnCollisionEnter(Collision collision)
    {
        Drop();
    }
    */
}
