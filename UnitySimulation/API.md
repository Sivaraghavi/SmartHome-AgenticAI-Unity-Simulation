# IoT WebSocket API Documentation

## Overview

- **Endpoint:** `ws://localhost:8080/iot`
- **Protocol:** WebSocket
- **Message Format:** JSON

All commands are exchanged as JSON objects over the WebSocket connection. The server processes each command and returns a JSON response.

---

## Message Structure

### Request Format

```json
{
  "device": "device_type",
  "action": "action_name",
  "deviceIndex": optional_integer,  // Only needed for devices with multiple instances (e.g., lights)
  "parameters": { /* action-specific parameters */ }
}
```

- **device:** Specifies the device type. Valid values include:
  - `"light"`
  - `"tv"`
  - `"ac"`
  - `"fridge"`
  - `"induction"`
  - `"washingmachine"`
  - `"fan"`
  - `"general"` (for generic commands, such as processing text/voice input)
- **action:** The specific command to execute (see the sections below).
- **deviceIndex:** *(Optional)* The index of the device instance (e.g., `0` for Light 1, `1` for Light 2).
- **parameters:** An object containing any parameters required by the command.

---

## Supported Devices and Actions

### 1. Light Control

- **Toggle Light**
  - **Action:** `"toggle"`
  - **Parameters:**
    - `state` (Boolean): `true` for ON, `false` for OFF.
  - **Example Request:**
    ```json
    {
      "device": "light",
      "action": "toggle",
      "deviceIndex": 0,
      "parameters": { "state": true }
    }
    ```

- **Set Light Intensity**
  - **Action:** `"setintensity"`
  - **Parameters:**
    - `intensity` (Float): A value between 0.0 and 2.0.
  - **Example Request:**
    ```json
    {
      "device": "light",
      "action": "setintensity",
      "deviceIndex": 0,
      "parameters": { "intensity": 1.5 }
    }
    ```

- **Set Light Color**
  - **Action:** `"setcolor"`
  - **Parameters:**
    - `color` (String): Hexadecimal color code (without the `#`), e.g., `"FFAA00"`.
  - **Example Request:**
    ```json
    {
      "device": "light",
      "action": "setcolor",
      "deviceIndex": 0,
      "parameters": { "color": "FFAA00" }
    }
    ```

---

### 2. TV Control

- **Toggle TV**
  - **Action:** `"toggle"`
  - **Parameters:**
    - `state` (Boolean)
  - **Example Request:**
    ```json
    {
      "device": "tv",
      "action": "toggle",
      "parameters": { "state": true }
    }
    ```

- **Set Volume**
  - **Action:** `"setvolume"`
  - **Parameters:**
    - `volume` (Integer): A value from 0 to 100.
  - **Example Request:**
    ```json
    {
      "device": "tv",
      "action": "setvolume",
      "parameters": { "volume": 25 }
    }
    ```

- **Set Channel**
  - **Action:** `"setchannel"`
  - **Parameters:**
    - `channel` (Integer)
  - **Example Request:**
    ```json
    {
      "device": "tv",
      "action": "setchannel",
      "parameters": { "channel": 5 }
    }
    ```

- **Set Source**
  - **Action:** `"setsource"`
  - **Parameters:**
    - `source` (String): e.g., `"HDMI1"`, `"HDMI2"`, or `"TV"`.
  - **Example Request:**
    ```json
    {
      "device": "tv",
      "action": "setsource",
      "parameters": { "source": "HDMI1" }
    }
    ```

---

### 3. AC Control

- **Toggle AC**
  - **Action:** `"toggle"`
  - **Parameters:**
    - `state` (Boolean)
  - **Example Request:**
    ```json
    {
      "device": "ac",
      "action": "toggle",
      "parameters": { "state": true }
    }
    ```

- **Set Temperature**
  - **Action:** `"settemperature"`
  - **Parameters:**
    - `temperature` (Integer): Typically between 16 and 30 (°C).
  - **Example Request:**
    ```json
    {
      "device": "ac",
      "action": "settemperature",
      "parameters": { "temperature": 22 }
    }
    ```

- **Set Fan Speed**
  - **Action:** `"setfanspeed"`
  - **Parameters:**
    - `speed` (Integer): Range from 0 to 3.
  - **Example Request:**
    ```json
    {
      "device": "ac",
      "action": "setfanspeed",
      "parameters": { "speed": 2 }
    }
    ```

- **Toggle Eco Mode**
  - **Action:** `"toggleeco"`
  - **Parameters:**
    - `eco` (Boolean)
  - **Example Request:**
    ```json
    {
      "device": "ac",
      "action": "toggleeco",
      "parameters": { "eco": true }
    }
    ```

---

### 4. Fan Control

- **Toggle Fan**
  - **Action:** `"toggle"`
  - **Parameters:**
    - `state` (Boolean)
  - **Example Request:**
    ```json
    {
      "device": "fan",
      "action": "toggle",
      "parameters": { "state": true }
    }
    ```

- **Set RPM**
  - **Action:** `"setrpm"`
  - **Parameters:**
    - `rpm` (Integer): For example, a value between 100 and 2000.
  - **Example Request:**
    ```json
    {
      "device": "fan",
      "action": "setrpm",
      "parameters": { "rpm": 1200 }
    }
    ```

---

### 5. Fridge Control

- **Toggle Fridge**
  - **Action:** `"toggle"`
  - **Parameters:**
    - `state` (Boolean)
  - **Example Request:**
    ```json
    {
      "device": "fridge",
      "action": "toggle",
      "parameters": { "state": true }
    }
    ```

- **Set Main Temperature**
  - **Action:** `"settemperature"`
  - **Parameters:**
    - `temperature` (Integer)
  - **Example Request:**
    ```json
    {
      "device": "fridge",
      "action": "settemperature",
      "parameters": { "temperature": 4 }
    }
    ```

- **Set Freezer Temperature**
  - **Action:** `"setfreezetemperature"`
  - **Parameters:**
    - `temperature` (Integer)
  - **Example Request:**
    ```json
    {
      "device": "fridge",
      "action": "setfreezetemperature",
      "parameters": { "temperature": -18 }
    }
    ```

- **Set Door Status**
  - **Action:** `"setdoorstatus"`
  - **Parameters:**
    - `fridgeDoor` (Boolean): `true` if the main door is open.
    - `freezeDoor` (Boolean): `true` if the freezer door is open.
  - **Example Request (Toggle main door):**
    ```json
    {
      "device": "fridge",
      "action": "setdoorstatus",
      "parameters": { "fridgeDoor": true }
    }
    ```

---

### 6. Induction Control

- **Set Heat Level**
  - **Action:** `"setheat"`
  - **Parameters:**
    - `level` (Integer): Typically between 0 and 3.
  - **Example Request:**
    ```json
    {
      "device": "induction",
      "action": "setheat",
      "parameters": { "level": 2 }
    }
    ```

---

### 7. Washing Machine Control

- **Toggle Washing Machine**
  - **Action:** `"toggle"`
  - **Parameters:**
    - `state` (Boolean)
  - **Example Request:**
    ```json
    {
      "device": "washingmachine",
      "action": "toggle",
      "parameters": { "state": true }
    }
    ```

---

### 8. General Command (Text/Voice Processing)

- **Process General Command**
  - **Action:** `"processCommand"`
  - **Parameters:**
    - `input` (String): The command text.
  - **Example Request:**
    ```json
    {
      "device": "general",
      "action": "processCommand",
      "parameters": { "input": "Turn on the living room lights" }
    }
    ```

---

## Response Format

After processing a command, the server returns a JSON response in the following structure:

```json
{
  "success": true,
  "message": "Descriptive message",
  "data": null
}
```

- **success:** Boolean indicating whether the command was successfully processed.
- **message:** A descriptive message about the outcome.
- **data:** *(Optional)* Additional data relevant to the command.

---

## Example Interaction

**Request: Toggle Light 1 On**

```json
{
  "device": "light",
  "action": "toggle",
  "deviceIndex": 0,
  "parameters": { "state": true }
}
```

**Response:**

```json
{
  "success": true,
  "message": "Light command processed"
}
```

---

Developers can use this documentation as a guide to build custom frontends that interact with the IoT Device Controller via WebSocket. Simply connect to `ws://localhost:8080/iot` and exchange JSON messages as demonstrated.
