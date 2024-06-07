using UnityEngine;
using System;

public class PressurePlate : MonoBehaviour
{
    public MovingPlatform[] platformsToActivate;

    private bool isActivated = false;

    // Define delegate types for activation and deactivation
    public delegate void PlateActivated();
    public delegate void PlateDeactivated();

    // Define events for activation and deactivation
    public event PlateActivated OnPlateActivated;
    public event PlateDeactivated OnPlateDeactivated;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("canPickUp") || collision.gameObject.CompareTag("Throwable") && !isActivated)
        {
            isActivated = true;
            ActivatePlatforms();

            // Invoke the OnPlateActivated event
            if (OnPlateActivated != null)
            {
                OnPlateActivated();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("canPickUp") || collision.gameObject.CompareTag("Throwable") && isActivated)
        {
            isActivated = false;
            DeactivatePlatforms();

            // Invoke the OnPlateDeactivated event
            if (OnPlateDeactivated != null)
            {
                OnPlateDeactivated();
            }
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