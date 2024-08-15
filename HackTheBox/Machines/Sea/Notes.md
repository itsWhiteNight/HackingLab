## Linux - Machine

- [+] : Target IP
  >>	10.129.207.147
  
  
  
  ──(kali㉿kali)-[~/HackingLab/HTB/Sea]
└─$ dirsearch -u 10.129.185.133 -r -R 3
/usr/lib/python3/dist-packages/dirsearch/dirsearch.py:23: DeprecationWarning: pkg_resources is deprecated as an API. See https://setuptools.pypa.io/en/latest/pkg_resources.html
  from pkg_resources import DistributionNotFound, VersionConflict

  _|. _ _  _  _  _ _|_    v0.4.3                                             
 (_||| _) (/_(_|| (_| )                                                      
                                                                             
Extensions: php, aspx, jsp, html, js | HTTP method: GET | Threads: 25
Wordlist size: 11460

Output File: /home/kali/HackingLab/HTB/Sea/reports/_10.129.185.133/_24-08-10_16-08-15.txt

Target: http://10.129.185.133/

[16:08:19] Starting:                                                         
[16:08:20] 403 -  199B  - /%3f/                                             
Added to the queue: %3f/
[16:08:37] 403 -  199B  - /.ht_wsr.txt
[16:08:37] 403 -  199B  - /.htaccess.bak1
[16:08:37] 403 -  199B  - /.htaccess.sample
[16:08:37] 403 -  199B  - /.htaccess.orig
[16:08:37] 403 -  199B  - /.htaccessBAK
[16:08:37] 403 -  199B  - /.htaccess_orig
[16:08:37] 403 -  199B  - /.htaccess.save
[16:08:37] 403 -  199B  - /.htaccess_sc
[16:08:37] 403 -  199B  - /.htaccessOLD2
[16:08:37] 403 -  199B  - /.htaccessOLD
[16:08:37] 403 -  199B  - /.htm
[16:08:37] 403 -  199B  - /.htaccess_extra
[16:08:38] 403 -  199B  - /.html
[16:08:38] 403 -  199B  - /.htpasswds
[16:08:38] 403 -  199B  - /.httr-oauth
[16:08:38] 403 -  199B  - /.htpasswd_test
[16:08:39] 403 -  199B  - /.php
[16:08:41] 200 -    1KB - /404
[16:08:43] 500 -    0B  - /adm/style/admin.css
[16:08:43] 500 -    0B  - /adm_auth.php
[16:08:43] 403 -  199B  - /admin%20/
Added to the queue: admin%20/
[16:08:43] 500 -    0B  - /admin/account.jsp
[16:08:44] 500 -    0B  - /admin/phpMyAdmin/
[16:08:55] 200 -  939B  - /contact.php
[16:08:56] 301 -  235B  - /data  ->  http://10.129.185.133/data/
Added to the queue: data/
[16:08:56] 403 -  199B  - /data/
[16:08:56] 403 -  199B  - /data/files/
Added to the queue: data/files/
[16:09:06] 403 -  199B  - /login.wdm%20
[16:09:08] 301 -  239B  - /messages  ->  http://10.129.185.133/messages/
Added to the queue: messages/
[16:09:09] 403 -  199B  - /New%20Folder
[16:09:09] 403 -  199B  - /New%20folder%20(2)
[16:09:12] 403 -  199B  - /phpliteadmin%202.php
[16:09:14] 403 -  199B  - /plugins/
Added to the queue: plugins/
[16:09:14] 301 -  238B  - /plugins  ->  http://10.129.185.133/plugins/
[16:09:15] 403 -  199B  - /Read%20Me.txt
[16:09:18] 403 -  199B  - /server-status/
Added to the queue: server-status/
[16:09:18] 403 -  199B  - /server-status
[16:09:25] 301 -  237B  - /themes  ->  http://10.129.185.133/themes/
Added to the queue: themes/
[16:09:25] 403 -  199B  - /themes/

[16:09:34] Starting: %3f/                                                    

[16:10:32] Starting: admin%20/                                               
[16:10:33] 404 -    3KB - /admin%20/%2e%2e//google.com

[16:11:25] Starting: data/                                                   
[16:11:31] 200 -    1KB - /data/404
[16:11:34] 200 -    1KB - /data/admin/home
[16:11:51] 301 -  241B  - /data/files  ->  http://10.129.185.133/data/files/
[16:11:53] 200 -    1KB - /data/home
[16:12:06] 500 -    0B  - /data/popup_songs.php
[16:12:07] 500 -    0B  - /data/qwertypoiu.htw
[16:12:12] 200 -    1KB - /data/sitecore/content/home
[16:12:16] 200 -    1KB - /data/sym/root/home/

[16:12:27] Starting: data/files/                                             
[16:12:32] 200 -    1KB - /data/files/404
[16:12:36] 200 -    1KB - /data/files/admin/home
[16:12:54] 200 -    1KB - /data/files/home
[16:13:17] 200 -    1KB - /data/files/sitecore/content/home
[16:13:20] 200 -    1KB - /data/files/sym/root/home/

[16:13:29] Starting: messages/                                               
[16:13:36] 200 -    1KB - /messages/404
[16:13:41] 200 -    1KB - /messages/admin/home
[16:14:01] 200 -    1KB - /messages/home
[16:14:11] 500 -    0B  - /messages/php5.fcgi
[16:14:11] 500 -    0B  - /messages/phpMyAdmin-2.11.2/
[16:14:19] 200 -    1KB - /messages/sitecore/content/home
[16:14:21] 200 -    1KB - /messages/sym/root/home/

[16:14:32] Starting: plugins/                                                
[16:14:40] 200 -    1KB - /plugins/404
[16:14:43] 200 -    1KB - /plugins/admin/home
[16:15:00] 200 -    1KB - /plugins/home
[16:15:16] 500 -    0B  - /plugins/rest/beta/repositories/go/group
[16:15:18] 200 -    1KB - /plugins/sitecore/content/home
[16:15:21] 200 -    1KB - /plugins/sym/root/home/

[16:15:29] Starting: server-status/                                          
[16:15:30] 404 -    3KB - /server-status/%2e%2e//google.com

[16:16:45] Starting: themes/                                                 
[16:16:51] 200 -    1KB - /themes/404
[16:16:54] 200 -    1KB - /themes/admin/home
[16:17:17] 200 -    1KB - /themes/home
[16:17:18] 500 -    0B  - /themes/importcockpit
[16:17:18] 500 -    0B  - /themes/inc
[16:17:19] 500 -    0B  - /themes/install.sql
[16:17:20] 500 -    0B  - /themes/learn/ruubikcms/ruubikcms/cms/includes/newsmenu.php                                                                     
[16:17:20] 500 -    0B  - /themes/learn/ruubikcms/ruubikcms/cms/includes/mainmenu.php                                                                     
[16:17:20] 500 -    0B  - /themes/learn/ruubikcms/ruubikcms/cms/includes/multilang.php                                                                    
[16:17:20] 500 -    0B  - /themes/learn/ruubikcms/ruubikcms/cms/includes/pagemenu.php                                                                     
[16:17:20] 500 -    0B  - /themes/learn/ruubikcms/ruubikcms/cms/includes/required.php                                                                     
[16:17:20] 500 -    0B  - /themes/lib/tinymce
[16:17:34] 200 -    1KB - /themes/sitecore/content/home
[16:17:37] 200 -    1KB - /themes/sym/root/home/

