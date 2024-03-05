## Machine Lame : 10.10.10.3

### Tasks 

- [*] : How many of the nmap top 1000 TCP ports are open on the remote host?
	>> 4

- [*] : What version of VSFTPd is running on Lame?
	>> 2.3.4

- [*] : There is a famous backdoor in VSFTPd version 2.3.4, and a Metasploit module to exploit it. Does that exploit work here?
	>> no

- [*] : What version of Samba is running on Lame? Give the numbers up to but not including "-Debian".
	>> 3.0.20

- [*] : What 2007 CVE allows for remote code execution in this version of Samba via shell metacharacters involving the SamrChangePassword function when the "username map script" option is enabled in smb.conf?
	>> CVE-2007-2447

- [*] : Exploiting CVE-2007-2447 returns a shell as which user?
	>> root

- [*] : Submit the flag located in the makis user's home directory.
	>> 94cb1246950095c7061042c14efb2571

- [*] : Submit the flag located in root's home directory.
	>> bf1578c77e5a6a579498dabea727ecb9

- [*] : We'll explore a bit beyond just getting a root shell on the box. While the official writeup doesn't cover this, you can look at 0xdf's write-up for more details. With a root shell, we can look at why the VSFTPd exploit failed. Our initial nmap scan showed four open TCP ports. Running netstat -tnlp shows many more ports listening, including ones on 0.0.0.0 and the boxes external IP, so they should be accessible. What must be blocking connection to these ports?

	>> firewall

- [*] : When the VSFTPd backdoor is trigger, what port starts listening?

	>> 6200

- [*] : When the VSFTPd backdoor is triggered, does port 6200 start listening on Lame?

	>> yes





