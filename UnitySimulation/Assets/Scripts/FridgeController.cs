using UnityEngine;
using TMPro;

public class FridgeController : SmartDevice
{
    public bool isOn = false;
    public int mainTemperature = 4;   // Default fridge temp
    public int freezeTemperature = -18;  // Default freezer temp
    public bool mainDoorOpen = false;
    public bool freezeDoorOpen = false;

    [SerializeField] private TMP_Text FridgeStatusText;
    [SerializeField] private TMP_Text FridgeTempText;
    [SerializeField] private TMP_Text FreezeTempText;
    [SerializeField] private TMP_Text FridgeDoorStatusText;
    [SerializeField] private TMP_Text FreezeDoorStatusText;
    [SerializeField] private string roomNumberPublic = "Kitchen";
    protected override void Awake()
    {
        base.Awake();
        SetRoomNumber(roomNumberPublic); // Assign SmartDevice's room number from public variable
    }

    private void Start()
    {
        UpdateFridgeUI();
    }

    public void ToggleFridge(bool state)
    {
        isOn = state;
        Debug.Log($"Fridge is now {(isOn ? "ON" : "OFF")}");
        UpdateFridgeUI();
    }

    public void SetTemperature(int temp)
    {
        mainTemperature = temp;
        Debug.Log($"Fridge temperature set to {mainTemperature}�C");
        UpdateFridgeUI();
    }

    public void SetFreezeTemperature(int temp)
    {
        freezeTemperature = temp;
        Debug.Log($"Freezer temperature set to {freezeTemperature}�C");
        UpdateFridgeUI();
    }

    private void UpdateFridgeUI()
    {
        if (FridgeStatusText != null)
            FridgeStatusText.text = $"Fridge: {(isOn ? "ON" : "OFF")}";

        if (FridgeTempText != null)
            FridgeTempText.text = $"Main Temp: {mainTemperature}�C";

        if (FreezeTempText != null)
            FreezeTempText.text = $"Freezer Temp: {freezeTemperature}�C";

        if (FridgeDoorStatusText != null)
            FridgeDoorStatusText.text = $"Main Door: {(mainDoorOpen ? "Open" : "Shut")}";

        if (FreezeDoorStatusText != null)
            FreezeDoorStatusText.text = $"Freezer Door: {(freezeDoorOpen ? "Open" : "Shut")}";
    }
}
