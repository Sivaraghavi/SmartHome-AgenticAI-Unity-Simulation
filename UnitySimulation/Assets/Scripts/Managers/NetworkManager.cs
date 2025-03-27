using UnityEngine;
using System;
using System.Collections.Generic;
using System.Net;
using WebSocketSharp;
using WebSocketSharp.Server;
using Newtonsoft.Json;

[Serializable]
public class DeviceCommand
{
    public string device;     // e.g., "light", "tv", "ac"
    public string action;     // e.g., "toggle", "setTemperature"
    public int deviceIndex;   // For arrays like lights
    public Dictionary<string, object> parameters;
}

[Serializable]
public class WebSocketResponse
{
    public bool success;
    public string message;
    public object data;
}

public class NetworkManager : MonoBehaviour
{
    private WebSocketServer wssv;
    private DeviceController deviceController;

    [SerializeField] private int port = 8080;
    [SerializeField] private bool startServerOnAwake = true;

    private void Awake()
    {
        deviceController = FindObjectOfType<DeviceController>();
        if (deviceController == null)
        {
            Debug.LogError("DeviceController not found in the scene!");
            return;
        }

        if (startServerOnAwake)
            StartServer();
    }

    public void StartServer()
    {
        try
        {
            wssv = new WebSocketServer(IPAddress.Any, port);
            wssv.AddWebSocketService<IoTWebSocketService>("/iot",
                () => new IoTWebSocketService(deviceController));
            wssv.Start();
            Debug.Log($"WebSocket server started on port {port}");
        }
        catch (Exception e)
        {
            Debug.LogError($"Failed to start WebSocket server: {e.Message}");
        }
    }

    private void OnDestroy()
    {
        if (wssv != null && wssv.IsListening)
        {
            wssv.Stop();
            Debug.Log("WebSocket server stopped");
        }
    }
}

public class IoTWebSocketService : WebSocketBehavior
{
    private readonly DeviceController deviceController;

    public IoTWebSocketService(DeviceController controller)
    {
        deviceController = controller;
    }

    protected override void OnMessage(MessageEventArgs e)
    {
        try
        {
            var command = JsonConvert.DeserializeObject<DeviceCommand>(e.Data);
            var response = ProcessCommand(command);
            Send(JsonConvert.SerializeObject(response));
        }
        catch (Exception ex)
        {
            var errorResponse = new WebSocketResponse
            {
                success = false,
                message = $"Error processing command: {ex.Message}"
            };
            Send(JsonConvert.SerializeObject(errorResponse));
        }
    }

    private WebSocketResponse ProcessCommand(DeviceCommand command)
    {
        switch (command.device.ToLower())
        {
            case "light":
                return HandleLightCommand(command);
            case "tv":
                return HandleTVCommand(command);
            case "ac":
                return HandleACCommand(command);
            case "fridge":
                return HandleFridgeCommand(command);
            case "induction":
                return HandleInductionCommand(command);
            case "washingmachine":
                return HandleWashingMachineCommand(command);
            case "fan":
                return HandleFanCommand(command);
            default:
                return new WebSocketResponse
                {
                    success = false,
                    message = $"Unknown device: {command.device}"
                };
        }
    }

    #region Device Command Handlers
    private WebSocketResponse HandleLightCommand(DeviceCommand command)
    {
        try
        {
            if (command.deviceIndex >= deviceController.lightSettings.Count)
                throw new IndexOutOfRangeException("Light index out of range");

            var lightSetting = deviceController.lightSettings[command.deviceIndex];

            switch (command.action.ToLower())
            {
                case "toggle":
                    lightSetting.isOn = command.parameters.ContainsKey("state") ?
                        Convert.ToBoolean(command.parameters["state"]) : !lightSetting.isOn;
                    break;

                case "setintensity":
                    if (command.parameters.ContainsKey("intensity"))
                        lightSetting.intensity = Convert.ToSingle(command.parameters["intensity"]);
                    break;

                case "setcolor":
                    if (command.parameters.ContainsKey("color"))
                        lightSetting.hexColor = command.parameters["color"].ToString();
                    break;

                default:
                    throw new ArgumentException($"Unknown light action: {command.action}");
            }

            return new WebSocketResponse { success = true, message = "Light command processed" };
        }
        catch (Exception ex)
        {
            return new WebSocketResponse { success = false, message = ex.Message };
        }
    }

    private WebSocketResponse HandleTVCommand(DeviceCommand command)
    {
        try
        {
            switch (command.action.ToLower())
            {
                case "toggle":
                    deviceController.tvOn = command.parameters.ContainsKey("state") ?
                        Convert.ToBoolean(command.parameters["state"]) : !deviceController.tvOn;
                    break;

                case "setvolume":
                    if (command.parameters.ContainsKey("volume"))
                        deviceController.tvVolume = Convert.ToInt32(command.parameters["volume"]);
                    break;

                case "setchannel":
                    if (command.parameters.ContainsKey("channel"))
                        deviceController.tvChannel = Convert.ToInt32(command.parameters["channel"]);
                    break;

                case "setsource":
                    if (command.parameters.ContainsKey("source"))
                        deviceController.tvSource = command.parameters["source"].ToString();
                    break;

                default:
                    throw new ArgumentException($"Unknown TV action: {command.action}");
            }

            return new WebSocketResponse { success = true, message = "TV command processed" };
        }
        catch (Exception ex)
        {
            return new WebSocketResponse { success = false, message = ex.Message };
        }
    }

    private WebSocketResponse HandleACCommand(DeviceCommand command)
    {
        try
        {
            switch (command.action.ToLower())
            {
                case "toggle":
                    deviceController.acOn = command.parameters.ContainsKey("state") ?
                        Convert.ToBoolean(command.parameters["state"]) : !deviceController.acOn;
                    break;

                case "settemperature":
                    if (command.parameters.ContainsKey("temperature"))
                        deviceController.acTemperature = Convert.ToInt32(command.parameters["temperature"]);
                    break;

                case "setfanspeed":
                    if (command.parameters.ContainsKey("speed"))
                        deviceController.acFanSpeed = Convert.ToInt32(command.parameters["speed"]);
                    break;

                case "toggleeco":
                    deviceController.acEcoMode = command.parameters.ContainsKey("eco") ?
                        Convert.ToBoolean(command.parameters["eco"]) : !deviceController.acEcoMode;
                    break;

                default:
                    throw new ArgumentException($"Unknown AC action: {command.action}");
            }

            return new WebSocketResponse { success = true, message = "AC command processed" };
        }
        catch (Exception ex)
        {
            return new WebSocketResponse { success = false, message = ex.Message };
        }
    }

    private WebSocketResponse HandleFridgeCommand(DeviceCommand command)
    {
        try
        {
            switch (command.action.ToLower())
            {
                case "toggle":
                    deviceController.fridgeOn = command.parameters.ContainsKey("state") ?
                        Convert.ToBoolean(command.parameters["state"]) : !deviceController.fridgeOn;
                    break;

                case "settemperature":
                    if (command.parameters.ContainsKey("temperature"))
                        deviceController.fridgeTemperature = Convert.ToInt32(command.parameters["temperature"]);
                    break;

                case "setfreezetemperature":
                    if (command.parameters.ContainsKey("temperature"))
                        deviceController.freezeTemperature = Convert.ToInt32(command.parameters["temperature"]);
                    break;

                case "setdoorstatus":
                    if (command.parameters.ContainsKey("fridgeDoor"))
                        deviceController.fridgeDoorOpen = Convert.ToBoolean(command.parameters["fridgeDoor"]);
                    if (command.parameters.ContainsKey("freezeDoor"))
                        deviceController.freezeDoorOpen = Convert.ToBoolean(command.parameters["freezeDoor"]);
                    break;

                default:
                    throw new ArgumentException($"Unknown fridge action: {command.action}");
            }

            return new WebSocketResponse { success = true, message = "Fridge command processed" };
        }
        catch (Exception ex)
        {
            return new WebSocketResponse { success = false, message = ex.Message };
        }
    }

    private WebSocketResponse HandleInductionCommand(DeviceCommand command)
    {
        try
        {
            switch (command.action.ToLower())
            {
                case "setheat":
                    if (command.parameters.ContainsKey("level"))
                        deviceController.inductionHeat = Convert.ToInt32(command.parameters["level"]);
                    break;

                default:
                    throw new ArgumentException($"Unknown induction action: {command.action}");
            }

            return new WebSocketResponse { success = true, message = "Induction command processed" };
        }
        catch (Exception ex)
        {
            return new WebSocketResponse { success = false, message = ex.Message };
        }
    }

    private WebSocketResponse HandleWashingMachineCommand(DeviceCommand command)
    {
        try
        {
            switch (command.action.ToLower())
            {
                case "toggle":
                    deviceController.washingMachineOn = command.parameters.ContainsKey("state") ?
                        Convert.ToBoolean(command.parameters["state"]) : !deviceController.washingMachineOn;
                    break;

                default:
                    throw new ArgumentException($"Unknown washing machine action: {command.action}");
            }

            return new WebSocketResponse { success = true, message = "Washing machine command processed" };
        }
        catch (Exception ex)
        {
            return new WebSocketResponse { success = false, message = ex.Message };
        }
    }

    private WebSocketResponse HandleFanCommand(DeviceCommand command)
    {
        try
        {
            switch (command.action.ToLower())
            {
                case "toggle":
                    deviceController.fanOn = command.parameters.ContainsKey("state") ?
                        Convert.ToBoolean(command.parameters["state"]) : !deviceController.fanOn;
                    break;

                case "setrpm":
                    if (command.parameters.ContainsKey("rpm"))
                        deviceController.fanRPM = Convert.ToInt32(command.parameters["rpm"]);
                    break;

                default:
                    throw new ArgumentException($"Unknown fan action: {command.action}");
            }

            return new WebSocketResponse { success = true, message = "Fan command processed" };
        }
        catch (Exception ex)
        {
            return new WebSocketResponse { success = false, message = ex.Message };
        }
    }
    #endregion
}