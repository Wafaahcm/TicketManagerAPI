# TicketManagerAPI

## Description

TicketManagerAPI is a web API for managing tickets, built with ASP.NET Core.

## Setup Instructions

To set up and run the TicketManagerAPI project, follow these steps:

### Prerequisites

Make sure you have the following software installed on your machine:

- [.NET SDK](https://dotnet.microsoft.com/download/dotnet) (version 6.0 or later)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads#express)
- [Visual Studio](https://visualstudio.microsoft.com/) (recommended) or [Visual Studio Code](https://code.visualstudio.com/)
- [Git](https://git-scm.com/) (for cloning the repository)

### Step 1: Clone the Repository

1. Open your terminal or command prompt.
2. Navigate to the directory where you want to clone the repository.
3. Run the following command to clone the repository:

   ```bash
   git clone https://github.com/yourusername/TicketManagerAPI.git
   
#### Step 2: Configure the Database : 

Open the cloned project directory and locate the appsettings.json file.

Update the connection string to point to your SQL Server instance. Replace the placeholder values with your actual SQL Server credentials:
"ConnectionStrings": {
    "TicketManagerDB": "Server=your_server;Database=your_database;User Id=your_username;Password=your_password;"
}

##### Step 3: Install Dependencies

Navigate to the project directory in your terminal and run the following command to restore dependencies:

cd TicketManagerAPI
dotnet restore

#### Step 4: Run Migrations
dotnet ef database update

#### Step 5: Run the Application
In your terminal, ensure you're still in the project directory:

cd TicketManagerAPI
dotnet run

