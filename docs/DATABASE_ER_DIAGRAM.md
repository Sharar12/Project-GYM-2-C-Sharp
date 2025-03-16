# Database ER Diagram & Table Reference

## Tables
- `Member` (Id, Name, Email, Phone, JoiningDate, ExpireDate, Amount, TrainerId, Status)
- `Employee` (Id, Name, Designation, Email, Phone, Salary)
- `Admin` (Id, Name, Password)
- `AttendanceRecord` (Id, MemberId, CheckInTime, CheckOutTime, AccessMethod, GateId)
- `LockerRental` (LockerNumber, OccupantMemberId, IsRented, RentedUntil, MonthlyRate)
- `PaymentReceipt` (Id, MemberId, ReceiptNumber, AmountPaid, Method, IssuedAt)
