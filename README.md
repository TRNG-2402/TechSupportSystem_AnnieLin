# TechSupportSystem_AnnieLin
**Overview:**

The Tech Support System is a RESTful API built with ASP.NET core that allows support requests to be logged, tracked, updated, and resolved in an organized and efficient way. The app also interacts with SQL databases through Entity Framework Core. 

**Functionality:**

- Create, Update, Read, Delete for Support Tickets
- Create, Read, And Delete for Technicians
- Input validation 
- Persist data using a relational database (SQLite)
- Test API endpoint using Swagger UI

**Project Structure:**

- Controller - contains the API endpoints (GET, POST, PUT, DELETE)
- Services - contains the business logic and has exception handling
- Data - contains the DbContext, database config, and repo pattern
- Models - contains all entity models (SupportTicket, Technician, SupportNote)
- Defines 1-M and M-M relationships
- DTO - contains data transfer objects 
- Migrations - contains EF Core Migrations 
- Basic exception throwing/handling and null checks 
- Dependency Injection
- Async operations

**Database Relationships:**

- One-to-Many: A SupportTicket can have multiple SupportNotes
- Many-to-Many: A SupportTicket can be assigned to many Technicians, and a Technician can work on multiple SupportTickets 

**Future Improvements:**

- Adding additional unit test with Moq for different layers
- Adding authentication and authorization for technicians
- Attempt adding a frontend UI
- Connecting to Azure 
