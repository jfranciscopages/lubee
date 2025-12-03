# Lubee 

This project is a property listing app with a **Vue 3 frontend** and a **.NET 8 backend API**.  
It allows users to:

- View listings in a grid
- Create new listings
- Edit existing listings
- Delete listings
- View listing details, including a map with coordinates and images

---

## Project Structure

lubee/
    backend/ # .NET 8 API
    frontend/ # Vue 3 frontend (build served by Nginx)
    docker-compose.yml
    README.md

---

## 🚀 Running the Whole App with Docker (recommended)
This project includes a docker-compose.yml that builds and runs both frontend and backend.

###  1. Open a terminal in the project root:

```bash
cd lubee
```

### 2. Build and start all services

```bash
docker compose up --build
```
### 3. Access the app:
- Frontend: http://localhost:8080
- Backend (Swagger): http://localhost:5000/swagger


## Contact
If there are any issues running the project, contact Juan Francisco.