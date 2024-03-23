## Forest Notes 

## Target Windows , Easy -> 10.10.10.161

## Tasks 

- [*] : For which domain is this machine a Domain Controller?
	>>htb.local

- [*] : Which of the following services allows for anonymous authentication and can provide us with valuable information about the machine? FTP, LDAP, SMB, WinRM
	>>LDAP

- [*] : Which user has Kerberos Pre-Authentication disabled?
	>>svc-alfresco

- [*] : What is the password of the user svc-alfresco?
	>>s3rvice

- [*] : To what port can we connect with these creds to get an interactive shell?
	>>5985

- [*] : Which group has WriteDACL permissions over the HTB.LOCAL domain? Give the group name without the @htb.local.
	>>Exchange Windows Permissions

- [*] : The user svc-alfresco is a member of a group that allows them to add themself to the "Exchange Windows Permissions" group. Which group is that?
	>>Account Operators

- [*] : Which of the following attacks you can perform to elevate your privileges with a user that has WriteDACL on the domain? PassTheHash, PassTheTicket, DCSync, KrbRelay
	>>DCSync




