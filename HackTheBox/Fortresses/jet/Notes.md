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

- [+] : 
   >>	


## - RECON -

- [+] : 
   >>	

- [+] : 
   >>	

- [+] : 
   >>	

- [+] : 
   >>	

- [+] : 
   >>	

   
