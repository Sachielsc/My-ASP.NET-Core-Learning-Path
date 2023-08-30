# Links
- [Click here to the roadmap site](https://github.com/MoienTajik/AspNetCore-Developer-Roadmap)
- [学习进度](https://app.pluralsight.com/course-player?clipId=e5661b60-7bfe-4fa3-be3c-0803306186fb)

# Basic knowledge
## Rounting
Routing matches a request URI to an action on a controller

## ORM
Object-Relational Mapping is a technique the lets you query and manipulate data from a database using an object-oriented paradigm

## About Entity Framework Core
- [Database providers](https://learn.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli)
- Two approaches to start: code-first and database-first. Since I don't have a database, I will start with the code-first approach

### What is DTO?
DTO stands for "Data Transfer Object." It is a design pattern commonly used in software development, especially in applications that involve the exchange of data between different layers or components of a system. The main purpose of a DTO is to encapsulate and transfer data between different parts of a program, often across different boundaries like network communication, service layers, or between application layers.

DTOs are used to address issues like:

1. **Reducing Overhead:** When transferring data between layers or components, it's often more efficient to package the required data into a single object (DTO) rather than sending multiple individual data elements.

2. **Data Transformation:** DTOs can be used to transform data from one format to another. For instance, data fetched from a database might need to be converted into a different format before being sent over the network.

3. **Hiding Implementation Details:** DTOs can be used to expose only necessary information while hiding implementation-specific details. This helps in maintaining a clear separation of concerns between different parts of the system.

4. **Versioning:** When an application evolves, the structure of data might change. By using DTOs, you can manage data versioning and ensure that changes in one part of the application do not immediately impact other parts that rely on the data structure.

5. **Security:** DTOs can be used to sanitize or limit the data being exposed to external sources. This helps in protecting sensitive or confidential information.

DTOs are often implemented as simple classes or structures that contain fields corresponding to the data elements being transferred. They usually lack significant behavior, focusing primarily on carrying data from one place to another.

Here's a simple example of a DTO in a hypothetical scenario:

```java
public class EmployeeDTO {
    private String firstName;
    private String lastName;
    private String department;

    // Getters and setters...
}
```

In this example, `EmployeeDTO` is a data transfer object that could be used to transfer employee data between different layers of an application. It encapsulates the relevant data fields without containing any complex logic.

It's important to note that while DTOs provide benefits, they can also introduce additional complexity, especially in applications with many layers or a significant amount of data transformation. As with any design pattern, their usage should be carefully considered based on the specific requirements and architecture of the application.

# Misc
## Some dev hints
- If we've worked with collections before, you will know that it is a good idea to always initialize them to an empty collection instead of leaving them null, as to avoid null reference issues 
- we will have the following error when two controller methods are pointing to the same endpoint location:
  ```
  Fetch error
  response status is 500 https://localhost:7066/swagger/v1/swagger.json
  ```

## About class properties
- { get; set; }:<br>
This is the property accessor syntax in C#.

## What is the difference between Icollection and Ienumerable
`ICollection` and `IEnumerable` are both interfaces in the .NET Framework that represent collections of items. They are part of the collections framework and provide different levels of functionality.

`IEnumerable` is the base interface for all collections that can be enumerated. It defines a single method called `GetEnumerator()`, which returns an `IEnumerator` object. This object allows you to iterate over the collection and retrieve its elements one by one. `IEnumerable` is typically used for read-only access to a collection.

On the other hand, `ICollection` is an interface that extends `IEnumerable` and adds additional methods for modifying the collection. It provides functionality for adding, removing, and counting elements. The `ICollection` interface includes methods such as `Add`, `Remove`, `Clear`, and `Count`. Implementing `ICollection` implies that the collection supports modifying operations.

In summary, the main differences between `ICollection` and `IEnumerable` are:

1. **Functionality:** `IEnumerable` provides read-only access to a collection and allows you to iterate over its elements, while `ICollection` adds additional methods for modifying the collection.

2. **Modifiability:** `IEnumerable` collections are typically read-only and cannot be modified, whereas `ICollection` collections support modification operations such as adding or removing elements.

3. **Methods:** `ICollection` includes methods like `Add`, `Remove`, `Clear`, and `Count`, which are not present in `IEnumerable`.

4. **Inheritance:** `ICollection` extends `IEnumerable`, meaning that a collection that implements `ICollection` also implicitly implements `IEnumerable`. However, the reverse is not true.

In general, if you need to work with a collection that requires modification operations, you would use `ICollection`. If you only need to iterate over a collection without modifying it, `IEnumerable` is sufficient.

## Explain to me in details about the purpose of the arrow function here:
```csharp
var city = someCityCollection.FirstOrDefault(c => c.Id == cityId);
```

In the given code snippet, the arrow function is used as a predicate in the `FirstOrDefault` method to find an element in the `someCityCollection` collection that satisfies a specific condition. 

Let's break down the code and explain each part:
- `someCityCollection`: It represents a collection of city objects.
- `FirstOrDefault`: It is a LINQ (Language Integrated Query) method that is used to retrieve the first element of a collection that satisfies a specified condition. If no element is found, it returns the default value for the element's type (in this case, `null` since we are dealing with reference types).
- `c => c.Id == cityId`: This is the arrow function (also known as a lambda expression). It defines the condition that each element of the collection is checked against. Here's how it works:
  - `c` is a parameter that represents each element of the collection as the method iterates over it.
  - `c.Id == cityId` is the condition that is evaluated for each element `c`. It checks whether the `Id` property of the city object `c` is equal to the specified `cityId` value.

In summary, the purpose of the arrow function in this code is to define a condition that filters the `someCityCollection` collection. The `FirstOrDefault` method uses this condition to find the first city object whose `Id` property matches the specified `cityId`. If a match is found, the `city` variable will contain the reference to that city object. If no matching element is found, the `city` variable will be assigned `null`.

## Using `public ICollection<T> Objects { get; set; } = new List<T>()` instead of `public List<T> Objects { get; set; } = new List<T>()` provides several advantages in terms of flexibility and code maintainability, why?

Here are a few reasons why using `ICollection<T>` is preferred:

1. **Encapsulation and Abstraction**: By exposing the `Objects` property as `ICollection<T>`, you are using an interface that represents a generic collection. This promotes encapsulation and abstraction, allowing you to easily switch between different implementations of `ICollection<T>` without affecting the consumers of the class. It also decouples the class from specific implementation details and allows for more flexible code.

2. **Flexibility and Polymorphism**: Declaring the property as `ICollection<T>` allows you to assign any collection that implements the `ICollection<T>` interface. This means you can assign different types of collections (e.g., `List<T>`, `HashSet<T>`, etc.) to the `Objects` property without modifying the consuming code. This flexibility allows you to take advantage of different collection types based on your specific needs.

3. **API Design**: Using `ICollection<T>` instead of `List<T>` conveys the intention that the property is a collection, but the specific implementation is not important. It communicates to the consumers of the class that they can expect a collection without depending on a particular implementation or assuming specific features of `List<T>`. This helps to keep the API clean and avoids exposing unnecessary implementation details.

4. **Loose Coupling**: By depending on an interface (`ICollection<T>`) instead of a concrete type (`List<T>`), you reduce the coupling between components. This makes it easier to change or extend the implementation in the future without affecting the code that relies on it. It promotes good coding practices like the Dependency Inversion Principle and allows for better maintainability.

5. **Testing and Mocking**: When writing unit tests, it's often helpful to mock dependencies. Using an interface like `ICollection<T>` allows you to easily create mock implementations for testing scenarios without being tied to the specific behavior of `List<T>`. This improves testability and makes it easier to isolate the behavior being tested.

In summary, using `public ICollection<T> Objects { get; set; } = new List<T>()` instead of `public List<T> Objects { get; set; } = new List<T>()` provides greater flexibility, promotes abstraction, improves code maintainability, and enables loose coupling between components.

## What is singleton?
The term "singleton" typically refers to a design pattern in software engineering. It is a creational design pattern that restricts the instantiation of a class to a single object. In other words, a singleton class ensures that only one instance of the class can exist at any given time.

Here are some key characteristics of a singleton class:

1. Single Instance: A singleton class allows only one instance of itself to be created.
2. Global Access: The single instance is globally accessible, meaning that it can be accessed from anywhere within the codebase.
3. Lazy Initialization: The singleton instance is usually created only when it is first requested, rather than being created upfront.

Singletons are often used in scenarios where there should be a single point of access to a resource or when there is a need to coordinate actions across a system. For example, a logging service, database connection, or configuration manager might be implemented as a singleton to ensure that there is only one instance handling the resource.

It's worth noting that the use of singletons has been a topic of debate in software engineering due to potential issues with testability, tight coupling, and potential concurrency problems. Therefore, it's important to consider the specific requirements and implications before implementing a singleton pattern in your codebase.

## What is null-coalescing operator
In C#, the "??", also known as the null-coalescing operator, is used for null checking and provides a concise way to assign a default value when a nullable reference type is null.

Here's how it works:

```csharp
T result = nullableValue ?? defaultValue;
```

In the above code snippet, `nullableValue` is a nullable reference type, and `defaultValue` is a value that will be assigned to `result` if `nullableValue` is null. The null-coalescing operator checks if `nullableValue` is null. If it is null, the operator assigns `defaultValue` to `result`; otherwise, it assigns the value of `nullableValue` to `result`.

## What is constructor chaining or constructor delegation?
Adding `: parentclassname` after a constructor in certain programming languages is a way to invoke the constructor of the parent class (also known as the superclass or base class) within the constructor of the derived class (also known as the subclass). This process is called constructor chaining or constructor delegation.

In object-oriented programming, when you create a new class that inherits from an existing class, the new class can have its own constructors. If you want to reuse the initialization logic from the parent class's constructor, you can call the parent class's constructor from within the derived class's constructor. This is particularly useful when the parent class has some specific setup that the derived class wants to include without duplicating code.

The syntax for invoking a parent class's constructor depends on the programming language you're using. Here are a couple of examples in different languages:

1. **Java:**
In Java, you use the `super` keyword to call the constructor of the parent class. The syntax looks like this:

```java
public class ChildClass extends ParentClass {
    public ChildClass() {
        super(); // Calls the constructor of the ParentClass
        // Additional initialization for ChildClass
    }
}
```

2. **C#:**
In C#, you can use the `base` keyword to call the constructor of the parent class. Here's an example of constructor chaining in C#:

```csharp
class ParentClass
{
    public ParentClass()
    {
        Console.WriteLine("ParentClass constructor");
    }
}

class ChildClass : ParentClass
{
    public ChildClass() : base()
    {
        Console.WriteLine("ChildClass constructor");
    }
}

class Program
{
    static void Main(string[] args)
    {
        ChildClass child = new ChildClass();
    }
}
```

In this example:

1. `ParentClass` defines a constructor that prints a message when it's invoked.
2. `ChildClass` inherits from `ParentClass` and defines its own constructor. The `: base()` syntax calls the constructor of the parent class.
3. In the `Main` method of the `Program` class, we create an instance of `ChildClass`.

When you run this program, you'll see the following output:

```
ParentClass constructor
ChildClass constructor
```

The `base()` call in the `ChildClass` constructor ensures that the constructor of the `ParentClass` is executed before the code in the `ChildClass` constructor is executed. This allows you to reuse the initialization logic from the parent class while adding any additional logic specific to the child class.

3. **Python:**
In Python, you don't need to explicitly call the parent class's constructor. By default, the parent class's constructor is automatically called when you create an instance of the child class. If you want to extend or modify the behavior, you can explicitly call the parent class's constructor using the `super()` function:

```python
class ChildClass(ParentClass):
    def __init__(self):
        super().__init__()  # Calls the constructor of the ParentClass
        # Additional initialization for ChildClass
```

The `: parentclassname` part that you mentioned in your question is used to specify inheritance in some languages like C++. It indicates that the derived class is inheriting from the specified parent class. This is done as part of the class declaration and is not used directly after a constructor. Instead, the constructor chaining is achieved using the techniques described above.

## How to hide reference counts in VS2013?
Tools → Options → Text Editor → All Languages → CodeLens

## What is DTO and entity, and why do we need both in our api programming
In API programming, "DTO" stands for Data Transfer Object, and "Entity" refers to an object that represents data in a persistent storage (usually a database). Both concepts are commonly used in the context of designing APIs and managing data.

**Data Transfer Object (DTO):**
A DTO is a design pattern used to transfer data between different layers of an application, often between the backend and frontend or between different microservices. The purpose of a DTO is to encapsulate the data being transferred in a format that is tailored for the specific use case. DTOs typically include only the necessary data fields and do not contain any business logic. They are used to minimize the amount of data being transferred over the network and to provide a clear contract between different parts of the application.

DTOs are especially useful when there's a need to transform or combine data from multiple sources before sending it to the client, or when you want to shield the client from changes to the underlying data model. For example, if you have an API that returns user information, you might create a `UserDTO` with only the required fields like name, email, and role, regardless of the complexity of the internal data representation.

**Entity:**
An entity is a representation of a data object in a persistent storage, such as a database table in a relational database management system (RDBMS). Entities often map directly to database tables, with each field of the entity corresponding to a column in the table. Entities typically have attributes and methods that relate to the business logic associated with that data.

Entities are used to model the core data structures of your application and are often subject to more complex rules and validation logic. They might also be connected to database relationships like foreign keys and associations.

**Why Use Both in API Programming:**
Using both DTOs and entities in API programming helps to separate concerns and maintain a clear separation of layers in your application architecture:

1. **Data Integrity:** Entities maintain the integrity of your application's data model and encapsulate business logic and data validation rules.

2. **Data Transfer:** DTOs allow you to tailor the data being sent over the network to the specific needs of the client, avoiding over-exposure of sensitive information and minimizing unnecessary data transfer.

3. **Flexibility:** Using DTOs provides flexibility to change your internal data structures without affecting external clients that rely on your API.

4. **Performance:** DTOs allow you to optimize data transfer by sending only the necessary data, improving API performance.

5. **Security:** DTOs can help you control the information exposed to clients, ensuring that sensitive data is not leaked.

In summary, entities represent your data at the core of your application's logic, while DTOs manage how that data is presented and transferred across different layers of your application and to external clients via your API. This separation enhances modularity, security, and maintainability in your API programming.

## About negative test scenarios API testing
Negative test scenarios in API testing involve testing the system's behavior under conditions that are outside the expected or valid range. These scenarios help ensure that the API handles errors and exceptions gracefully. Here are some examples of negative test scenarios in API testing:

1. **Invalid Input Data:**
   - Sending empty or null values for required parameters.
   - Providing data in the wrong format (e.g., sending a string instead of an integer).
   - Sending data with special characters that could potentially break the API's parsing.

2. **Boundary Testing:**
   - Sending values at the lower and upper boundaries of valid ranges for numeric parameters.
   - Sending strings with the maximum allowed length.

3. **Authentication and Authorization Failures:**
   - Sending requests without proper authentication tokens or API keys.
   - Using expired or invalid authentication tokens.
   - Testing different levels of authorization to ensure users can't access unauthorized resources.

4. **Rate Limiting:**
   - Sending requests that exceed the allowed rate limit to check if the API correctly enforces rate limits.

5. **Error Responses:**
   - Triggering errors intentionally by sending incorrect or missing parameters and checking if the API returns the expected error codes and messages.
   - Testing how the API responds when it encounters internal errors or exceptions.

6. **Concurrency Testing:**
   - Sending multiple requests simultaneously to see how the API handles concurrent requests and whether it maintains data consistency.

7. **Network Failures:**
   - Interrupting the network connection while a request is in progress to test the API's behavior during network failures.
   - Sending requests with high latency to assess how the API handles slow connections.

8. **Resource Deletion and Modification:**
   - Attempting to delete or modify resources that are not owned by the requester.
   - Trying to modify resources that have been deleted.

9. **Input Validation:**
   - Sending input data that contains SQL injection or other malicious code to test the API's input validation and security measures.

10. **Data Integrity:**
    - Tampering with the data being sent or received to check if the API can detect data corruption or unauthorized changes.

11. **Version Compatibility:**
    - Sending requests with a version number that the API does not support to verify if versioning is handled correctly.

12. **Load Testing:**
    - Sending a large number of requests to test how the API performs under heavy load, and monitoring for performance degradation or crashes.

13. **Edge Cases:**
    - Testing scenarios that involve unusual or unexpected combinations of parameters or conditions to uncover hidden bugs.

14. **Timeouts:**
    - Sending requests that take longer to respond than the configured timeout to ensure the API handles timeouts appropriately.

Remember, negative test scenarios are designed to find weaknesses and vulnerabilities in your API. Properly addressing these scenarios will lead to a more robust and reliable API implementation.

## About filtering and searching feature of api
Filtering allows you to be precise by adding filters until you get exactly the property/value pair
Searching allows you to go wider, it is used when you don't exactly know which items will be in the collection

## What is ORM (EF is an ORM)
ORM stands for "Object-Relational Mapping." It's a programming technique and a set of tools or frameworks that facilitate the communication between object-oriented programming languages and relational databases. 

In traditional software development, data is often stored in relational databases using tables, rows, and columns. On the other hand, modern programming languages like Java, Python, or C# use object-oriented structures to represent data and functionality. ORM bridges this gap by providing a way to map objects from the programming language to rows in database tables and vice versa.

Here's how ORM works:

1. **Mapping**: Developers define a mapping between the classes (objects) in their programming language and the tables in the database. This mapping describes how data in objects should be stored in the database and how database records should be loaded into objects.

2. **Abstraction**: ORM abstracts away much of the low-level SQL code that's required to interact with the database. Developers can work with objects and high-level queries rather than writing direct SQL statements.

3. **CRUD Operations**: ORM frameworks provide methods and APIs to perform basic database operations like Create, Read, Update, and Delete (CRUD) directly using objects and their methods.

4. **Optimization and Query Generation**: ORM frameworks often optimize the database queries they generate to improve performance. They might also provide ways to write complex queries in a more object-oriented manner.

5. **Database Agnostic**: ORM allows developers to switch between different database systems (like MySQL, PostgreSQL, SQLite, etc.) without changing much of the application code, as long as the ORM supports those databases.

6. **Relationship Management**: ORM handles relationships between objects, such as one-to-many, many-to-many, etc., by managing the relationships between the corresponding database tables.

Popular ORM frameworks include:

- **Hibernate**: For Java applications.
- **Entity Framework**: For .NET applications.
- **Django ORM**: For Python applications using the Django framework.
- **SQLAlchemy**: A Python ORM that can be used with various databases.

ORM can significantly simplify database interactions, speed up development, and improve maintainability of code by reducing the need to write raw SQL queries. However, understanding the underlying SQL and database concepts is still important when working with ORM, especially for complex scenarios or performance optimization.

## What is Swashbuckle
Swashbuckle is a tool within the .NET ecosystem, specifically for working with ASP.NET Web API applications. Swashbuckle is a library that provides automated generation of Swagger documentation and a UI for exploring and interacting with APIs.

Here's what Swashbuckle offers:

1. **Swagger Documentation Generation:** Swagger is a specification for documenting APIs. Swashbuckle enables you to automatically generate Swagger documentation for your ASP.NET Web API endpoints. This documentation includes information about the API endpoints, their parameters, request and response formats, and other relevant details.

2. **Interactive API Documentation UI:** Swashbuckle includes a built-in UI called Swagger UI. This UI provides a user-friendly interface where developers can visualize and interact with the API documentation. It allows users to make API requests directly from the documentation page, see responses, and understand how to use the API effectively.

3. **API Exploration and Testing:** Swagger UI, provided by Swashbuckle, allows developers to explore API endpoints, understand their functionality, and even test them by sending requests with various parameters. This can be immensely helpful during development and testing phases.

4. **Code Annotations:** Swashbuckle can use XML code comments or attributes within your ASP.NET Web API code to enhance the generated Swagger documentation. By adding comments or attributes, you can provide additional information about endpoints, parameters, and responses, making the documentation more comprehensive.

5. **Integration with ASP.NET Web API:** Swashbuckle integrates seamlessly with ASP.NET Web API projects, making it easy to set up and configure. It's available as a NuGet package that you can add to your project.

Overall, Swashbuckle is a valuable tool for improving the documentation and usability of ASP.NET Web API applications. It helps developers create clear, interactive, and accurate documentation for their APIs, which can lead to better communication with API consumers and more efficient development processes.

## What are the 3 different types of lifetime of dependency injection in asp.net core, and what are their differences?
In ASP.NET Core's dependency injection (DI) system, there are three main types of lifetime for registered services. These lifetimes dictate how long a service instance is maintained and how it's shared among different parts of the application. The three types are: **Transient**, **Scoped**, and **Singleton**. Here's an explanation of each:

1. **Transient Lifetime:**
   - A new instance of the service is created every time it's requested from the DI container.
   - Transient services are best suited for lightweight, stateless components that don't need to maintain state across different parts of the application.
   - This lifetime is useful for scenarios where you want a fresh instance each time, such as for data access, logging, or simple utility classes.
   - Transient services may have higher overhead due to the creation of new instances frequently.

2. **Scoped Lifetime:**
   - A single instance of the service is created and used throughout the scope of a single HTTP request (in a web application) or a single operation (in a non-web application).
   - Scoped services are intended to be used for stateful components that need to maintain state within a specific scope, such as a single HTTP request.
   - Services registered as scoped are created once per scope and then reused within that scope.
   - Scoped services help reduce the overhead of creating instances for each request while still isolating state within the context of the scope.

3. **Singleton Lifetime:**
   - A single instance of the service is created and shared across all requests for the lifetime of the application.
   - Singleton services are appropriate for components that are expensive to create or maintain and should be shared across the application.
   - They are suitable for caching, configuration, and services that maintain application-wide state.
   - Singleton services are created the first time they are requested and the same instance is reused for subsequent requests.

**Key Differences:**

- **Scope of Instances:**
  - Transient: New instance per request.
  - Scoped: One instance per scope (e.g., one HTTP request).
  - Singleton: One instance for the entire application lifetime.

- **Usage:**
  - Transient: Stateless, lightweight services.
  - Scoped: Stateful services specific to a scope (e.g., request).
  - Singleton: Expensive-to-create components, application-wide state.

- **Performance Impact:**
  - Transient: Can have a higher performance overhead due to frequent instance creation.
  - Scoped: Offers a balance between instance creation and reuse.
  - Singleton: Potential contention for the single instance in high-concurrency scenarios.

- **Memory Usage:**
  - Transient: Can lead to more memory usage due to many short-lived instances.
  - Scoped: More memory-efficient within a scope compared to transient.
  - Singleton: Can lead to memory retention, potentially causing memory leaks if not managed properly.

Choosing the appropriate lifetime for your services depends on the nature of the service and the behavior you need in your application. Careful consideration of these lifetimes helps you optimize performance and resource utilization in your ASP.NET Core application.
