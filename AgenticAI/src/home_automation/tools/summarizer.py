import smtplib
from langchain.tools import tool
# from crewai.tools import tool
import json

class summarize:
    @tool("summarized context")
    def context_sum(data):
        """
        write a summarized and to the point solution of the context,
        understand the {data} and bring out the simple solution
        example: input= "the hall is too hot"
        output="the fan needs to be turned on in hall"
        """

        print(data,"+++++++++++++++++++++++++++++++++++++++")
        return data