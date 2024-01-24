#### HackTheBox - Surveillance Box Writeup
## Introduction

### This markdown file contains my notes and findings from the Surveillance box on HackTheBox. It outlines the steps I took to compromise the system and obtain root access.

## Initial Reconnaissance
<ul>
	<li>Conduct an NMAP scan to identify open ports and services.<li/>
	<li>Identify an open HTTP port and check if a webpage is viewable in a web browser.<li/>
<ul/>

## Web Application Enumeration

<ul>

Resolve webpage issues by adding the IP and DNS name to /etc/hosts.
Perform directory busting using GoBuster.
Discover an admin login running Craft CMS by examining the source code of surveillance.htb/index.php.

<ul/>
## Exploiting Craft CMS
<ul>
Identify the version of Craft CMS by viewing the source code.
Find a Remote Code Execution (RCE) Proof of Concept (PoC) for the discovered version.
Edit the script as instructed in the PoC to obtain a shell.
<ul/>
## Establishing a Stable Shell
<ul>
Use a one-liner for a stable shell using Netcat and Bash commands.
Breakdown of the one-liner's components explained.
<ul/>
## Privilege Escalation
<ul>
Find a backup directory in the storage and copy it to the web server.
Use wget to extract the file and crack the hashed password for the user "Matthew."
Use the cracked password to access SSH and obtain user privileges.
<ul/>
## Enumerating MySQL Credentials
<ul>
Run linpeas to check for credentials.
Find MySQL credentials related to the database stored in the storage/backups directory.
Investigate configurations related to "zoneminder."
<ul/>
## Exploiting ZoneMinder
<ul>
Discover ZoneMinder software and initiate port forwarding using SSH.
Identify a login page for ZoneMinder and attempt default credentials (admin:admin).
Determine the version (1.36.32) and find an exploit PoC for ZoneMinder.
Explore different options, including Metasploit exploits involving snapshots.
<ul/>
## Local Privilege Escalation (LPE)
<ul>
Check sudo privileges using sudo -l.
Spawn a stable shell via Python.
<ul/>
## Root Access
<ul>
Exploit a vulnerability in zmupdate.pl by inputting a file directory instead of a user.
Use a reverse shell script, transfer it via Python server, and run it.
Utilize busybox to access the netcat command.
Alternative method using /bin/bash -i instead of a reverse shell file.
Obtain root access and find the root flag.
<ul/>
## Update and Keynotes
<ul>
Discover an alternative method for root access without using a reverse shell file.
Acknowledge the importance of studying port forwarding and reading code.
Note the significance of learning more about busybox, the Swiss Army knife of embedded Linux.
<ul/>
