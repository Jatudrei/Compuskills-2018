**Learning Objectives**
=======================
- Recognize the "attack surface" and "attack vectors" and how to harden your app against them
- Learn industry best-practice for most common security questions
- Beyond technical security - principles of social engineering and information leaks

**Outline**
===========
- Attack surface
  - The part of your application that you "expose" to the outside world is vulnerable to attempted attack
  - Each potential way a malicious agent can attack is called an "attack vector"
  - As a metaphor - consider a walled city
    - Direct (Brute Force) Attack Vectors
      - The outer walls
      - The gates / windows of the walls
      - The air above the city
      - Tunneling from under the city
    - Infrastructure Attack Vectors
      - Water / food supply
      - Trade
      - Destabilizing city foundations (not breaking into the city like tunneling)
    - Indirect Attack Vectors
      - Disguised entry
      - Misinformation / propoganda campaign directed at residents (encourage unrest)
      - Government manipulation - manchurian candidate, voting influence
- Identifying your attack surface ([OWASP summary](https://www.owasp.org/index.php/Attack_Surface_Analysis_Cheat_Sheet))
1. Direct attack vectors in the UI
    - Remember in a client / server app, the UI is an _artificial representation_ that uses your server in the background
    - An attacker could skip the UI entirely and attack directly against your server with HTTP request tools (like Postman)
    - A _direct_ attack vector in the UI will normally expose sensitive information allowing the attacker to make unauthorized RPC calls
    1. UI forms / fields
    2. Include forms / fields that are "hidden" from a user by default; can easily be manipulated with js / console / Postman / etc
    3. Cookies - session / auth cookie, user claims, 3rd party auth cookies
    4. Headers - authorization or other spcl use headers
2. Indirect attack vectors in the UI
    - Indirect attack means forcing your _users_ to attack you
    - Inject behavior into your UI to send the users auth token to a 3rd party or to make the RPC with a users credentials
    - Common attacks
        1. [XSS attacks](https://www.owasp.org/index.php/Cross-site_Scripting_(XSS))
        2. [CSRF attacks](https://www.owasp.org/index.php/Cross-Site_Request_Forgery_(CSRF))
    1. User submitted page contents: eg - testimonials, comments, reviews, etc
    2. Dynamic pages (incl. all MVC views)
    3. 3rd party content (eg ads / video hosting / 3rd party libs)
    - Always use @Html helpers to show server content - they _encode_ the data for HTML display
3. Direct attack vectors on the server (API and other services)
    - The attacker will simulate input to try and make un'auhted RPC
    - The attacker will use _injection_ attacks to make server reveal additional data
    1. [SQL injection](https://www.owasp.org/index.php/SQL_Injection) potential - _**always**_ use SQL parameters and sanitize your data; [Little Johnny Tables](https://xkcd.com/327/)
    2. _Bugs_ that lead to RCE / privelege elevation - most are "automatically" mitigated in .NET; this may not be true for 3rd party libraries
    3. Brute force attack on login page - implement rate limiting, banning, and 2FA
    4. [Credential stuffing](https://www.owasp.org/index.php/Credential_stuffing) with compromised user / passwords from 3rd party sites
    5. Brute force against unrelated services running on the server - FTP, RDC, SSH, PHP, CGI, MySQL, etc; - _always_ disable any service you do not need to run on the server _and_ check and address issues in logs
    6. Information leak - login failed error message example
4. Indirect attack vectors on the server
    - The attacker will trick a legitimate user into making an action on their behalf
    - CSRF and MITM with stolen credentials is common
    1. RPC calls with "automatic" authorization (cookies, auth headers) - use MVC CSRF token validation
    2. Caches
5. Direct attack vectors on the connection (between client / server)
    1. MITM - Always use SSL / TLS
6. Direct attack vectors on the machine
    - The attacker connects directly to your machine or network - _very_ dangerous
    1. Physical hard disk access
    2. USB hijack - [True Example - Momentary Access](https://security.stackexchange.com/a/187516/13907)
    3. Keyloggers, sniffers, etc
7. Direct attack vectors through social engineering
    - The attacker talks to your customer support / online support system to gather sensitive information
    1. Training - people are susceptible to feelings that have _very little to do with fact_;
    2. Company Policies - if the policy is specific, little room for assumption
    3. Flexibility - rep's should be flexible to be more strict than policy, but never to be less
    - [Example - Amazon / Apple Hack](https://www.wired.com/2012/08/apple-amazon-mat-honan-hacking/)
8. Indirect attack vectors through social engineering
    - The attacker convinces the user to authorize something
    - Phishing e-mails; scare tactics
    - [Phone porting](https://www.nextadvisor.com/blog/phone-porting-how-hackers-can-hijack-your-mobile-phone-number/)
    1. Be aware of what information you expose - PII
    2. Be aware of who you trust for 2FA
9. Infrastructure attack vectors
    1. DDoS
    2. 3rd party servive blocking / hijacking
- Review of attack surfaces
    1. Direct: UI, API, MITM, Services (eg DB), Physical Machine Access, Customer Support
    2. Infrastructure: DDoS, 3rd party service, Interim connection providers
    3. Indirect: XSS, CSRF, 3rd party information leaking, password reuse
- Cleaning a Compromised Server
  - It is _impossible_ to verify a server has been disinfected from an attack
  - Dont' fix it. _Nuke it from orbit_
  - Maintain regular and complete backups so nuking is a viable option
- [10 immutable laws of security](https://technet.microsoft.com/en-us/library/hh278941.aspx)
- [10 immutable laws of administration](https://technet.microsoft.com/en-us/library/cc722488.aspx)
- Addt'l information on the Information Security field
  - DEFCON
  - Pentesting
  - Bug bounty programs