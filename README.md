
# GameVoid

GameVoid is a comprehensive platform designed for users to explore, view, and interact with game details. It provides a seamless interface to manage and display game data, making it ideal for gaming enthusiasts and developers alike.

## Features

- **Game Table**: Displays a list of games with details such as name, genre, release date, and more.
- **User View**: A dedicated section for users to interact with and view specific game details.
- **Edit and Update**: Functionality to edit game details with confirmation alerts.
- **Responsive Design**: Ensures optimal viewing experience across devices.

## Technology Stack

### Backend
- **ASP.NET Core**: Handles server-side logic and database interactions.
- **Entity Framework Core**: Manages database access and migrations.

### Frontend
- **Razor Pages**: Dynamic and user-friendly interfaces for interaction.

### Database
- **SQL Server**: Stores and manages game data.

## Installation

Follow these steps to set up the project locally:

1. **Clone the repository**:
   ```bash
   git clone https://github.com/mahir1522/GameVoid
   cd GameVoid
   ```

2. **Configure the database**:
   - Update the connection string in the `appsettings.json` file to point to your SQL Server instance.

3. **Run migrations**:
   ```bash
   dotnet ef database update
   ```

4. **Run the application**:
   ```bash
   dotnet run
   ```

5. Access the application at `http://localhost:5000` in your web browser.

## Usage

### Viewing Games
Navigate to the game table to see a list of all games available in the database.

### Editing Games
Click on a game's edit button to update its details. A confirmation alert will appear once the update is successful.

## Contributing

We welcome contributions to GameVoid! If you'd like to contribute:
1. Fork the repository.
2. Create a new branch for your feature/bugfix.
3. Submit a pull request with a detailed description of the changes.
