let ws;

function connectWebsocket() {
  ws = new WebSocket('ws://localhost:8080/iot');

  ws.onopen = () => {
    const statusElement = document.getElementById('connectionStatus');
    if (statusElement) {
      statusElement.textContent = 'Connected';
      statusElement.classList.replace('disconnected', 'connected');
    }
  };

  ws.onclose = () => {
    const statusElement = document.getElementById('connectionStatus');
    if (statusElement) {
      statusElement.textContent = 'Disconnected';
      statusElement.classList.replace('connected', 'disconnected');
    }
    setTimeout(connectWebsocket, 2000); // Reconnect after 2 seconds
  };

  ws.onerror = (error) => {
    console.error('Websocket error:', error);
  };

  ws.onmessage = (event) => {
    const response = JSON.parse(event.data);
    console.log('Received:', response);
  };
}

function sendCommand(command) {
  if (ws && ws.readyState === WebSocket.OPEN) {
    ws.send(JSON.stringify(command));
  } else {
    console.error('Websocket is not connected');
  }
}

// Call connectWebsocket when the page loads
window.onload = connectWebsocket;