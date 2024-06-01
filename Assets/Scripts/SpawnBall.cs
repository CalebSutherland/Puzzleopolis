using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    public GameObject ball;
    public Transform playerCam;
    public Collider playerCollider;
    public Transform spawnPoint;

    public float forceX = -3f;
    public float minZForce = -1f;
    public float maxZForce = 1f;
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

        if (rb != null) {
            float randomZForce = Random.Range(minZForce, maxZForce);
            Vector3 force = new Vector3(forceX, 0, randomZForce);

            rb.AddForce(force, ForceMode.Impulse);
        }
    }

}
