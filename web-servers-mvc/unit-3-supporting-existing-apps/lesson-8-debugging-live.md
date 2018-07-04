**Learning Objectives**
=======================
- Overview of the difficulties with troubleshooting and debugging a live system
- Techniques to get the best information possible about "bugs" (both technical and social)

**Outline**
===========
- Debugging Live
  - Attach directly to IIS
    - w3wp.exe
    - `%systemroot%\system32\inetsrv\` folder - appcmd list wp
    - What is "code optimization"
  - "Recreate" the problem in a debug environment
  - Debugging steps - 1. repro case, 2. identify, 3. fix
  - Attach to remote IIS
    - On some servers you can attach to remote IIS; generally not for shared hosts
    - Must enable remote debugging: see [MSDN](https://msdn.microsoft.com/en-us/library/mt621540.aspx)
- In Class Demo - Attaching to Running IIS
- "Real" Bugs
  - Happen at unpredictable times
  - Almost unlimited number of factors to consider
    1. What OS / browers was the client using
    2. What other programs do they have installed
    3. Were they properly logged in
    4. Was the data they sent valid
    5. Was their internet working properly (filters can cause trouble with this)
    6. Were all the server features running properly (sometimes its a temporary outage)
    7. ...
  - End users _will not_ be able to provide all this information
    - A lot of it is too technical for them to know how to look up
    - They don't realize they should bother to look it up
    - Error message anxiety causes them to ignore any useful information you try to show them
- Error Logging
  - The goal of a _log_ is to preseve as much of that contextual information as possible
  - Logs should be automatic; as we said above, you cannot expect an end user to get you the data
  - Rule of thumb - Keep all contextual information in the log you would need to reproduce the environment the error occured in
- Sidebar - When to check logs
  - Reactive - when a user reports an error you find the corresponding crash dump in the logs
  - Proactive - regularly review the logs and fix errors before end users notice them
- Exceptions
  - An exception means something that _you had not anticipated_ happened in the program
  - This _does not_ apply to a problem that prevents your program from continuing but that you could _anticipate_
  - This is an important distinction to recognize; _many many_ programmers misuse exceptions for unexceptional behavior
  - Examples of misused exceptions
    - when the user types data in the wrong format...
    - when the user forgets to plug in their USB stick...
    - when there's no internet connection...
    - when the user doesn't have permission to do what they tried to...
  - The .NET Core Libraries have misleading exceptions
    - `FormatException` is thrown when you use int.Parse, DateTime.Parse, etc with invalid data
    - `IndexOutOfRangeException` is thrown when you try to access an array element that is "too high" or "too low"	
    - `ArgumentException` is thrown on _many_ core library methods if you pass an invalid argument
    - Countless more under `System.SystemException`
- Provider / consumer paradigm
  - .NET core library methods are designed for programmers; they put the burden of correct use on the programmer
  - In other words, they _provide_ only to other programs, never to end users
  - Reasons why we don't anticipate programmers misusing an API
    1. There's a strong _professional_ obligation to read the docs for any API you use
    2. The API cannot interact with the end user directly anyway
    3. A program is only written once
  - Always base your exceptions on your anticipated consumer
  - Rule of thumb - You should never intentionally use an exception in end user facing code
- MVC exception handling
  - A _handler_ is a block of code designed to handle an unanticipated exception
  - The goal is to fail _gracefully_;  this includes
    1. Log the contextual information
    2. Notify the bug fixing team
    3. Notify the end user including _general instructions_ of what they can try (eg try again, reboot, login and out, etc)
  - A handler is where you should put error logging code
  - Order of potential handlers
    1. try / catch block
    2. Action filter (including `HandleErrorAttribute` from below)
    3. Global action filter (Startup.cs or Global.asax)
    4. <customErrors> error action / view
    5. Controller OnException event
    6. Application OnError event
  - NB: Additional options with OWIN
    7. IExceptionHandler - global service
    8. OWIN middleware
- try / catch
  - When you work with an API that you _anticipate_ might throw an exception
  - Handle the exception and return _specific instructions_ to the end user
  eg "You must provide a username"
- `<customErrors>`
  - Should the end user see the actual _raw error data_ (exception name, stack trace, etc) or a "custom" error
  - On = show custom errors to client
  - RemoteOnly = show custom if client is running on server computer
  - Off = show raw error data
  - You can specify redirect pages divided by HTTP status code to provide somewhat more specific information
- In Class Demo - Setting up customErrors for 404 (not found), 408 (timeout), 500 (general server error), 502 (downstream error)
  - ErrorController
  - Setting the status code - NB: by default it's 200
- Action filters / global
  - Added with `[Attribute]` to individual actions
  - Built in HandleErrorAttribute let's you specify an exception type and view to show
  - Custom action filters are very flexible; override OnException
  - Can also create a global filter to use the same filter on all actions; good global error handling
- In Class Demo - Exception filter for SqlException's
- Sidebar - What to log in MVC
  - You want to be able to _reproduce_ the client problem request, so you should know everything about it
  - Form data
  - Querystring
  - Headers
  - URI
  - Session info - eg user claims
- In Class Demo - Simple text based log with action filter
- Bug trackers
  - Common for software projects; organize bugs by milestone / sprint, person working on it, related bugs, commits, etc
  - Ex: github issues, jira, pivotal tracker, etc
  - Most trackers support opening new bug reports from remote logging tools
- NB: Automated error logging
  - Log4Net
  - ELMAH