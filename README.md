# BTickets - Movie Ticket Booking System

A comprehensive movie ticket booking and cinema management system built with ASP.NET Core MVC, implementing modern web development practices with Entity Framework Core and ASP.NET Core Identity.

## 🎬 About The Project

BTickets is a full-featured cinema management platform that allows users to browse movies, book tickets, and manage cinema operations. The system supports multiple user roles including customers, cinema staff, and administrators.

## 🏗️ Architecture

- **MVC Pattern** with ASP.NET Core
- **Repository Pattern** for data access
- **Unit of Work Pattern** for transaction management
- **Entity Framework Core** with Code First approach
- **ASP.NET Core Identity** for authentication and authorization
- **Responsive Design** with modern UI/UX

## 🔧 Technologies Used

- ASP.NET Core MVC 8.0
- Entity Framework Core
- ASP.NET Core Identity
- SQL Server
- HTML5, CSS3, JavaScript
- Bootstrap for responsive design
- LINQ for data querying

## 🎭 Core Features

### 🎪 Cinema Management
- **Movies**: Add, edit, and manage movie listings
- **Cinemas**: Manage multiple cinema locations
- **Actors**: Maintain actor database and movie associations
- **Producers**: Manage movie producers and their portfolios

### 🎫 Booking System
- **Ticket Booking**: Real-time seat selection and booking
- **Shopping Cart**: Add multiple tickets before checkout
- **Order Management**: Track and manage customer orders
- **Order Items**: Detailed breakdown of bookings

### 👥 User Management
- **Customer Accounts**: User registration and profile management
- **Role-Based Access**: Different access levels for users
- **Authentication**: Secure login and session management

### 📊 Administrative Features
- **Dashboard**: Overview of system statistics
- **Movie Scheduling**: Manage showtimes and availability
- **Revenue Tracking**: Monitor ticket sales and revenue
- **User Management**: Admin control over user accounts

## 🚀 Getting Started

### Prerequisites

- .NET 8.0 SDK or later
- SQL Server (LocalDB or full version)
- Visual Studio 2022 or VS Code
- Git

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/btickets-mvc.git
   cd btickets-mvc
   ```

2. **Restore packages**
   ```bash
   dotnet restore
   ```

3. **Update connection string**
   
   In `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BTicketsDB;Trusted_Connection=true;MultipleActiveResultSets=true"
     }
   }
   ```

4. **Apply migrations**
   ```bash
   dotnet ef database update
   ```

5. **Seed initial data**
   ```bash
   dotnet run --seed
   ```

6. **Run the application**
   ```bash
   dotnet run
   ```

Visit `https://localhost:5001` to access the application.

## 📁 Project Structure

```
BTickets/
