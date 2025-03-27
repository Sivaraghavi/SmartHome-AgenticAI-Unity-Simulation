#!/usr/bin/env python
#src/home_automation/main.py
import sys
import warnings
import winsound
from datetime import datetime

from home_automation.crew import HomeAutomation

warnings.filterwarnings("ignore", category=SyntaxWarning, module="pysbd")

# This main file is intended to be a way for you to run your
# crew locally, so refrain from adding unnecessary logic into this file.
# Replace with inputs you want to test with, it will automatically
# interpolate any tasks and agents information

def run():
    """
    Run the crew.
    """
    inputs = {
        'topic': input("please put your prompt: ")
    }
    HomeAutomation().crew().kickoff(inputs=inputs)
# run()
# winsound.Beep(2000,1000)