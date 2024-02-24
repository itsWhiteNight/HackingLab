DNS Root Server is responsible for the top-level domains (TLD) As the last instance, they are only requested if the name server does not respond. Thus, a root server is a central interface between users and content on the Internet, as it links domain and IP address. The Internet Corporation for Assigned Names and Numbers (ICANN) coordinates the work of the root name servers. There are 13 such root servers around the globe.

Authoritative Nameserver holds authority for a particular zone. They only answer queries from their area of responsibility, and their information is binding. If an authoritative name server cannot answer a client's query, the root name server takes over at that point

Non-authoritative name servers are not responsible for a particular DNS zone. Instead, they collect information on specific DNS zones themselves, which is done using recursive or iterative DNS querying.

Caching DNS servers cache information from other name servers for a specified period. The authoritative name server determines the duration of this storage.

Forwarding servers perform only one function: they forward DNS queries to another DNS server.

Resolvers are not authoritative DNS servers but perform name resolution locally in the computer or router.

