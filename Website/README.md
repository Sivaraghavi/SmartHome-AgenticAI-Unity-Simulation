# SmartHome Website

This web interface controls the `SmartHome-AgenticAI-Simulation` with three modes: basic manual controls (v1), AI-assisted controls (v2), and advanced AI integration (v3).

## Structure
```
Website/
├── index.html          # Landing page
├── README.md           # This guide
├── remote/
│   ├── index.html      # Chooser page
│   ├── v1.html         # Basic controls (No AI)
│   ├── v2.html         # AI-assisted controls
│   ├── v3.html         # Advanced AI controls
│   └── assets/
│       ├── style.css   # Shared styles
│       └── script.js   # WebSocket logic
└── favicon.ico         # Browser icon
```

## Setup
1. **Run Simulation**: Start `../UnitySimulation/Environment Samsung.exe` (see [UnitySimulation README](../UnitySimulation/README.md)).
2. **Serve Website**:
   ```bash
   cd Website
   python -m http.server 8000
   ```
3. **Open Browser**: Visit [http://localhost:8000](http://localhost:8000).

## Interfaces
| Version       | Path             | Features                  | Devices                     |
|---------------|------------------|---------------------------|-----------------------------|
| Basic         | /remote/v1.html  | Manual controls           | Lights, TV, AC, Fan         |
| AI-Assisted   | /remote/v2.html  | Manual + text/voice AI    | Lights, TV, AC, Fan         |
| Advanced AI   | /remote/v3.html  | Full control + advanced AI| + Fridge, Induction, Washer |

## Usage
- **Start**: Go to `/index.html`, then pick an interface at `/remote/index.html`.
- **v1**: Use buttons/sliders for Lights, TV, AC, Fan.
- **v2**: Add text or voice commands (e.g., "Turn on TV").
- **v3**: Control all devices with advanced commands (e.g., "Set AC to 22°C").

## Core Features
- **Real-time**: Connects via WebSocket (`ws://localhost:8080/iot`).
- **Voice**: Works in Chrome/Edge with mic enabled.
- **Shortcuts**:
  - `Ctrl+/`: Focus text input
  - `Alt+V`: Toggle voice input
  - `Ctrl+R`: Refresh connection

**Sample Command** (for developers):
```javascript
// Toggle light on (use in remote/assets/script.js)
sendCommand({ device: "light", action: "toggle", deviceIndex: 0, parameters: { state: true } });
```

## Troubleshooting
| Issue                | Fix                             |
|----------------------|---------------------------------|
| No response          | Ensure simulation is running    |
| Voice not working    | Use Chrome/Edge, allow mic      |
| WebSocket errors     | Check `ws://localhost:8080/iot` |
| Layout issues        | Refresh (`Ctrl+F5`), clear cache|

## Development
- **Styles**: Edit `style.css`.
- **Logic**: Update `script.js`.
- **API**: See [UnitySimulation API](../UnitySimulation/API.md) for WebSocket command details.
- **Contribute**: Follow [CONTRIBUTING.md](../CONTRIBUTING.md).

## Next Steps After Running the Website
To fully integrate with the `SmartHome-AgenticAI-Simulation` project:
- **[UnitySimulation README](../UnitySimulation/README.md):** Details on running the 3D simulation that the website controls via WebSocket.
- **[AgenticAI README](../AgenticAI/README.md):** Guide to setting up AI agents for automated control through the website (v2 and v3 interfaces).
- **[Root README](../README.md):** Overview and quick start for the entire project.
