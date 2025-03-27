# Fullstack Auction App

This project is a full-stack web application built with a React frontend and an ASP.NET Core backend. The backend was built as part of a group project. The app includes auction- and bid management, as well as authentication via JWT tokens. Users can view and search auctions without being logged in, while authentication is required to post auctions, place bids on auctions and manage one's user profile.

## Tech Stack

## Backend

- **ASP.NET Core Web API**: For building the backend API.
- **SQL Server**: For managing the relational database that stores data for the application, such as customers, accounts, transactions and loans.
- **JWT (JSON Web Tokens)**: For handling user authentication through token-based access control.
- **Entity Framework Core**: For object-relational mapping from database tables to C# objects, providing efficient database access.
- **AutoMapper**: For simplifying object-to-object mapping between DTOs and models.
- **BCrypt**: For secure password hashing.
- **Moq**: For unit testing and mocking dependencies.
- **xUnit**: For writing unit tests in the backend, ensuring reliability and correctness of the API.
- **Swagger**: For API testing and documentation.

## Frontend

- **React**: For building the user interface through dynamic UI components.
- **CSS**: For styling the application.
- **React Router**: For handling navigation between pages.
- **Context API**: For managing global state across the application and passing data through the component tree.
