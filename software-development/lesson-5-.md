**Learning Objectives**
=======================
- Review the basics of encapsulation and programming to an interface
- Learn to communicate _between_ components without breaking encapsulation

**Outline**
===========
- Review - General Guiding Principles #1 and #2
  - Encapsulation - Close off, or "encapsulate" behavior / knowledge to only one part of your program
    - Using encapsulation makes it easier to make changes in the future
    - You encapsulate _knowledge_; knowledge means HOW a behavior is implemented, not WHAT the behavior is
    - Knowledge is _exposed_ when it's part of the public interface
  - Program to an Interface / Contract
    - Define a conceptual boundary between knowledge: encapsulated and not; the interface is the WHAT; it's the only thing the consumer knows about;
    - C# interfaces are a tool to _enforce_ the interface pattern in your code; they are far from perfect!
    - The responsibility for programming to an interface is ultimately on the programmer
- Providers and Consumers
  - You should consider your program to be a collection of _providers_ and _consumers_
  - A provider _provides_ (ie does the work) behaviors / functions; that's the WHAT
  - A consumer _consumes_ (ie uses) those behaviors
  - The consumer should never "know" HOW the provider works internally
- Ways to consider encapsulation
  - These all are tools to accomplish the same goal
  1. Encapsulate what changes / what you expect to change
  2. Encapsulate entire behaviors - eg WriteLine, ImportDocument
  3. Encapsulate knowledge
- Sidebar - Patterns and Principles
  - Represent the collective experience of programmers for the last 50 years
  - There is probably a pattern for anything you need to do
  - You can question the principles / patterns if you have good basis
  - REMEMBER - you're arguing with 100's of other programmers when you reject a pattern or principle!
- General Guiding Principle #3 - Don't Reinvent the Wheel
  - Map you're requirements to an existing pattern or principle
  - The last dev who invented the wheel probably ran into a lot of problems along the way; the "final product" represents his solution accounting for everything
- Class Interaction
  - Your classes can and should interact with each other
- General Guiding Principle #4 - 