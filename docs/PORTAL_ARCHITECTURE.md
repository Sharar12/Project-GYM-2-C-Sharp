# Razor Pages Portal Architecture

## Access Control Matrix
| Portal Route | Public | Member | Trainer | Admin |
| :--- | :---: | :---: | :---: | :---: |
| `/Index` | Yes | Yes | Yes | Yes |
| `/Action/SignIn` | Yes | - | - | - |
| `/Action/MemberSignUp` | Yes | - | - | - |
| `/Action/MemberDashboard` | - | Yes | - | Yes |
| `/Action/EmployeeDashboard` | - | - | Yes | Yes |
| `/Admins/*` | - | - | - | Yes |
| `/Employees/*` | - | - | - | Yes |
| `/Members/*` | - | - | Yes | Yes |
