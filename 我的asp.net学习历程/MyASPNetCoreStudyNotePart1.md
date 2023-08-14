<b>Overall AspNetCore-Developer-Roadmap</b><br>
[Click here to the roadmap site](https://github.com/MoienTajik/AspNetCore-Developer-Roadmap)

<b>Table of Contents</b><br>
<i>To make this work, better check the header's anchor tag and its ID value from a html view of the md file</i>

- [General Development Skills](#general-development-skills)
  - [An overview of HTTP](#an-overview-of-http)
  - [What is TLS, what is SSL?](#what-is-tls-what-is-ssl)
  - [What's the difference between TLS and SSH](#whats-the-difference-between-tls-and-ssh)
  - [What's the difference between HTTP protocol and HTTPS protocol](#whats-the-difference-between-http-protocol-and-https-protocol)
  - [(TODO)Read a few books about algorithms and data structures](#todoread-a-few-books-about-algorithms-and-data-structures)
- [Learn C# itself](#learn-c-itself)
  - [What's the difference between .net and C#](#whats-the-difference-between-net-and-c)
  - [C#10](#c10)
  - [.Net 7](#net-7)
  - [What is .NET CLI](#what-is-net-cli)
  - [What is a SDK](#what-is-a-sdk)
  - [What is the .NET SDK?](#what-is-the-net-sdk)
- [SQL Fundamentals](#sql-fundamentals)
  - [What's the difference between T-SQL and normal SQL](#whats-the-difference-between-t-sql-and-normal-sql)
  - [The performance impact of an index in SQL](#the-performance-impact-of-an-index-in-sql)
  - [Different SQL databases](#different-sql-databases)
  - [What are the most commonly used types of indexes in SQL database](#what-are-the-most-commonly-used-types-of-indexes-in-sql-database)
  - [DDL vs DML](#ddl-vs-dml)
  - [Explain me these statements in SQL server - INSERT, UPDATE, DELETE, CREATE, ALTER, DROP, and so on](#explain-me-these-statements-in-sql-server---insert-update-delete-create-alter-drop-and-so-on)
    <details>
      <summary>Click to expand</summary>
      
      - [INSERT](#insert-data-manipulation-language)
      - [UPDATE](#update-data-manipulation-language)
      - [MERGE](#merge-data-manipulation-language)
      - [BULK INSERT](#bulk-insert-data-manipulation-language)
      - [ALTER](#alter---data-definition-language)
      - [Collations](#collations---data-definition-language)
      - [CREATE](#create---data-definition-language)
      - [DROP](#drop---data-definition-language)
      </details>
  - [DISABLE TRIGGER](#disable-trigger---data-definition-language-and-enable-trigger---data-definition-language)
  - [The `GO` keyword](#the-go-keyword)
  - [Stored procedures](#stored-procedures)
  - [Triggers](#triggers)
  - [Types of DML Triggers](#types-of-dml-triggers)
  - [What happens when you drop a table that has a trigger on it?](#what-happens-when-you-drop-a-table-that-has-a-trigger-on-it)
  - [A list of the clauses that are used in multiple DML statements or clauses](#a-list-of-the-clauses-that-are-used-in-multiple-dml-statements-or-clauses)
  - [What is a PARTITION BY Clause](#what-is-a-partition-by-clause)
  - [What is the GROUP BY clause in sql server and give me some examples](#what-is-the-group-by-clause-in-sql-server-and-give-me-some-examples)
  - [What is a WITH clause in sql server and give me some examples](user-content-what-is-a-with-clause-in-sql-server-and-give-me-some-examples)
  - [Explain me the different types of JOIN clause in sql server](#explain-me-the-different-types-of-join-clause-in-sql-server)
  - [what is a view in sql server?](#what-is-a-view-in-sql-server)
  - [give me some examples of Constrains in sql server](#give-me-some-examples-of-constrains-in-sql-server)

# General Development Skills
## An overview of HTTP
https://developer.mozilla.org/en-US/docs/Web/HTTP/Overview <br>
HTTP is a protocol for fetching resources such as HTML documents. It is the foundation of any data exchange on the Web and it is a client-server protocol, which means requests are initiated by the recipient, usually the Web browser. 
## What is TLS, what is SSL?
- Transport Layer Security (TLS), formerly known as Secure Sockets Layer (SSL), is a protocol used by applications to communicate securely across a network, preventing tampering with and eavesdropping on email, web browsing, messaging, and other protocols. Both SSL and TLS are client / server protocols that ensure communication privacy by using cryptographic protocols to provide security over a network. When a server and client communicate using TLS, it ensures that no third party can eavesdrop or tamper with any message.
- SSL (Secure Sockets Layer) and TLS (Transport Layer Security) are both cryptographic protocols that provide secure communication over the internet.
The main difference between SSL and TLS is the version number and the technical details of the protocol. SSL is an older protocol, and TLS is its successor.

## What's the difference between TLS and SSH
TLS (Transport Layer Security) and SSH (Secure Shell) are both protocols used for secure communication over the internet, but they serve different purposes.<br>
- TLS is a protocol used to secure network communication, typically between web servers and web clients. It provides a way to encrypt and authenticate data as it is transmitted over the network, protecting against eavesdropping, interception, and tampering.
- SSH, on the other hand, is a protocol used for secure remote access and command execution on a remote system. It provides a secure way to log in to a remote system over an unsecured network, such as the internet, and execute commands as if you were sitting in front of the remote system's terminal.
While TLS and SSH both provide security for data in transit, they are used in different scenarios. TLS is used to secure data exchanged between web servers and clients, while SSH is used for secure remote access to servers and other devices.

## What's the difference between HTTP protocol and HTTPS protocol
HTTP (Hypertext Transfer Protocol) and HTTPS (Hypertext Transfer Protocol Secure) are both protocols used to transfer data over the internet. The main difference between them is that HTTP is unsecured and operates on top of plain text, while HTTPS is secured by SSL/TLS and operates on top of an encrypted connection.

## (TODO)Read a few books about algorithms and data structures
A few links:<br>
https://app.pluralsight.com/library/courses/algorithms-data-structures-part-one/table-of-contents

# Learn C# itself

## What does encapsulation mean in OOP and give me an example of encapsulation in C#
Encapsulation is a fundamental concept in Object-Oriented Programming (OOP) that refers to the bundling of data and methods into a single unit called a class. Encapsulation hides the implementation details of a class from the outside world and provides a well-defined interface for interacting with it.

In C#, encapsulation can be achieved by using access modifiers such as `public`, `private`, `protected`, and `internal` to control the visibility of class members. Public members can be accessed by any code, while private members can only be accessed within the class itself.

Here's an example of encapsulation in C#:

```csharp
public class BankAccount
{
    private decimal _balance;

    public void Deposit(decimal amount)
    {
        _balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (_balance < amount)
        {
            throw new ArgumentException("Insufficient funds");
        }
        _balance -= amount;
    }

    public decimal GetBalance()
    {
        return _balance;
    }
}
```

In this example, the `BankAccount` class encapsulates a private field called `_balance`, which stores the balance of the account. The class provides public methods called `Deposit`, `Withdraw`, and `GetBalance` to interact with the account. The implementation details of the class, such as how the balance is stored and updated, are hidden from the outside world.

To use the `BankAccount` class, you can create a new instance of the class and call its public methods:

```
BankAccount account = new BankAccount();
account.Deposit(100);
account.Withdraw(50);
decimal balance = account.GetBalance();
```

In this example, a new `BankAccount` object is created, and its `Deposit` and `Withdraw` methods are called to add and subtract funds from the account. The `GetBalance` method is then called to retrieve the current balance of the account. The implementation details of the class, such as how the balance is stored and updated, are hidden from the outside world, providing a clear and well-defined interface for interacting with the account.

## What are properties in a C# class and give me an example of using it
In C#, a property is a member of a class that encapsulates a private field or variable, and provides a way to get or set its value using accessor methods called "getters" and "setters". Properties are used to expose the state of an object in a controlled manner, and allow for data validation and manipulation.

Here's an example of using properties in a C# class:

```csharp
public class Person
{
    private string name;

    public string Name 
    { 
        get { return name; }
        set 
        { 
            if (value != null && value.Length > 0)
            {
                name = value;
            }
            else
            {
                throw new ArgumentException("Name cannot be null or empty.");
            }
        }
    }
}
```

In this example, the `Person` class has a private field called `name`, which is exposed as a public property with the same name. The property has a getter that returns the value of `name`, and a setter that checks if the new value being set is not null or empty before assigning it to `name`. If the value is not valid, an exception is thrown.

To set the value of the `Name` property of a `Person` object, you can use the following code:

```
Person person = new Person();
person.Name = "John Doe";
```

This code creates a new `Person` object, and sets its `Name` property to "John Doe". The `set` method of the property is called behind the scenes to assign the value to the private `name` field. You can also get the value of the `Name` property using the following code:

```
string name = person.Name;
```

This code retrieves the value of the `Name` property of the `person` object, and assigns it to the `name` variable using the `get` method of the property.

## C# naming conventions
Here are some C# naming conventions:

1. Class names should be written in PascalCase, i.e., the first letter of each word should be capitalized. For example: `Customer`, `ProductCatalog`.

2. Interface names should be written in PascalCase and prefixed with "I", i.e., `IProduct`, `ICustomer`.

3. Method names should be written in PascalCase, i.e., the first letter of each word should be capitalized. For example: `GetCustomerById()`, `SaveProduct()`.

4. Variable names should be written in camelCase, i.e., the first letter of the first word should be lowercase and the first letter of subsequent words should be capitalized. For example: `productId`, `customerName`.

5. Constant names should be written in uppercase with underscores between words, i.e., `MAX_RETRY_COUNT`, `MINIMUM_ORDER_AMOUNT`.

6. Parameter names should be written in camelCase, i.e., the first letter of the first word should be lowercase and the first letter of subsequent words should be capitalized. For example: `customerId`, `productName`.

7. Property names should be written in PascalCase, i.e., the first letter of each word should be capitalized. For example: `FirstName`, `LastName`.

8. Event names should be written in PascalCase and suffixed with "EventHandler", i.e., `ButtonClickedEventHandler`, `ProductSavedEventHandler`.

9. Namespace names should be written in PascalCase, i.e., the first letter of each word should be capitalized. For example: `MyApp.Controllers`, `MyApp.Models`.

10. Enum names should be written in PascalCase, i.e., the first letter of each word should be capitalized. For example: `ProductStatus`, `OrderType`.

11. In C#, the naming convention for read-only variables is the same as for private variables, which is to use camelCase with a leading underscore (_) to prefix the variable name. This convention helps to distinguish read-only variables from other variables that may be mutable.

## What is interface in C# and give me an example of using interface in C#
In C#, an interface is a contract that defines a set of methods, properties, and events that a class can implement. Interfaces are used to provide a common set of functionality that can be shared across different classes, without requiring them to share a common base class.

Here is an example of using an interface in C#:

```csharp
using System;

interface IAnimal
{
    void Eat();
    void Sleep();
}

class Dog : IAnimal
{
    public void Eat()
    {
        Console.WriteLine("The dog is eating.");
    }

    public void Sleep()
    {
        Console.WriteLine("The dog is sleeping.");
    }
}

class Cat : IAnimal
{
    public void Eat()
    {
        Console.WriteLine("The cat is eating.");
    }

    public void Sleep()
    {
        Console.WriteLine("The cat is sleeping.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        IAnimal animal1 = new Dog();
        IAnimal animal2 = new Cat();

        animal1.Eat();
        animal1.Sleep();

        animal2.Eat();
        animal2.Sleep();
    }
}
```

In this example, we define an interface called `IAnimal` that has two methods, `Eat` and `Sleep`. We then define two classes, `Dog` and `Cat`, that implement the `IAnimal` interface.

In the `Main` method, we create two instances of the `Dog` and `Cat` classes, but assign them to variables of type `IAnimal`. This allows us to treat the `Dog` and `Cat` objects as if they were both of the same type, because they both implement the `IAnimal` interface.

We then call the `Eat` and `Sleep` methods on both `IAnimal` objects, and the appropriate implementation for each class is called.

By using an interface in this way, we are able to define a common set of methods that can be implemented by different classes, while still allowing each class to have its own specific implementation of those methods. This makes it easy to write flexible and reusable code, because we can write code that works with any object that implements a specific interface, without having to know anything about the specific class that is implementing the interface.

## What is IEnumerable and give me some examples of using IEnumerable
`IEnumerable` is an interface in C# that represents a sequence of values that can be enumerated. The interface has a single method called `GetEnumerator()` that returns an `IEnumerator` object, which can be used to iterate over the values in the sequence. 

Here are some examples of using `IEnumerable`:

1. Enumerating an array of integers:

```csharp
int[] numbers = { 1, 2, 3, 4, 5 };
IEnumerable<int> sequence = numbers;

foreach (int number in sequence)
{
    Console.WriteLine(number);
}
```

In this example, we create an array of integers and assign it to a variable called `numbers`. We then assign `numbers` to a variable of type `IEnumerable<int>`. This creates a sequence of integers that can be enumerated.

We then use a `foreach` loop to iterate over the sequence and print out each number to the console.

2. Filtering a sequence using LINQ:

```csharp
int[] numbers = { 1, 2, 3, 4, 5 };
IEnumerable<int> evenNumbers = numbers.Where(n => n % 2 == 0);

foreach (int number in evenNumbers)
{
    Console.WriteLine(number);
}
```

In this example, we create an array of integers and assign it to a variable called `numbers`. We then use the `Where()` method from LINQ to filter the sequence to include only even numbers.

We assign the filtered sequence to a variable of type `IEnumerable<int>` called `evenNumbers`. We then use a `foreach` loop to iterate over the `evenNumbers` sequence and print out each even number to the console.

These are just a few examples of how `IEnumerable` can be used in C#. By implementing this interface, you can easily create sequences of values that can be enumerated, filtered, and manipulated in various ways.

## What's the difference among List, array, ArrayList and IEnumerable in C#
In C#, `List`, `array`, `ArrayList`, and `IEnumerable` are all different types of collections that can be used to store and manipulate sets of data. Here's a brief summary of the differences between these types:

1. `List<T>`: `List<T>` is a generic collection type that can store a sequence of elements of type `T`. It is similar to an array, but provides additional functionality such as dynamic resizing and built-in methods for adding, removing, and sorting elements.

2. `Array`: `Array` is a fixed-size collection type that can store a sequence of elements of a specific type. Once an array is created, its size cannot be changed. It provides methods for accessing and manipulating elements by index, but does not provide any built-in functionality for resizing or sorting.

3. `ArrayList`: `ArrayList` is a non-generic collection type that can store a sequence of elements of any type. It is similar to `List<T>` but is less type-safe and provides fewer built-in methods for manipulating elements.

4. `IEnumerable<T>`: `IEnumerable<T>` is an interface that represents a sequence of elements of type `T`. It provides a method for iterating over the elements in the sequence, but does not provide any built-in methods for adding, removing, or manipulating elements.

Here are some additional differences between these types:

- `List<T>` and `ArrayList` both implement the `IList` interface, which provides additional functionality for accessing and modifying elements by index. However, `List<T>` is type-safe and provides more efficient and flexible methods for working with sequences of elements.
- `Array` provides a fixed-size, type-safe collection that is useful for scenarios where the size of the collection is known in advance and will not change during runtime.
- `IEnumerable<T>` is the most basic type of collection and provides only the most essential functionality for working with sequences of elements. It is commonly used as a return type for methods that produce sequences of data, such as LINQ queries.

Overall, the choice of which type of collection to use in C# depends on the specific requirements of your code. `List<T>` is the most commonly used collection type in C# because it provides a balance of type safety, performance, and functionality. `Array` is useful for scenarios where the size of the collection is known in advance and will not change during runtime. `ArrayList` is rarely used in modern C# code because it is less type-safe and less efficient than `List<T>`. `IEnumerable<T>` is commonly used in combination with LINQ to query and manipulate sequences of data in a functional programming style.

## What's the FirstOrDefault method in C# List and give me some examples
The `FirstOrDefault` method in C# is a LINQ extension method that is used to return the first element of a sequence that satisfies a given condition or a default value if the sequence is empty. Here are some examples of using the `FirstOrDefault` method with a `List<T>`:

Example 1: Using `FirstOrDefault` to find the first element in a list

```csharp
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
int firstNumber = numbers.FirstOrDefault();
Console.WriteLine(firstNumber); // Output: 1
```

In this example, `FirstOrDefault` returns the first element in the `numbers` list, which is `1`.

Example 2: Using `FirstOrDefault` to find the first even number in a list

```csharp
List<int> numbers = new List<int> { 1, 3, 5, 7, 8, 9 };
int firstEvenNumber = numbers.FirstOrDefault(x => x % 2 == 0);
Console.WriteLine(firstEvenNumber); // Output: 8
```

In this example, `FirstOrDefault` returns the first element in the `numbers` list that is even, which is `8`. The lambda expression `x => x % 2 == 0` is used as a condition to check if a number is even.

Example 3: Using `FirstOrDefault` to handle empty lists

```csharp
List<int> numbers = new List<int>();
int firstNumber = numbers.FirstOrDefault();
Console.WriteLine(firstNumber); // Output: 0
```

In this example, `FirstOrDefault` returns the default value for `int`, which is `0`, because the `numbers` list is empty.

Example 4: Using `FirstOrDefault` with a custom default value

```csharp
List<int> numbers = new List<int>();
int firstNumber = numbers.FirstOrDefault();
int defaultValue = 10;
int result = firstNumber != default ? firstNumber : defaultValue;
Console.WriteLine(result); // Output: 10
```

In this example, `FirstOrDefault` returns the default value for `int`, which is `0`, because the `numbers` list is empty. To handle this case, we check if `firstNumber` is not equal to the default value, and if so, we return `firstNumber`. Otherwise, we return a custom default value of `10`.

## What's the difference between .net and C#
.NET and C# are two different but related technologies used for software development. .NET is a framework that provides a set of tools and libraries for building various types of applications, while C# is a programming language used to write applications that run on the .NET framework.<br>
In other words, C# is a programming language that is used to write code that runs on the .NET framework. It is an object-oriented language that is similar to Java in syntax and structure. C# provides features such as garbage collection, automatic memory management, and support for various programming paradigms, such as functional programming.<br>
.NET, on the other hand, is a framework that provides a set of libraries, tools, and services for building various types of applications, such as desktop applications, web applications, and mobile applications. It includes a runtime environment, a class library, and various tools for building, testing, and deploying applications.

## C#10
A few links:<br>
https://app.pluralsight.com/paths/skills/c-10<br>
We have C#11 already now<br>

## .Net 7
A few links:<br>
https://devblogs.microsoft.com/dotnet/announcing-dotnet-7/

## What is .NET CLI
https://learn.microsoft.com/en-us/dotnet/core/tools/<br>
The .NET command-line interface (CLI) is a cross-platform toolchain for developing, building, running, and publishing .NET applications.<br>
The .NET CLI is included with the .NET SDK<br>

## What is a SDK
SDK stands for Software Development Kit. It is a collection of software development tools that are bundled together to help developers create software for a particular platform, operating system, or programming language.<br>
An SDK typically includes a range of tools such as libraries, APIs, sample code, compilers, and debugging tools, among others. These tools are designed to simplify the process of building applications, and they provide developers with the resources they need to build software more efficiently.

## What is the .NET SDK?
https://learn.microsoft.com/en-us/dotnet/core/sdk<br>
The .NET SDK is a set of libraries and tools that allow developers to create .NET applications and libraries. It contains the following components that are used to build and run applications:<br>
- The .NET CLI.
- The .NET runtime and libraries.
- The dotnet driver.

# SQL Fundamentals
Pluralsight Learning Path: Querying Data with T-SQL from SQL Server<br>
https://www.pluralsight.com/paths/querying-data-with-t-sql-from-sql-server<br>

## What's the difference between T-SQL and normal SQL
T-SQL (Transact-SQL) is a proprietary SQL language developed by Microsoft for use with SQL Server and Azure SQL Database. It is an extension of the standard SQL language and includes additional features that are specific to Microsoft's database systems.<br>
Here are some of the key differences between T-SQL and standard SQL:<br>
- Syntax: While the basic SQL syntax is similar across database management systems, T-SQL has its own syntax that includes additional keywords and functionality specific to Microsoft's database systems.
- Stored Procedures: T-SQL includes the ability to create stored procedures, which are reusable pieces of code that can be called from within a query. Standard SQL does not have this feature.
- Triggers: T-SQL also includes triggers, which are pieces of code that are automatically executed in response to certain events, such as data changes. While standard SQL also supports triggers, the syntax and functionality may differ.
- Error Handling: T-SQL includes more robust error handling capabilities, including the ability to catch and handle exceptions within a stored procedure.
- Transaction Control: T-SQL includes additional commands for controlling transactions, such as BEGIN TRANSACTION, COMMIT TRANSACTION, and ROLLBACK TRANSACTION.
<p>
These are some of the key differences between T-SQL and standard SQL. If you are working with Microsoft's database systems, such as SQL Server or Azure SQL Database, you will likely need to use T-SQL to take advantage of the additional features and functionality it provides.<br>
The local installation to provide you a connection to SQL server would be:<br>
<li>SQL Server Management Studio (SSMS)</li>
<li>Azure data Studio</li>
</p>

## The performance impact of an index in SQL
The performance impact of an index in SQL can be significant. On the one hand, using an index can speed up queries by reducing the amount of data that needs to be read and processed by the database engine. This can lead to faster query execution times, especially for large tables or queries with complex search conditions. On the other hand, creating and maintaining an index can also have overhead, as the database engine needs to update the index whenever data is inserted, updated, or deleted from the table. This overhead can be particularly noticeable for large tables or indexes with many columns.

## Different SQL databases
- MySQL: This is an open-source SQL database that is widely used for web applications. It is known for its speed and scalability, and is compatible with many programming languages.
- Oracle: This is a popular commercial SQL database that is used by many large organizations. It offers advanced features for data security, scalability, and availability.
- Microsoft SQL Server: This is a popular commercial SQL database that is used by many businesses. It offers features for data analytics, business intelligence, and integration with Microsoft tools and technologies.

## What are the most commonly used types of indexes in SQL database
- Clustered Index: This is an index that determines the physical order of data in a table. In other words, it sorts the table data based on the index key. Each table can have only one clustered index, and it is typically created on the primary key of the table.
- Non-Clustered Index: This is an index that does not determine the physical order of data in a table. Instead, it is a separate data structure that contains a copy of the indexed columns along with a pointer to the corresponding row in the table. Each table can have multiple non-clustered indexes.
- Unique Index: This index is commonly used to enforce the uniqueness of values in one or more columns.
- Composite Index: This index is commonly used to improve the performance of queries that involve multiple columns.
- Covering Index: This index is commonly used to avoid the need for a table lookup and improve query performance by including all the columns required to satisfy a query.
## DDL vs DML
Data Definition Language (DDL) statements defines data structures. Use these statements to create, alter, or drop data structures in a database. These statements include:
- ALTER
- Collations
- CREATE
- DROP
- DISABLE TRIGGER
- ENABLE TRIGGER
- RENAME
- UPDATE STATISTICS
- TRUNCATE TABLE

Data Manipulation Language (DML) affect the information stored in the database. Use these statements to insert, update, and change the rows in the database.
- BULK INSERT
- DELETE
- INSERT
- SELECT
- UPDATE
- MERGE

## Explain me these statements in SQL server - INSERT, UPDATE, DELETE, CREATE, ALTER, DROP, and so on
### INSERT (Data Manipulation Language)
<i>Both "INSERT" and "INSERT INTO" are valid syntaxes for the INSERT statement in SQL Server, and they can be used interchangeably.</i>

This statement is used to insert new rows into a table. Here is an example
```
INSERT INTO my_table (column1, column2, column3)
VALUES
  (1, 'value1', '2022-01-01'),
  (2, 'value2', '2022-01-02'),
  (3, 'value3', '2022-01-03');
```
### UPDATE (Data Manipulation Language)
The UPDATE statement in SQL Server is used to modify or update existing data in a table. It allows you to change one or more columns in one or more rows based on a specified condition.
```
UPDATE my_table
SET column1 = 'new_value1', column2 = 'new_value2'
WHERE id = 1;
DELETE (Data Manipulation Language)
DELETE FROM my_table
WHERE column1 = 'condition';
```
### MERGE (Data Manipulation Language)
The MERGE statement in SQL Server is used to combine multiple operations like INSERT, UPDATE, and DELETE into a single statement based on a specified condition. It allows you to synchronize data between two tables or update data in a target table based on the data in a source table.
Here is an example of using the MERGE statement in SQL Server:
```
MERGE INTO my_table AS target
USING source_table AS source
ON target.id = source.id
WHEN MATCHED THEN
  UPDATE SET target.column1 = source.column1, target.column2 = source.column2
WHEN NOT MATCHED BY TARGET THEN
  INSERT (id, column1, column2) VALUES (source.id, source.column1, source.column2)
WHEN NOT MATCHED BY SOURCE THEN
  DELETE;
```

In this example, the `MERGE` statement is used to synchronize data between `my_table` and `source_table` based on the `id` column. The statement performs the following operations:

- When a match is found between `my_table` and `source_table` based on the `id` column, the statement updates the values of `column1` and `column2` in `my_table` with the corresponding values from `source_table`.
- When a match is not found between `my_table` and `source_table` based on the `id` column, the statement inserts a new row into `my_table` with the `id`, `column1`, and `column2` values from `source_table`.
- When a row exists in `my_table` that does not exist in `source_table` based on the `id` column, the statement deletes the row from `my_table`.

### BULK INSERT (Data Manipulation Language)
The BULK INSERT statement in SQL Server is used to insert large amounts of data from a data file into a table. It is often used to import data from external sources such as text files, CSV files, or other database systems.<br>
Here is an example of using the BULK INSERT statement in SQL Server:
```
BULK INSERT my_table
FROM 'C:\data\my_data.csv'
WITH (
  FIELDTERMINATOR = ',',
  ROWTERMINATOR = '\n',
  FIRSTROW = 2
);
```

In this example, the `BULK INSERT` statement is used to insert data from a CSV file located at `C:\data\my_data.csv` into the `my_table` table. The statement specifies that the fields in the CSV file are separated by commas (`,`), each row is terminated by a newline character (`\n`), and the data starts on the second row (skipping the header row).

### ALTER - Data Definition Language
```
ALTER TABLE employees
ADD department VARCHAR(50);
```

This statement will add a new column named "department" to the "employees" table with a data type of VARCHAR and a maximum length of 50 characters.

Alternatively, if you wanted to modify the data type of an existing column, you could use the ALTER statement like this:

```
ALTER TABLE employees
ALTER COLUMN age INT;
```

This statement will change the data type of the "age" column from whatever it was before to an integer data type. 

### Collations - Data Definition Language
The COLLATE clause can be niche one (?)<br>
[official site](https://learn.microsoft.com/en-us/sql/t-sql/statements/collations?view=sql-server-ver16)

### CREATE - Data Definition Language
Here are some examples of CREATE statements in SQL Server:

1. Creating a new database:

```
CREATE DATABASE myDatabase;
```

This statement creates a new database with the name "myDatabase".

2. Creating a new table:

```
CREATE TABLE myTable (
    id INT PRIMARY KEY,
    name VARCHAR(50),
    age INT,
    salary DECIMAL(10,2)
);
```

This statement creates a new table with the name "myTable", and defines four columns: "id" (an integer column that is also the primary key), "name" (a character column that can hold up to 50 characters), "age" (an integer column), and "salary" (a decimal column with 10 digits of precision and 2 digits to the right of the decimal point).

3. Creating a new view:

```
CREATE VIEW myView AS
SELECT id, name, age
FROM myTable
WHERE age > 30;
```

This statement creates a new view with the name "myView", which selects data from the "myTable" table and filters it to only show rows where the "age" column is greater than 30.

4. Creating a new stored procedure:

```
CREATE PROCEDURE myProcedure
    @param1 INT,
    @param2 VARCHAR(50)
AS
BEGIN
    SELECT *
    FROM myTable
    WHERE id = @param1
    AND name = @param2;
END;
```

This statement creates a new stored procedure with the name "myProcedure", which takes two input parameters (@param1, an integer, and @param2, a character string). The stored procedure selects data from the "myTable" table, filtering it by the input parameters.

### DROP - Data Definition Language
Here are some examples of DROP statements in SQL Server:

1. Dropping a database:

```
DROP DATABASE myDatabase;
```

This statement drops (deletes) the database with the name "myDatabase".

2. Dropping a table:

```
DROP TABLE myTable;
```

This statement drops (deletes) the table with the name "myTable".

3. Dropping a view:

```
DROP VIEW myView;
```

This statement drops (deletes) the view with the name "myView".

4. Dropping a stored procedure:

```
DROP PROCEDURE myProcedure;
```

This statement drops (deletes) the stored procedure with the name "myProcedure".

5. Dropping a column from a table:

```
ALTER TABLE myTable
DROP COLUMN myColumn;
```

This statement drops (deletes) the column named "myColumn" from the "myTable" table.

6. Dropping an index from a table:

```
DROP INDEX myIndex ON myTable;
```

This statement drops (deletes) the index with the name "myIndex" from the "myTable" table.

Note that when you use the DROP statement, it permanently deletes the specified object from the database. It's important to use this statement carefully and double-check that you're dropping the correct object before executing the command.

### DISABLE TRIGGER - Data Definition Language and ENABLE TRIGGER - Data Definition Language
1. Disabling a specific trigger on a table:

```
DISABLE TRIGGER myTrigger ON myTable;
```

This statement disables the trigger with the name "myTrigger" on the table named "myTable".

2. Disabling all triggers on a table:

```
DISABLE TRIGGER ALL ON myTable;
```

This statement disables all triggers on the table named "myTable".

3. Disabling a specific trigger on a database:

```
DISABLE TRIGGER myTrigger ON DATABASE;
```

This statement disables the trigger with the name "myTrigger" on the entire database.

4. Disabling all triggers on a database:

```
DISABLE TRIGGER ALL ON DATABASE;
```

This statement disables all triggers on the entire database.

5. Disabling a trigger temporarily for a specific transaction:

```
DISABLE TRIGGER myTrigger ON myTable;
-- Perform some actions here
ENABLE TRIGGER myTrigger ON myTable;
```

This statement disables the trigger with the name "myTrigger" on the table named "myTable" temporarily for the duration of the current transaction. After the desired actions are performed, the ENABLE TRIGGER statement is used to enable the trigger again.

Note that disabling a trigger should be used with caution, as it can affect the integrity of the data in the database. It's important to have a clear understanding of the potential impact before using the DISABLE TRIGGER statement.

### RENAME - Data Definition Language
### UPDATE STATISTICS - Data Definition Language
### TRUNCATE TABLE - Data Definition Language

## The `GO` keyword
In T-SQL, `GO` is a batch separator that is used to indicate the end of a batch of SQL statements. 

When you run a SQL script or query in SQL Server Management Studio (SSMS), the statements are sent to the server as a batch. The server executes the batch and returns the results. The `GO` keyword is used to separate one batch of statements from another.

Here's an example of how you might use the `GO` keyword in a SQL script:

```
CREATE TABLE myTable (id INT, name VARCHAR(50))

INSERT INTO myTable (id, name) VALUES (1, 'John')
INSERT INTO myTable (id, name) VALUES (2, 'Jane')

GO

UPDATE myTable SET name = 'Alice' WHERE id = 1

SELECT * FROM myTable
```

In this example, the `GO` keyword separates the first batch of statements (which creates a table and inserts two rows) from the second batch of statements (which updates one of the rows and selects all the rows). When you run this script in SSMS, the first batch will be executed, then the second batch will be executed after the first batch completes.

## Stored procedures
In SQL Server, a stored procedure is a named block of code that is stored in the database and can be executed on demand. Stored procedures are often used to encapsulate complex database operations, improve performance by reducing network traffic, and provide a layer of abstraction for application code.

Here are some examples of stored procedures in SQL Server:

1. A simple stored procedure that selects all rows from a table:

```
CREATE PROCEDURE SelectAllRows
AS
BEGIN
    SELECT * FROM myTable;
END
```

This stored procedure, named "SelectAllRows", contains a single SELECT statement that retrieves all rows from the "myTable" table.

2. A stored procedure that accepts a parameter and filters the results of a SELECT statement:

```
CREATE PROCEDURE SelectRowsByName
    @name VARCHAR(50)
AS
BEGIN
    SELECT * FROM myTable WHERE Name = @name;
END
```

This stored procedure, named "SelectRowsByName", accepts a single parameter named "@name" and uses it to filter the results of a SELECT statement that retrieves rows from the "myTable" table where the "Name" column matches the provided value.

3. A stored procedure that inserts a new row into a table:

```
CREATE PROCEDURE InsertNewRow
    @name VARCHAR(50),
    @age INT,
    @city VARCHAR(50)
AS
BEGIN
    INSERT INTO myTable (Name, Age, City) VALUES (@name, @age, @city);
END
```

This stored procedure, named "InsertNewRow", accepts three parameters named "@name", "@age", and "@city" and uses them to insert a new row into the "myTable" table with the provided values.

4. A stored procedure that updates a row in a table:

```
CREATE PROCEDURE UpdateRow
    @id INT,
    @name VARCHAR(50),
    @age INT,
    @city VARCHAR(50)
AS
BEGIN
    UPDATE myTable SET Name = @name, Age = @age, City = @city WHERE ID = @id;
END
```

This stored procedure, named "UpdateRow", accepts four parameters named "@id", "@name", "@age", and "@city" and uses them to update a row in the "myTable" table with the provided values, based on the value of the "ID" column.

Note that these are just a few examples of what you can do with stored procedures in SQL Server. They can be much more complex and can include logic for error handling, transaction management, and more.

## Triggers
In SQL Server, a trigger is a special type of stored procedure that is automatically executed in response to certain events.

Triggers can be useful for a variety of purposes, such as enforcing business rules, maintaining referential integrity between tables, auditing changes to data, and generating notifications or alerts when certain conditions are met.

- Logon triggers<br>
Logon triggers fire stored procedures in response to a LOGON event.
- DDL triggers<br>
DDL triggers fire in response to a variety of Data Definition Language (DDL) events. These events primarily correspond to Transact-SQL statements that start with the keywords CREATE, ALTER, DROP, GRANT, DENY, REVOKE or UPDATE STATISTICS.<br>
Use DDL triggers when you want to do the following:<br>
  - Prevent certain changes to your database schema.<br>
  - Have something occur in the database in response to a change in your database schema.<br>
  - Record changes or events in the database schema.<br>
- DML triggers<br>
DML triggers is a special type of stored procedure that automatically takes effect when a data manipulation language (DML) event takes place that affects the table or view defined in the trigger. DML events include INSERT, UPDATE, or DELETE statements.

## Types of DML Triggers
### FOR | AFTER trigger
FOR or AFTER specifies that the DML trigger fires only when all operations specified in the triggering SQL statement have launched successfully. All referential cascade actions and constraint checks must also succeed before this trigger fires.

An AFTER trigger is run only after the triggering SQL statement has run successfully. This successful execution includes all referential cascade actions and constraint checks associated with the object updated or deleted. An AFTER does not recursively fire an INSTEAD OF trigger on the same table.

You can't define AFTER triggers on views.

### INSTEAD OF trigger
Specifies that the DML trigger launches instead of the triggering SQL statement, thus, overriding the actions of the triggering statements. You can't specify INSTEAD OF for DDL or logon triggers.

At most, you can define one INSTEAD OF trigger per INSERT, UPDATE, or DELETE statement on a table or view. You can also define views on views where each view has its own INSTEAD OF trigger.

You can't define INSTEAD OF triggers on updatable views that use WITH CHECK OPTION. Doing so results in an error when an INSTEAD OF trigger is added to an updatable view WITH CHECK OPTION specified. You remove that option by using ALTER VIEW before defining the INSTEAD OF trigger.

[Reference](https://learn.microsoft.com/en-us/sql/t-sql/statements/create-trigger-transact-sql?view=sql-server-ver16)

## What happens when you drop a table that has a trigger on it?
All associated triggers are also dropped.

## A list of the clauses that are used in multiple DML statements or clauses
[Official site](https://learn.microsoft.com/en-us/sql/t-sql/queries/queries?view=sql-server-ver16)

## What is a PARTITION BY Clause
In SQL Server, the PARTITION BY clause is used in conjunction with the OVER clause to divide a result set into partitions or groups based on one or more columns.

[Good site here](https://www.sqlshack.com/sql-partition-by-clause-overview/)

Notice the difference between PARTITION BY Clause and GROUP Clause

## What is the GROUP BY clause in sql server and give me some examples
In SQL Server, the GROUP BY clause is used to group rows based on one or more columns and aggregate their values using various functions like SUM, AVG, COUNT, MAX, MIN, etc. 

Here's an example that demonstrates the GROUP BY clause in action:

```
SELECT 
    Region, 
    Country, 
    SUM(Sales) AS TotalSales
FROM 
    Sales
GROUP BY 
    Region, 
    Country
```

In this example, the result set is grouped by Region and Country, and then the SUM function is applied to the Sales column for each group. The resulting column, TotalSales, shows the total sales for each unique combination of Region and Country.

Here's another example that demonstrates how to use the GROUP BY clause with the HAVING clause to filter the groups based on a condition:

```
SELECT 
    ProductID, 
    SUM(Quantity) AS TotalQuantity
FROM 
    OrderDetails
GROUP BY 
    ProductID
HAVING 
    SUM(Quantity) > 1000
```

In this example, the result set is grouped by ProductID, and then the SUM function is applied to the Quantity column for each group. The HAVING clause is used to filter the groups and return only those groups where the total quantity is greater than 1000. The resulting column, TotalQuantity, shows the total quantity for each product that meets the condition.

Note that when using the GROUP BY clause, any column that is not part of the GROUP BY clause must be included in an aggregate function or the result set will not be valid.

## What is a WITH clause in sql server and give me some examples
In SQL Server, the WITH clause, also known as a Common Table Expression (CTE), is a temporary result set that you can reference within a SELECT, INSERT, UPDATE, or DELETE statement. 

The WITH clause is useful when you want to break down a complex query into smaller, more manageable pieces, or when you want to reference a subquery multiple times within a larger query. 

Here's an example that demonstrates the WITH clause in action:

```
WITH SalesByCountry AS (
    SELECT 
        Country, 
        SUM(Sales) AS TotalSales
    FROM 
        Sales
    GROUP BY 
        Country
)
SELECT 
    Country, 
    TotalSales, 
    TotalSales / (SELECT SUM(TotalSales) FROM SalesByCountry) * 100 AS Percentage
FROM 
    SalesByCountry
```

In this example, a CTE named SalesByCountry is created that calculates the total sales for each country. Then, the CTE is referenced in a SELECT statement that calculates the percentage of total sales for each country. The resulting columns, Country, TotalSales, and Percentage, show the country name, total sales, and percentage of total sales, respectively.

Here's another example that demonstrates how to use the WITH clause to simplify a complex query:

```
WITH ProductInfo AS (
    SELECT 
        ProductID, 
        ProductName, 
        CategoryID
    FROM 
        Products
    WHERE 
        Discontinued = 0
),
CategoryInfo AS (
    SELECT 
        CategoryID, 
        CategoryName
    FROM 
        Categories
)
SELECT 
    ProductInfo.ProductName, 
    CategoryInfo.CategoryName
FROM 
    ProductInfo
    INNER JOIN CategoryInfo ON ProductInfo.CategoryID = CategoryInfo.CategoryID
```

In this example, two CTEs are created to simplify a query that joins the Products and Categories tables. The first CTE, ProductInfo, selects only the columns needed from the Products table and filters out discontinued products. The second CTE, CategoryInfo, selects only the columns needed from the Categories table. Then, the two CTEs are joined together to return only the product name and category name for each product.

## Explain me the different types of JOIN clause in sql server
In SQL Server, there are several types of JOIN clauses that you can use to combine rows from two or more tables based on a specified condition. The different types of JOIN clauses are:

1. INNER JOIN: Returns only the rows that have matching values in both tables. (Note: INNER JOIN is the default JOIN)

```
SELECT 
    Customers.CustomerName, 
    Orders.OrderID
FROM 
    Customers
    INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID
```

In this example, an INNER JOIN is used to return only the customers who have placed an order, and their corresponding order IDs.

2. LEFT JOIN: Returns all the rows from the left table and the matching rows from the right table. If there is no match, the result set will contain NULL values for the right table columns.

```
SELECT 
    Customers.CustomerName, 
    Orders.OrderID
FROM 
    Customers
    LEFT JOIN Orders ON Customers.CustomerID = Orders.CustomerID
```

In this example, a LEFT JOIN is used to return all the customers, including those who have not placed an order, and their corresponding order IDs (if any).

3. RIGHT JOIN: Returns all the rows from the right table and the matching rows from the left table. If there is no match, the result set will contain NULL values for the left table columns.

```
SELECT 
    Customers.CustomerName, 
    Orders.OrderID
FROM 
    Customers
    RIGHT JOIN Orders ON Customers.CustomerID = Orders.CustomerID
```

In this example, a RIGHT JOIN is used to return all the orders, including those that do not have a corresponding customer record, and their corresponding customer names (if any).

4. FULL OUTER JOIN: Returns all the rows from both tables, including the unmatched rows. If there is no match, the result set will contain NULL values for the missing columns.

```
SELECT 
    Customers.CustomerName, 
    Orders.OrderID
FROM 
    Customers
    FULL OUTER JOIN Orders ON Customers.CustomerID = Orders.CustomerID
```

In this example, a FULL OUTER JOIN is used to return all the customers and orders, including those that do not have a matching record in the other table, and their corresponding order IDs and customer names (if any).

5. CROSS JOIN: Returns all possible combinations of rows from both tables, without a specified condition. This type of join is also known as a Cartesian product.

```
SELECT 
    Customers.CustomerName, 
    Products.ProductName
FROM 
    Customers
    CROSS JOIN Products
```

In this example, a CROSS JOIN is used to return all possible combinations of customers and products. Note that this type of join can produce a large result set, and should be used with caution.

## what is a view in sql server?
In SQL Server, a view is a virtual table that is based on the result set of a SELECT statement. A view is similar to a table in that it has columns and rows, but it does not store any data physically. Instead, a view is a stored query that retrieves data from one or more tables and presents it as a table-like structure.

Views provide several benefits in SQL Server, including:

1. Security: Views can be used to restrict access to sensitive data by allowing users to view only a subset of the data in a table.

2. Simplification: Views can simplify complex queries by combining data from multiple tables into a single virtual table.

3. Consistency: Views can ensure that queries return consistent results by enforcing rules and filters on the data.

4. Performance: Views can improve query performance by precomputing complex calculations and aggregations, and by reducing the amount of data that needs to be transferred between the client and the server.

Creating a view in SQL Server is simple. Here's an example of creating a view that retrieves data from the "Customers" table:

```
CREATE VIEW vw_Customers AS
SELECT 
    CustomerID,
    CustomerName,
    ContactName,
    City
FROM 
    Customers
```

Once a view is created, it can be queried like a table using the SELECT statement. For example:

```
SELECT 
    CustomerName,
    City
FROM 
    vw_Customers
WHERE 
    City = 'London'
``` 

This query will retrieve the customer names and cities of all customers from the vw_Customers view that are located in London. Note that the view is not a physical table, but rather a stored query that returns the desired results.


## give me some examples of Constrains in sql server
Sure! Here are some examples of constraints in SQL Server:

1. Primary Key Constraint: 

```
CREATE TABLE Customers (
  CustomerID int NOT NULL PRIMARY KEY,
  CustomerName varchar(255) NOT NULL,
  ContactName varchar(255),
  Country varchar(255)
);
```

This constraint ensures that the values in the "CustomerID" column are unique and cannot be null.

2. Foreign Key Constraint: 

```
CREATE TABLE Orders (
  OrderID int NOT NULL PRIMARY KEY,
  CustomerID int NOT NULL,
  OrderDate date,
  FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);
```

This constraint ensures that the values in the "CustomerID" column of the "Orders" table match the values in the "CustomerID" column of the "Customers" table.

3. Check Constraint:

```
CREATE TABLE Products (
  ProductID int NOT NULL PRIMARY KEY,
  ProductName varchar(255) NOT NULL,
  Price decimal(10, 2) NOT NULL CHECK (Price > 0)
);
```

This constraint ensures that the values in the "Price" column are greater than 0.

4. Unique Constraint: 

```
CREATE TABLE Employees (
  EmployeeID int NOT NULL PRIMARY KEY,
  FirstName varchar(255) NOT NULL,
  LastName varchar(255) NOT NULL,
  Email varchar(255) UNIQUE
);
```

This constraint ensures that the values in the "Email" column are unique and cannot be null.

5. Not Null Constraint:

```
CREATE TABLE Orders (
  OrderID int NOT NULL PRIMARY KEY,
  CustomerID int NOT NULL,
  OrderDate date NOT NULL
);
```

This constraint ensures that the values in the "OrderDate" column cannot be null.