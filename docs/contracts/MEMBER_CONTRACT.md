# Member Domain Model Contract Specification

```csharp
public class MemberContract
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime JoinDate { get; set; }
    public int? AssignedTrainerId { get; set; }
}
```
