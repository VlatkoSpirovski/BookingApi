
# Property Booking API

A RESTful API built with ASP.NET Core to manage properties, bookings, ratings, and reviews. This project includes functionalities for property management, user registration, login, photo management, and bookings.

## Features

- **Authentication**: 
  - User registration and login
  - Email confirmation functionality
  - JWT-based authentication for secure access
- **Booking Management**:
  - Create, view, and delete bookings
- **Photo Management**:
  - Upload, view, and delete property photos
- **Property Management**:
  - View, create, update, and delete properties
  - Search for properties based on availability and other filters
- **Ratings and Reviews**:
  - Submit and view ratings and reviews for properties

## Technologies

- **ASP.NET Core**
- **Entity Framework Core**
- **Swagger for API documentation**
- **PostgreSQL or MySQL** for data persistence
- **JWT** for authentication

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/vlatkospirovski/<your-repo>.git
   ```
   
2. Navigate to the project directory:
   ```bash
   cd <your-project-folder>
   ```

3. Set up your database connection string in the `appsettings.json`:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=your-server;Database=your-database;User Id=your-username;Password=your-password;"
   }
   ```

4. Apply migrations to the database:
   ```bash
   dotnet ef database update
   ```

5. Run the project:
   ```bash
   dotnet run
   ```

## Usage

After running the project, you can access the API documentation through Swagger at:
```
http://localhost:5283/swagger
```

The API is structured around key resources such as **Auth**, **Booking**, **Photo**, **Property**, and **RatingsAndReviews**. You can perform the following operations:

### Auth
- `POST /register` - Register a new user
- `POST /login` - Log in with credentials
- `GET /Auth/confirmemail` - Confirm email address

### Booking
- `GET /api/Booking` - Get all bookings
- `POST /api/Booking` - Create a new booking
- `GET /api/Booking/{id}` - Get a booking by ID
- `DELETE /api/Booking/{id}` - Delete a booking

### Property
- `GET /api/Property` - Get all properties
- `POST /api/Property` - Create a new property
- `GET /api/Property/{id}` - Get a property by ID
- `PUT /api/Property/{id}` - Update a property
- `DELETE /api/Property/{id}` - Delete a property
- `GET /api/Property/search` - Search for available properties

### Photo
- `POST /api/Photo/properties/photos` - Upload photos for a property
- `GET /api/Photo/{id}` - Get a photo by ID
- `DELETE /api/Photo/{id}` - Delete a photo

### Ratings and Reviews
- `POST /api/RatingsAndReviews` - Submit a new rating/review
- `GET /api/RatingsAndReviews/{id}` - Get a rating/review by ID
- `GET /api/RatingsAndReviews/{propertyId}/ratings` - Get ratings for a property

## Contributing

Feel free to submit issues or contribute to this project. Open a pull request with a detailed description of your changes.

## License

This project is licensed under the MIT License.
