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
    private float startTime;

    private GameObject player;

    void Start()
    {
        initialPosition = transform.position;
        startTime = Time.time;
    }

    void FixedUpdate()
    {
        if (on)
        {
            switch (movementDirection)
            {
                case MovementDirection.Vertical:
                    MoveVertically();
                    break;
                case MovementDirection.HorizontalX:
                    MoveHorizontallyX();
                    break;
                case MovementDirection.HorizontalZ:
                    MoveHorizontallyZ();
                    break;
            }
        }
    }

    void MoveVertically()
    {
        float time = Time.time - startTime;
        float posY = initialPosition.y + Mathf.PingPong(time * movementSpeed, movementDistance) * (startTop ? -1f : 1f);
        Vector3 newPosition = new Vector3(transform.position.x, posY, transform.position.z);
        Vector3 deltaPosition = newPosition - transform.position;
        transform.position = newPosition;

        if (player != null)
            player.transform.Translate(deltaPosition, Space.World);
    }

    void MoveHorizontallyX()
    {
        float time = Time.time - startTime;
        float posX = initialPosition.x + Mathf.PingPong(time * movementSpeed, movementDistance) * (startTop ? -1f : 1f);
        Vector3 newPosition = new Vector3(posX, transform.position.y, transform.position.z);
        Vector3 deltaPosition = newPosition - transform.position;
        transform.position = newPosition;

        if (player != null)
            player.transform.Translate(deltaPosition, Space.World);
    }

    void MoveHorizontallyZ()
    {
        float time = Time.time - startTime;
        float posZ = initialPosition.z + Mathf.PingPong(time * movementSpeed, movementDistance) * (startTop ? -1f : 1f);
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, posZ);
        Vector3 deltaPosition = newPosition - transform.position;
        transform.position = newPosition;

        if (player != null)
            player.transform.Translate(deltaPosition, Space.World);
    }

    public void Activate()
    {
        on = true;
        startTime = Time.time; // Reset the start time to synchronize the movement
    }

    public void Deactivate()
    {
        on = false;
    }
    /*
     * Not yet working as intended*/
    private void OnCollisionEnter(Collision collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.transform.SetParent(null);
    }
    
}