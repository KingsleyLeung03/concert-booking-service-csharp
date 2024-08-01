# Concert Booking Service  
By Kingsley Leung (Zihong Liang)  

A concert booking service, using C# and ASP.NET.  

## Description  
This is a booking service for a venue. The venue has 15 seats with three rows and five columns. The venue's seats are classified into two price bands ($120 and $80).  
A concert can happen on different dates, and each concert has at least one performer. A performer can be in many concerts.  
The service lets clients get information about concerts and performers, ask about seats and reservations, and log in.  
When making a reservation, clients can ask about available seats. They should know which seats are free and their prices. Clients can choose any number of seats to book. Double-bookings are not allowed. Only one client can book a seat for a concert on a specific date. Clients must book all their selected seats or none at all.  
Clients can see concert and performer information and ask about available seats, whether they are logged in or not. When logged in, clients can make reservations and see their own reservations. Clients cannot see other guests’ reservation information.  

## Implementation Checklist
- [x] Domain Model  
- [x] Authentication and Authorisation  
- [x] User Registration and Login  
- [x] Get Performer by ID  
- [x] Get All Performers  
- [x] Get Concert by ID  
- [x] Get All Concerts  
- [x] Get All Concerts Summary (Intended to be used when not all info is required)  
- [x] Add Booking for Current User  
- [x] Get All Booking for Current User  
- [x] Get Booking by ID  
- [x] Get Seats for a Specific Date with Status Condition  
- [ ] Admin Features  
- [ ] Async  
- ... more will be added later.

## Endpoints  
- `POST /concert-service/Register`. Register a new `User`. The body of the HTTP request message must contain `userName` and `password`. The HTTP response message should have a status code of either 200 or 400, depending on whether the `User` is created.  
- `POST /concert-service/TestAuth`. Login to a `User`. The HTTP response message should have a status code of either 200 or 401, depending on whether the `User` is successfully logged in.  
- `GET /concert-service/Performers`. Retrieves all `Performer`. The HTTP response message should have a status code of 200.  
- `GET /concert-service/Performers/{id}`. Retrieves a representation of a `Performer` by its unique id. The HTTP response message should have a status code of either 200 or 404, depending on whether the specific `Performer` is found.  
- `GET /concert-service/Concerts`. Retrieves all `Concert`. The HTTP response message should have a status code of 200.  
- `GET /concert-service/Concerts/{id}`. Retrieves a representation of a `Concert` by its unique id.  The HTTP response message should have a status code of either 200 or 404, depending on whether the specific `Concert` is found.  
- `GET /concert-service/Concerts/Summaries`. Retrieves the summarisation of all `Concert`. It can be used when not all info is required, like the home page. The HTTP response message should have a status code of 200.  
- `POST /concert-service/Bookings`. Create a new `Booking` using the current user. This interface is only accessible to an existing `User`. The body of the HTTP request message must contain `concertId`, `date` and `seatLabels`. The date should be in this format: `YYYY-MM-DDTHH:MM:SS`. The HTTP response message should have a status code of either 201, 400, 401 or 403. 
-- If the booking is created, the status code should be 201. 
-- If there's any format issue, the status code should be 400. 
-- If there's no existing `User`, the status code should be 401.
-- If one of the seats is already booked, the status code should be 403.  
- `GET /concert-service/Bookings`. Retrieves all bookings under the current user. This interface is only accessible to an existing `User`. The HTTP response message should have a status code of either 200 or 401, depending on whether the account is successfully logged in.  
- `GET /concert-service/Bookings/{id}`. Retrieves a representation of a `Booking` by its unique id. This interface is only accessible to an existing `User`. The HTTP response message should have a status code of either 200, 400 or 401.  
-- If the requested `Booking` is under the existing `User`, the status code should be 200.  
-- If the requested `Booking` is not found, the status code should be 400.  
-- If the requested `Booking` is not under the existing `User`, or there's no existing `User`, the status code should be 401.  
- `GET /concert-service/Seats/{date}?status={status}`. Retrieves all seats that match the specified date and specified booking status. The date should be in this format: `YYYY-MM-DDTHH:MM:SS`. The booking status should be one of them: `Unbooked`, `Booked`, `Any`. The HTTP response message should have a status code of either 200 or 400, depending on whether the date and booking status format are correct.  

- ... more will be added later.

## Domain Model Design
This diagram is created by DbVisualizer from DbVis Software.  
![concert-booking-service-csharp-erdiagram](https://github.com/user-attachments/assets/80c28041-debb-4260-b20e-3666a5c4c032)

## Test
Two users are already created for testing.  
- User 1  
UserName: `testuser`  
Password: `pa55word`  
- User 2  
UserName: `testuser2`  
Password: `pa55word`  
