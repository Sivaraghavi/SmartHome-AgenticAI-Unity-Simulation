using UnityEngine;

public class WashingMachineController : SmartDevice
{
    [SerializeField] private GameObject onCylinder;  
    [SerializeField] private GameObject offCylinder;
    [SerializeField] private string roomNumberPublic = "Bathroom";
    protected override void Awake()
    {
        base.Awake();
        SetRoomNumber(roomNumberPublic); 
    }

    private bool isOn = false;

    public void ToggleWashingMachine(bool state)
    {
        isOn = state;
        onCylinder.SetActive(isOn);
        offCylinder.SetActive(!isOn);
    }
}
