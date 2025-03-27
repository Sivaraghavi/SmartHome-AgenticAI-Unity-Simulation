from langchain.tools import tool
# import src.home_automation.tools.state

import json
class device_select:
    @tool("device list")
    def list_device(data):
        """
        this will parse and list the device names in the rooms
        this will get the list of devices in the specific room from the json
        list of available devices
        the output is an json
        """

        house_data={
                        "house": {
                        "name": "My Smart Home",
                        "rooms": [
                            {
                            "name": "Living Room",
                            "devices": [
                                {
                                "device_id": "LR-001",
                                "type": "Smart Light",
                                "state": "ON",
                                "parameters": {
                                    "brightness": "80%",
                                    "color": "Warm White",
                                    "power_usage": "10W"
                                }
                                },
                                {
                                "device_id": "LR-002",
                                "type": "Smart AC",
                                "state": "OFF",
                                "parameters": {
                                    "temperature": "24°C",
                                    "mode": "Cool",
                                    "fan_speed": "Medium"
                                }
                                }
                            ]
                            },
                            {
                            "name": "Bedroom",
                            "devices": [
                                {
                                "device_id": "BR-001",
                                "type": "Smart Light",
                                "state": "OFF",
                                "parameters": {
                                    "brightness": "50%",
                                    "color": "Cool White",
                                    "power_usage": "8W"
                                }
                                },
                                {
                                "device_id": "BR-002",
                                "type": "Smart Fan",
                                "state": "ON",
                                "parameters": {
                                    "speed": "High",
                                    "timer": "2 hours"
                                }
                                }
                            ]
                            },
                            {
                            "name": "Kitchen",
                            "devices": [
                                {
                                "device_id": "KT-001",
                                "type": "Smart Refrigerator",
                                "state": "ON",
                                "parameters": {
                                    "temperature": "4°C",
                                    "mode": "Eco",
                                    "power_usage": "120W"
                                }
                                },
                                {
                                "device_id": "KT-002",
                                "type": "Smart Oven",
                                "state": "OFF",
                                "parameters": {
                                    "temperature": "180°C",
                                    "timer": "30 min",
                                    "mode": "Bake"
                                }
                                }
                            ]
                            }
                        ]
                        }
                    }
        room_list = data
        result = {}  # Dictionary to store room-device mapping
        for room in house_data["house"]["rooms"]:
            if room["name"] in room_list:
                result[room["name"]] = room["devices"]
        x=json.dumps(result, indent=4)
        return x
    
    @tool("json output")
    def output_json(data):
        """
        understand the json
        understand the devices present
        understand the changes to be done
        write json to send the changes
        the output should be an json
        """

        print(data)
        return data


