/*using UnityEngine;

public class TestLightController : MonoBehaviour
{
    private LightController lightController;

    void Start()
    {
        lightController = GetComponent<LightController>();  // Get the LightController script
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            lightController.SetLightIntensity(2.0f);  // Increase intensity
            Debug.Log("Increased light intensity to 2.0");
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            lightController.SetLightIntensity(0.5f);  // Decrease intensity
            Debug.Log("Decreased light intensity to 0.5");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            lightController.SetLightColor(Color.red);  // Change light color to red
            Debug.Log("Changed light color to Red");
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            lightController.ToggleLight(!GetComponent<Light>().enabled);  // Toggle light on/off
            Debug.Log("Toggled Light");
        }
    }
}
*/