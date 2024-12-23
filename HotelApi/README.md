
# Hotel API Backend

This is an ASP.NET Core backend project created to provide real data to the frontend application for the Hotel SPA Test. Although the test required only one of either frontend or backend, I decided to complete both. The backend is designed to integrate with the frontend seamlessly, providing real data to the application. However, the frontend includes a failsafe mechanism to use dummy data in case the backend is not running, ensuring flexibility during testing.

## Project Structure

The project consists of the following key components:

- **`Controllers/HotelController.cs`**: Contains the API endpoints for managing hotel data.
- **`Models/Hotel.cs`**: Defines the data structure for hotel objects.
- **`Data/hotels.json`**: A JSON file containing hotel data used by the API.

## Prerequisites

Before running the project, ensure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)


## Getting Started

Follow these steps to set up and run the backend project:

### 1. Clone the Repository

Clone this repository to your local machine:

```bash
git clone <repository-url>
cd <repository-folder>
```

### 2. Restore Dependencies

Although this project has no external dependencies, run the following command to ensure everything is set up correctly:

```bash
dotnet restore
```

### 3. Run the Application

Start the development server by running:

```bash
dotnet run
```

### 4. Access the API

Once the server is running, the API will be accessible at:

- **Base URL**: `http://localhost:5000` (or the URL provided by your local environment)
- **Endpoints**:
  - `GET /api/hotels`: Retrieves a list of hotels.
  - `GET /api/hotels/{id}`: Retrieves details for a specific hotel by ID.


## Project Details

- **Language**: C#
- **Framework**: ASP.NET Core
- **Data Source**: `hotels.json`

