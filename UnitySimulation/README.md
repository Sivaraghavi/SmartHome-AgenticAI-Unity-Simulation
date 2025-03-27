# SmartHome Simulation (using Unity Engine)

A real-time 3D smart home environment built with Unity, featuring IoT device controls. This simulation integrates with the `SmartHome-AgenticAI-Simulation` project via a WebSocket server.

**Full Changelog**: [https://github.com/Shival-Gupta/HomeAutomation-UnitySimulation/commits/v0.1-alpha](https://github.com/Shival-Gupta/HomeAutomation-UnitySimulation/commits/v0.1-alpha)

## Guide to Developers

1. **Download:** [Winx64.zip](https://github.com/Shival-Gupta/HomeAutomation-UnitySimulation/releases/download/v0.1-alpha/Win.x64.zip)
2. **Extract and Run:** Launch `"Environment Samsung.exe"` from inside the extracted folder

The simulation will start, and the WebSocket server will be active at `ws://localhost:8080/iot`. You can interact with it using the web interface or AI agents.

## API Documentation

For detailed information on interacting with the IoT Device Controller via WebSocket, see [API.md](./API.md).

## Next Steps After Running the Simulation

To fully utilize the simulation within the `SmartHome-AgenticAI-Simulation` ecosystem, refer to the following documentation:
- **[Website README](../Website/README.md):** Instructions for setting up and using the web interface to control devices in the simulation.
- **[AgenticAI README](../AgenticAI/README.md):** Guide to configuring and running AI agents for automated device control.
- **[Root README](../README.md):** Overview of the entire project and quick start instructions for all components.

These files provide setup and usage details for the integrated web and AI systems that connect to the simulation via `ws://localhost:8080/iot`.

Happy coding!
