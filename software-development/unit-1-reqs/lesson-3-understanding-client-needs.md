**Learning Objectives**
===================================
- Understand client / customer needs based on "fuzzy" ideas
- Reccommend existing solutions or non-software solutions when appropriate
- Understand the role of professional responsibility in development

**Outline**
========================
- "Fuzzy" ideas
  - We've discussed how ideas are difficult to refine in the past
  - When the idea originally comes from a client or customer it can be much harder
  - What customers know (or think they know)
    - Their goal
     This might be a rough or general goal like "keep track of my to do list" or it might be something specific like "send a picture of my daughter to her grandma".

     How they did it until now; sometimes they don't know exactly how, or they want to change and improve the process

    What's "possible" to do with a computer - and what's not

    Vague other ideas about their goal - this is the largest part of what they know; it's all the subconcious information they use when they work on the goal without ever thinking about it
- The X / Y Problem
  - Most people are uncomfortable with "questions" or "problems"
  - You ask them something and they automatically start forming an answer
  - This can be habitual to the point they don't even realize they are doing it
  - The problem is compounded when you need to communicate with someone
  - You ask them to help with your "solution" and never mention the problem!
  - This is referred to as the x / y problem; x is the real problem, y is what you talk about
  - (NOTE: this often happens in learning as well)
- Examples
  - Y: Can you automatically synchronize two copies of a database between my house and work?
  - X: I want to work from home.

  - Y: Can you disable the backup on my computer?
  - X: Every time I try to play my favorite game, it crashes and says the backup engine is causing problems.

  - Y: We need a way to automatically add 1 to a number once a day
  - X: We need to know how long a part has been in use

  - Y: Can you make our website "hack" a visitors computer to see if use our program or not?
  - X: We want to show a special message to users with our program on their computer.
- The Developers Role / Resolving the Problem
  - As a developer you are a professional with expert knowledge in the field
  - You should expect to take customer input and mold it into a more useful problem
  - Be prepared to assert your role as a professional if the customer resists
- Practical Tools
  - Don't Accept "Artificial" Limitations
    - The customer might not actually know when something isn't possible, he just assumes
    - Ask him and _independently verify_ what he says
  - The 5 Whys - make sure you understand what the real goal is
  - Feedback Loop
    - Make an initial draft based on what the client said;
    - Meet with them and demonstrate why it might not work
    - The goal is to figure out what would work better for them
  - Consider non-software solutions
  - Be Realistic
    - Consider how long something will really take; it's always better to deliver early than late
    - You should be firm about how difficult things are to implement - _you're the professional_
    - Customers always want the solution now; you're job is to help them understand why it has to wait
- Professional Responsibility - To The Client
  - Protect their privacy
    - Don't disclose any data to a 3rd party directly
    (this _can_ include immediate family depending on the family members role and the type  of data)
    - Your own computer and source code repos must be properly secured against attack
    - You must have a process in place with employees / contractors to ensure they also protect client privacy;
      in large companies this is normally formalized with contracts;
    - You may want to use an NDA for this

    - This also means - you should never read any client data you have access to;
    - Physical ability to access data != permission!
    - In general you should request to work with sanitized data to avoid potential problems

    - Last note: permission for you to access private data may not extend to subcontractors or other departments of your company
  - Protect their data / software
    - Clients _do not understand_ the risks of data loss
    - You must either backup their system for them or advise them on how to do it
    - Same goes for basic network security / virus scanners
  - Protect them from themselves
    - As a rule you should never give customers access to "super user" tools (like SSMS) or create "super user" tools in the app
    - Even someone who is a competent computer user can easily make a mistake with these tools!
    - Instead work with them to find out their goal and come up with a different solution (x/y problem)
- Professional Responsibilty - To The Public
  - Ethics / Legality
    - As a developer you have "inside information" about what your client / customer plans to do with their software
    - Those plans might be unethical or illegal
    - You have a responsibility to _refuse to write the program_ that does what they want!
  - Consider Your Impact
    - Even if something is _legal_, it might not be _nice_ to end users
    - For example - mass e-mail is generally considered SPAM
  - Regulatory Compliance
    - Software development overall is _not_ government regulated;
  - HOWEVER - many industries that we work with _are_ regulated
  - Some industries place the burden of compliance on the developer not the end user
    You should never work in a "gray" area without confirming what you're doing is allowed
  - Some sample "well known" regulations
    - HIPAA - for anything dealing with US health records
    Main point - you can never disclose personal medical information without express patient consent

    - FERPA - for anything dealing with US education records
    Main point - you can never disclose specific information (like grades) without express consent; general verification is allowed (like "yes he was a student")

    - GDPR - for _any_ personal data in EU
    Main point - you must inform the user of 1) any personal data you collect, 2) why you collect it, 3) allow them to opt out without penalty

    - COPPA - for any child's (under 13) data of any kind in US
    Main point - parents have absolute authority over the data; they can allow you to use it, disallow, or change their mind

    - CAN-SPAM - for any messages you send to US customers
    Main point - you cannot send unsolicited messages; all non-direct messages must include information on how to unsubscribe;

    - ADA - for any "public" application (where public means its intended for any audience)
    Main point - you must make reasonable accomodations to allow disabled or partially disabled users to use your product

    - PCI-DSS - for any credit cards

    - Misrad Hamisim - for any financial applications with Israeli companies / individuals
    Main point - you can never delete data; period; if you want to reverse a transaction, enter a new one with a negative value; this also applies to inventory (makes restocks complicated)

    - Copyright / DMCA
    Main point - any creative work has an "automatic" copyright to the creator; this includes pictures, text, websites, vector graphics, icons, etc; to use it you need _permission_ from the creator

  - You should always check for the industry your working in

- Licenses - Getting Permission to Use Someone Else's Content
  - To use copyrighted content you'll normally want a "license" from the copyright owner.  The license dictates how and when you can use the content
  - Commercial license - usually paid; you can use for any purpose;
  - "Open Source" - you can use for anything you want
    - MIT like - You can use for anything _without submitting changes_; you _must_ attribute
    - GPL like - You _must_ attribute and submit changes
  - Split License - open source for most "public" projects; commercial for commerical projects;
  - Non Software license - Creative Commons CCSA; for non source code content; you can use it but you must _attribute_
  - Plain English [explanations](https://choosealicense.com/licenses) of most open source licenses

- Fair Use
  - **Remember**: Copyright / Trademark apply _even to product / company names and logos_!
  - That means for example, you cannot put the name "Compuskills" on your web app w/out permission from Compuskills
  - **However**: Copyright / Trademark laws have a special "fair use" exception allowing you to use content _without permission_
  - Fair use law is complex; unless there is a well established precedent, you should consult an IP attorney before using something wihtout permission - see more on [Wikipedia](https://en.wikipedia.org/wiki/Fair_use)
  - General idea - you can use copyrighted / trademarked material without permission as long you don't gain unfair commercial advantage by doing it;
  - Specific types of fair use in Trademarks
    1. Nominative - You can refer to a trademarked item by name as a way to _identify_ the product; eg, you can say "he has an iPhone" even though the name "iPhone" is trademarked
    2. Descriptive - If a trademark is a valid description of your product, you may use it; for example, a photography website could say it "helps you share moments and share your life" even though "share moments, share life" is a trademark of Kodak.
    3. Comparative - You can compare your product directly to another similar product; eg, if you make a social networking site, you could say "ReallyGreatSocialNetwork has more users than Facebook".

- "Industry Standard"
  - In the absence of actual laws / regulations about what we as devs must do, we rely on what everybody else does
  - When something is the "standard" in the industry, it's generally considered to be good enough
  - Exception: If the industry standard is gross negligence, you cannot rely on it
e.g. - if industry standards say to store plain text password data, you can't do it "because they did"