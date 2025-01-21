# Multi-Service Application with Docker, PostgreSQL, and Redis

## Overview

    This project is a multi-service application that demonstrates the integration of a web service, a PostgreSQL database, and a Redis cache. The services are containerized using Docker, with Docker Compose managing their orchestration.

## Key Features

    Web Service: Built using ASP.NET Core with Entity Framework Core for database interactions.
    Database Service: PostgreSQL used as the relational database.
    Cache Service: Redis used for caching.
    Dockerized Environment: All services run in isolated containers.
    Data Management: Database migrations and data seeding handled via Entity Framework Core.

## Prerequisites

    Docker and Docker Compose installed on your machine.
    .NET 8 SDK installed for local development.
    WSL (if running Docker on Windows).

## Setup Instructions

1. Clone the Repository

    git clone <repository_url>
    cd <repository_directory>

2. Build and Run the Application
    Use Docker Compose to build and start all services in detached mode.

    docker-compose up -d

3. Access the Services

    Web Service: Accessible at http://localhost:5000.
    PostgreSQL Database: Accessible on port 5432 (credentials configured in docker-compose.yml).
    Redis Cache: Accessible on port 6379.
