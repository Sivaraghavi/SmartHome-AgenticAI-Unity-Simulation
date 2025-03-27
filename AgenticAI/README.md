# SmartHome AgenticAI (using CrewAI)

Welcome to the SmartHome AgenticAI project, powered by [crewAI](https://crewai.com). This module sets up a multi-agent AI system for smart home automation, enabling agents to collaborate on tasks like device control and natural language processing. It integrates with the `SmartHome-AgenticAI-Simulation` project via WebSocket (`ws://localhost:8080/iot`).

## Installation

Ensure you have Python (>=3.10, <3.13) installed. This project uses [UV](https://docs.astral.sh/uv/) for dependency management.

1. **Install UV:**
   ```bash
   pip install uv
   ```
2. **Install Dependencies:**
   ```bash
   uv sync  # Installs locked dependencies
   ```
   *(Note: If using a `requirements.txt` instead, run `pip install -r requirements.txt`.)*

## Customization

1. **Configure API Key:**
   Create a `.env` file in the `AgenticAI` directory with:
   ```bash
   OPENAI_API_KEY=your_api_key_here
   ```

2. **Update Configurations:**
   - Modify `src/home_automation/config/agents.yaml` to define your agents.
   - Modify `src/home_automation/config/tasks.yaml` to set up your tasks.
   - Customize `src/home_automation/crew.py` and `src/home_automation/main.py` as needed for additional logic or inputs.

## Running the Project

Start your crew of AI agents by running the following command from the `AgenticAI` directory:

```bash
crewai run
```

This command initializes the agents and begins task execution. By default, it generates a `report.md` file with the results of AI-driven smart home task execution (e.g., device control commands sent via WebSocket).

## Understanding Your Crew

The crew consists of multiple AI agents, each with a unique role and capability. Their configurations are defined in `config/agents.yaml`, while their tasks are specified in `config/tasks.yaml`. Together, they work to automate and enhance smart home operations by communicating with the Unity simulation over `ws://localhost:8080/iot`.

## Next Steps After Running the AI

To integrate the AI system with the rest of the `SmartHome-AgenticAI-Simulation` project, refer to:
- **[UnitySimulation README](../UnitySimulation/README.md):** Instructions for running the 3D simulation that the AI controls via WebSocket.
- **[Website README](../Website/README.md):** Guide to setting up the web interface for manual and AI-assisted device control.
- **[Root README](../README.md):** Overview and quick start for the entire project.

These components work together to provide a complete smart home automation experience.

## Support

For help or feedback, please:
- Visit the [crewAI Documentation](https://docs.crewai.com)
- Check our [GitHub repository](https://github.com/joaomdmoura/crewai)
- Join our [Discord community](https://discord.com/invite/X4JWnZnxPb)
- Chat with our support team: [Chat with our docs](https://chat.g.pt/DWjSBZn)

Let's build an intelligent future together with the simplicity and power of crewAI.
