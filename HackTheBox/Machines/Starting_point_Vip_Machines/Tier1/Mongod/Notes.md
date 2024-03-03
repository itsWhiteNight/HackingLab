## Mongod 
		Tags
		MongoDB
		Databases
		Reconnaissance
		Misconfiguration
		Anonymous/Guest Access
		
## Tasks

- [*] : How many TCP ports are open on the machine? 
	>> 2
	
- [*] : Which service is running on port 27017 of the remote host? 
	>> MongoDB 3.6.8
	
- [*] : What type of database is MongoDB? (Choose: SQL or NoSQL) 
	>> NoSQL
	
- [*] : What is the command name for the Mongo shell that is installed with the mongodb-clients package? 
	>> mongo	# mongo ip_target:port 
	
- [*] :What is the command used for listing all the databases present on the MongoDB server? (No need to include a trailing ;) 
	>> show dbs
	
- [*] : What is the command used for listing out the collections in a database? (No need to include a trailing ;) 
	>> show collections
	
- [*] : What is the command used for dumping the content of all the documents within the collection named flag in a format that is easy to read? 
	>> db.flag.find().help() -> db.flag.find().pretty()
	
- [*] : Submit root flag 
	>> 1b6e6fb359e7c40241b6d431427ba6ea
	

