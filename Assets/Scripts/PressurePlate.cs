using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public MovingPlatform[] platformsToActivate;

    private bool isActivated = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("canPickUp") && !isActivated)
        {
            isActivated = true;
            ActivatePlatforms();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("canPickUp") && isActivated)
        {
            isActivated = false;
            DeactivatePlatforms();
        }
    }

    private void ActivatePlatforms()
    {
        foreach (MovingPlatform platform in platformsToActivate)
        {
            platform.Activate(); // Assuming MovingPlatform has an Activate method
        }
    }

    private void DeactivatePlatforms()
    {
        foreach (MovingPlatform platform in platformsToActivate)
        {
            platform.Deactivate(); // Assuming MovingPlatform has a Deactivate method
        }
    }
}