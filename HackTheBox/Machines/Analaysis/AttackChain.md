findings 

gobuster dns -d analysis.htb -w /usr/share/spiderfoot/spiderfoot/dicts/subdomains-10000.txt -r 10.10.11.250:53 -o gob.xml -t 100
---------------------------------------
Found: www.analysis.htb
                                                                                                                    
Found: internal.analysis.htb
                                                                                                                    
Found: domaindnszones.analysis.htb
                                                                                                                    
Found: forestdnszones.analysis.htb
---------------------------------------
http://internal.analysis.htb/users
http://internal.analysis.htb/users/list.php

http://internal.analysis.htb/employees/login.php  
---------------------------------------
  
[02:10:08] 200 -   13KB - /dashboard/404.html                               
                      
[02:10:29] 200 -   38B  - /dashboard/index.php/login/                       

---------------------

kerbrute userenum -d analysis.htb --dc analysis.htb /usr/share/wordlists/Seclists/Usernames/xato-net-10-million-usernames-dup.txt -t 100 -o logs_kerbrute.txt


2024/01/22 23:56:40 >  [+] VALID USERNAME:       jdoe@analysis.htb
2024/01/22 23:56:48 >  [+] VALID USERNAME:       ajohnson@analysis.htb
2024/01/22 23:57:05 >  [+] VALID USERNAME:       cwilliams@analysis.htb
2024/01/22 23:57:13 >  [+] VALID USERNAME:       wsmith@analysis.htb                  
2024/01/22 23:57:35 >  [+] VALID USERNAME:       jangel@analysis.htb
2024/01/22 23:58:53 >  [+] VALID USERNAME:       technician@analysis.htb
2024/01/23 00:01:03 >  [+] VALID USERNAME:       JDoe@analysis.htb
2024/01/23 00:01:08 >  [+] VALID USERNAME:       AJohnson@analysis.htb

---------

ffuf -w /usr/share/wordlists/Seclists/Discovery/Web-Content/url-params_from-top-55-most-popular-apps.txt -u "http://internal.analysis.htb/users/list.php?FUZZ"  

    
