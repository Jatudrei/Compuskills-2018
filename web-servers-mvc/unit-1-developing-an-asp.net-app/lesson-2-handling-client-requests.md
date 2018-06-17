**Learning Objectives**
=======================
- Understand what information is included in an HTTP request and how to access it in MVC
- Connect MVC with a database to load information based on the user request
- Intro to stateless applictations and HTTP "sessions"

**Outline**
===========
- "Stateless" development
  - Every request that comes in to a web server is _independent_ of what came before and what will come after
  - Unlike a traditional C# or angular program, you cannot "set" a local variable in one request and access in the next one; it gets deleted!
  - This makes sense - you might have many people accessing the server at the same time; the requests come in a random order, so you must recheck who's who on every request.
  - In a later lesson we'll learn how to use cookies and sessions to compensate for stateless dev.
- In Class Demo - Data gets "lost" if local and "overwritten" if static
- HTTP Request Breakdown
  - NB: This is an overview; you do not need to be an expert in each of these parts; you just need familiarity in what they are for; we'll deal with each of these in more as we use them in later lessons.

  - **Headers** - Metadata about the request; these are automatically managed by the browser and included with every request;

  - **Querystring** - Parameters supplied by the user directly in the URL; for example on google.com, using google.com/?s=term will run a search for the word 'term'.

  - **Form Data / Body** - Data supplied by the user.  The body normally contains one of three things
    1. Key / value pairs with user parameters
    2. A JSON object with user parameters
    3. Raw binary file data for uploading files

  - **HTTP Method / Verb** - GET, POST, etc; what do you want to do with the resource you're requesting.

  - **Cookies** - Key/value pairs with user information that is stored for _more than one request_.  These are per client; The server asks the client to store information in a response and the client sends in back in subsequent requests. _Careful_ not to mix up request and response cookies.
  NB: Cookies are technically a type of header

  - **Authentication / Authorization** - Who is making the request?  Are they allowed to do it?
  NB: Auth can either be a type of header or a cookie
- In Class Demo - Using Fiddler to examine requests / responses
- Request Data => Action Method Parameters
  - MVC makes it easy to access request data by converting it into C# DTO's with strongly typed names and properties
  - For querystring data - just add a parameter to your action method with the same name as the querystring value
  - For form data - create a model where every property name corresponds to a name from the form data
  - For route data - add a paremter to the action method with the same name as the route parameter name
  - Auth data is automatically parsed and added to the User property
  - Cookies are automatically parsed and added to the Request.Cookies
- In Class Demo - Binding data for querystring and form and common errors (e.g. wrong data type)
- Doing something with the data
  - A typical ASP.NET endpoint looks like this:
  http://mysite.com/Entity/Details/32

  - Entity is the name of some entity in your DB;
  Details means you want to view the details of the entity
  32 is the id number of the entity (PK)
  - Use model binding to get get the value of the PK, look it up in the DB, then send back a view with the data
- In Class Demo - Simple read only views of DB data