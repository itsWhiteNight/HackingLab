# Devvortex HTB Walkthrough

## Port Scanning

As usual, start by scanning for open ports using Nmap:

```bash
nmap -sT 10.10.11.242
The results show that ports 22 (SSH) and 80 (HTTP) are open.
```
## Foothold

Visit the website at http://10.10.11.242 and note that you need to resolve the domain devvortex.htb. Add the entry 10.10.11.242 devvortex.htb to your /etc/hosts file.

Upon visiting the website, you find interesting forms like "Contact us" and "Email subscription" in the source code. However, these forms don't seem to be processing data. Proceed to enumerate directories 

		dirsearch -u devvortex.htb or gobuster whatever you prefer
		No interesting directories are found. Switch to enumerating virtual hosts using Gobuster:

		gobuster vhost -u devvortex.htb -w /usr/share/seclists/Discovery/DNS/subdomains-top1million-5000.txt
		Discover the virtual host dev.devvortex.htb and visit it.


		gobuster dir -u http://dev.devvortex.htb/ -w /usr/share/seclists/Discovery/Web-Content/common.txt -r
		Find the directory /administrator and explore it. You find a Joomla installation.

Check directories for joomla version -> 4.2

You can also run a Joomla scan

		joomscan --url http://dev.devvortex.htb
		Identify the Joomla version as 4.2.6, vulnerable to CVE-2023-23752. Download an exploit PoC from exploit-db.com and run it against the Joomla installation.

Retrieve the database login credentials from the exploit output.

Attempt to log in via SSH using the obtained credentials, but no success.

Use the Joomla admin login page to authenticate with the credentials exfiltrated.

Gain access to the Joomla admin panel.

Explore the installed templates to find a page where you can edit PHP code. Edit the code to execute a bash command and save the changes.

Start a netcat listener on the host machine, visit the edited page, and wait for the reverse shell.

Explore the system, check /etc/passwd to find users, and check /home for additional information.

Identify the user logan. Since logan is also a registered user on the Joomla panel, retrieve the password from the MySQL database.

Connect to the MySQL database and dump user credentials.

Use John utility to crack the password for logan.

Authenticate via SSH using the obtained credentials for logan and capture the user flag.

##Escalating to Root
###Check the sudo privileges for the user:

		sudo -l
		Identify that the user can run apport-cli as root.

##Execute apport-cli with a crash report file:

		sudo /usr/bin/apport-cli -c /var/crash/_usr_bin_apport-cli.0.crash
		When prompted, type V to load the pager. Once in the pager, run !/bin/bash to spawn a root shell.

##Capture the root flag:

		
		cat /root/root.txt
		Congratulations, the machine is successfully rooted!
