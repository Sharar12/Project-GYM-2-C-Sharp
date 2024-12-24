# Admin Authentication & Access Contract

```csharp
public class AdminContract
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string PasswordHash { get; set; }
    public string SecurityRole { get; set; } // SuperAdmin, Manager, Auditor
}
```
