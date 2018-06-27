**Learning Objectives**
=======================
- Learn to manage hosts - DNS, FTP, hosting
- Understand the security implications of shared / VPS hosting

**Outline**
===========
- Domain Names
  - Unique name for your app on the internet
  - TLD - **T**op **L**evel **D**omain
    - com, org, net, int, edu, gov, mil - the "originals";
    - ccTLD - Two letter TLD's for every country in the world;
    many countries have com / net / org / etc under their TLD;
    eg .co.il, .muni.il, .ac.il
    - gTLD - "Generic" TLD's; recently opened up so any organization can make their own TLD's
    eg .actor, .rich, .pharma
  - Which TLD to use
    - The "classics" offer legitimacy; "best" is .com;
    - "Cute" names based on hijacking ccTLD's are popular but risky - the country itself has authority over the TLD; they could charge more or just take it away;
    - Popular ccTLD's - .tv, .io, .ly (eg bit.ly), .sy

- DNS - **D**omain **N**ame **S**ervice
  - Find the "address" (IP address) of any named app by it's domain name
  - Several different types of record exist for every domain
  - A - Mapping - this is the "main" record type; it lists the IP address for the "main" server
  - CNAME - Alias
  - MX - E-mail server for the domain
  - NS - DNS server for the domain
  - PTR - Reverse name lookup
  - TXT - Can contain any arbitrary text you want
    - TXT records are used for security and verification
    - Security - SPF - special TXT record that specifies what servers are allowed to send e-mail for your domain; useful to cut spam;
    - Verification - Add a unique string to your TXT record to prove you own a domain
  - Subdomains - named A records for specific "parts" of your site; these are essentially different domain names;
  - Propogation - changes on DNS are _not_ immediate; expect up to 48 hours from the change until it's available everywhere
  - TTL - use to overcome propogration on addrs you expect to change

- Ports - Specify the "service" you want on a server
  - "[Well known](https://www.iana.org/assignments/service-names-port-numbers/service-names-port-numbers.xhtml)" ports exists but not a strong mapping
  - 80 - HTTP
  - 8080 - Not a "real" port, but often used for admin services over HTTP
  - 443 - HTTPS (and any type of SSL)
  - 25 - SMTP - send e-mails
  - 465 - Encrypted SMTP

- In Class Demo - Namecheap domain management
  - Registering a new domain
  - Setting up DNS

- In Class Demo - IIS / DNS / hosts review
  - IIS Host Header
  - VS / IIS Express ports to host multiple sites on one "domain name" (localhost)

- File System Security
  - Basic permissions: Read, Write, Execute
  - Divided by user / group
  - Principle of least privelege - only allow a user the minimum amount of access they need to get the job done;
  - For the majority of your web app - only need _Read_ permission
  - In IIS you have a special IISUSR account which IIS uses for file access; allows you to set file permissions specifically for your app
  - (NOTE: IIS can also use the Local Service, Network Service, or user account depending on setup)

- Special case - uploading files
  - Many apps accept arbitrary file uploads from end user
  - You need to store the files on the disk - thats Write access
  - You should _limit_ the write acccess to the upload directory _only_
  - You can use _virtual directories_ to sandbox your physical uploads e/though they're on many sites

- In Class Demo - File Security and Uploads in IIS

- Hosting Options
  - "Rent" Space Per App
    - Shared Host
    - "Cloud" Hosting
  - "Rent" A Host
    - VPS
    - Managed VPS
    - Managed Private Server
  - Run Your Own Host
    - Rackspace Rental
    - "In House"

- Shared Server Security
  - On a shared server, _other subscribers_ have some access to your app and your data
  - Eg - in SSMS can see the name of all DB's on the server
  - The server admin severely _restricts_ access to prevent one user from compromising another
  - Using a shared server opens an additional _attack surface_; eg - find a vulnerability in Plesk, cpanel, FTP, etc
  - As of now shared servers are considered secure enough for most "non-sensitive" data; "sensitive" data like CC numbers is normally not allowed on a shared server;

- Sidebar - Security Attack Surfaces
  - The basis behind "better" security on VPS, Bare Metal, etc is reducing attack surfaces
  - An attack surface is any way an attacker can try to attack your system
  - Eg - direct DB attack, SQL injection via your UI, bugs in management system, brute-force login attack, DDoS, upload files, etc
  - The more isolated you make your app, the fewer attack surfaces
  - There is no panacea in security; you must be aware of your setup and the security concerns;
  - On shared hosting - _disable unused services_
  - eg PHP, CGI, MySQL, etc

- In Class Demo - Plesk
  - Setup an app and DB
  - Setup subdomain apps
  - Setup "upload directory" - 1) physical folder, 2) permissions, 3) virtual directory

- SSL Certificates
  - Issued by trusted agencies
  - Cryptographically secure way to verify your identity
  - Also increases your privacy; MITM cannot track what you're doing
  - Google requirement - built in to Chrome which means most people expect it's required; you will lose customers if Chrome gives warnings

- Sidebar - The "insecure connection" page
  - [!https://prod-cdn.sumo.mozilla.net/uploads/images/2016-02-05-14-08-50-9f62b4.png](Firefox)
  - [!https://www.technipages.com/wp-content/uploads/2015/04/Chrome-Advanced.png](Chrome)
  - Do not train users to ignore it!

- Let'sEncrypt
  - Free SSL certs for everyone
  - Great for use w/ 3rd party hosting; it's automated and verification is easy
  - For your "own" server, you need to manage it w/ scripts;

- "Always Up" services
  - Most apps we rely on regularly are available 24/7
  - Technology is actually _very_ fallible and frequently fails; how do we acheive the appearance of "always up" when we know tech _will_ fail?
  - **Redundancy** - we keep duplicates of every service we need and setup a _failover_
  - A _failover_ is a tool which detects the active redundant service failed and switches to the backup automatically
  - DDoS - **D**istributed **D**enial **o**f **S**ervice attack
    - A network of computers constantly send pointless requests to your app in an effort to overwork and cause it to crash
    - Failovers help protect against this
  - Failovers in use by major players in the cloud world - 
    - Redundant power sources / NICs in server
    - Redundant servers (with all redundancies already listed in each)
    - Redundant internet connections from _different providers_
    - _Independent_ battery backups on all power sources / routing equipment
    - Gas powered generators for extended power outage
    - Redundant and _independent_ connections to power utility
    - Redundant data centers in _different geographic locations_
  - SLA - **S**ervice **L**evel **A**greement
    - The "promise" your provider makes about how often the service will be up
    - 99.9% for all the "big" players
    - Prorated refunds if there actually is an outage
  - Big advantage of cloud providers like Azure and AWS
    - Split your app up on top of their failovers
    - Classic shared hosting cannot do this

- Displaying Error Information
  - Any error information you show exposes information about your server
  - Might include server type, version, libraries used, etc
  - An attacker can use this information to formulate an attack; you should never expose it
  - <customErrors> in Web.config
    - Off - Always show real error messages; this is somewhat reverse from expectation;
    - RemoteOnly - If the site is accessed from the server itself show real message, otherwise custom message
    - On - Always show custom message

- XML transformations 
  - Several settings change depending on evnironment
  - Connection string - debug server shouldn't use live DB
  - XML transform lets you change some parts of Web.config based on build mode

- In Class Demo - Changing Custom Errors By Build Mode