## Web requests notes :

### HTTP :

+ [1] : HTTP communication consists of a client and a server where client requests a server for a resource through port 80 by default though this can be changed depending on the server configuration .

+ [2] : Http request can take the following form :

	http://username:password@inlanefreight.com:80/dahsboard.php?login=true#status
	
	not all components are required to acces a ressource though it's good to have it visually
	
+ [3] : HTTP Flow
 
		Me -> DNS {where is inlanefreaight ?} 
		DNS -> ME {152.153.81.13}
		ME -> HTTP GET -> 152.153.81.13 
		152.153.81.13 -> HTTP POST -> ME 
	
+ [4] : curl is a command line tool and library that supports HTTP along with other protocols 

	flags : 
	-O : downloads a file curl -O inlanefreight.com/index.html 
	-o : output
	-s : silent 
	
+ [FLAG] : To get the flag, start the above exercise, then use cURL to download the file returned by '/download.php' in the server shown above. 

		curl -s 94.237.48.205:31620/download.php
		HTB{64$!c_cURL_u$3r}

