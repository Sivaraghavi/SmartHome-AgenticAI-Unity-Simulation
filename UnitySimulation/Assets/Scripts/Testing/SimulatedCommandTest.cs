/*using System.Collections;
using UnityEngine;
using UnityEngine.UI;  // For UI Elements (TV, AC, Fridge)

public class SimulatedCommandTest : MonoBehaviour
{
    public LightController[] lightControllers;
    public TVController tvController;
    public InductionController inductionController;
    public FridgeController fridgeController;
    public ACController acController;
    public WashingMachineController washingMachineController;

    void Start()
    {
        Invoke("SimulateCommand", 2f);  // Start Simulation after 2 sec
    }

    void SimulateCommand()
    {
        Debug.Log("=== Simulating IoT Commands ===");

        // **1. Light Simulation**
        if (lightControllers.Length > 0)
        {
            lightControllers[0].SetLightIntensity(2.0f);
            lightControllers[0].SetLightColor(Color.blue);
            lightControllers[0].ToggleLight(true);
            Debug.Log("Light 1: Intensity 2.0, Color Blue, Light ON");

            if (lightControllers.Length > 1)
            {
                lightControllers[1].SetLightIntensity(0.5f);
                lightControllers[1].SetLightColor(Color.red);
                lightControllers[1].ToggleLight(false);
                Debug.Log("Light 2: Intensity 0.5, Color Red, Light OFF");
            }
        }

        // **2. TV Simulation**
        if (tvController != null)
        {
            tvController.ToggleTV(true); // Turn TV ON
            Debug.Log("TV: Turned ON");
        }

        // **3. Induction Stove Simulation**
        *//*if (inductionController != null)
        {
            inductionController.SetInductionLevel(2);  // Set to 2 cylinders ON
            Debug.Log("Induction Stove: Level 2 (Two cylinders ON)");
        }*//*

        // **4. Fridge Simulation**
        if (fridgeController != null)
        {
            fridgeController.SetTemperature(5);  // Set fridge temp to 5°C
            Debug.Log("Fridge: Temperature set to 5°C");
        }

        // **5. AC Simulation**
        if (acController != null)
        {
            acController.SetTemperature(22);  // Set AC temp to 22°C
            Debug.Log("AC: Temperature set to 22°C");
        }

        // **6. Washing Machine Simulation**
        if (washingMachineController != null)
        {
            washingMachineController.ToggleWashingMachine(true);  // Turn Washing Machine ON
            Debug.Log("Washing Machine: Turned ON");
        }

        Debug.Log("=== IoT Simulation Completed ===");
    }
}
*/