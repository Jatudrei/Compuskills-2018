Decomposition example

Behaviors
=========
1. Typing - Read input
  1. Show an input box
  2. Store the input
2. Accept instruction to search ("Search Button")
  1. Show a button
  2. Handle the button being clicked
3. Send HTTP request to server with query
  1. Send HTTP request to server
  2. Receive incoming HTTP request
4. Query the data
  1. Build a SQL query
  2. Execute the query
    1. Make a connection to the database
5. Identify stores to suggest based on settings
  1. Read the settings for this shopper
  2. Algorithm to assign weights to different settings
  3. Sort the results by weight
6. Return formatted data
7. Show data on the screen
  1. Update the DOM
  2. OR update the model

Server
======
- Receive HTTP request: ASP.NET does this
  - Action method: GetSuggestions(string itemName);
  - AND MVC will provide a User property
  - var settings = Query the settings for this user
  - GetSuggestions(itemName, settings)
  - Return View(suggestions)
  - GetSettings(string username)
  - GetSuggestions(string itemName, SuggestionRatings ratings)
    - Build a SQL query - BuildSuggestionQuery(string itemName, SuggestionRating ratings)
    - Execute query
    - ProcessSuggestions(SuggestionResult result)
- Classes
  - SuggestionController.GetSuggestions
  - SuggestionService
    - GetSuggestions(itemName, ratings)
    - private BuildSuggestionQuery
    - private ProcessSuggestions
  - UserService / ProfileService / SettingsService
    - GetSettings(username)

Client
======
- HTML Form
- Event handler: SubmitButton_Click
  - HTTP requests, but I can rely on jQuery or angular for this
  - HTTP response, function to update the view