## Synced
		Rsync
		Protocols
		Reconnaissance
		Anonymous/Guest Access
		
## Tasks

- [*] : What is the default port for rsync? 
	>>873

- [*] : How many TCP ports are open on the remote host? 
	>>1

- [*] : What is the protocol version used by rsync on the remote machine?
	>>31

- [*] : What is the most common command name on Linux to interact with rsync? 
	>>rsync

- [*] : What credentials do you have to pass to rsync in order to use anonymous authentication? anonymous:anonymous, anonymous, None, rsync:rsync 
	>>none

- [*] : What is the option to only list shares and files on rsync? (No need to include the leading -- characters) 
	>>list-only

- [*] : Submit root flag 
	>>72eaf5344ebb84908ae543a719830519

## Notes :
Nmap shows port 873 -> hacktricks port 873 https://book.hacktricks.xyz/network-services-pentesting/873-pentesting-rsync 

```bash
nc -vn 10.129.228.37 873 
@RSYNCD: 31.0
@RSYNCD: 31.0
#list
public		Anonymous Share
```

```bash 
rsync -av --list-only rsync://10.129.228.37/public  ## no need to add anonymous username
receiving incremental file list
drwxr-xr-x          4,096 2022/10/24 23:02:23 .
-rw-r--r--             33 2022/10/24 22:32:03 flag.txt

sent 24 bytes  received 74 bytes  8.52 bytes/sec
total size is 33  speedup is 0.34
```

```bash
rsync -av rsync://anonymous@10.129.228.37/public ./flag.txt
```
