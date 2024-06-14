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
  

- [1] : Clearml 
  >>	login page -> Users : (Chad Jippity , default user , ray flection , Car Melo , e) 

- [2] : clearml-init 
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
- [3] :  
  >>	


## Foothold



- [+] : 
   >>	
   
- [+] : 
   >>	
   
- [+] : 
   >>	
   
- [+] : 
   >>	
   
- [+] : 
   >>	
   
- [+] : 
   >>	
   
- [+] : 
   >>	
   

