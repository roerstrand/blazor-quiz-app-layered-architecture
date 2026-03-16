# Blazor Quiz Application – Layered Architecture

ASP.NET Blazor quiz application demonstrating a scalable layered architecture with clear separation between the client interface and backend services.

This project was originally developed as a group project during academic studies. I was responsible for designing the main system architecture, structuring the layered project setup, and implementing significant parts of the backend logic and API integration. The version presented in this repository is maintained by Robin Erik Strandberg as part of a professional portfolio.

---

## Demo

Video preview  
YouTube: 

---

## Key Features

- Layered architecture separating client/UI from backend services (API, BLL, DAL)
- Secure API communication using JWT authentication
- AI and external API integration
- Scalable architecture designed to support multiple clients
- Structured project with clear layer responsibilities and naming conventions
- Designed for straightforward deployment to cloud environments such as Azure

---

## Architecture

Client (Blazor UI)

↓

API Layer

↓

Business Logic Layer (BLL)

↓

Data Access Layer (DAL)

This architecture allows multiple clients or web applications to connect to the same backend while maintaining strong separation between presentation, business logic and data access.

---

## Technologies

- ASP.NET
- Blazor
- C#
- SQL
- REST APIs
- JWT Authentication

---

## Project Structure
