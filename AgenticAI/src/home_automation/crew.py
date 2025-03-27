# src/home_automation/crew.py
from crewai import Agent, Crew, Process, Task, LLM
from crewai.project import CrewBase, agent, crew, task
from pydantic import SkipValidation
from crewai import Knowledge
# from crewai.knowledge.source.json_knowledge_source import JSONKnowledgeSource
from crewai.knowledge.source.text_file_knowledge_source import TextFileKnowledgeSource
from crewai.knowledge.source.pdf_knowledge_source import PDFKnowledgeSource
from crewai.knowledge.source.string_knowledge_source import StringKnowledgeSource
from crewai_tools import PDFSearchTool
from dotenv import load_dotenv 
import os
from pathlib import Path
from src.home_automation.tools.summarizer import summarize
from src.home_automation.tools.array import array_out
from src.home_automation.tools.room import room_select
from src.home_automation.tools.devices import device_select
load_dotenv()

# If you want to run a snippet of code before or after the crew starts, 
# you can use the @before_kickoff and @after_kickoff decorators
# https://docs.crewai.com/concepts/crews#example-crew-class-with-decorators
@CrewBase
class HomeAutomation():
	"""HomeAutomation crew"""

	GROQ_API_KEY=os.getenv('GROQ_API_KEY')
	def __init__(self,GROQ_API_KEY=GROQ_API_KEY):
		self.llm=LLM(model="groq/gemma2-9b-it",temperature=0.7)

	# Learn more about YAML configuration files here:
	# Agents: https://docs.crewai.com/concepts/agents#yaml-configuration-recommended
	# Tasks: https://docs.crewai.com/concepts/tasks#yaml-configuration-recommended
	agents_config = 'config/agents.yaml'
	tasks_config = 'config/tasks.yaml'

	# If you would like to add tools to your agents, you can learn more about it here:
	# https://docs.crewai.com/concepts/agents#agent-tools
	@agent
	def home_analyst(self) -> Agent:
		return Agent(
			config=self.agents_config['home_analyst'],
			verbose=True,
			memory=True,
			max_rpm=5000,
			allow_delegation=True,
			llm=self.llm,
			tools=[summarize.context_sum],
		)

	@agent
	def location_detector(self) -> Agent:
		return Agent(
			config=self.agents_config['location_detector'],
			verbose=True,
			memory=True,
			max_rpm=5000,
			allow_delegation=True,
			llm=self.llm,
			tools=[room_select.list_room],
		)
	
	@agent
	def device_action(self) -> Agent:
		return Agent(
			config=self.agents_config['device_action'],
			verbose=True,
			memory=True,
			max_rpm=5000,
			allow_delegation=False,
			llm=self.llm,
			tools=[device_select.list_device, device_select.output_json],
		)

	# To learn more about structured task outputs, 
	# task dependencies, and task callbacks, check out the documentation:
	# https://docs.crewai.com/concepts/tasks#overview-of-a-task
	@task
	def home_analyst_task(self) -> Task:
		return Task(
			agent=self.home_analyst(),
			config=self.tasks_config['home_analyst_task'],
		)

	@task
	def location_detector_task(self) -> Task:
		return Task(
			input=self.home_analyst_task().output,
			agent=self.location_detector(),
			config=self.tasks_config['location_detector_task'],
			context=[self.home_analyst_task()]
		)
	
	@task
	def device_action_task(self) -> Task:
		return Task(
			agent=self.device_action(),
			config=self.tasks_config['device_action_task'],
			output_file='report.md',
			context=[self.home_analyst_task()]
		)

	@crew
	def crew(self) -> Crew:
		"""Creates the HomeAutomation crew"""
		# To learn how to add knowledge sources to your crew, check out the documentation:
		# https://docs.crewai.com/concepts/knowledge#what-is-knowledge

		return Crew(
			agents=self.agents, # Automatically created by the @agent decorator
			tasks=self.tasks, # Automatically created by the @task decorator
			process=Process.sequential,
			verbose=True,
			# planning=True,
			# process=Process.sequential, # In case you wanna use that instead https://docs.crewai.com/how-to/Hierarchical/
		)
