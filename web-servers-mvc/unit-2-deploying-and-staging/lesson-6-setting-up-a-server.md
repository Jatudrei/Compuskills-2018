**Learning Objectives**
=======================
- Understand the components of a "live" web app
- Learn the common tools you'll use to configure your running web app
- Learn the options available to publish and update your app

**Outline**
===========
- Parts of a "running" ASP.NET application
  - Web Server - Program which "listens" for incoming HTTP requests and sends responses; this is _not_ the same as your MVC app; a server can handle many different types of websites / web apps at the same time;
  - .NET Runtime - The CLR running on your host; you can have multiple versions of the runtime on the host;
  - Your App - the files for your app to run; you configure the server to host your app;
  - DBMS - Program which handles database queries; does not have to be on the same computer as your server;
  - Host - Computer which constantly runs the server and/or database program(s); a host is usually a dedicated computer optimized only for running web applications; we'll discuss host options later in the lesson.
  - Cache / Redis - Targeted cache for storing "final" versions of dynamic pages; avoids having to recreate dynamic content more often than it changes;
  - Internet Connection / Firewall - How _other people_ get access to your host; backwards from how you traditionally think about internet;
  - Domain Name / DNS - Your "website address", eg www.compuskills.org; How the address gets connected to the right host;
  - Static IP Address - A permanent "fixed address"; we'll discuss in next lesson;
  - SSL - Creates an encrypted connection between the host and clients

- Server jobs and MVC jobs
  - NB: When you run an MVC app directly from Visual Studio, all of this is hidden from you
  - Look at the MVC app compile settings; it's set to compile to an Assembly (DLL), _not_ an Application;
  - You've also never had an `exe` for your server like your console applications
  - That's because MVC is designed to run as a _plugin_ to a web server; it's not the entire server by itself
  - The server has two jobs
    1. "Run" the program; this includes networking, ports, host headers, server permissions, etc
    2. Basic "server" functionality; selecting the correct site (if multiple sites exist), serving files, basic auth, etc
  - **IMPORTANT** - The server has first go at all requests; the server might decide to _handle the request by itself_ and never call your code;
  - This can cause deploy bugs
    - Your code works fine in Visual Studio
    - BUT... when you deploy it doesn't
    - AND you don't get good error messages
  - In this calss we'll use IIS (Internet Information Services); Microsoft's web server (part of Windows Server);
  - NB: when you run from Visual Studio directly, it uses a small version of IIS called IIS Express;

- Request lifecycle - How MVC "runs" on your server
  1. IIS receives an HTTP request
  2. IIS checks the domain name against registered host headers to choose which site should handle the request
  3. IIS tries to handle the request directly by serving a file or sending an auth response
  4. If IIS cannot handle the request, it passes off to MVC

  - That means direct file requests - ie index.html - are handled by IIS
  - Action methods are eventually passed off to MVC

- In Class Demo - IIS
  - Adding IIS to Windows Home - for development practice _only_
    1. appwiz.cpl
    2. Turn Windows Features on or off
    3. Internet Information Services | World Wide Web Services | Check All
    4. services.msc - don't leave IIS running all the time
  - Adding Sites / Applications
  - App Pools
  - Choosing the .NET version

- Handling _everything_ in MVC
  - If you're handling static file requests in MVC, you need to _disable_ IIS's handler
  - <modules runAllManagedModulesForAllRequests="true" />
  - This is probably one of the most confusing and misused aspects of ASP.NET
  - https://weblog.west-wind.com/posts/2012/Oct/25/Caveats-with-the-runAllManagedModulesForAllRequests-in-IIS-78

- Deploy Files
  - Compiled Assemblies
    - Contains all your C# code for action methods, routing, config, etc.  _does not include_ C# Razor files;
    - bin = "binaries"; ie files which can be executed by a computer;
    - obj; partially compiled program files;
  - pdb and xml
    - All your projects generate 3 files: ProjectName.dll, ProjectName.xml, and ProjectName.pdb
    - The .dll is the actual code; you _could_ deploy just this if you want
    - The .pdb has debugging "symbols" to let a debugger attach to the code; don't normally need to deploy
    - The .xml has deploy info; it's generally not needed
  - Web.config and Global.asax - how the server should run your app; you must deploy this file;
  - MVC views - Razor view files (.cshtml) are _not_ pre compiled like the rest of your code; you must deploy the actualy .cshtml files;
  - Static files- Any static HTML / CSS / JS resource files you have; this may or may not be part of your app;
  - App auto "refereshes" when you update a global config file or a binary;

- 3rd Party Assemblies
  - GAC - Where "global" assemblies are stored; not every computer has the same GAC assemblies;
  - bin deploy - You can include _any_ assembly in the bin; this supersedes the GAC;
  - Nuget - Servers can be set to automatically install all packages from your nuget packages.config file
  - Multiple versions - assembly redirects
    - A reference to an assembly _includes_ the version number of the assembly
    - Providing an assembly with the wrong version number will cause a binding failure
    - Binding redirect - use code written for different versions of an assembly together in one project
  - Strong names
    - Fully qualified name - Assembly name
    - Public Key Token
    - Version Number

- In Class Demo
  - Binding redirect
  - Setting assembly for bin deploy

- Deployment Types
  - 1 Click via IIS integration
  - FTP
  - Local Network
  - Manual

- In Class Demo - 1 Click Deploy to "Local IIS"