### Footprinting - DNS Section

## Server types :

- [1] - >> DNS Root Server is responsible for the top-level domains (TLD) As the last instance, they are only requested if the name server does not respond. Thus, a root server is a central interface between users and content on the Internet, as it links domain and IP address. The Internet Corporation for Assigned Names and Numbers (ICANN) coordinates the work of the root name servers. There are 13 such root servers around the globe.

- [2] - >> Authoritative Nameserver holds authority for a particular zone. They only answer queries from their area of responsibility, and their information is binding. If an authoritative name server cannot answer a client's query, the root name server takes over at that point

- [3] - >> Non-authoritative name servers are not responsible for a particular DNS zone. Instead, they collect information on specific DNS zones themselves, which is done using recursive or iterative DNS querying.

- [4] - >> Caching DNS servers cache information from other name servers for a specified period. The authoritative name server determines the duration of this storage.

- [5] - >> Forwarding servers perform only one function: they forward DNS queries to another DNS server.

- [6] - >> Resolvers are not authoritative DNS servers but perform name resolution locally in the computer or router.

DNS is mainly unencrypted. IT security professionals apply DNS over TLS (DoT) or DNS over HTTPS (DoH) In addition with the network protocol DNSCrypt that encrypts traffic between computer and name server

## DNS Records :
		
|A|	|Returns an IPv4 address of the requested domain as a result.|
|AAAA|	|Returns an IPv6 address of the requested domain.|
|MX|	|Returns the responsible mail servers as a result.|
|NS|	|Returns the DNS servers (nameservers) of the domain.|
|TXT|	|This record can contain various information. The all-rounder can be used, e.g., to validate the Google Search Console or validate SSL certificates. In addition, SPF and DMARC entries are set to validate mail traffic and protect it from spam.|
|CNAME|	|This record serves as an alias. If the domain www.hackthebox.eu should point to the same IP, and we create an A record for one and a CNAME record for the other.
|PTR|	|The PTR record works the other way around (reverse lookup). It converts IP addresses into valid domain names.|
|SOA|	|Provides information about the corresponding DNS zone and email address of the administrative contact.|

## Default Configs:

- [+] - >> [Three types ] :

- [1] - >> local DNS configuration files
- [2] - >> zone files
- [3] - >> reverse name resolution files

Most used DNS server is [Bind9] 
# BIND9 very good documentation about config files and more ->  https://wiki.debian.org/Bind9#Introduction 
name.conf file dived into 2 sections 
options section for general settings and secondly the zone entries for the individual domains. The local configuration files are usually:

+ : named.conf.local
+ : named.conf.options
+ : named.conf.log

```
			root@bind9:~# cat /etc/bind/named.conf.local

			//
			// Do any local configuration here
			//

			// Consider adding the 1918 zones here, if they are not used in your
			// organization
			//include "/etc/bind/zones.rfc1918";
			zone "domain.com" {
		//	    type master;
		//	    file "/etc/bind/db.domain.com";
		//	    allow-update { key rndc-key; };
			};
```



----
# Zone Files
A zone file is a text file that describes a DNS zone completely with the BIND file format.it is a point of delegation in the DNS tree.There must be precisely one [SOA] record and at least one [NS] record

```
		root@bind9:~# cat /etc/bind/db.domain.com
		;
		; BIND reverse data file for local loopback interface
		;
		$ORIGIN domain.com
		$TTL 86400
		@     IN     SOA    dns1.domain.com.     hostmaster.domain.com. (
				    2001062501 ; serial
				    21600      ; refresh after 6 hours
				    3600       ; retry after 1 hour
				    604800     ; expire after 1 week
				    86400 )    ; minimum TTL of 1 day

		      IN     NS     ns1.domain.com.
		      IN     NS     ns2.domain.com.

		      IN     MX     10     mx.domain.com.
		      IN     MX     20     mx2.domain.com.

			     IN     A       10.129.14.5

		server1      IN     A       10.129.14.5
		server2      IN     A       10.129.14.7
		ns1          IN     A       10.129.14.2
		ns2          IN     A       10.129.14.3

		ftp          IN     CNAME   server1
		mx           IN     CNAME   server1
		mx2          IN     CNAME   server2
		www          IN     CNAME   server2
```
# Reverse Name Resolution Zone Files
For the IP address to be resolved from FQDN, the DNS server must have a reverse lookup file.The PTR records are responsible for the reverse translation of IP addresses into names
```
		root@bind9:~# cat /etc/bind/db.10.129.14

		;
		; BIND reverse data file for local loopback interface
		;
		$ORIGIN 14.129.10.in-addr.arpa
		$TTL 86400
		@     IN     SOA    dns1.domain.com.     hostmaster.domain.com. (
				    2001062501 ; serial
				    21600      ; refresh after 6 hours
				    3600       ; retry after 1 hour
				    604800     ; expire after 1 week
				    86400 )    ; minimum TTL of 1 day

		      IN     NS     ns1.domain.com.
		      IN     NS     ns2.domain.com.

		5    IN     PTR    server1.domain.com.
		7    IN     MX     mx.domain.com.
		...SNIP...
```
## Dangerous Settings
Vulnerabilities : 

https://www.cvedetails.com/product/144/ISC-Bind.html?vendor_id=64
https://securitytrails.com/blog/most-popular-types-dns-attacks

Cause :

|Option| 		|Description|
|allow-query| 	|Defines which hosts are allowed to send requests to the DNS server.|
|allow-recursion| 	|Defines which hosts are allowed to send recursive requests to the DNS server.|
|allow-transfer| 	|Defines which hosts are allowed to receive zone transfers from the DNS server.|
|zone-statistics| 	|Collects statistical data of zones.|



## Brute Force DNS 

- [1] - >> : for sub in $(cat /opt/useful/secLists/Discovery/DNS/subdomains-top1million-110000.txt);do dig $sub.inlanefreight.htb @10.129.14.128 | grep -v ';\|SOA' | sed -r '/^\s*$/d' | grep $sub | tee -a subdomains.txt;done

- [1] - >> : dnsenum --dnsserver 10.129.10.89 --enum -p 0 -s 0 -o sub.txt -f /usr/share/wordlists/seclists/Discovery/DNS/bitquark-subdomains-top100000.txt dev.inlanefreight.htb

## footprinting


