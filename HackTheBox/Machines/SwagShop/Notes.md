## Linux Machine - SwagShop 

- [+] :  Target IP 
      >> 10.10.10.140
	 
## Recon 	 
PORT   STATE SERVICE
22/tcp open  ssh
80/tcp open  http

## Tasks
- [+] :  Target IP 
      >> 10.10.10.140
	 
- [-] :  Task 1
	 
- [+] :  How many TCP ports are open on SwagShop?
      >> 2

- [-] :  Task 2

- [+] :  What is the name of the eCommerce Software being used by the website?
      >> Magento

- [-] :  Task 3

- [+] :  Which version of Magento is in use?
      >> 1.9.0.0

- [-] :  Task 4

- [+] :  The Magento Shoplift vulnerability can be used to change the credentials of what user?
      >> admin

- [-] :  Task 5

- [+] :  There are multiple different methods to use this admin access to get remote code execution on SwagShop through Magento. What user is the web server running the site as?
      >> www-data

- [-] :  Task 7

- [+] :  Which binary can www-data run as root without a password?
      >> vi

## Privesc

```bash
sudo /usr/bin/vi /var/www/html/* -c ':!/bin/sh' /dev/null
```
