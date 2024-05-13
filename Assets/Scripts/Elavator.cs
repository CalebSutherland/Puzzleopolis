using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Transform pressurePlate;
    public Transform basePlate;
    public enum MovementDirection { Vertical, HorizontalX, HorizontalZ } // Enum to define movement direction
    public MovementDirection movementDirection = MovementDirection.Vertical; // Default to vertical movement
    public float movementDistance = 4f; // Total distance the platform moves
    public float movementSpeed = 2f; // Speed of the platform's movement
    private Vector3 initialPosition; // Initial position of the platform
    private float initialPlatePosition; // Initial position of the activation plate
    public bool movingPositive = true; // Flag to track the direction of movement
    public bool startTop = false;

    private GameObject player; // Reference to the player

    void Start()
    {
        initialPosition = transform.position;
        initialPlatePosition = basePlate.position.y;
    }

    void Update()
    {
        if (pressurePlate.position.y < (initialPlatePosition - 0.05))
        {
            if (movementDirection == MovementDirection.Vertical)
            {
                // Vertical movement
                MoveVertically();
            }
            else if (movementDirection == MovementDirection.HorizontalX)
            {
                // Horizontal movement along the X-axis
                MoveHorizontallyX();
            }
            else if (movementDirection == MovementDirection.HorizontalZ)
            {
                // Horizontal movement along the Z-axis
                MoveHorizontallyZ();
            }
        }
    }

    void MoveVertically()
    {
        float verticalMovement = movementSpeed * Time.deltaTime * (movingPositive ? 1f : -1f);
        transform.Translate(Vector3.up * verticalMovement);

        if (startTop)
        {
            if (transform.position.y >= initialPosition.y)
                movingPositive = false;
            else if (transform.position.y <= initialPosition.y - movementDistance)
                movingPositive = true;
        }
        else
        {
            if (transform.position.y >= initialPosition.y + movementDistance)
                movingPositive = false;
            else if (transform.position.y <= initialPosition.y)
                movingPositive = true;
        }

        if (player != null)
            player.transform.Translate(Vector3.up * verticalMovement);
    }

    void MoveHorizontallyX()
    {
        float horizontalMovement = movementSpeed * Time.deltaTime * (movingPositive ? 1f : -1f);
        transform.Translate(Vector3.right * horizontalMovement);

        if (startTop)
        {
            if (transform.position.x >= initialPosition.x)
                movingPositive = false;
            else if (transform.position.x <= initialPosition.x - movementDistance)
                movingPositive = true;
        }
        else
        {
            if (transform.position.x >= initialPosition.x + movementDistance)
                movingPositive = false;
            else if (transform.position.x <= initialPosition.x)
                movingPositive = true;
        }

        if (player != null)
            player.transform.Translate(Vector3.right * horizontalMovement);
    }

    void MoveHorizontallyZ()
    {
        float horizontalMovement = movementSpeed * Time.deltaTime * (movingPositive ? 1f : -1f);
        transform.Translate(Vector3.forward * horizontalMovement);

        if (startTop)
        {
            if (transform.position.z >= initialPosition.z)
                movingPositive = false;
            else if (transform.position.z <= initialPosition.z - movementDistance)
                movingPositive = true;
        }
        else
        {
            if (transform.position.z >= initialPosition.z + movementDistance)
                movingPositive = false;
            else if (transform.position.z <= initialPosition.z)
                movingPositive = true;
        }

        if (player != null)
            player.transform.Translate(Vector3.forward * horizontalMovement);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            other.transform.parent = transform; // Parent the player to the platform
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null; // Unparent the player from the platform
            player = null;
        }
    }
}