## Linux Machine


## Recon 

[+] + Port 22,80

## Foothold

[+] + In comprezzor.htb code source -> report.comprezzor.htb

[+] + in order to report a bug you have to be authentified 

[+] + redirection to auth.comprezzor.htb 

[+] + after registration login with account

```base64  eyJ1c2VyX2lkIjogNiwgInVzZXJuYW1lIjogInRyeXRoaXNvbmUiLCAicm9sZSI6ICJ1c2VyIn18MDFiMDBiYWFlODhjMTk4ZWE4NTc4Nzc4MWJjN2U3NDc1NDAzMGFiMmJhNjVjZmRkNDUxODIwN2U1ZmE5MjZmNw==
```

[+] + base64 decoded :
```{"user_id": 6, "username": "trythisone", "role": "user"}|01b00baae88c198ea85787781bc7e74754030ab2ba65cfdd4518207e5fa926f7
```

[+] + ffuf -> http://dashboard.comprezzor.htb/

{"user_id": 6, "username": "trythisone", "role": "admin"}|01b00baae88c198ea85787781bc7e74754030ab2ba65cfdd4518207e5fa926f7
e3VzZXJfaWQ6IDYsIHVzZXJuYW1lOiB0cnl0aGlzb25lLCByb2xlOiBhZG1pbn18MDFiMDBiYWFlODhjMTk4ZWE4NTc4Nzc4MWJjN2U3NDc1NDAzMGFiMmJhNjVjZmRkNDUxODIwN2U1ZmE5MjZmNwo==

{"_flashes":[{" t":["success","Logged in successfully!"]}]{"role": "admin"}}

eyJfZmxhc2hlcyI6W3siIHQiOlsic3VjY2VzcyIsIkxvZ2dlZCBpbiBzdWNjZXNzZnVsbHkhIl19XXsicm9sZSI6ICJhZG1pbiJ9fQo=



