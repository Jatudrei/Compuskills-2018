**Learning Objectives**
=======================
- DRY out your views (reuse content) with Layouts and Partials
- Use AJAX page updates with partial views to create an SPA effect
- Client side validation in an MVC app

**Outline**
===========
- "Layered" Views
  - MVC uses three "layers" of views
  - The named view for an action is the "primary" view;
  - This is optionally inserted into a Layout; a common view with the structure of the overall site in it;
  (you can define the default layout in a _ViewStart file)
  - You can also optionally include partial views; small sections of views to insert
- RenderSection / RenderBody
  - A "section" is defined by the child view; allows adding full blocks of code to layout
  - RenderPartial to add extra DRY elements (topbars, menus, etc)
- In Class Demo - Changing the Layout
- Bundles and minification
  - For separation of concerns and LIFT we want to keep all our application source in independent files
  - That means listing out each file with it's own <script> or <link> to load it to our page
    - Error prone - we could forget a reference
    - Bad design; Forces the developer to update the Layout file whenever they add a new resource
    - Results in the browser loading every resource independently - that slows things down (6 connection limit)
  - Bundles: automatically combine multiple source files into a single output file;
  - Minification: automatically remove "unneeded" parts of your source code (like whitespace and long variable names)
  - MVC automatically handles bundles and minifaction
    - App_Start.BundlesConfig
    - Wildcard file matches w/ *
    - The {version} placeholder
      - Auto use highest version number
      - Auto use min/full version based on release/debug
    - Minification happens based on build mode (Release / Debug)
    - Auto handles updating cache when you change the source files
  - "Advanced" - NB: you do not need to know these for class; they are for reference only
    - Bundle transformations - use to "process" your scripts before publishing
    - Great for preprocessors like scss, less, CoffeeScript, TypeScript, etc
- Caching
  - Browsers make things appear faster by saving files they don't expect to change (called a "cache")
  - As a rule - GET requests can be safely cached unless the server says otherwise;
- CDNs
  - "High speed" for static files (like script and style libraries)
  - More likely to hit a cache b/c multiple sites use it (for libraries that never change, this is good)
  - With a CDN, you should write fallback code in case the CDN doesn't work
onerror
  check for "success"
- In Class Demo - Create an angular bundle including UI router and UI router extras
  - See cache type in Chrome Dev Tools
  - See how bundles load in the browser
- Partial Views 
  - Similar to angular templates, but using Razor/C#
  - Biggest difference - does not use the _ViewStart or Layout files - just the HTML in the view
  - Used to generate HTML _pre filled_ with data
  - In an app with an MVVM front end (like angular), you get raw _data_ (generally JSON) and create the HTML from the data
  - In MVC, you get pre-formatted HTML which you just append to the page.
- AJAX in MVC
  - You can use all the standard $.ajax methods in MVC; make sure to use the @section scripts { } syntax so the script goes to the end of the page
  - Use @Html.IdFor(x => x.Property) to get the correct ID on the page of model elements
- Ajax View Helpers
  - @Ajax.BeginForm - creates a standard HTML form but submits the data in the background without reloading the page
  - @Ajax.ActionLink - downloads the contents of the action without reloading the page
  - Make sure to include jqueryunobtrusive
- In Class Demo - Category with "load next 10 products"
- Client side validation
  - jquery.validation.unobtrusive.js
  - Automatic as long as you include the scripts