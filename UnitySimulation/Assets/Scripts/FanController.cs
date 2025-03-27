using UnityEngine;
using TMPro;

public class FanController : SmartDevice
{
    [SerializeField] private string roomNumberPublic = "Living Room";
    public bool isOn = false;   
    public int rpm = 400;       

    [SerializeField] private TMP_Text FanStatusText;
    [SerializeField] private TMP_Text FanRPMText;

    private void Start()
    {
        UpdateFanUI();
    }
    protected override void Awake()
    {
        base.Awake();
        SetRoomNumber(roomNumberPublic); // Assign SmartDevice's room number from public variable
    }

    public void ToggleFan(bool state)
    {
        isOn = state;
        Debug.Log($"Fan is now {(isOn ? "ON" : "OFF")}");
        UpdateFanUI();
    }

    public void SetRPM(int newRPM)
    {
        rpm = Mathf.Clamp(newRPM, 100, 2000);  // Limit RPM range
        Debug.Log($"Fan speed set to {rpm} RPM");
        UpdateFanUI();
    }

    private void UpdateFanUI()
    {
        if (FanStatusText != null)
            FanStatusText.text = $"Fan: {(isOn ? "ON" : "OFF")}";

        if (FanRPMText != null)
            FanRPMText.text = $"RPM: {rpm}";
    }
}
