<b>Overall AspNetCore-Developer-Roadmap</b><br>
[Click here to the roadmap site](https://github.com/MoienTajik/AspNetCore-Developer-Roadmap)

<b>Table of Contents</b><br>
<i>To make this work, better check the header's anchor tag and its ID value from a html view of the md file</i>
- [ASP.NET core basic](#aspnet-core-basic)
  - [Difference between .net core and .net framework](#difference-between-net-core-and-net-framework)
  - [What's the difference beween .NET Core and ASP.NET Core](#whats-the-difference-beween-net-core-and-aspnet-core)
  - [What is MVC pattern](#what-is-mvc-pattern)
  - [What is REST in asp.net core and give me a demo about REST in asp.net core](#what-is-rest-in-aspnet-core-and-give-me-a-demo-about-rest-in-aspnet-core)

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
Razor Pages can make coding page-focused scenarios easier and more productive than using controllers and views: [Official site](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-7.0&tabs=visual-studio)

[Tutorial: Get started with Razor Pages in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/tutorials/razor-pages/razor-pages-start?view=aspnetcore-7.0&tabs=visual-studio)

## What is SignalR?
SignalR enables developers to build real-time web applications and add real-time functionalities to existing applications. SignalR simplifies the process of establishing bi-directional communication between a server and multiple clients, allowing real-time updates and notifications to be pushed from the server to the connected clients.



