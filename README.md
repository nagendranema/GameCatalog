**Game Catalog API**
This repository contains a .NET 8.0 API for performing basic CRUD (Create, Read, Update, and Delete) operations on the Game model.

**Project Setup**
Prerequisites
To run this project, you will need:
- .NET 8.0 SDK or later
- A suitable IDE such as Visual Studio or Visual Studio Code
- 
**Cloning the Repository**
To clone the repository and run the project locally, you will need to follow these steps:

- Open your terminal and navigate to the directory where you want to clone the repository.

- Run the following command to clone the repository:
    https://github.com/nagendranema/GameCatalog.git


**Running the Project Locally**
Open the project in your chosen IDE.
If using Visual Studio, select Run > Start Debugging or Run > Start Without Debugging from the menu or press F5 or Ctrl + F5.
If using Visual Studio Code or terminal, navigate to the project directory and run dotnet run to start the server.
Your API will now be running on https://localhost:7185

**API Endpoints**
The API provides the following endpoints:

- GET GameCatalog/GetAllGames: Retrieve all games.
- GET GameCatalog/GetGameById?id={Id}: Fetch details of a specific game by Id. Returns 404 if the game is not found.
- GET GameCatalog/GetGamesPerPage?page={page}&pageSize={pageSize}: Fetch list of games on a specific page. Returns 404 if the page is not found.
- POST GameCatalog/AddGame : Add a new game. Returns 409 if a game with the same ID already exists.
- PUT GameCatalog/UpdateGame: Update an existing game. Returns 404 if the game is not found.
- DELETE /GameCatalog/DeleteGame?id={Id}: Delete a game by Id. Returns 404 if the game is not found.
  
**Making API Requests**
While making requests to POST and PUT, provide the request body in the following format:
json-
  {
      "id": 4,
      "title": "Pac-Man",
      "genre": "Arcade",
      "description": "Navigate mazes and eat pellets while avoiding ghosts in this arcade classic.",
      "price": 14.99,
      "releaseDate": "1980-05-22T00:00:00",
      "stockQuantity": 120
    }
