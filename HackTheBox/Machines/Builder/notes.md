## Machine Builder . Linux Medium Box

##

Nmap shows open ports 22 and 8080 

	port 8080 webpage -> jenkins 2.441
		jenkins 2.441 looks vulnerable to Arbitrary read file vulnerability which could allow me perhaps to read some sensitive files 
		
	testing payload : https://github.com/Praison001/CVE-2024-23897-Jenkins-Arbitrary-Read-File-Vulnerability
