## SSH Ninja LAB 

- [+]:	TargetIP
   >>	10.8.0.2  -> Truestory
   >>	10.8.0.3  -> ceri 
   
   
   going for truestory
   
   10.8.0.2
   
   
## Recon 


22/tcp open  ssh     OpenSSH 7.6p1 Ubuntu 4ubuntu0.3 (Ubuntu Linux; protocol 2.0)



PORT   STATE SERVICE
22/tcp open  ssh
| ssh-auth-methods: 
|   Supported authentication methods: 
|     publickey
|_    password
| ssh-hostkey: 
|   2048 d2:4e:c2:93:a0:50:ef:bc:fb:95:0d:2b:12:ec:f4:a7 (RSA)
|   256 ad:a6:74:82:54:bc:92:d5:6e:a4:28:f0:80:67:ce:19 (ECDSA)
|_  256 e3:47:0c:13:58:d4:ea:7b:33:a6:b4:66:d0:42:43:fb (ED25519)
| ssh-publickey-acceptance: 
|_  Accepted Public Keys: No public keys accepted
|_ssh-run: Failed to specify credentials and command to run.
| ssh2-enum-algos: 
|   kex_algorithms: (10)
|       curve25519-sha256
|       curve25519-sha256@libssh.org
|       ecdh-sha2-nistp256
|       ecdh-sha2-nistp384
|       ecdh-sha2-nistp521
|       diffie-hellman-group-exchange-sha256
|       diffie-hellman-group16-sha512
|       diffie-hellman-group18-sha512
|       diffie-hellman-group14-sha256
|       diffie-hellman-group14-sha1
|   server_host_key_algorithms: (5)
|       ssh-rsa
|       rsa-sha2-512
|       rsa-sha2-256
|       ecdsa-sha2-nistp256
|       ssh-ed25519
|   encryption_algorithms: (6)
|       chacha20-poly1305@openssh.com
|       aes128-ctr
|       aes192-ctr
|       aes256-ctr
|       aes128-gcm@openssh.com
|       aes256-gcm@openssh.com
|   mac_algorithms: (10)
|       umac-64-etm@openssh.com
|       umac-128-etm@openssh.com
|       hmac-sha2-256-etm@openssh.com
|       hmac-sha2-512-etm@openssh.com
|       hmac-sha1-etm@openssh.com
|       umac-64@openssh.com
|       umac-128@openssh.com
|       hmac-sha2-256
|       hmac-sha2-512
|       hmac-sha1
|   compression_algorithms: (2)
|       none
|_      zlib@openssh.com


- [+] :	
   >>	
   
- [+] :	
   >>	
   
- [+] :	
   >>	
   
- [+] :	
   >>	
   
- [+] :	
   >>	
   
- [+] :	
   >>	
   
- [+] :	
   >>	
   
- [+] :	
   >>	
   
- [+] :	
   >>	
   
- [+] :	
   >>	
   [+] OpenSSH version 7.6 found
[+] mail found!
[+] root found!
[+] news found!
^^^^^[+] man found!
[+] bin found!
[+] games found!
[+] nobody found!
[+] backup found!


