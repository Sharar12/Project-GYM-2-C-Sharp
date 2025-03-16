# GYMWeb System Architecture & Design

```mermaid
graph TD
    Client[Web Browser] --> RazorPages[ASP.NET Core Razor Pages]
    RazorPages --> Services[Service Layer: Plans, Attendance, Lockers]
    Services --> Context[EF Core GYMWebContext]
    Context --> DB[(SQL Server / LocalDB)]
```

## Layers
1. **Presentation**: ASP.NET Core Razor Pages (`Pages/Action/`, `Pages/Members/`, `Pages/Employees/`, `Pages/Admins/`).
2. **Business Services**: Enforces membership durations, attendance logs, and locker rentals.
3. **Data Layer**: Entity Framework Core DbContext mapping Code-First domain models.
