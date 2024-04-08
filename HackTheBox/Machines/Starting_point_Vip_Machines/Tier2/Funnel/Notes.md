## Funnel

		FTP
		PostgreSQL
		Reconnaissance
		Tunneling
		Password Spraying
		Port Forwarding
		Anonymous/Guest Access
		Clear Text Credentials
		
## Tasks

- [*] : How many TCP ports are open? 
	>>2

- [*] : What is the name of the directory that is available on the FTP server? 
	>>mail_backup

- [*] : What is the default account password that every new member on the "Funnel" team should change as soon as possible? 
	>>funnel123#!#

- [*] : Which user has not changed their default password yet?
	>>christine

- [*] : Which service is running on TCP port 5432 and listens only on localhost? 
	>>postgresql

- [*] : Since you can't access the previously mentioned service from the local machine, you will have to create a tunnel and connect to it from your machine. What is the correct type of tunneling to use? remote port forwarding or local port forwarding? 
	>>local port forwarding

- [*] : What is the name of the database that holds the flag? 
	>>secrets

- [*] : Could you use a dynamic tunnel instead of local port forwarding? Yes or No. 
	>>yes

- [*] : Submit root flag 
	>>cf277664b1771217d7006acdea006db1

## Notes :

+ [1] : Ftp 
 
```txt_file
Frome: root@funnel.htb
To: optimus@funnel.htb albert@funnel.htb andreas@funnel.htb christine@funnel.htb maria@funnel.htb
``

```pdf
Default password : funnel123#!#
```

+ [2] : local port forwarding -> https://book.hacktricks.xyz/generic-methodologies-and-resources/tunneling-and-port-forwarding

```bash 
ssh -L 1234:localhost:5432 christine@{target_IP}
psql -U christine -h localhost -p 1234
``



