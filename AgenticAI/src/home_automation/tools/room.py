from langchain.tools import tool
# import src.home_automation.tools.state

import json
class room_select:
    @tool("room list")
    def list_room(data):
        """
        this will parse and list the room names
        this will get the list of room from the json
        list of available rooms
        the output is an array
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
  
        return [room["name"] for room in house_data["house"]["rooms"]]


import numpy as np
class array_out:
    @tool("creat array")
    def arrayout(data):
        """
        understand the {data}
        list the the room in which the changes is needed
        the rooms should be available, if not then choose the most closest available room
        output="[hall,bedroom]"
        """
        
        # array = np.fromstring(data, dtype=int, sep=',')
        
        print(data,"+++++++++++++++++++++++++++++++++++")
        return data