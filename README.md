# Bid Calculation Tool

## Project Description

This project consists of a backend in C#/.NET and a frontend in Vue.js to calculate the total cost of a vehicle based on its base price and type (Common or Luxury).

### Backend

The backend is developed in C#/.NET and provides an API to calculate the total cost of a vehicle. We used best practices principles like SOLID and DRY to structure the code. The creation of services and repositories, even if not practically used, was done to demonstrate skills in class separation and pattern application.

#### Main Technologies:
- .NET 8
- Entity Framework Core
- AutoMapper
- Moq (for unit testing)
- Bogus (for unit testing)

#### Endpoints:
- `POST /api/vehicle/calculate`: Calculates the total cost of the vehicle.

#### Project Structure:
- **Controllers**: Contain the API endpoints.
- **Services**: Contain business logic.
- **Repositories**: Manage data persistence.
- **DTOs**: Transfer data between layers.
- **Enums**: Define specific data types.

### Frontend

The frontend is developed in Vue.js and provides a user interface for data input and displaying the calculated total cost.

#### Main Technologies:
- Vue.js 3
- Axios (for HTTP requests)

#### Components:
- **BidCalculator**: Main component that contains the form for data input and result display.

Execution Instructions
Backend
Navigate to the backend project directory.

bash
Copy code
cd /path/to/your/backend/project
Restore dependencies and build the project:

bash
Copy code
dotnet restore
dotnet build
Start the application:

bash
Copy code
dotnet run
The API will be available at https://localhost:5001.

Frontend
Navigate to the frontend project directory.

bash
Copy code
cd /path/to/your/frontend/project
Install dependencies:

bash
Copy code
npm install
Start the application:

bash
Copy code
npm run serve
The application will be available at http://localhost:8080.

Considerations
Although we created services and repositories that are not practically used, this was done to demonstrate our ability to apply best practices principles like SOLID, KISS, DRY, and YAGNI. I understand the importance of not developing functionalities that will not be used, keeping the focus on the simplicity and efficiency of the code.
