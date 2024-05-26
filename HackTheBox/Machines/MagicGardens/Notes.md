## Insane Linux Machine [MagicGardens]

-[+] Target IP : 10.10.11.9

## Recon

PORT     STATE SERVICE
22/tcp   open  ssh
25/tcp   open  smtp
80/tcp   open  http
1337/tcp open  waste
5000/tcp open  upnp

## Enumerating / footprinting 

-[+] -> : Dirbusting shows admin control pannel django , maybe some authentication bypass but its an insane machine I doubt that


-[+] -> : http://magicgardens.htb/wish_list/?product=Snowdrop
gonna try to fuzz this later


-[+] -> : port 5000 shows a username and password to enter in /v2 .
       >> request shows a docker running on that port 5000 
       >> found this online :https://forums.docker.com/t/unable-to-get-private-docker-registry-to-work-locally-works-remotely/44144
       >> checking /v2/_catalog

-[+] -> : TELNET SMTP
		220 magicgardens.magicgardens.htb ESMTP Postfix (Debian/GNU)
		500 5.5.2 Error: bad syntax
		501 Syntax: EHLO hostname
		501 Syntax: HELO hostname
		421 4.4.2 magicgardens.magicgardens.htb Error: timeout exceeded


hydra -l root -p /usr/share/wordlists/rockyou.txt ssh://10.10.11.9 
