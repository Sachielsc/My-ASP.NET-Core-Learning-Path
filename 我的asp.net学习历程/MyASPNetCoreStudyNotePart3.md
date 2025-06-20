<b>Overall AspNetCore-Developer-Roadmap</b><br>
[Click here to the roadmap site](https://github.com/MoienTajik/AspNetCore-Developer-Roadmap)

<b>Table of Contents</b><br>
<i>To make this work, better check the header's anchor tag and its ID value from a html view of the md file</i>

- [Caching](#caching)

# Caching
Microsoft.Extensions.Caching.Memory/IMemoryCache (described in this article) is recommended over System.Runtime.Caching/MemoryCache because it's better integrated into ASP.NET Core. [Official site](https://learn.microsoft.com/en-us/aspnet/core/performance/caching/memory?view=aspnetcore-7.0)

## Distributed caching
[Official site](https://learn.microsoft.com/en-us/aspnet/core/performance/caching/distributed?view=aspnetcore-7.0)

[StackExchange.Redis](https://stackexchange.github.io/StackExchange.Redis/)

## Response caching
[Official site](https://learn.microsoft.com/en-us/aspnet/core/performance/caching/response?view=aspnetcore-7.0)

### what's the difference between in memory caching and response caching in c#?
In-memory caching and response caching in C# serve different purposes and operate at different levels within a web application. Here's a breakdown of the key differences between the two:

**1. Purpose:**

- **In-Memory Caching:** In-memory caching is a general caching technique used to store and retrieve frequently accessed data or objects within the application's memory (RAM). It is not limited to caching HTTP responses but can be used to cache any kind of data or computation results. It is typically used to optimize application performance by reducing the need to fetch data from slower data sources (e.g., databases) repeatedly.

- **Response Caching:** Response caching, on the other hand, is specifically designed for caching HTTP responses at the web server or application level. It focuses on caching entire HTTP responses, including the content, headers, and status codes, to improve the speed and efficiency of web applications. Response caching is primarily used to reduce the load on web servers and improve user experience by serving cached responses for static or relatively static content.

**2. Scope:**

- **In-Memory Caching:** In-memory caching operates within the application itself. Data or objects are stored in memory and are accessible to the application's code. It is typically used to cache application-specific data.

- **Response Caching:** Response caching is applied at the web server or application level, typically using HTTP headers like "Cache-Control" and "Expires." It affects how web responses are cached and served to clients (e.g., browsers). Response caching is often used to cache resources that are shared across multiple requests, such as images, stylesheets, or API responses.

**3. Granularity:**

- **In-Memory Caching:** Developers have fine-grained control over what data or objects are cached and for how long. They can programmatically decide what to cache, when to update the cache, and when to invalidate cached data.

- **Response Caching:** Response caching is often applied to entire HTTP responses based on caching directives provided by the web server or application. It caches the entire response for a specific URL, and cache control is configured using HTTP headers. It's less fine-grained compared to in-memory caching.

**4. Configuration:**

- **In-Memory Caching:** Developers have more control over cache configuration and can choose caching strategies, eviction policies, and cache expiration times based on application-specific requirements. Caching libraries like `MemoryCache` in C# provide flexibility in how caching is managed.

- **Response Caching:** Response caching is typically configured through HTTP response headers and settings within the web server or web application framework. Configuration is often simpler and standardized for common caching scenarios.

In summary, while both in-memory caching and response caching aim to improve application performance through caching, they differ in scope, purpose, and granularity. In-memory caching is a general-purpose technique for caching data within the application, while response caching is specifically focused on caching HTTP responses at the web server or application level to optimize web application performance. The choice between the two depends on your caching requirements and whether you're dealing with application-specific data or web response optimization.

## Output caching
[Official site](https://learn.microsoft.com/en-us/aspnet/core/performance/caching/output?view=aspnetcore-7.0)

# Log Frameworks
## Serilog
[Official site](https://github.com/serilog/serilog) - Serilog is a diagnostic logging library for .NET applications. It is easy to set up, has a clean API, and runs on all recent .NET platforms. While it's useful even in the simplest applications, Serilog's support for structured logging shines when instrumenting complex, distributed, and asynchronous applications and systems.

# API Clients & Communications (TODO)
# Real-Time Communication (TODO)
# Object Mapping (TODO)
# Background Task Scheduler (TODO)
# Testing (TODO)
# Microservices
## Message-Brokers: Apache Kafka
- [Apache Kafka](https://github.com/confluentinc/confluent-kafka-dotnet)
- RabbitMQ
- ActiveMQ
- Azure Service Bus
- NetMQ
## Message-Bus
- MassTransit
- NServiceBus
- EasyNetQ
- CAP
## API Gateway
- Ocelot
- YARP
- Apigee
## Containerization
- Docker
## Orcherstration
- Kubernetes
- Docker Swarm


