# Loyalty Program App

This repository contains a minimal ASP.NET Core Razor Pages application that demonstrates a simple point-based loyalty program.

## Features

- Registration page that stores new users in an in-memory database and saves a cookie with the user email.
- Leaderboard page showing the top 10 users ordered by points.
- Endpoint `/code/{code}` that redirects to `/Register` with the provided one-time code.

## Running

The project targets .NET 7.0. Use the .NET SDK to run the application:

```bash
dotnet run --project LoyaltyProgramApp/LoyaltyProgramApp.csproj
```

Then open `http://localhost:5000` in your browser.
