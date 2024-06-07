using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject ball;
    public Transform playerCam;
    public Collider playerCollider;
    public Transform spawnPoint;

    public bool dispenseAlongX = true; // True for dispensing along x axis, false for z axis

    public float forceX = -3f;
    public float minZForce = -1f;
    public float maxZForce = 1f;
    public float forceZ = -3f;
    public float minXForce = -1f;
    public float maxXForce = 1f;

    public void Spawn()
    {
        GameObject newBall = Instantiate(ball, spawnPoint.position, spawnPoint.rotation);

        ObjectPickup objectPickup = newBall.GetComponent<ObjectPickup>();

        // If the component exists, set the cam variable
        if (objectPickup != null)
        {
            objectPickup.cam = playerCam;
            objectPickup.playerCollider = playerCollider;
        }

        Rigidbody rb = newBall.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 force;
            if (dispenseAlongX)
            {
                // Dispense along the x axis with a random z value
                float randomZForce = Random.Range(minZForce, maxZForce);
                force = new Vector3(forceX, 0, randomZForce);
            }
            else
            {
                // Dispense along the z axis with a random x value
                float randomXForce = Random.Range(minXForce, maxXForce);
                force = new Vector3(randomXForce, 0, forceZ);
            }

            rb.AddForce(force, ForceMode.Impulse);
        }
    }
}