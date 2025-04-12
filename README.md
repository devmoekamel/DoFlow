# FreelanceManager MVC Project

A full-featured ASP.NET MVC web application for managing freelance projects, clients, invoices, time tracking, and administrative tasks.  
This system is built to help freelancers and agencies streamline project workflows, manage clients, track missions, and handle invoicing all in one place.

---

## 📂 Project Structure

- **Controllers/**  
  Application controllers (Admin, Clients, Projects, Invoices, etc.)

- **Enums/**  
  Enum types for status, categories, currencies, priorities

- **Interfaces/**  
  Repository interfaces for dependency injection

- **Migrations/**  
  EF Core database migrations

- **Models/**  
  Database models (Client, Freelancer, Project, Invoice, etc.)

- **Repositry/**  
  Repository implementations

- **ViewModels/**  
  ViewModels for passing data to views

- **Views/**  
  Razor views for UI (CSHTML)

- **wwwroot/**  
  Static files (CSS, JS, images, libraries)

- **Program.cs**  
  Application startup

- **FreelanceManager.csproj**  
  Main project file

- **FreelanceManager.sln**  
  Solution file

---

## 💡 Features

- **Admin Dashboard:** Overview of all activities and statistics
- **Client Management:** Add, edit, and list clients
- **Freelancer Portal:** Registration and login system
- **Project Management:** Create, view, update, and manage projects
- **Mission Tracking:** Assign and track tasks/missions per project
- **Invoice Management:** Generate and track invoices
- **Time Tracking:** Log time entries per project and mission
- **Role Management:** Manage user roles
- **Partial Views:** Dynamic loading of forms and modals
- **Entity Framework Core:** Database-first migrations and operations
- **Clean Architecture:** Separation of concerns with repository patterns
- **Responsive UI:** Built with Bootstrap and jQuery

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- SQL Server
- Visual Studio 2022+ (Recommended)

### Setup Instructions

1. **Clone the Repository**

```bash
git clone https://github.com/your-username/devmoekamel-mvcproject.git
cd devmoekamel-mvcproject
