### Mr. Robot CTF Walkthrough

## Introduction

**<mr. robot>** Hello friend. If you’ve come, you’ve come for a reason. There's a part of you exhausted with this world—a world that dictates where you work, who you see, and how you fill your bank account. Today, your education begins.

## Objective

This walkthrough guides you through exploiting vulnerabilities on the Mr. Robot target machine. Discover and exploit weaknesses to find three flags and elevate privileges to become root.

## Scanning

Start by scanning the target machine (e.g., 10.10.173.33) using nmap:

		```
		$ sudo nmap -sC -sV -O 10.10.173.33 -oN nmap-scan
		```
		
## Explore directories with dirsearch or gobuster:

Key directories: /wp-login and /robots.txt

1. Exploiting
2. Visit /dashboard to find the first flag.
3. Use Burp Suite for a dictionary attack on the admin login.
4. Discover a valid username (e.g., Elliot) and password.
5. Launch a php reverse shell in the 404/archive template.
6. Set up a listener and visit 404.php or archive.php for shell access.
7. Find user daemon and another flag in the robot directory.

## PasswordCracking 

Crack md5 hash of the robot's password using tools like JohnTheRipper or Hashcat, I did it woith an online md5cracker 

## PrivilegeEscalation

1. Switch to the robot user with the cracked password.
2. Obtain the second flag.
3. Identify an interesting program (e.g., nmap) using LinEnum.sh.
4. Exploit nmap with SUID bit for root access.
5. Obtain the third flag.

##Reports and Screenshots

Nmap and dirsearch reports are available in the Reports directory.
Screenshots for each step can be found in the Figures directory.
