#!/bin/python3

import requests

# Construct the sample HTTP response (URL-encoded)
sample_response = "flag"

# Send an HTTP request to /check
check_url = "https://learn-http.ctf.pearlctf.in/check"
headers = {"Content-Type": "application/x-www-form-urlencoded"}
data = {"body": sample_response}
response = requests.post(check_url, data=data, headers=headers)

# Extract the token from the response headers
set_cookie_header = response.headers.get("Set-Cookie")
extracted_token = set_cookie_header.split(";")[0].split("=")[1]

# Send an HTTP request to /flag
flag_url = "https://learn-http.ctf.pearlctf.in/flag"
cookies = {"token": extracted_token}
flag_response = requests.get(flag_url, cookies=cookies)

# Parse the flag
flag = flag_response.text
print(f"Flag: {flag}")

