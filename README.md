# Lubee 

This project is a property listing app with a **Vue 3 frontend** and a **.NET 6 backend API**.  
It allows users to:

- View listings in a grid
- Create new listings
- Edit existing listings
- Delete listings
- View listing details, including a map with coordinates and images

---

## Project Structure

lubee/
- backend/ # .NET 6 API
- frontend/ # Vue 3 frontend
- README.md

---

## Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
- [Node.js 20+](https://nodejs.org/) (includes npm)

Optional: VS Code or Visual Studio for easier development.

---

## Running the Backend

1. Open a terminal in the `backend/` folder:

```bash
cd backend
```

2. Restore packages:

```bash
dotnet restore
```

2. Run the API

```bash
dotnet run
```

The backend will start on http://localhost:5151

Swagger is available at http://localhost:5151/swagger
(for testing endpoints)

## Running the Frontend

Open a terminal in the frontend/ folder:

```bash
cd frontend
```

Install dependencies:

```bash
npm install
```

Run the development server:

```bash
npm run dev
```

The frontend will start on http://localhost:5173

It communicates with the backend at http://localhost:5151/api/listing


## Contact
If there are any issues running the project, contact Juan Francisco.