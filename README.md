# Hello Local

**Hello Local** is an ASP.NET Core MVC web application designed to connect travelers with verified local guides for authentic, off-the-beaten-path experiences. Built as a practical project for SoftUni.

## Features
* **Local Guides Directory:** Browse through profiles of verified local experts.
* **Tour Experiences:** Discover and explore various tours with detailed descriptions and pricing.
* **Search & Filter:** Easily find specific experiences by keyword or filter them by maximum price.
* **Automated Data Seeding:** The database automatically populates with sample guides and tours upon the first run.
* **Full CRUD Operations:** Complete Create, Read, Update, and Delete functionality for both guides and experiences.

## Tech Stack
* **Framework:** ASP.NET Core MVC
* **Language:** C#
* **Database:** MS SQL Server & Entity Framework Core
* **Frontend:** HTML, CSS, native Bootstrap

## How to Run the Project
1. Clone the repository.
2. Open the solution (`.sln`) file in Visual Studio.
3. Open the **Package Manager Console** (`Tools -> NuGet Package Manager -> Package Manager Console`) and run:
   ```bash
   Update-Database
