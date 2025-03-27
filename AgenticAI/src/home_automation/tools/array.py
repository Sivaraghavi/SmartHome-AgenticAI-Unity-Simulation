import smtplib
from langchain.tools import tool
# from crewai.tools import tool

import json
import numpy as np
class array_out:
    @tool("creat array")
    def arrayout(data):
        """
        understand the context,
        from the knowledge document understand what all rooms are the user talking about,
        give output as an array such that the we get a array of room_name,
        example: input= "the hall and bedroom is too hot"
        output="[hall,bedroom]"
        """
        
        # array = np.fromstring(data, dtype=int, sep=',')
        
        print(data,"+++++++++++++++++++++++++++++++++++")
        return data
