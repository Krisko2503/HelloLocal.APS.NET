
# HelloLocal.APS.NET

HelloLocal.APS.NET is a web application built with ASP.NET Core and C#, featuring separate interfaces for administrators and regular users.

The application uses ASP.NET Core Identity for authentication and authorization, allowing users to sign in and access functionality based on their roles.

## Features

- **User Interface** — Interface for regular users.
- **Admin Interface** — Separate interface for administrators.
- **Authentication** — Secure user authentication using ASP.NET Core Identity.
- **Role-Based Authorization** — Different access permissions for Admin and User roles.
- **Database Management** — Database migrations and updates using Entity Framework Core.
- **Test Accounts** — Predefined accounts for testing both interfaces.

## Technologies

- **C#** — Main programming language.
- **ASP.NET Core** — Web application framework.
- **ASP.NET Core Identity** — Authentication, user management, and role-based authorization.
- **Entity Framework Core** — Object-relational mapping (ORM) and database migrations.
- **SQL Server** — Database management.
- **Git & GitHub** — Version control and source code hosting.

## Installation and Setup

### 1. Clone the Repository

Clone the repository to your local machine:

```bash
git clone https://github.com/Krisko2503/HelloLocal.APS.NET.git
```

### 2. Navigate to the Project Directory

Open a terminal and navigate to the cloned repository:

```bash
cd HelloLocal.APS.NET
```

### 3. Update the Database

Open the solution in Visual Studio.

Open **Tools → NuGet Package Manager → Package Manager Console** and execute:

```powershell
Update-Database
```

This command applies the Entity Framework Core migrations and updates the database.

Make sure your database connection string is configured correctly before running the command.

### 4. Run the Project

Run the project from Visual Studio by pressing **F5** or clicking the **Start** button.

Alternatively, if the project is configured for command-line execution, run:

```bash
dotnet run
```

Open the local URL displayed in the console or browser to access the application.

## Test Accounts

Use the following predefined accounts to test both interfaces.

### User Account

| Field | Value |
|---|---|
| Email | `user@hellolocal.bg` |
| Password | `User123!` |
| Role | User |

### Admin Account

| Field | Value |
|---|---|
| Email | `admin@hellolocal.bg` |
| Password | `Admin123!` |
| Role | Admin |

### Testing the Application

1. Start the application.
2. Navigate to the login page.
3. Sign in using the User account to test the regular user interface.
4. Log out.
5. Sign in using the Admin account to test the administrative interface.
6. Explore the functionality and permissions available to each role.

**Note:** The test accounts must exist in the application's database. If they are not created automatically, configure the appropriate user and role seeding before testing.

## Database Configuration

Before running database migrations, verify that the database connection string in `appsettings.json` or the relevant configuration source points to the correct database server.

If the database has not been created or updated, execute `Update-Database` from the Visual Studio Package Manager Console.

## Authentication and Authorization

The application uses **ASP.NET Core Identity** to manage user accounts and authentication.

Identity supports user sign-in, account management, and integration with role-based authorization. The Admin and User roles allow the application to distinguish between administrative functionality and regular user functionality.


## Author

**Krisko2503**

GitHub: [@Krisko2503](https://github.com/Krisko2503)

## Repository

[HelloLocal.APS.NET](https://github.com/Krisko2503/HelloLocal.APS.NET)

