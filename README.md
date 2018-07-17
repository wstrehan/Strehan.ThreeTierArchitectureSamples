# Strehan.ThreeTierArchitectureSamples

Most developers use the Model View Controller (MVC) design pattern for their projects.  Microsoft has an MVC Framework available for both .Net Framework and .Net Core.  For many applications a three tiered architecture makes more sense but sometimes it doesn't and a more flexible architecture is required.  **This repository provides examples of five different ways to implement a three tiered architecture with .Net**.

**Disadvantages of using Microsoft's MVC Framework**
1.  Locked into using Visual Studio or Visual Studio Code for the front end development. Front end developers must know C# or another .Net programming language.
2.  MVC gets overly complicated for very complex applications.
3.  Difficult to use stored procedures with MVC.
4.  Layers must use the same technology.
5.  Parallel development more difficult because the model, view, and controller are all compiled at the same time.

**Advantages of a three tiered architecture**
1.  Front end developers can develop HTML with any development tool even Dreamweaver.  A different technology can be used for each tier.  Front end developers don't need to know .Net.
2.  More maintainable for larger more complex applications.
3.  Because the tiers are completely separate, the database developer can freely develop stored procedures. 
4.  Technology agnostic for application layers.    
5.  Parallel development easier.

**Architecture used for all five sample applications in this repository**

![alt text](https://raw.githubusercontent.com/wstrehan/Strehan.ThreeTierArchitectureSamples/master/ThreeTierDiagram.jpg)

**CoreSample Project Highlights**
1.  .Net Core 2.1
2.  Web application (Compiled with Visual Studio)
3.  HTTP web service used to communicate with client
4.  Dependency injection used for integrating data access layer
5.  Strehan.DataAccess used for the data access layer

**HandlerSample Project Highlights**
1.  .Net Framework 4.7.1
2.  Website (Compiled by IIS)
3.  Handlers (ashx files) used to communicate with client
4.  Strehan.DataAccess used for the data access layer
5.  Strehan.GenericHandlers used for the handlers

**WCF Project Highlights**
1.  .Net Framework 4.7.1
2.  Website (Compiled by IIS)
3.  HTTP web service used to communicate with client, web service implemented with WCF
4.  Strehan.DataAccess used for the data access layer

**WebAPI Project Highlights**
1.  .Net Framework 4.7.1
2.  Web application (Compiled with Visual Studio)
3.  HTTP web service used to communicate with client
4.  Dependency injection used for integrating data access layer
5.  Strehan.DataAccess used for the data access layer

**WebAPIWebsite Project Highlights**
1.  .Net Framework 4.7.1
2.  Website (Compiled by IIS)
3.  HTTP web service used to communicate with client
4.  Dependency injection used for integrating data access layer
5.  Strehan.DataAccess used for the data access layer
