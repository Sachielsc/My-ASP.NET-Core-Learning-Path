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