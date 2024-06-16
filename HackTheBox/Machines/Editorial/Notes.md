## Linux - Machine 
DownTheRabbitHole!
- [+] : Target Ip 
  >>	10.10.11.20
## Recon
PORT   STATE SERVICE VERSION
22/tcp open  ssh     OpenSSH 8.9p1 Ubuntu 3ubuntu0.7 (Ubuntu Linux; protocol 2.0)
| ssh-hostkey: 
|   256 0d:ed:b2:9c:e2:53:fb:d4:c8:c1:19:6e:75:80:d8:64 (ECDSA)
|_  256 0f:b9:a7:51:0e:00:d5:7b:5b:7c:5f:bf:2b:ed:53:a0 (ED25519)
80/tcp open  http    nginx 1.18.0 (Ubuntu)
|_http-title: Did not follow redirect to http://editorial.htb
|_http-server-header: nginx/1.18.0 (Ubuntu)


http://editorial.htb/upload

## Foothold

- [+] : http://editorial.htb/upload
  >>	preview stores file or img into /static and can see my php revshell tries etc...
  >>	ssrf in url param localhost:5000
  >>	/api/path for dev creds
		dev
		dev080217_devAPI!@
		
## User Recon 

- [+] : Run linpeas 
  >>	found git ???
  >> 	git log
			commit b73481bb823d2dfb49c44f4c1e6a7e11912ed8ae
			Author: dev-carlos.valderrama <dev-carlos.valderrama@tiempoarriba.htb>
			Date:   Sun Apr 30 20:55:08 2023 -0500

			    change(api): downgrading prod to dev
			    
			    * To use development environment.

			commit 1e84a036b2f33c59e2390730699a488c65643d28
			Author: dev-carlos.valderrama <dev-carlos.valderrama@tiempoarriba.htb>
			Date:   Sun Apr 30 20:51:10 2023 -0500

			    feat: create api to editorial info
			    
			    * It (will) contains internal info about the editorial, this enable
			       faster access to information.

			commit 3251ec9e8ffdd9b938e83e3b9fbf5fd1efa9bbb8
			Author: dev-carlos.valderrama <dev-carlos.valderrama@tiempoarriba.htb>
			Date:   Sun Apr 30 20:48:43 2023 -0500

  >>	git show interesting_downgrading?

			dev@editorial:~/apps/.git$ git show b73481bb823d2dfb49c44f4c1e6a7e11912ed8ae
			commit b73481bb823d2dfb49c44f4c1e6a7e11912ed8ae
			Author: dev-carlos.valderrama <dev-carlos.valderrama@tiempoarriba.htb>
			Date:   Sun Apr 30 20:55:08 2023 -0500

			    change(api): downgrading prod to dev
			    
			    * To use development environment.

			diff --git a/app_api/app.py b/app_api/app.py
			index 61b786f..3373b14 100644
			--- a/app_api/app.py
			+++ b/app_api/app.py
			@@ -64,7 +64,7 @@ def index():
			 @app.route(api_route + '/authors/message', methods=['GET'])
			 def api_mail_new_authors():
			     return jsonify({
			-        'template_mail_message': "Welcome to the team! We are thrilled to have you on board and can't wait to see the incredible content you'll bring to the table.\n\nYour login credentials for our internal forum and authors site are:\nUsername: prod\nPassword: 080217_Producti0n_2023!@\nPlease be sure to change your password as soon as possible for security purposes.\n\nDon't hesitate to reach out if you have any questions or ideas - we're always here to support you.\n\nBest regards, " + api_editorial_name + " Team."
			+        'template_mail_message': "Welcome to the team! We are thrilled to have you on board and can't wait to see the incredible content you'll bring to the table.\n\nYour login credentials for our internal forum and authors site are:\nUsername: dev\nPassword: dev080217_devAPI!@\nPlease be sure to change your password as soon as possible for security purposes.\n\nDon't hesitate to reach out if you have any questions or ideas - we're always here to support you.\n\nBest regards, " + api_editorial_name + " Team."
			     })  TODO: replace dev credentials when checks pass
			     
			     
## Prod recon

- [+] : linpeas ur friend shows the best SUID on /usr/bin/bash 
  >>	/usr/bin/bash -p = root
			 
			  
			  

  
