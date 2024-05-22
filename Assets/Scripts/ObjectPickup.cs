using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickup : MonoBehaviour
{
    private Rigidbody objectRigidbody;
    private Transform objectGrabPointTransform;
    private Collider objectCollider;

    private float lerpSpeed = 10f;
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
        StartCoroutine(DelayedDisableCollider());
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objectRigidbody.useGravity = true;
        objectRigidbody.isKinematic = false;
        objectCollider.enabled = true;
    }

    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRigidbody.MovePosition(newPosition);
        }
    }

    private IEnumerator DelayedDisableCollider()
    {
        yield return new WaitForSeconds(0.1f); // Delay of 0.1 second
        objectCollider.enabled = false;
    }
}
