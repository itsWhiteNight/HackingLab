## Machine WebGoat 

- [+] :	Target 
   >>	http://localhost:8080/WebGoat/
   
   

Introducing WebWolf

You only need WebWolf if a lesson specifies that you can use it. For many lessons, you use WebGoat without using WebWolf. Lessons where you can use WebWolf, are marked with the following icon (top right in the assignment):

 
wolf enabled

 

Even if the icon is present, you are not obliged to use WebWolf. You can also use any intercepting tool you like. (netcat etc.)

You can always open WebWolf by clicking the icon in the top right corner.

WebWolf opens in a new browser tab and is a separate web application that simulates an attacker’s machine. It makes it possible for us to distinguish between what takes place on the attacked website and what actions you need to take as an "attacker." The idea for WebWolf came about after a couple of workshops where we received feedback that there was no clear distinction between what was part of the "attackers" role and what was part of the "users" role on the website. WebWolf supports the following functionality:

    Hosting a file

    Receiving email

    Landing page for incoming requests


## General 
### HTTP BASICS
- [+] :	Concept

   >>	This lesson presents the basics for understanding the transfer of data between the browser and the web application and how to trap a request/response with a HTTP proxy.
- [+] :	Goals

   >>	The user should become familiar with the features of WebGoat by manipulating the above buttons to view hints, show the HTTP request parameters, the HTTP request cookies, and the Java source code. You may also try using OWASP Zed Attack Proxy for the first time.
How HTTP works:

   >>	All HTTP transactions follow the same general format. Each client request and server response has three parts: the request or response line, a header section and the entity body.

The client initiates a transaction as follows:

   >>	The client contacts the server and sends a document request. A GET request can have url parameters and those parameters will be available in the web access logs.

        GET /index.html?param=value HTTP/1.0

   >>	Next, the client sends optional header information to inform the server of its configuration and the document formats it will accept.

        User-Agent: Mozilla/4.06 Accept: image/gif,image/jpeg, /
        
   >>    In a POST request, the user supplied data will follow the optional headers and is not part of the contained within the POST URL.



 exo 1 
 enter your name : admin123 -> password 
 
 exo 2 
 
 intercept request in network to check for magic number in data of request 
 
### HTTP PROXIES 


- [+] :	What’s an HTTP Proxy

   >>	A proxy is some forwarder application that connects your HTTP client to backend resources. HTTP clients can be browsers or applications like curl, SOAP UI, Postman, etc. Usually, these proxies are used for routing and getting internet access when there is no direct connection to the internet from the client itself. HTTP proxies are therefore also ideal when you are testing your application. You can always use the proxy log records to see what was actually sent from client to server. So you can check the request and response headers and the XML, JSON, or other payloads.

   >>	HTTP Proxies receive requests from a client and relay them. They also typically record them. They act as a man-in-the-middle. It even works fine with or without HTTPS as long as your client or browser trusts the certificate of the HTTP Proxy.

 
- [+] :	ZAP Proxy Capabilities

   >>	With ZAP, you can record traffic, inspect traffic, modify requests and responses from and to your browser, and get reports on a range of known vulnerabilities that ZAP detects through the inspection of the traffic. The passive and active reporting on security issues is usually used in Continuous Delivery pipelines that use a GUI-less ZAP. Here we will use ZAP interactively and mainly to see and modify requests to find vulnerabilities and solve assignments. ZAP has a graphical user interface but now also has a HUD Heads-On-Display, which uses a web socket connection between the browser, and the ZAP proxy.

 
- [+] :	Next pages

   >>	You can go through all lesson pages or click on these links to skip some pages
   >>
   >>
   >>
   >>
   >>
   >>
   >>
   >>
   >>

	
