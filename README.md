# XYZ Hotels API Core Project

This project is an API Core implementation for XYZ Hotels, a renowned hotel chain operating globally. It aims to streamline the reservation process and provide an efficient booking experience for customers. The project is developed using a code-first approach and includes features such as CRUD operations, filtering capabilities, room availability counts, JWT token authentication, exception handling, and the repository pattern.

## Features

- CRUD Operations: The API allows for creating, reading, updating, and deleting hotel information, empowering hotel staff to manage hotel details effectively.
- Filtering: Customers can search and filter hotels based on criteria such as location, price range, or amenities, enabling a personalized booking experience.
- Count Functionality: Users can obtain counts of available rooms in specific hotels, providing insights into room availability for informed decision-making.
- JWT Token Authentication: The API employs JWT token authentication to ensure secure access to protected resources, safeguarding customer and hotel data.
- One-to-Many Relationship: The project handles the one-to-many relationship between hotels and rooms, allowing each hotel to have multiple rooms for efficient management.
- Exception Handling: The API gracefully handles exceptions, providing meaningful error messages to ensure system stability and a smooth user experience.
- Repository Pattern: The repository pattern is utilized to separate the data access layer from the business logic, promoting code modularity and maintainability.

## Getting Started

To get started with the XYZ Hotels API Core Project, follow these steps:

1. Clone the repository.
2. Install the necessary dependencies.
3. Configure the database connection in the application settings.
4. Run the database migrations to create the required tables.
5. Build and run the project.

## API Documentation

The API endpoints and their usage are documented using Swagger. You can access the API documentation by running the project and navigating to the `/swagger` endpoint in your browser.

## Acknowledgements

We would like to thank the contributors and open-source community for their valuable contributions to this project.
