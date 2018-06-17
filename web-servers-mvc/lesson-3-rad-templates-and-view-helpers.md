**Learning Objectives**
=======================
- Use Visual Studio's RAD tools to generate all the views and actions you need for basic CRUD
- Explore view templates with layouts, partials, and view helpers

**Outline**
===========
- RAD - Rapid Application Development
  - "Boilerplate" code refers to code you need to make your app work _but_ it's 90% the same for every app you'll ever work on
  - This includes DbContext's, basic CRUD actions for every DB entity, routing, standard config, etc
  - In VS, we can use _scaffolding_ to automatically write most of the boilerplate code we'll use in an app
  - A VS _scaffold_ works similar to an angular template with model binding; the difference is in VS, the "model" is your entity classes
  - For every property of your model, VS creates a matching section on the view
- In Class Demo - Add A "Details" View
- Scaffold Types
  - Project scaffold - We've used many different project templates already; VS automatically creates a project with the correct compilation settings and adds many default files and folders
  - Item scaffold  - VS creates a skeleton of the file and optionally adds sections based on your models
  - Code template / code snippet - VS write a section of code for you;
  - NuGet template - These automatically rewrite parts of your code to work with the lib you install
- The MVC RAD Workflow
  - Create your model classes; generally this is in a separate DB project;
  - Use the MVC / EF controller template to generate a controller pre-filled with all the correct CRUD actions
  - For each action, use the correct MVC view template to pre-fill a view
- In Class Demo - "Fully Automated RAD" (ctrl, models, and views)
- View Helpers
  - You've seen @Html and @Url peppered around MVC views
  - These are "view helpers"; they're special methods you use to generate an appropriate HTML block _based on your model_
  - For example, @Html.EditorFor(x => x.Property) will select the appropriate HTML input element for the property type; a date picker for a DateTime, a checkbox for a bool, etc
  - Two reasons to use helpers
    1. As you change your model and config your view changes automatically
    2. DRY. Change your model and all related views are instantly updated.
- Helper Types
  - @Html - generate HTML snippets based on the model and MVC app config
  - @Url - generate URL's (links) based on the controller, action, and other routing rules
- Common Helpers
  - Html.ActionLink - Create an <a> that targets an action method instead of a URL
  - Html.DisplayNameFor - Get the name of a property to show on the screen
  - Html.Label - SAME as display name but generates an HTML label instead of text.  Use in a form.
  - Html.DisplayFor - Shows the value formatted by type
  - Html.EditorFor - Shows an appropriate HTML input field with the value
  - Html.BeginForm - Creates an HTML form pointing at the right action
- Model Attributes
  - Cange view helper behavior with model attributes
  - [Display(Name = "display name")]
  - [UIHint("editor name")]
- NB: Custom HTML Helpers
  - You can create your own HTML helpers by adding extensions to the HtmlHelper class
  - Many libraries create custom helpers using this; eg Kendo MVC helpers
- Using MVC Editor and Display templates
  - MVC has a rich set of templates to create custom editors _based on model type_
  - Add a template for display / editing to the /Views/Shared/EditorTemplates or /Views/Shared/DisplayTemplates folder and MVC will match it based on type
  - [UIHint] can be used for a fully custom editor
  - These editors are normal Razor views just targeted at a single model property
- In Class Demo - Using a date chooser for date type