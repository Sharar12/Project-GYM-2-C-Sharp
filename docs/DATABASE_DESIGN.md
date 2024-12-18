# Database Architecture & Entity Relationships

```text
+----------------+          +-------------------+          +-----------------+
|     Member     | 1      * | MembershipRecord  | *      1 |  MembershipPlan |
|----------------|<-------->|-------------------|--------->|-----------------|
| MemberID (PK)  |          | RecordID (PK)     |          | PlanID (PK)     |
| FullName       |          | MemberID (FK)     |          | PlanName        |
| Email          |          | StartDate         |          | MonthlyFee      |
| Phone          |          | EndDate           |          | TierLevel       |
+----------------+          +-------------------+          +-----------------+
        | 1
        | *
+----------------+
| AttendanceLog  |
+----------------+
```
