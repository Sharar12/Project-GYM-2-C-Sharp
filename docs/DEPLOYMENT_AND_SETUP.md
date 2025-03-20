# Deployment & Setup Guide

## Requirements
- .NET 8.0 SDK
- Visual Studio 2022 / VS Code with C# Dev Kit
- SQL Server Express / LocalDB

## Setup Steps
```bash
dotnet restore
dotnet ef database update --project GYMWeb
dotnet run --project GYMWeb
```
