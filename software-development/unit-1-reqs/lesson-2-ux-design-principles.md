**Learning Objectives**
=======================
- Understand how to create interfaces centered on the user _experience_ and not the data
- Learn to effectively use affordances and signifiers in your design; learn to avoid "false signifiers"
- Learn the basics of UI wireframing / mockups

**Outline**
===========
- Paradigm: User Interface
  - Early programmers designed software around the math and science the software performed
  - Computers are great at storing large amounts of random data and arbitrarily computing it together
  - Humans are terrible at storing and computing that same data!
  - At the time we considered the problem to be fundamentally on the _human_ side; ie - people were deficient because they couldn't think like a computer
  - The solution was to design _interfaces_ for humans to interact with machines
  - In this paradigm, people treated computers as infallible / perfect
  Most problems were blamed on user error; the user didn't use the software the way they were supposed to!
- Failure of the paradigm - the mental model
  - People don't come to software as a "clean slate"; we come with subconcious preconceptions about how the software works
  - For example, we expect clicking on something to select that item; we expect dragging something to move it;
  - The way a user expects your program to work is called the "mental model" or "user model"; users will always make decisions based on the mental model _even if it's wrong_
  - The way your program actually works is called the "conceptual model" or "program model";
  - _If the mental model doesn't match the conceptual model, the user **will** "misuse" the program!_
- Expected Degree of Complexity / Difficulty
  - People have subconcious feelings about how complex and/or difficult different tasks _should_ be
  - We expect the controls on a device to have the _same complexity_ as the task it performs
  - Consider a simple task - turning on the lights
    - We expect a quick switch flip
    - What if it requires multiple switches?  Or there's a "master circuit breakder" you need to turn on first?  Or a separate circuit for that part of the building?
- Fatal Example of Mental / Conceptual Model Clash - Iran Air Flight 655
  - (see http://xenon.stanford.edu/~lswartz/vincennes.pdf)
  - A civilian airliner was shot down by a US cruiser after misidentifying the flight as an enemy figher jet on an attack run.  290 people were killed in the explosion.
  - Part of the problem was the radar UI;
  The radar required the operator to _separately_ update the aircraft they were tracking onscreen and the aircraft they were listening to;
  There was no indication in the UI if these were set to different aircraft;
  - There was also a problem with the flight profile sensors (speed, altitude, etc)
  The sensors only showed instantaneous data, not changes
  Mental math mistakes were easy to make under the pressure of combat
  - To make things worse - people trusted the computer as a "single source of truth" against their own judgement;
  - Another US ship in the area correctly identified the aircraft as civilian but defered tot he Vincennes because it had the superior radar system
- _Figure Out The Mental Model!_
  - As a software designer, you must always try to identify a users mental model and design your product to match it
  - This does not mean becoming an expert in graphic design!
  - A _usability bug_ occurs when you're product behaves as designed but not as expected; that normally means you broke the mental model;
  - Design to match the the users expectations; don't try to change them
- The pshychology of design
  - Error messages: Anxiety response; "just make it go away!"
  - Why/how do users make decisions
  - There's an entire industry built around this
- Affordances
  - An "affordance" is something your device allows the user to do
  - Ie - a mouse affords clicking, moving, and scrolling; a door handle affords pulling, twisting, pushing, pushing a key in;
  - Affordances aren't always easy to spot; this is the "what can it do"
  - In a UI, affordances might be double clicking for more information, mousing over, or right clicking
- Signifiers
  - Artificially "highlight" an affordance to a user
  - Example: glass doors have a handle to signify where you should push
  - If you have too many, it just becomes noise
  - One option: use "just in time" signifiers which show up just as the user might want to use them
- "False" Signifiers
  - Happens when your product _appears_ to afford something that it does not
  - Toshiba laptop example
    - Text "Toshiba" is positioned in bottom corner
    - Gray strip looks like part of a hinge
  - Norman Doors - whole collection of doors that are hard to open; literally; in the his book, he actually has a story of someone getting trapped in an antechamber because he couldn't figure out how to open either door;
- Discoverability
  - Can a user identify what actions are possible; ie - can a user "see" the affordances
  - Two types of actions - this is relevant in all products; particularly in software
    1. Always Available - Links, scrolling, close window, menus, etc;
    2. Context - Show up _as needed_ in a given context - right click menus, hover menus, etc
  - You need to consider discoverability for both; how do you make sure a user realizes a hover action exists on an item?
  - You also need to make sure the user _understands_ what the signifier / feature does
  - Catch-22
    - If your signifier becomes _invasive_ it will distract users and drive them away from your app;
    - If you have no signifier noone knows the power of your features and they don't use your app;
- Hallway Usability Testing
- Classic design example: Mobile vs Computer
  - These are two fundamentally different devices; you should treat them that way
  - Consider scrolling the screen; this is a difference in the mental model
  - Mobile device
    - You "hold" the device directly
    - "Touch" the documents on the screen
    - In other words, you feel like you're interacting directly with a mobile app
    - So when you move your finger up on a mobile, you expect to move the "paper" up and end up going down
  - Computer
    - Use a keyboard/mouse combo with the device; it's detached
    - Even on the screen, always interact with the chrome (scrollbars, menus, etc), not the document; again, detached;
    - You feel like your looking through a window at the content
    - So when you move the scrollbar, your moving the window, you expect to go the same direction you move
- In Class Demo - Design "Kosher Near Me" Search Page
  - What's the main point of the page?  (Hide other options by default)
  - What kind of input?  (Combo box, free text, auto complete, table?)
  - Can we use ranges?  Button bars?