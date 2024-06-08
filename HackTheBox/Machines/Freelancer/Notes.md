# Machine Freelancer 

- [+] : TargetIP
   >>	10.10.11.5
   
## RECON 
PORT     STATE SERVICE       VERSION
53/tcp   open  domain        Simple DNS Plus
88/tcp   open  kerberos-sec  Microsoft Windows Kerberos (server time: 2024-06-02 04:41:30Z)
135/tcp  open  msrpc         Microsoft Windows RPC
139/tcp  open  netbios-ssn   Microsoft Windows netbios-ssn
389/tcp  open  ldap          Microsoft Windows Active Directory LDAP (Domain: freelancer.htb0., Site: Default-First-Site-Name)
445/tcp  open  microsoft-ds?
464/tcp  open  kpasswd5?
593/tcp  open  ncacn_http    Microsoft Windows RPC over HTTP 1.0
636/tcp  open  tcpwrapped
3268/tcp open  ldap          Microsoft Windows Active Directory LDAP (Domain: freelancer.htb0., Site: Default-First-Site-Name)
3269/tcp open  tcpwrapped

## Enumeration 

sudo ldapsearch -H ldap://10.10.11.5 -x -b "DC=htb,DC=freelancer" '{}' | cut -d ' ' -f 2 | sort | uniq | cut -d ',' -f 1 > ~/Desktop/HackingLab/HackTheBox/Machines/Freelancer/new_users.txt 

## Enumeration 

./kerbrute_linux_amd64 userenum -d freelancer.htb --dc 10.10.11.5 /usr/share/se	clists/Usernames/xato-net-10-million-usernames.txt -o kerb-results

2024/06/02 00:56:50 >  [+] VALID USERNAME:	 taylor@freelancer.htb
2024/06/02 00:57:01 >  [+] VALID USERNAME:	 administrator@freelancer.htb
2024/06/02 00:57:04 >  [+] VALID USERNAME:	 Taylor@freelancer.htb


- [+] : Port 80 Open now .
   >>	http://freelancer.htb/blog/details/?article_id=1 on source page .
   >>	http://freelancer.htb/blog/details/ : Show malicious behavior detected .
   >>	sqlmap -u http://freelancer.htb/blog/details/?article_id=1 --tamper=space2comment --level 5 --risk 3
   >>	dirsearch [http://freelancer.htb/admin/login/?next=/admin/] Django 
   




##   
  
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
   

