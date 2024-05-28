## Bank - Linux Machine

- [+] :    Target IP
	>> 10.10.10.29


## Tasks


- [+] :    How many TCP ports are listening and accessible on Bank?
	>> 3

- [+] :    What virtual host returns a website that isn't the default Ubuntu Apache page?
	>> bank.htb

- [+] :    What is the relative path on the webserver that allows directory listing and shows a bunch of .acc files?
	>> /balance-transfer

- [+] :    Which .acc file stands out as different from the others?
	>> 68576f20e9732f1b2edc4df5b8533230.acc

- [+] :    Optional question: There is an alternative way to bypass the login form on Bank without finding creds for chris. What kind of vulnerability allows for this? Choose from SQLI, EAR, XSS, or XSRF.
	>> EAR

- [+] :    What file extension will execute as PHP for debugging purposes? Don't include the . in your answer.
	>> htb

- [+] :    What user is the web server running as?
	>> www-data

- [+] :    What is the full path to the non-standard binary that has SetUID permissions such that it executes as root?
	>> /var/htb/bin/emergency
	
- [+] :    There's an alternative path from www-data to root on Bank. What is the full path of the critical Linux system file that is world-writable that shouldn't be?
	>> /etc/passwd

find / -perm -4000 2>/dev/null
EAR


