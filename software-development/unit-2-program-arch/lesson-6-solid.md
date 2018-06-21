**Learning Objectives**
=======================
- Learn the SOLID program architecture principles including
- Analyze several sample designs using SOLID and identify design flaws

**Outline**
===========
- What is SOLID
  - Generally accepted as the "most important" 5 principles of class design
  - Developed by Robert Martin ("Uncle Bob")
  - You should consider SOLID while you _develop_ your classes and when you _analyze_ your design
  - All our principles so far have been general guidance;
  - The SOLID principles all describe specific characteristics of good design
  - NB: The technical definition of most of the SOLID principles is complex and academic; we'll explain what they mean in detail;
- Just for fun - counter acronym is STUPID
  - **S**ingleton, **T**ightly coupled, **U**ntestable, **P**remature optimization, **I**ndescriptive naming, **D**uplication
- **S** - SRP - Single Responsibility Principle
  - "A class should have only a single responsiblity" - Uncle Bob
  - Your program is _responsible_ to fulfill certain requirements; requirements come from different types of people or _roles_ (also called _actors_)
  - Example roles
    - The DB administrator
    - The financial analyst
    - The accountant
    - HR
  - SRP says each class should be responsible to only one role;
  - Two other ways to think about it
    1. Only one role should be able to "tell" a class to change
    2. A change in requirements from any role should only affect classes responsible to that role
  - _Identify_ responsibilities in a class by thinking about reasons the class might change; every reason is probably a _different_ responsibility
- SRP vs Cohesion
  - SRP often leads to high cohesion because a single _role_ normally has related behaviors
  - (the opposite is also true)
  - But they are not the same!
  - SRP focuses on what roles your code is responsible to;  A single role might care about many non-cohesive parts of your code;
  - Cohesion focuses on how the behaviors related to each other;
  - [Great article](https://stackoverflow.com/questions/11215141/is-high-cohesion-a-synonym-for-the-single-responsibility-principle) with more explanation
- SRP in long-lived projects
  - The longer you work on a single project, the more likely you are to break SRP
  - A class is originally designed around a _single_ goal; automatically meets SRP
  - As the system requirements grow, you add more and more _behaviors_ to the class
  - If those behaviors are for different resonsibilities, you break SRP!
  - Common problem for classes to evolve into "all-powerful control everthing" classes
  - You _must_ consider SRP with every change you make to a class
- Naming classes / methods
  - Naming things is hard - possibly one of the harder parts of software development
  - A name has to be 
    - Recognizable - a consumer must understand from the name what the class / method does
    - Accurate - you can't use a name differently than I expect; eg you can't use GetItem() to create a _new_ item
    - Short - when names get too long, you can't understand them
    - Memorable - Interfaces are huge; the consumer needs to be able to find the right class / method
  - Good names are a great way to help prevent SRP violations
  - Interesting read on names by [Jon Skeet](https://codeblog.jonskeet.uk/2009/02/27/what-s-in-a-name/)
- Refactoring
  - If you discover an extra responsibility in a class - refactor
  - Break it up into two or more classes and have one consume the other
- In Class SRP Demos
  - DataClient analysis (breaks SRP from the start)
  - HttpRequestHandler analysis (grew to the point it breaks SRP)
- **O** - OCP - Open Closed Principle
  - "A component (class, module, etc) should be open for _extension_ and closed for _modification" - Uncle Bob
  - _Modfication_ means you need to actually rewrite the code in your method to change / add behavior;
  - Any time you rewrite code, you open yourself up to possible regression bugs
  - (in particular in unrelated parts of the system that also rely on the code your rewriting)
  - OCP says you should initially write the code in a way that
    1. Anticipates what types of _extension_ will happen
    2. Enables that _extension_ without requiring rewrites of the initial code
- For example - consider an algorithm to validates a registration form
  - Algorithm
    1. Check the first / last name are filled out and no invalid chars
    2. Check the birth date is filled out and a valid date
    3. If younger than 13, check the parental consent form is attached
    4. Check the mailing address is in the service area
  - That entire algorithm could be in a single method; it doesn't break any principle we've learned so far...
  - If the requirements change - eg now you need to use a CAPTCHA before allowing registration - you need to rewrite the validateForm() method!
  - OCP says you should have designed the method initially to make adding validation steps (_extending_) possible without rewriting the code
- Practical OCP implementation
  - You'll generally use interfaces and collections to implement OCP
  - Store a list of actions in your class; allow the consumer to add any extra action;
  - Use an interface so that each action has a guaranteed behavior; rely on that behavior from your main code;
- In Class OCP Demos
  - Middleware in OWIN pipeline
  - Credit card transaction validation
- **L** - LSP - Liskov Substitution Principle
  - "Objects in a program should be replaceable with instances of their subtypes without altering the correctness of that program" - Uncle Bob
  - Remember princple #4 - program to interfaces / contract, not implementations
  - LSP helps guarantee you don't break the contract with the way you write a subclass
  - To satisfy it's contract, a subclass must _behave_ exactly the same way as the base class would have
  - This enables a consumer to use either the base class or a subclass with no noticeable effect on the results
- "Classic" Contrived Example - Rectangle and Square
  - "Every square is a rectangle but not every rectangle is a square..."
  - You might try to implement this in code with inheritance...

    // Given a Square class...
    public class Square : Rectangle

    // Consider
    Rectangle r = new Square();
    r.Width = 20;
    r.Height = 10;

    r.CalculateArea(); // what should this be? 200?

  - Problem: The square has a _different_ behavior than it's parent; when you change any side of a square _the other sides also change_ that breaks LSP;
- Inherit based on _behavior_ not _properties_
  - This reinforces the general guiding principles we've already covered
  - Class design should always be based on _behavior_!
  - A class can inherit from another class if it _behaves_ the same way (and _extends_ that behavior)
  - **NOTE**: Unfortunately the vast majority of introductory material on OO design uses "real world analogies" to define the principles; that requires designing based on properties; 
  - (even the LSP example of Rectangle / Square broke this rule)
- Rule of Thumb - If you need to perform a type check before calling a method, there's a good chance you broke LSP
  - var column = getDbColumn(name);
  - if(!(column instanceof HiddenColumn)) column.Render();
  - ISP can often help avoid LSP problems
- In Class LSP Demos
  - IPersistedResource ([original article](https://lassala.net/2010/11/04/a-good-example-of-liskov-substitution-principle/))
- When to use a nop
  - nop = No Operation
  - You might want to just override a method with code to do nothing (a nop) and "avoid" LSP problems
  - That can lead to subtle bugs; consider the IPersistedResource example; if my UI exposes a "Save" buton which calls the Persist method _and_ that method is a nop, the user will get inconsistent behavior
    - When they load a read/write resource everything works fine
    - When they load a read only resource it does not save _AND_ it does not tell them it failed!
    - The NotImplementedException is important in this case - it forces the consumer to realize there's a problem; you can't persist a read only resource;
  - However - nop is still a great concept; use it when the method is _optional_
  - Optional normally means we only care about the _result_ of the action, not the action itself
  - Example "optional" methods - notice the names
    - Cleanup() - if there's nothing to clean in this subclass, a nop is fine;
    - OnUpdateFinished()
    - EnsureConnected() - for an OfflineDataStore; it's "always connected"
- **I** - ISP - Interface Segragation Principle
  - "Many client-specific interfaces are better than one general-purpose interface" - Uncle Bob
  - Even when you use a single _concrete_ class to define many behaviors, separate the behaviors themselves into independent interfaces
  - Example - A C# Dictionary is an IDictionary, IList, ICollection, IEnumerable, etc
  - By keeping interfaces independent you enable _consumer code_ to focus on one aspect it cares about
  - A foreach loop can work with any IEnumerable _even if_ the IEnumerable has a lot more features
  - This also prevents you from needing to _rewrite_ all the consumers when an unrelated part of the _concrete class_ changees; the consumers each only work with _their interface_
- OCP, LSP, and ISP work together
  - You'll often find violations of any one of these 3 cause violations of the other(s)
  - Consider the IPersistedResource example
    - The type check violates OCP; we need to _rewrite_ the SaveAll method every time we add a new read only persisted resource
    - The new resource itself violates LSP; it doesn't have the same behavior as it's parent
    - The interface we designed violates IPS; we've forced consumers to always work with read/write resources even if some resources can be read-only
  - Fix any one of the 3 and you're likely to fix the other(s)
- In Class Demos
  - FixedSizeArray
- **D** - DIP - Dependency Inversion Principle
  - "One should 'depend upon abstractions, [not] concretions'" - Uncle Bob
  - A dependency is another piece of code that you _interact_ with
  - General idea - don't create / get your dependencies from _inside_ the class; pass them in from _outside_
  - Example - your DbContext class is a dependency for most of your controllers
  - If you create the dependency directly in the controller with using(var ctx = new DbContext...) you've broken DIP
- Why invert
  - It's all about planning for change; your class should be programmed to the _interface_ your dependencies define, not the _concrete implementation_
  - If we eventually swap out the implementation - your code should be unaffected
  - If you deal with the dependency from inside your class, you have to _rewrite it_ every time the dependency changes
- In Class Demos
  - IDateProvider - InjectedDateProvider, SystemClockDateProvider
  - IIdentity - SelectableIdentity, ClaimsIdentity