## Linux Machine BoardLight

- [+] : Target IP 
     >> 10.10.11.11
     
## Recon & Enum 

PORT   STATE SERVICE
22/tcp open  ssh
80/tcp open  http

## Foothold

- [+] : subdomain crm.board.htb

- [1] : admin:admin
- [2] : can create a page . since its php i can try php revshell .
- [3] : <?PHP // to bypass filtre
	php revshell here <- preferably pentestmonkey
	?>
	
## Privesc on www-data

- [1] : Found user Larissa
- [2] : Found port 3306 mysql running with netstat 
- [3] : Found db pass in conf.php 
		www-data@boardlight:~/html/crm.board.htb/htdocs/conf cat conf.php
		$dolibarr_main_db_host='localhost';
		$dolibarr_main_db_port='3306';
		$dolibarr_main_db_name='dolibarr';
		$dolibarr_main_db_prefix='llx_';
		$dolibarr_main_db_user='dolibarrowner';
		$dolibarr_main_db_pass='serverfun2$2023!!';
		$dolibarr_main_db_type='mysqli';

- [+] : mysql -u 'dolibarrowner' -p 'serverfun2$2023!!' -> no need cuz db pass is larissa's pass [ty na9ani9 4 spoiling this one]

### Root_recon

## Linpeas

[+] SUID
[i] https://book.hacktricks.xyz/linux-unix/privilege-escalation#commands-with-sudo-and-suid-commands

/usr/lib/x86_64-linux-gnu/enlightenment/utils/enlightenment_sys [(exploitable)]
/usr/lib/x86_64-linux-gnu/enlightenment/utils/enlightenment_ckpasswd
/usr/lib/x86_64-linux-gnu/enlightenment/utils/enlightenment_backlight
/usr/lib/x86_64-linux-gnu/enlightenment/modules/cpufreq/linux-gnu-x86_64-0.23.1/freqset
/usr/lib/dbus-1.0/dbus-daemon-launch-helper

- [+] : CVE-2022-37706 that exploit engligntment_sys
	>> We have root !
     

