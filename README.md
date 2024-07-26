# Concert Booking Service  
Kingsley Leung  

A concert booking service, using C# and ASP.NET.  

## Description  
This is a booking service for a venue.  
A concert can happen on different dates, and each concert has at least one performer. A performer can be in many concerts.  
The service lets clients get information about concerts and performers, ask about seats and reservations, and log in.  
When making a reservation, clients can ask about available seats. They should know which seats are free and their prices. Clients can choose any number of seats to book. Double-bookings are not allowed. Only one client can book a seat for a concert on a specific date. Clients must book all their selected seats or none at all.  
Clients can see concert and performer information and ask about available seats, whether they are logged in or not. When logged in, clients can make reservations and see their own reservations. Clients cannot see other guests’ reservation information.  

## Implementation Checklist
- [x] Domain Model
- [x] Authentication and Authorisation
- [x] User Registration and Login
- [ ] Get Performer by ID
- [ ] Get All Performers
- [ ] Get Concert by ID
- [ ] Get All Concerts
- [ ] Get All Concerts Summary (Intended to be used when not all info is requred)
- [ ] Add Booking for Current User
- [ ] Get All Booking for Current User
- [ ] Get Booking by ID
- [ ] Get Seats for a Specific Date with Status Condition
- [ ] Admin Features
... more will be add later.

## Endpoints  
- `POST /concert-service/Register`. Register a new user account. UserName and Password are required. The HTTP response message should have a status code of either 200 or 400, depending on whether the account is created.  
- `POST /concert-service/TestAuth`. Login to a user account. The HTTP response message should have a status code of either 200 or 401, depends on whether the account is successfully logged in.  
... more will be add later.

## Test
A user is already created for testing.  
UserName: `test`  
Password: `pa55word`  