using concert_booking_service_csharp.Data;
using concert_booking_service_csharp.Dtos;
using concert_booking_service_csharp.Enums;
using concert_booking_service_csharp.Models;
using concert_booking_service_csharp.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace concert_booking_service_csharp.Controllers
{
    [Route("concert-service")]
    [ApiController]

    public class ServiceController : Controller
    {
        private readonly IServiceRepo _repository;
        
        public ServiceController(IServiceRepo repository)
        {
            _repository = repository;
        }

        [HttpPost("Register")]
        public ActionResult<string> Register(UserDTO input)
        {
            if (_repository.GetUserByUserName(input.UserName) == null)
            {
                //User user = _repository.AddUserHashed(input.userName, input.password);
                PasswordHasherUtil.CreatePasswordHash(input.Password, out byte[] passwordHash, out byte[] passwordSalt);
                User user = new User { UserName = input.UserName, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Version = 1 };
                User addedUser = _repository.AddUser(user);
                return Ok($"User {input.UserName} successfully registered.");
            }
            else
            {
                return BadRequest("UserName " + input.UserName + " is not available.");
            }
        }

        [Authorize(AuthenticationSchemes = "Authentication")]
        [Authorize(Policy = "UserOnly")]
        [HttpPost("TestAuth")]
        public ActionResult<string> Login()
        {
            return Ok("Login successful");
        }

        [HttpGet("Performers")]
        public ActionResult GetAllPerformers()
        {
            IEnumerable<Performer> performers = _repository.GetAllPerformers();
            List<PerformerDTO> performerDTOs = new List<PerformerDTO>();
            foreach (Performer performer in performers)
            {
                performerDTOs.Add(new PerformerDTO 
                { 
                    PerformerId = performer.PerformerId, 
                    Name = performer.Name, 
                    ImageName = performer.ImageName, 
                    Genre = performer.Genre.ToString(), 
                    Blurb = performer.Blurb 
                });
            }
            return Ok(performerDTOs);
        }

        [HttpGet("Performers/{id}")]
        public ActionResult GetPerformerById(int id)
        {
            Performer performer = _repository.GetPerformerById(id);
            if (performer != null)
            {
                PerformerDTO performerDTO = new PerformerDTO 
                { 
                    PerformerId = performer.PerformerId, 
                    Name = performer.Name, 
                    ImageName = performer.ImageName, 
                    Genre = performer.Genre.ToString(), 
                    Blurb = performer.Blurb 
                };
                return Ok(performerDTO);
            }
            return NotFound("Performer " + id + " does not exist.");
        }

        [HttpGet("Concerts")]
        public ActionResult GetAllConcerts()
        {
            IEnumerable<Concert> concerts = _repository.GetAllConcerts();
            List<ConcertDTO> concertDTOs = new List<ConcertDTO>();
            foreach (Concert concert in concerts)
            {
                ICollection<ConcertDate> concertDates = concert.ConcertDates;
                List<DateTime> dates = new List<DateTime>();
                foreach (ConcertDate concertDate in concertDates)
                {
                    dates.Add(concertDate.Date);
                }

                ICollection<Performer> performers = concert.Performers;
                List<PerformerDTO> performerDTOs = new List<PerformerDTO>();
                foreach (Performer performer in performers)
                {
                    performerDTOs.Add(new PerformerDTO
                    {
                        PerformerId = performer.PerformerId,
                        Name = performer.Name,
                        ImageName = performer.ImageName,
                        Genre = performer.Genre.ToString(),
                        Blurb = performer.Blurb
                    });
                }

                ConcertDTO concertDTO = new ConcertDTO
                {
                    ConcertId = concert.ConcertId,
                    Title = concert.Title,
                    ImageName = concert.ImageName,
                    Blurb = concert.Blurb,
                    Dates = dates,
                    Performers = performerDTOs
                };
                concertDTOs.Add(concertDTO);
            }
            return Ok(concertDTOs);
        }

        [HttpGet("Concerts/{id}")]
        public ActionResult GetConcertById(long id)
        {
            Concert concert = _repository.GetConcertById(id);
            if (concert != null)
            {
                ICollection<ConcertDate> concertDates = concert.ConcertDates;
                List<DateTime> dates = new List<DateTime>();
                foreach (ConcertDate concertDate in concertDates)
                {
                    dates.Add(concertDate.Date);
                }

                ICollection<Performer> performers = concert.Performers;
                List<PerformerDTO> performerDTOs = new List<PerformerDTO>();
                foreach (Performer performer in performers)
                {
                    performerDTOs.Add(new PerformerDTO 
                    { 
                        PerformerId = performer.PerformerId, 
                        Name = performer.Name, 
                        ImageName = performer.ImageName, 
                        Genre = performer.Genre.ToString(), 
                        Blurb = performer.Blurb 
                    });
                }

                ConcertDTO concertDTO = new ConcertDTO 
                { 
                    ConcertId = concert.ConcertId, 
                    Title = concert.Title, 
                    ImageName = concert.ImageName, 
                    Blurb = concert.Blurb, 
                    Dates = dates,
                    Performers = performerDTOs
                };
                return Ok(concertDTO);
            }
            return NotFound("Concert " + id + " does not exist.");
        }

        [HttpGet("Concerts/Summaries")]
        public ActionResult GetConcertSummaries()
        {
            IEnumerable<Concert> concerts = _repository.GetAllConcerts();
            List<ConcertSummaryDTO> concertSummaryDTOs = new List<ConcertSummaryDTO>();
            foreach(Concert concert in concerts)
            {
                concertSummaryDTOs.Add(new ConcertSummaryDTO
                {
                    ConcertId = concert.ConcertId,
                    Title = concert.Title,
                    ImageName = concert.ImageName
                });
            }
            return Ok(concertSummaryDTOs);
        }

        [Authorize(AuthenticationSchemes = "Authentication")]
        [Authorize(Policy = "UserOnly")]
        [HttpPost("Bookings")]
        public ActionResult MakeBooking(BookingRequestDTO bookingRequestDTO)
        {
            ClaimsIdentity ci = HttpContext.User.Identities.FirstOrDefault();
            Claim c = ci.FindFirst("user");
            string name = c.Value;
            User user = _repository.GetUserByUserName(name);

            Concert concert = _repository.GetConcertById(bookingRequestDTO.ConcertId);
            if (concert != null)
            {
                ICollection<ConcertDate> concertDates = concert.ConcertDates;
                List<DateTime> dates = new List<DateTime>();
                foreach (ConcertDate concertDate in concertDates)
                {
                    dates.Add(concertDate.Date);
                }

                if (dates.Contains(bookingRequestDTO.Date))
                {
                    //List<Seat> seats = new List<Seat>();
                    foreach (string seatLabel in bookingRequestDTO.SeatLabels)
                    {
                        Seat seat = _repository.GetSeatByDateLabel(bookingRequestDTO.Date, seatLabel);
                        if (seat == null)
                        {
                            return BadRequest("One of the seat labels does not exist.");
                        }
                        if (seat.IsBooked == true)
                        {
                            return StatusCode(StatusCodes.Status403Forbidden, "One of the seats is already booked.");
                        }
                        //seats.Add(seat);
                    }

                    if (bookingRequestDTO.SeatLabels.Count == 0)
                    {
                        return BadRequest("Seat labels error.");
                    }

                    Booking booking = new Booking
                    {
                        UserId = user.UserId,
                        ConcertId = concert.ConcertId,
                        Date = bookingRequestDTO.Date
                    };
                    //Booking addedBooking = _repository.AddBooking(booking);
                    //foreach (Seat seat in seats)
                    //{
                    //    seat.BookingId = addedBooking.BookingId;
                    //    seat.IsBooked = true;
                    //    _repository.AddSeat(seat);
                    //}

                    Booking createdBooking = _repository.MakeBooking(booking, bookingRequestDTO.SeatLabels);
                    List<SeatDTO> seatDTOs = new List<SeatDTO>();
                    foreach (Seat seat in booking.Seats)
                    {
                        SeatDTO seatDTO = new SeatDTO
                        {
                            Label = seat.Label,
                            Price = seat.Cost
                        };
                        seatDTOs.Add(seatDTO);
                    }

                    BookingDTO bookingDTO = new BookingDTO
                    {
                        ConcertId = createdBooking.ConcertId,
                        Date = createdBooking.Date,
                        Seats = seatDTOs
                    };

                    return Created($"/concert-service/Bookings/{createdBooking.BookingId}", bookingDTO);
                }
                return BadRequest("Date does not exist.");
            }
            return BadRequest($"Concert {bookingRequestDTO.ConcertId} does not exist.");
        }

        [Authorize(AuthenticationSchemes = "Authentication")]
        [Authorize(Policy = "UserOnly")]
        [HttpGet("Bookings")]
        public ActionResult GetUserAllBookings()
        {
            ClaimsIdentity ci = HttpContext.User.Identities.FirstOrDefault();
            Claim c = ci.FindFirst("user");
            string name = c.Value;
            User user = _repository.GetUserByUserName(name);

            IEnumerable<Booking> bookings = _repository.GetBookingsByUserId(user.UserId);
            List<BookingDTO> bookingDTOs = new List<BookingDTO>();
            foreach (Booking booking in bookings)
            {
                List<SeatDTO> seatDTOs = new List<SeatDTO>();
                foreach (Seat seat in booking.Seats)
                {
                    SeatDTO seatDTO = new SeatDTO
                    {
                        Label = seat.Label,
                        Price = seat.Cost
                    };
                    seatDTOs.Add(seatDTO);
                }

                BookingDTO bookingDTO = new BookingDTO
                {
                    ConcertId = booking.ConcertId,
                    Date = booking.Date,
                    Seats = seatDTOs
                };
                bookingDTOs.Add(bookingDTO);
            }
            return Ok(bookingDTOs);
        }

        [Authorize(AuthenticationSchemes = "Authentication")]
        [Authorize(Policy = "UserOnly")]
        [HttpGet("Bookings/{id}")]
        public ActionResult GetBookingById(long id)
        {
            ClaimsIdentity ci = HttpContext.User.Identities.FirstOrDefault();
            Claim c = ci.FindFirst("user");
            string name = c.Value;
            User user = _repository.GetUserByUserName(name);

            Booking booking = _repository.GetBookingById(id);
            if (booking != null)
            {
                if (booking.User == user)
                {
                    List<SeatDTO> seatDTOs = new List<SeatDTO>();
                    foreach (Seat seat in booking.Seats)
                    {
                        SeatDTO seatDTO = new SeatDTO
                        {
                            Label = seat.Label,
                            Price = seat.Cost
                        };
                        seatDTOs.Add(seatDTO);
                    }

                    BookingDTO bookingDTO = new BookingDTO
                    {
                        ConcertId = booking.ConcertId,
                        Date = booking.Date,
                        Seats = seatDTOs
                    };
                    return Ok(bookingDTO);
                }
                return Unauthorized($"You are not the owner of the booking {id}.");
            }
            return BadRequest($"Booking {id} does not exist.");
        }

        [HttpGet("Seats/{date}")]
        public ActionResult GetSeatsByDateStatus(string date, [FromQuery] string status)
        {
            try
            {
                DateTime dateTime = DateTime.Parse(date);
                BookingStatus bookingStatus = (BookingStatus)Enum.Parse(typeof(BookingStatus), status);
                if (bookingStatus == BookingStatus.Booked || bookingStatus == BookingStatus.Unbooked)
                {
                    Boolean isBooked;
                    if (bookingStatus == BookingStatus.Booked)
                    {
                        isBooked = true;
                    }
                    else
                    {
                        isBooked = false;
                    }

                    IEnumerable<Seat> seats = _repository.GetSeatsByDateIsBooked(dateTime, isBooked);
                    List<SeatDTO> seatDTOs = new List<SeatDTO>();
                    foreach (Seat seat in seats)
                    {
                        SeatDTO seatDTO = new SeatDTO { Label = seat.Label, Price = seat.Cost };
                        seatDTOs.Add(seatDTO);
                    }
                    return Ok(seatDTOs);
                }
                else if (bookingStatus == BookingStatus.Any)
                {
                    IEnumerable<Seat> seats = _repository.GetSeatsByDate(dateTime);
                    List<SeatDTO> seatDTOs = new List<SeatDTO>();
                    foreach (Seat seat in seats)
                    {
                        SeatDTO seatDTO = new SeatDTO { Label = seat.Label, Price = seat.Cost };
                        seatDTOs.Add(seatDTO);
                    }
                    return Ok(seatDTOs);
                }
                else
                {
                    return BadRequest("Status error. \nStatus should be one of them: Unbooked, Booked, Any.");
                }

            }
            catch (Exception e) when (
            e is ArgumentNullException || 
            e is ArgumentException || 
            e is FormatException || 
            e is OverflowException || 
            e is InvalidOperationException) 
            {
                return BadRequest("Date and / or status error. \n" +
                    "Date should be in this format: YYYY-MM-DDTHH:MM:SS. \n" +
                    "Status should be one of them: Unbooked, Booked, Any.");
            }

        }
    }
}
