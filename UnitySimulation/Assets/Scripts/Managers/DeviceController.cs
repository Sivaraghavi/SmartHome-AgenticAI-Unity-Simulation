using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class LightSettings
{
    public bool isOn = true;
    [Range(0, 2)] public float intensity = 1.0f;
    public string hexColor = "FFFFFF";
}

public class DeviceController : MonoBehaviour
{
    #region Device Controllers
    [Header("Device Controllers")]
    [SerializeField] private LightController[] lightControllers;
    [SerializeField] private TVController tvController;
    [SerializeField] private InductionController inductionController;
    [SerializeField] private FridgeController fridgeController;
    [SerializeField] private ACController acController;
    [SerializeField] private WashingMachineController washingMachineController;
    [SerializeField] private FanController fanController;
    #endregion

    #region Light Settings
    [Header("Light Settings")]
    public List<LightSettings> lightSettings = new List<LightSettings>();
    #endregion

    #region TV Settings
    [Header("TV Settings")]
    public bool tvOn;
    [Range(0, 100)] public int tvVolume = 10;
    public int tvChannel = 1;
    public string tvSource = "HDMI1";
    #endregion

    #region Induction Settings
    [Header("Induction Settings")]
    [Range(0, 3)] public int inductionHeat;
    #endregion

    #region Fridge Settings
    [Header("Fridge Settings")]
    public bool fridgeOn;
    [Range(-10, 10)] public int fridgeTemperature = 4;
    [Range(-30, -10)] public int freezeTemperature = -18;

    [Header("Fridge Door Status")]
    [Tooltip("Set manually for testing")]
    public bool fridgeDoorOpen;
    public bool freezeDoorOpen;
    #endregion

    #region AC Settings
    [Header("AC Settings")]
    [Range(16, 30)] public int acTemperature = 24;
    [Range(0, 3)] public int acFanSpeed = 1;
    public bool acOn;
    public bool acEcoMode;
    #endregion

    #region Washing Machine Settings
    [Header("Washing Machine Settings")]
    public bool washingMachineOn;
    #endregion

    #region Fan Settings
    [Header("Fan Settings")]
    public bool fanOn;
    public int fanRPM = 400;
    #endregion

    private void Update()
    {
        ApplyInspectorChanges();
    }

    private void ApplyInspectorChanges()
    {
        UpdateLightControllers();
        UpdateTVController();
        UpdateInductionController();
        UpdateFridgeController();
        UpdateACController();
        UpdateWashingMachineController();
        UpdateFanController();
    }

    #region Controller Update Methods
    private void UpdateLightControllers()
    {
        if (lightControllers == null || lightSettings.Count != lightControllers.Length) return;

        for (int i = 0; i < lightControllers.Length; i++)
        {
            if (lightControllers[i] == null) continue;

            var controller = lightControllers[i];
            var settings = lightSettings[i];

            controller.ToggleLight(settings.isOn);
            controller.SetLightIntensity(settings.intensity);

            if (ColorUtility.TryParseHtmlString("#" + settings.hexColor, out Color color))
            {
                controller.SetLightColor(color);
            }
            else
            {
                Debug.LogWarning($"Invalid hex color: {settings.hexColor}");
            }
        }
    }

    private void UpdateTVController()
    {
        if (tvController == null) return;

        tvController.ToggleTV(tvOn);
        tvController.SetVolume(tvVolume);
        tvController.SetChannel(tvChannel);
        tvController.SetSource(tvSource);
    }

    private void UpdateInductionController()
    {
        if (inductionController == null) return;

        inductionController.heatLevel = inductionHeat;
    }

    private void UpdateFridgeController()
    {
        if (fridgeController == null) return;

        fridgeController.ToggleFridge(fridgeOn);
        fridgeController.SetTemperature(fridgeTemperature);
        fridgeController.SetFreezeTemperature(freezeTemperature);
        fridgeController.mainDoorOpen = fridgeDoorOpen;
        fridgeController.freezeDoorOpen = freezeDoorOpen;
    }

    private void UpdateACController()
    {
        if (acController == null) return;

        acController.ToggleAC(acOn);
        acController.SetFanSpeed(acFanSpeed);
        acController.SetTemperature(acTemperature);
        acController.ToggleEcoMode(acEcoMode);
    }

    private void UpdateWashingMachineController()
    {
        if (washingMachineController == null) return;

        washingMachineController.ToggleWashingMachine(washingMachineOn);
    }

    private void UpdateFanController()
    {
        if (fanController == null) return;

        fanController.ToggleFan(fanOn);
        fanController.SetRPM(fanRPM);
    }
    #endregion
}