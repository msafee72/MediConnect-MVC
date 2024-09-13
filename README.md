# Medi-Connect:
Medi-Connect is a responsive web-based clinic management system developed using the Model-View-Controller (MVC) pattern in ASP.NET Core. It is designed to streamline clinic operations, including managing doctors, and laboratory operations.

## Features
- **Admin Panel**: Manage doctors, laboratorians, and other staff.
- **Doctor Dashboard**: Manage patient profiles, prescriptions, and view lab test results.
- **Laboratory Management**: Receive doctor prescriptions, conduct lab tests, and upload results.
- **User Management**: Role-based access control with ASP.NET Core Identity.
- **Authentication & Authorization**: Secure access using Claim and Policy-based Authorization.
- **Efficient CRUD Operations**: Using Repository Pattern and Dapper ORM.
- **State Management**: Managed with cookies and sessions.

## Technology Stack
### Front-End:
- HTML
- CSS
- Bootstrap
- JavaScript
### Back-End:
- ASP.NET Core MVC (C#)
- Dapper ORM
- Microsoft SQL Server

## Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/medi-connect.git

2. Open the solution in Visual Studio and restore the NuGet packages.

3. Update the connection string in appsettings.json to match your SQL Server configuration.

4. Run the following command to apply migrations and seed the database: 'Update-Database'

5. Build and run the application using IIS Express or your preferred hosting server.

## Usage
- **Admin**: Manage doctors, laboratorians, and view clinic statistics.
- **Doctors**: Manage patients, prescriptions, and view lab results.
- **Laboratorians**: Conduct lab tests and upload results.
