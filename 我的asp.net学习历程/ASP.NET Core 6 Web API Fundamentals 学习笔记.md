# Basic knowledge
## Rounting
Routing matches a request URI to an action on a controller

# Misc
## Some dev hints
- If we've worked with collections before, you will know that it is a good idea to always initialize them to an empty collection instead of leaving them null, as to avoid null reference issues 

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