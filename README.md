# SmartHome-AgenticAI-Unity-Simulation

A unified platform for smart home automation development, combining:
- **Unity Simulation**: 3D environment with IoT device controls
- **AI Automation**: Natural language processing for device control
- **Web Interface**: Multi-tier control interfaces (Basic → Advanced AI)

This project integrates its components via a WebSocket server at `ws://localhost:8080/iot`, enabling real-time control and automation of a simulated smart home.

## Prerequisites
- **Python 3.10+**: For running the AI system and web server
- **Unity**: Optional, for simulation development (pre-built executable provided)
- **CrewAI CLI**: Install via `pip install crewai` (for AI agents)
- **UV**: Optional, for dependency management (`pip install uv`)

## Structure

| Component       | Description                                  | Documentation                   |
|-----------------|----------------------------------------------|---------------------------------|
| `UnitySimulation` | Real-time 3D smart home environment         | [Setup Guide](./UnitySimulation/README.md) |
| `AgenticAI`       | AI agents for automated device control      | [AI Configuration](./AgenticAI/README.md) |
| `Website`         | Web interfaces (Basic/AI/Advanced controls) | [Web UI Guide](./Website/README.md) |

## Quick Start

1. **Launch Simulation**
   ```bash
   "UnitySimulation/Environment Samsung.exe"
   ```

2. **Start AI System**
   ```bash
   cd AgenticAI
   crewai run  # Requires Python 3.10+
   ```

3. **Access Web Interface**
   ```bash
   cd Website
   python -m http.server 8000  # Open browser to http://localhost:8000
   ```

## System Integration
Components communicate via WebSocket (`ws://localhost:8080/iot`):
1. **Web Interface ↔ Unity**: Device control commands
2. **Web Interface ↔ AI**: Natural language processing
3. **AI Agents ↔ Unity**: Automated command execution

For detailed WebSocket API specs, see [UnitySimulation API](./UnitySimulation/API.md).

## Component READMEs
For specific setup and usage instructions:
- **[UnitySimulation README](./UnitySimulation/README.md):** Run the 3D simulation environment.
- **[AgenticAI README](./AgenticAI/README.md):** Configure and launch AI agents for automation.
- **[Website README](./Website/README.md):** Set up the web interface for manual and AI-assisted control.

## Contact

For any questions or feedback, contact me at [sivaraghavi6103@gmail.com](mailto:sivaraghavi6103@gmail.com).
