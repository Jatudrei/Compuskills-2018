**ASP.NET**
=============================
A "server" is a special program that can distribute your app to users around the world via the internet.  While early servers sent static HTML, CSS, and JS files that ran your entire app, modern servers also have to manage databases, 3rd party service integrations, networks, file storage, etc.  As a result, developing software to manage all the aspects of a modern server is extremely difficult!

That's where ASP.NET comes in.  ASP.NET is a special server framework that lets you run a named C# method in response to an incoming request.  The framework's main jobs are

1. Most important: to map every incoming request to a C# method (routing)
2. Figure out who is making a request (authenticate) and if they should be allowed to do it (authorize)
3. Create C# DTO's to represent incoming request data (model binding)
4. Support HTML page generation with templates and data integration (view engine)
5. Handle any errors gracefully and tell the client what happened

**Units in this Course**
===========
1. [Unit 1 - Developing an ASP.NET App](unit-1-developing-an-asp.net-app)
2. [Unit 2 - Deploying and Staging](lesson-2-handling-client-requests.md)
3. [Unit 3 - Suporting Existing Apps](lesson-3-rad-templates-and-view-helpers.md)
4. [Unit 4 - ASP.NET and other Tech](lesson-4-partial-views-and-ajax.md)