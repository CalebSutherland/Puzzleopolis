using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float movementDistance = 4f; // Total distance the platform moves up and down
    public float movementSpeed = 2f; // Speed of the platform's movement
    private Vector3 initialPosition; // Initial position of the platform
    public bool movingUp = true; // Flag to track the direction of movement
    public bool startTop = false;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calculate the vertical movement
        float verticalMovement = movementSpeed * Time.deltaTime * (movingUp ? 1f : -1f);

        // Update the platform's position
        transform.Translate(Vector3.up * verticalMovement);

        if (startTop == true) 
        {
            // Check if the platform has reached the top or bottom position
            if (transform.position.y >= initialPosition.y)
            {
                movingUp = false; // Change direction to move down
            }
            else if (transform.position.y <= initialPosition.y - movementDistance)
            {
                movingUp = true; // Change direction to move up
            }
        } else
        {
            // Check if the platform has reached the top or bottom position
            if (transform.position.y >= initialPosition.y + movementDistance)
            {
                movingUp = false; // Change direction to move down
            }
            else if (transform.position.y <= initialPosition.y)
            {
                movingUp = true; // Change direction to move up
            }
        }

        
    }
}