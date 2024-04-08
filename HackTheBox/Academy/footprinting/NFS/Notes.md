## My NFS Notes :

### NFS is Network File system running on port 2049
### NFS is working with RPC -> port 111 using it for authentication 

## To install nfs : sudo apt install nfs-server ; be careful it will automatically run ports 2049 and 111

## To disable rpc : systemctl disable --now rpcbind.socket (and rpcbind.service)
 
## To disable rpc : systemctl disable --now nfs-server

# The default exports file contains some expamples of configurings nfs shares

  /etc/exports

# Do a cat /etc/exports

		┌──(kali㉿kali)-[~]
		└─$ cat /etc/exports
		# /etc/exports: the access control list for filesystems which may be exported
		#               to NFS clients.  See exports(5).
		#
		# Example for NFSv2 and NFSv3:
		# /srv/homes       hostname1(rw,sync,no_subtree_check) hostname2(ro,sync,no_subtree_check)
		#
		# Example for NFSv4:
		# /srv/nfs4        gss/krb5i(rw,sync,fsid=0,crossmnt,no_subtree_check)
		# /srv/nfs4/homes  gss/krb5i(rw,sync,no_subtree_check)
		#


## Additonal options can be added on Hosts 

		sudo sh -c 'echo "/mnt/nfs 10.10.14.0/24(sync,no_subtree_check)" >> /etc/exports'
		systemctl restart nfs-kernel-server
		sudo exportfs

----

Nmap :

		nmap localhost                                         
		Starting Nmap 7.94SVN ( https://nmap.org ) at 2024-02-03 18:51 +01
		Nmap scan report for localhost (127.0.0.1)
		Host is up (0.000063s latency).
		Other addresses for localhost (not scanned): ::1
		Not shown: 998 closed tcp ports (conn-refused)
		PORT     STATE SERVICE
		111/tcp  open  rpcbind
		2049/tcp open  nfs

----

|**Option** | **Description**|
|rw| 	|Read and write permissions.|
|ro| 	|Read only permissions.|
|sync| 	|Synchronous data transfer. (A bit slower)|
|async| 	|Asynchronous data transfer. (A bit faster)|
|secure| 	|Ports above 1024 will not be used.|
|insecure| 	|Ports above 1024 will be used.|
|no_subtree_check| 	|This option disables the checking of subdirectory trees.|
|root_squash| 	|Assigns all permissions to files of root UID/GID 0 to the UID/GID of anonymous, which prevents root from accessing files on an NFS mount.|

----

## Dangerous Settings

With NFS, some settings can be dangerous for the company and its infrastructure. Here are some of them listed:

|`Option`| 	Description|
|`rw`| 	Read and write permissions.|
|`insecure`| 	Ports above 1024 will be used.|
|`nohide`| 	If another file system was mounted below an exported directory, this directory is exported by its own exports entry.|
|`no_root_squash` 	All files created by root are kept with the UID/GID 0.|

----

## Footprinting the service

		┌──(kali㉿kali)-[~]
		└─$ nmap -sV -p111,2049 --script=nfs* --script=rpc* localhost 
		Starting Nmap 7.94SVN ( https://nmap.org ) at 2024-02-03 19:20 +01
		Nmap scan report for localhost (127.0.0.1)
		Host is up (0.000060s latency).
		Other addresses for localhost (not scanned): ::1

		PORT     STATE SERVICE VERSION
		111/tcp  open  rpcbind 2-4 (RPC #100000)
		| nfs-showmount: 
		|_  /mnt/nfs 10.10.14.109
		| rpcinfo: 
		|   program version    port/proto  service
		|   100000  2,3,4        111/tcp   rpcbind
		|   100000  2,3,4        111/udp   rpcbind
		|   100000  3,4          111/tcp6  rpcbind
		|   100000  3,4          111/udp6  rpcbind
		|   100003  3,4         2049/tcp   nfs
		|   100003  3,4         2049/tcp6  nfs
		|   100005  1,2,3      36331/tcp   mountd
		|   100005  1,2,3      38761/tcp6  mountd
		|   100005  1,2,3      56303/udp6  mountd
		|   100005  1,2,3      58349/udp   mountd
		|   100021  1,3,4      35076/udp6  nlockmgr
		|   100021  1,3,4      40589/tcp   nlockmgr
		|   100021  1,3,4      46081/tcp6  nlockmgr
		|   100021  1,3,4      55217/udp   nlockmgr
		|   100024  1          33615/udp   status
		|   100024  1          41409/tcp   status
		|   100024  1          52665/udp6  status
		|   100024  1          57085/tcp6  status
		|   100227  3           2049/tcp   nfs_acl
		|_  100227  3           2049/tcp6  nfs_acl
		2049/tcp open  nfs_acl 3 (RPC #100227)

## Show shares
		
		showmount -e 10.129.14.109
		Export list for 10.129.14.109:
		/mnt/nfs 10.129.14.0/24
		
## Mounting nfs share

		itsWhitenight@htb[/htb]$ mkdir target-NFS
		itsWhitenight@htb[/htb]$ sudo mount -t nfs 10.129.14.109:/ ./target-NFS/ -o nolock
		itsWhitenight@htb[/htb]$ cd target-NFS
		itsWhitenight@htb[/htb]$ tree .

		.
		└── mnt
		    └── nfs
			├── id_rsa
			├── id_rsa.pub
			└── nfs.share

		2 directories, 3 files
		
## Unmounting

		itsWhitenight@htb[/htb]$ cd ..
		itsWhitenight@htb[/htb]$ sudo umount ./target-NFS

