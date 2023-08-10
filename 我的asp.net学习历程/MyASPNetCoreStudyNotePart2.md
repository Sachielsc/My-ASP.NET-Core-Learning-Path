<b>Overall AspNetCore-Developer-Roadmap</b><br>
[Click here to the roadmap site](https://github.com/MoienTajik/AspNetCore-Developer-Roadmap)

<b>Table of Contents</b> - TODO<br>
<i>To make this work, better check the header's anchor tag and its ID value from a html view of the md file</i>
- [ASP.NET core basic](#aspnet-core-basic)
  - [Difference between .net core and .net framework](#difference-between-net-core-and-net-framework)
  - [What's the difference beween .NET Core and ASP.NET Core](#whats-the-difference-beween-net-core-and-aspnet-core)
  - [What is MVC pattern](#what-is-mvc-pattern)
  - [What is REST in asp.net core and give me a demo about REST in asp.net core](#what-is-rest-in-aspnet-core-and-give-me-a-demo-about-rest-in-aspnet-core)
  - [Configuration in ASP.NET Core](#configuration-in-aspnet-core)
  - [ASP.NET Core Middleware](#aspnet-core-middleware)
  - [Filters in ASP.NET Core](#filters-in-aspnet-core)
  - [Overview of ASP.NET Core authentication](#overview-of-aspnet-core-authentication)
  - [Introduction to authorization in ASP.NET Core](#introduction-to-authorization-in-aspnet-core)
  - [Choose an ASP.NET Core web UI](#choose-an-aspnet-core-web-ui)
  - [Razor Pages](#razor-pages)
  - [What is SignalR?](#what-is-signalr)
  - [what is IIS](#what-is-iis)
- [SOLID](#solid)
  - [What is SOLID?](#what-is-solid)
  - [Single Responsibility Principle (SRP)](#single-responsibility-principle-srp)
  - [Open-Closed Principle (OCP)](#open-closed-principle-ocp)
  - [Liskov Substitution Principle (LSP)](#liskov-substitution-principle-lsp)
  - [Interface Segregation Principle (ISP)](#interface-segregation-principle-isp)
  - [Dependency Inversion Principle (DIP)](#dependency-inversion-principle-dip)
  - [What is loose coupling in software development](#what-is-loose-coupling-in-software-development)
  - [What are IoC containers](#what-are-ioc-containers)
- [Logging](#logging)
  - [Logging to a file](#logging-to-a-file)
- [Pluralsight ASP.NET Core 6 Web API Path and other Pluralsight tutorials](unknown link)

# ASP.NET core basic
## Difference between .net core and .net framework
.NET Core and .NET Framework are both Microsoft technologies used for building Windows applications. However, they have some key differences:<br>
<li>Cross-platform support: .NET Core is designed to be cross-platform and runs on Windows, macOS, and Linux. .NET Framework, on the other hand, is designed to run only on Windows.</li>
<li>Open source: .NET Core is open source and has a larger community of developers contributing to it. .NET Framework, on the other hand, is not open source.</li>
<li>Deployment: .NET Core applications can be deployed as self-contained executables or as platform-specific packages, making it easier to deploy and manage. .NET Framework applications, on the other hand, require the framework to be installed on the target machine.</li>
<li>Compatibility: .NET Core is not backward compatible with .NET Framework. Applications built for .NET Framework cannot run on .NET Core without modification.</li>
<li>API availability: While both .NET Core and .NET Framework provide access to the .NET API, they have different APIs available. .NET Framework has a larger set of APIs than .NET Core.</li>
Overall, .NET Core is a more modern and flexible platform that is suited for building cross-platform applications, while .NET Framework is better suited for Windows-specific applications.

## What's the difference beween .NET Core and ASP.NET Core
.NET Core is a general-purpose development platform, while ASP.NET Core is a web framework that is built on top of .NET Core. In other words, ASP.NET Core is a subset of .NET Core that is specifically designed for building web applications.

## What is MVC pattern

[MVC official site](https://learn.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-7.0) (My Comment: 这个official教程我已大致读完一遍，完全不知道在说什么。不错的教程但是需要和实际结合. I also have a tutorial `ASP.NET Core MVC 2022 .NET 6` on my youTube. But i will go deep into MVC later maybe)

MVC - a clean separation of concerns<br>
MVC (Model-View-Controller) is a <b>software architectural pattern</b> that separates the application into three interconnected components: the Model, the View, and the Controller. The Model represents the data and the business logic of the application, the View represents the user interface, and the Controller handles the user's input and updates the Model and the View accordingly. This separation of concerns makes the application easier to develop, test, and maintain.

In ASP.NET, the MVC pattern is used to develop web applications using the ASP.NET MVC framework. Here's a basic example of how MVC works in ASP.NET:

1. Model: The Model represents the data and business logic of the application. In ASP.NET, the Model is implemented as a class that represents the data and a repository that handles the data access.

```csharp
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

public class StudentRepository
{
    public List<Student> GetStudents()
    {
        // Code to retrieve students from database or other data source
    }
}
```

2. View: The View represents the user interface of the application. In ASP.NET, the View is implemented as an HTML file that includes server-side code to render dynamic content.

```html
@model List<Student>

<table>
    <thead>
        <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Age</th>
        </tr>
    </thead>
    <tbody>
        @foreach (var student in Model)
        {
            <tr>
                <td>@student.Id</td>
                <td>@student.Name</td>
                <td>@student.Age</td>
            </tr>
        }
    </tbody>
</table>
```

3. Controller: The Controller handles the user's input and updates the Model and the View accordingly. In ASP.NET, the Controller is implemented as a class that handles user requests and returns the appropriate View.

```csharp
public class StudentController : Controller
{
    private readonly StudentRepository _repository = new StudentRepository();

    public ActionResult Index()
    {
        var students = _repository.GetStudents();
        return View(students);
    }
}
```

In this example, the StudentController handles the user's request for the Index page and retrieves the list of students from the StudentRepository. It then passes the list of students to the Index View, which renders the list in an HTML table.

This is a very basic example of how MVC works in ASP.NET. In a real-world application, there would be more complexity and additional components involved, such as routing, authentication, and validation. However, the basic principles of MVC would still apply, making the application easier to develop, test, and maintain.

## What is REST in asp.net core and give me a demo about REST in asp.net core
[MVC official site](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-7.0&tabs=visual-studio) (My Comment: 这个official教程我已大致读完一遍，完全不知道在说什么。不错的教程但是需要和实际结合.)

REST (Representational State Transfer) is an architectural style for building distributed systems based on web standards such as HTTP, URI, and MIME. RESTful systems are characterized by their simplicity, scalability, and loose coupling between components. In ASP.NET Core, the ASP.NET Core Web API framework provides built-in support for building RESTful web services.

Here's a basic example of how to implement a simple RESTful web service using ASP.NET Core:

1. Create a new ASP.NET Core Web API project:
```
dotnet new webapi -n MyWebApi
cd MyWebApi
```
2. Define a model for the data to be returned by the web service:
```csharp
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}
```
3. Define a controller to handle HTTP requests and return the data:
```csharp
[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly List<Product> _products = new List<Product>
    {
        new Product { Id = 1, Name = "Product 1", Price = 10.99m },
        new Product { Id = 2, Name = "Product 2", Price = 19.99m },
        new Product { Id = 3, Name = "Product 3", Price = 29.99m }
    };

    [HttpGet]
    public ActionResult<IEnumerable<Product>> Get()
    {
        return Ok(_products);
    }

    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product);
    }
}
```
4. Run the web service and test it using a web browser or a tool like Postman:
```
dotnet run
```
```
GET https://localhost:5001/products
GET https://localhost:5001/products/1
```

In this example, the ProductsController defines two HTTP endpoints: one to return a list of all products and one to return a single product by ID. The HTTP verb used for both endpoints is GET, which is a common convention for retrieving data in a RESTful web service. The [HttpGet] attribute is used to specify the HTTP verb and the route template for each endpoint.

The ActionResult<T> return type is used to provide a standardized way of returning HTTP status codes and response bodies from controller actions. The Ok method is used to return a 200 OK status code with the data in the response body, while the NotFound method is used to return a 404 Not Found status code when a requested resource is not found.

This is a very basic example of how to implement a RESTful web service using ASP.NET Core. In a real-world application, there would be more complexity and additional components involved, such as authentication, caching, and error handling. However, the basic principles of REST and ASP.NET Core would still apply, making the web service easy to develop, test, and maintain.

## Configuration in ASP.NET Core
[Official site](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-7.0)

Configuration providers from highest to lowest priority:
1. Command-line arguments using the Command-line configuration provider.
2. Non-prefixed environment variables using the Non-prefixed environment variables configuration provider.
3. User secrets when the app runs in the Development environment.
4. appsettings.{Environment}.json using the JSON configuration provider. For example, appsettings.Production.json and appsettings.Development.json.
5. appsettings.json using the JSON configuration provider.
6. A fallback to the host configuration described in the next section.

## ASP.NET Core Middleware
[Official site](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-7.0)

## Filters in ASP.NET Core
[Official site](https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-7.0) (My Comment: 这个official教程我已大致读完一遍，完全不知道在说什么。需要和实际结合)

## Overview of ASP.NET Core authentication
[Official site](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/?view=aspnetcore-7.0)

Authentication is the process of determining a user's identity. Authorization is the process of determining whether a user has access to a resource. In ASP.NET Core, authentication is handled by the authentication service, IAuthenticationService, which is used by authentication middleware.

## Introduction to authorization in ASP.NET Core
[Official site](https://learn.microsoft.com/en-us/aspnet/core/security/authorization/introduction?view=aspnetcore-7.0)

TODO: Identity, IdentityServer, OpenIddict, Auth0/OIDC, OWASP top10

## Choose an ASP.NET Core web UI
[official site](https://learn.microsoft.com/en-us/aspnet/core/tutorials/choose-web-ui?view=aspnetcore-7.0#choose-a-server-rendered-aspnet-core-ui-solution)

- Server rendered ASP.NET Core UI solution
  - ASP.NET Core Razor Pages
  - ASP.NET Core MVC
  - Blazor Server
- Client rendered ASP.NET Core solution
  - Blazor WebAssembly
  - ASP.NET Core Single Page Application (SPA) with JavaScript Frameworks such as Angular and React
    - [Use Angular with ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/client-side/spa/angular?view=aspnetcore-7.0&tabs=visual-studio)
    - [Use React with ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/client-side/spa/react?view=aspnetcore-7.0&tabs=visual-studio)
- Hybrid solution
  - ASP.NET Core MVC or Razor Pages plus Blazor

## Razor Pages
Razor is basically HTML with the option to embed C# code.

Razor Pages can make coding page-focused scenarios easier and more productive than using controllers and views: [Official site](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-7.0&tabs=visual-studio)

[Tutorial: Get started with Razor Pages in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/razor-pages-start?view=aspnetcore-7.0&tabs=visual-studio)

## What is SignalR?
SignalR enables developers to build real-time web applications and add real-time functionalities to existing applications. SignalR simplifies the process of establishing bi-directional communication between a server and multiple clients, allowing real-time updates and notifications to be pushed from the server to the connected clients.

## what is IIS
IIS stands for Internet Information Services. It is a web server software developed by Microsoft and is included with the Windows operating system. IIS provides a platform for hosting and serving websites, web applications, and other web services on the Windows server environment.

IIS supports various web protocols such as HTTP, HTTPS, FTP, SMTP, and NNTP, allowing it to handle different types of web-based content and services. It offers features like process isolation, security, load balancing, and application pool management to ensure efficient and reliable web hosting.

With IIS, you can deploy and manage websites and web applications built on different technologies such as ASP.NET, PHP, and static HTML. It also supports integration with other Microsoft technologies like SQL Server and Active Directory for enhanced functionality and authentication.

IIS provides a web-based management console, called Internet Information Services (IIS) Manager, which allows administrators to configure and monitor websites, application pools, security settings, and other server-related aspects.

Overall, IIS is a widely used web server software that powers many websites and web applications running on the Windows platform.

# SOLID
## What is SOLID?
It is five OOP principles, the first letter of each spelling out SOLID:
- Single Responsibility Principle (SRP)
- Open-Closed Principle (OCP)
- Liskov Substitution Principle (LSP)
- Interface Segregation Principle (ISP)
- Dependency Inversion Principle (DIP)

## Single Responsibility Principle (SRP)
The Single Responsibility Principle (SRP) states that a class should do one thing and one thing only.</br>
Doing lots of things in a class is bad not just because it is difficult to unit test, but it increases the odds of introducing bugs.</br>
Very good article [here](https://www.dotnetcurry.com/software-gardening/1148/solid-single-responsibility-principle)

## Open-Closed Principle (OCP)
Very good article [here](https://www.dotnetcurry.com/software-gardening/1176/solid-open-closed-principle)
- Closed for Modification</br>
In a nutshell, being closed for modification means you shouldn’t change the behavior of existing code.</br>
There are however, three ways you could change the behavior of existing code.</br>
The first is to fix a bug. After all, the code is not functioning properly and should be fixed. You need to be careful here as clients of the class may know about this bug and have taken steps to get around this. As an example, HP had a bug in some of their printer drivers for many years. This bug caused printing errors under Windows, and HP refused to change it. Microsoft made changes in Word and other applications to get around this bug.</br>
The second reason to modify existing code is to refactor the code so that it follows the other SOLID principles. For example, the code may be working perfectly but does too much, so you wish to refactor it to follow Single Responsibility.</br>
Finally, a third way, which is somewhat controversial, is you are allowed to change the code if it doesn’t change the need for clients to change. You have to be careful here so that you don’t introduce bugs that affect the client. Good unit testing is critical.
- Open for Extension</br>
Using this solution, you inherit a class and all its behavior then override methods where you want to change. This avoids changing the original code and allows the class to do something different.</br>
Anyone that has tried to do much implementation inheritance knows it has many pitfalls. Because of this many people have adopted the practice interface inheritance. Using this methodology, only method signatures are defined and the code for each method must be created each time the interface is implemented. That’s the down side. However, the upside is greater and allows you to easily substitute one behavior for another. The common example is a logging class based on an ILogger interface. You then implement the class to log to the Windows Event Log or a text file. The client doesn’t know which implementation it’s using nor does it care.</br>
Another way to have a method open for extension is through abstract methods. When inherited, an abstract method must be overridden. In other words, you are required to provide some type of functionality.</br>
Closely related to an abstract method is a virtual method. The difference is where you must override the abstract method; you are not required to override a virtual method. This allows a bit more flexibility to you as a developer.</br>
There is one other, and often overlooked, way to provide additional functionality. That is the extension method. While it doesn’t change the behavior of a method, it does allow you extend the functionality of a class without changing the original class code.

## Liskov Substitution Principle (LSP)
Very good article [here](https://www.dotnetcurry.com/software-gardening/1235/liskov-substitution-principle-lsp-solid-patterns)</br>
A subclass (Dog or Bird) can be substituted for the base class (Animal) and everything still works.

## Interface Segregation Principle (ISP)
Very good article [here](https://www.dotnetcurry.com/software-gardening/1257/interface-segregation-principle-isp-solid-principle)</br>

## Dependency Inversion Principle (DIP)
Very good article [here](https://www.dotnetcurry.com/software-gardening/1284/dependency-injection-solid-principles)</br>
This is about Dependency Inversion, or as it is commonly called, Dependency Injection (DI).
-  Using DI makes it easy to change out the implementation of that interface that has been injected and easy to unit test original method

## What is loose coupling in software development
In software development, loose coupling is a design principle that aims to reduce the dependencies between components or modules of a system. It promotes a more flexible and maintainable codebase by minimizing the direct interactions and knowledge that one component has about another.

To achieve loose coupling, software developers employ techniques such as using dependency injection, interfaces, abstract classes, and design patterns like the Dependency Inversion Principle (DIP) and the Observer pattern. These practices help to decouple components, enabling greater flexibility, maintainability, and extensibility of software systems.

# What are IoC containers
IoC (Inversion of Control) containers are software frameworks or libraries that implement the Inversion of Control principle in software development. Inversion of Control is a design pattern that helps decouple the dependencies between components or classes in an application. It allows for the inversion of the flow of control from the application code to an external container, which manages the creation and resolution of object dependencies.

IoC containers achieve this by providing a centralized mechanism for managing the lifecycle and dependencies of objects. They typically offer features such as dependency injection, automatic object creation, and object configuration. By using an IoC container, developers can define the dependencies of their classes or components in a configuration file or through annotations, and the container takes care of resolving and injecting those dependencies at runtime.

The IoC principle helps improve modularity, testability, and maintainability of software systems by reducing the coupling between components and promoting loose coupling and separation of concerns.

IoC stands for Inversion of Control, which is the underlying concept behind IoC containers.

# Logging
## Logging to a file
ASP.NET Core doesn't include a logging provider for writing logs to files. To write logs to files from an ASP.NET Core app, consider using a [third-party logging provider](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging/?view=aspnetcore-7.0#third-party-logging-providers)

# Pluralsight ASP.NET Core 6 Web API Path and other Pluralsight tutorials
记录：已经学完的视频：
- ASP.NET Core 6: Big Picture (by Roland Guijt) - chapter 1 & 2
- [ASP.NET Core 6 Web API Fundamentals (by Kevin Dockx)](https://app.pluralsight.com/course-player?clipId=ff09197b-954c-4a08-a5d9-83d3c17b17e0) - Learning progress here: [Link Text](./ASP.NET%20Core%206%20Web%20API%20Fundamentals%20%E5%AD%A6%E4%B9%A0%E7%AC%94%E8%AE%B0.md)
