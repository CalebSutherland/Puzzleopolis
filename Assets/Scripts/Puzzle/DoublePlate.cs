using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualPressurePlates : MonoBehaviour
{
    public PressurePlate pressurePlate1;
    public PressurePlate pressurePlate2;
    public MovingPlatform[] platformsToActivate;

    private int activatedPlates = 0;

    private void Start()
    {
        // Subscribe to the events of the pressure plates
        pressurePlate1.OnPlateActivated += HandlePlateActivated;
        pressurePlate1.OnPlateDeactivated += HandlePlateDeactivated;
        pressurePlate2.OnPlateActivated += HandlePlateActivated;
        pressurePlate2.OnPlateDeactivated += HandlePlateDeactivated;
    }

    private void HandlePlateActivated()
    {
        activatedPlates++;

        if (activatedPlates == 2)
        {
            ActivatePlatforms();
        }
    }

    private void HandlePlateDeactivated()
    {
        activatedPlates--;

        if (activatedPlates < 2)
        {
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