**Learning Objectives**
=======================
- General approach to patterns in this class
- Observable pattern

**Outline**
===========
- Approach to patterns
  1. Problem statement
  2. "Broken" code example analysis
  3. SOLID / encapsulation evaluation
  4. Solution statement
  5. Working code example analysis
  6. Other places used
1. Problem statement - many parts of your code need to be updated when one value changes
2. In Class Demo - Broken Solution
3. Principles
    - SRP - The value provider is only responsible to rules about how the value is updated / changed
    - OCP - You _do not_ need to change provider code to add new consumers
    - ~LSP~
    - ISP - The interface for setting a value is not the same as the interface for displaying it
    - DIP - The value provider _depends_ on consumers to display its data
    - Encapsulation - We expect list of consumers to change
4. Solution statement - Separate the _value provider_ and the _consumers_; let consumers _observe_ the provider for changes
5. In Class Demo - Working Solution