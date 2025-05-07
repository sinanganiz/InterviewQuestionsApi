# InterviewQuestionsApi

A minimal, professional-grade RESTful API built with **.NET 9**, **MongoDB**, and **Docker**, designed to store and manage technical interview questions.

---

## ✨ Features

- CRUD operations
- MongoDB integration using `IMongoClient`
- Professional layered architecture:
  - `Domain`, `Application`, `Infrastructure`, `Presentation`
- Global error handling & standardized API responses
- Docker support for MongoDB
- Swagger UI for API testing

---

## 🧱 Project Structure

```bash
├── docker/
│ └── docker-compose.yml
├── src/
│ ├── InterviewQuestionsApi.Application
│ ├── InterviewQuestionsApi.Domain
│ ├── InterviewQuestionsApi.Infrastructure
│ └── InterviewQuestionsApi.Presentation
├── InterviewQuestionsApi.sln
```

---

## 🚀 Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/download)
- [Docker](https://www.docker.com/)

### 🐳 Run MongoDB with Docker

```bash
docker-compose -f docker/docker-compose.yml up -d
```

MongoDB will be available at ``mongodb://root:example@localhost:28117``.

### Run Project

```bash
dotnet run --project ./src/InterviewQuestionsApi.Presentation
```

---

## ⚙️ Configuration

Ensure the following section exists in appsettings.Development.json:

```json
"MongoDbOptions": {
  "ConnectionString": "mongodb://root:example@localhost:28117",
  "DatabaseName": "InterviewQuestionsDb"
}
```

---

## 📚 API Documentation

After running the project, visit:

```bash
https://localhost:{port}/swagger
```
