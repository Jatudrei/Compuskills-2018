**Learning Objectives**
=====================
- Convert concept / requirements into a functional spec / user stories for your program
- Break each feature / story down into the actual work you'll need to do
- Cross the barrier from conceptual design into program architecture

**Outline**
===========
- Requirements vs Architecture
  - Two distinct phases to software design;
  - Requirements asks WHAT does the program do
    - Includes overall concept (Developing Ideas) and UI
    - Generally finishes wih a thorough requirements document that defines _absolute_ parameters for how the product wil work
  - Architecture asks HOW will the program do it
    - How will we divide the _responsibilities_ into different components in the program
    - What classes will we need?  Will they interact?
    - Are there any specific patterns we should use?  Libraries? Etc.

- The traditional development process (the Waterfall)
  1. Requirements; we covered this in the "Developing Ideas" unit of this class; define WHAT you intend to do.
  2. Design / Architecture; we're covering this in the "Design Principles" and "Well Known Patterns" units; HOW the program will do it;
  3. Implementation; write the actual code as per the design docs; you learned the tools to do this in the Programming Fundamentals, HTML 5 Web Apps, and MVC courses.
  4. Verification; check that the program meets the requirements from stage 1;
  5. Maintenance; fix any bugs or other support issues;

  - This is called waterfall b/c it's "one way" traffic. You finish a stage completely and then "fall" into the next stage.
  ![Waterfall Diagram](https://upload.wikimedia.org/wikipedia/commons/thumb/e/e2/Waterfall_model.svg/800px-Waterfall_model.svg.png)
  (From [Wikimedia Commons](https://en.wikipedia.org/wiki/File:Waterfall_model.svg));

- The "new" iterative process (Agile)
  - Waterfall drawbacks
    - NO USER FEEDBACK LOOP
    - "Feature inventory"
    - Difficult to handle changes in requirements
    - Bad management structure (top-down); coders felt taks were imposed on them with little context;
  - Agile was designed to address these problems
    - Feedback loop
      - Keep users (stakeholders) inolved at every step
      - _Iterate_ over all the steps; there's never  a "final" requirements doc
      - Expect constant change and growth as the product matures
    - Feature inventory
      - Release features as soon as they're useful
      - Create small MVP type features immediately and _expand them according to feedback_
      - Don't be afraid to completely redesign / reimplement features if needed
    - Changes in reqs - built in to agile
    - Management structure
      - Let programmers choose which parts they want to work on;
      - Management becomes about solving problems and keeping the team cohesive

- The Functional Spec
  - Written document describing every feature in detail
  - Includes instructions for every button, page, label, etc; how does it update? when? etc
  - In waterfall model, this is the "final requirements" doc with absolute definitions for every component

- An "Agile Spec"?
  - Absolutely defined requirement seems to be the antithesis of agile... so how can we have a spec?
  - Misunderstanding because "Functional Spec" really covered two concepts
    1. Written statement of what we _intend to develop_
    2. _Limitation_ on what we're allowed to develop; in other words, rules;
  - Agile rejects the limitation aspect of a functional spec; good design demands we keep the first one!
  - Whatever you call it, you definitely need a statement of intent to guide your work;
  - Think back to the Problem Statement in our early lessons; if I don't know what I'm doing, I cannot do it!

- The User Story
  - Easy way to describe a program requirement from user perspective
  - Limitations come from the _user_
  - Helps keep developer focus on how to best support user needs; encourages innovation when needed
  - Locked down in terms of the goal; flexible for innovation in meeting that goal;

- Story Writing Tips
  - Use first person; it's easier to relate to something a "real" person says about a feature;
  - Include _who_ will use the feature, _what_ they do, and _why_ they do it
  - You can use the following as a template
    "As a ____________ I can ____________ so that __________"
  - Consider
    - Email follow up reminders
    - As an employee I receive an e-mail every morning with a list of follow up phone calls to make so that I can find an appropriate time in my day for each call

- "Epic" Stories
  - In Agile, an epic describes an entire section of functionality in an app;
  - Eg a "user management epic" might say: As the company owner, I can add usernames for new employees, remove old employees, and reassign roles between existing employees.  I can reset their passwords (if needed), unlock accounts, disable accounts, and generally control access to the system.
   - Create epics with stories inside; even stories can have sub stories if they're too complex

- Non "user" stories
  - There will always be aspects of a system that are not _directly_ focused on the user
  - For example, a technical requirement to use a particual DB because the customer already has it
  - Or a requirement to use certain regional formatting
  - You can frame these as stories about _the person setting the constraint_
  - Ie
    - As the owner of GreatSoftwareDevelopers.Com, I expect you to include at least 20 references to our website in the product so I don't have to pay for 3rd party advertising
    - As a company in Portugal, I need to see all dates in the standard international format and all labels in Portuguese.

- Issue Trackers
  - Traditional functional specs are nicely formatted word docs;
  - Agile user stories generally live in "issue trackers"
  - You can add comments to issue trackers to track progress or collaborate within the team
  - Support statuses and other filters
  - Integrated with your DVCS - use #issue number to associate a commit with an issue

- How far to design the requirements
  - Old waterfall standard - BDUF - **B**ig **D**esign **U**p **F**ront
  - Agile counter - YAGNI - You ain't going to need it
  - Until the user feedback loop tells you otherwise, don't assume any BDUF is needed; design for what you need now;
  - **IMPORTANT** - Don't confuse YAGNI with vague requirements
  - You must still clearly define what you already _know_ you plan to do
  - YAGNI only says don't commit to things you _might_ do before you need to
  - Rules of thumb
    - If you can't estimate how long a task will take, you don't know what needs to be done
    - If you can't conceptualize how to implement a task, you don't know what needs to be done
    - If you say "something like" in your description, you don't know what needs to be done
    - If you haven't done everything on your list before, you don't know what needs to be done
  - (NB: this all goes on your spec / user story)

- In Class Demo - Capstone Project Story
  - Write a story for our capstone project
  - Add it to our GitHub repo's issue tracker
  - Write some sample code for it and commit w/ the issue #
  - Push and view the results

- Requirements / Architecture Barrier
  - As we said before: requirements are WHAT a program will do; architecture is HOW it will do that;
  - Classic OO misstep - modeling your program after your requirements directly
  - You will have some parallels between your requirements and your architecture, but you should not expect them to be the same
  - Architecture focuses on encapsulation and behaviors; these often _do not_ reflect UI

- Decomposition / Factoring
  - Official name for breaking requirements up into code
  - There are many formal methods for this process; we're only going to focus on the goals and techniques
  - The goal is to simplify a complex problem so it's easier to program and maintain
  - This is an iterative process; you can start with procedural code and slowly iterate to well designed classes if you need;

- Sidebar - Programming Paradigms
  - You've heard the terms "Object Oriented" and "Procedural" several times in this class
  - (you may also have heard of "Functional")
  - These are called paradigms; a paradigm describes "how the world works"; it's the assumptions we make and what we expect to happen;
  - Paradigms you'll encounter

| Name | Builds on... | We assume... | We expect to _encapsulate_...|
|---|---|---|---|
|**Structured**|_All_ modern programming languages are structured|Every behavior can be rerpesented with a predefined "control structure" like if / else / while / for.|None|
|**Procedural**|Structured by adding reusable procedures|Data is stored in primitives or structures and _manipulated_ in common ways by procedures|Encapsulate behavior into a procedure with static input / output|
|**Functional**|Introduces "pure functions" to procedural code|Objects are immutable; Functions have no side effects; No such thing as "state";|Basically same as procedural|
|**Object-Oriented**|Procedural by orgranizing into "objects"|Objects contain current state;No "global methods" b/c object manage themselvs;|Behaviors that work with the same data belong in the same class; Two stages to encapsulation;|

  - Side affect of paradigms - in "no paradigm" programming, your program starts on line 1 and just runs; as you introduce paradigms, you need to define "entry points" that match the paradigm; e.g. the Main() function in a procedural program or the [STAThread] / Main() method in OO code;

- General Guiding Principle #1 - _Encapsulation_
  - You've heard this word a lot; you'll hear it a lot more
  - Encapsulation means creating putting _all_ the code for a given behavior in one place only;
  - You can then _consume_ that code from other parts of the program
  - Encapsulation enables us to change the behavior in one place and it will affect everywhere
  - Also allows us to redefine the internal behavior of our method without affecting everywhere
  - As a rule we encapsulate "knowledge"; knowledge doesn't mean facts here; it means the HOW as opposed to the WHAT

- General Guiding Principle #2 - _Interfaces_ / _Contracts_
  - Define how a list of methods a _consumer_ can use to interact with your class
  - This is the interface; it acts as an implicit contract between the class and the consumer; if you call these methods you get these results
  - The contract _does not_ include any rules about how the we do it; just what we do;
  - C# interfaces allow you to formally define the contract within your code directly;
    - There's no method bodies or property values b/c those aren't part of the contract!
    - JUST the method names / params, and properties
    - A class implements those interface properties _in any it wants_

- Practical Encapsulation in OO
  - NB: Many of the principles we'll work on in later lessons deal with encapsulation
  1. Identify _behaviors_ in your requirements that you need to implement
  2. _Group_ those behaviors based on the type of data their working on; these groups will be your classes
  3. Within each class, identify specific _actions_ that make up each behavior; these actions will be your methods
  - Helpful guideline to remember: _behavior_ belongs in classes / methods; _data_ belongs in properties or DTOs;

- In Class Demo - Capstone Project Architecture
  - We'll decompose the user story we wrote earlier
  - Demo possible "missteps" (procedural, direct modeling)
  - Iterative process w/ encapusaltion and interfaces