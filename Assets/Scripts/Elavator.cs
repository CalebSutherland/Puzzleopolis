using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public enum MovementDirection { Vertical, HorizontalX, HorizontalZ }
    public MovementDirection movementDirection = MovementDirection.Vertical;
    public float movementDistance = 4f;
    public float movementSpeed = 2f;
    private Vector3 initialPosition;
    public bool startTop = false;
    public bool on = false;

    private GameObject player;
    private float progress = 0f;
    private bool movingPositive = true;

    void Start()
    {
        initialPosition = transform.position;
    }

    void FixedUpdate()
    {
        if (on)
        {
            MovePlatform();
        }
    }

    void MovePlatform()
    {
        float deltaMovement = movementSpeed * Time.fixedDeltaTime;

        if (movingPositive)
        {
            progress += deltaMovement;
            if (progress >= movementDistance)
            {
                progress = movementDistance;
                movingPositive = false;
            }
        }
        else
        {
            progress -= deltaMovement;
            if (progress <= 0f)
            {
                progress = 0f;
                movingPositive = true;
            }
        }

        Vector3 targetPosition = initialPosition;
        switch (movementDirection)
        {
            case MovementDirection.Vertical:
                targetPosition += Vector3.up * (startTop ? -progress : progress);
                break;
            case MovementDirection.HorizontalX:
                targetPosition += Vector3.right * (startTop ? -progress : progress);
                break;
            case MovementDirection.HorizontalZ:
                targetPosition += Vector3.forward * (startTop ? -progress : progress);
                break;
        }

        transform.position = targetPosition;

        if (player != null)
        {
            player.transform.position += targetPosition - transform.position;
        }
    }

    public void Activate()
    {
        on = true;
    }

    public void Deactivate()
    {
        on = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.transform.SetParent(null);
    }
    
}