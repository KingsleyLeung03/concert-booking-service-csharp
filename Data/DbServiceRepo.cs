using concert_booking_service_csharp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

namespace concert_booking_service_csharp.Data
{
    public class DbServiceRepo : IServiceRepo
    {
        private readonly ServiceDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;

        public DbServiceRepo(ServiceDbContext dbContext, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }

        // Booking
        public IEnumerable<Booking> GetAllBookings()
        {
            IEnumerable<Booking> bookings = _dbContext.Bookings.ToList<Booking>();
            return bookings;
        }

        public Booking GetBookingById(long bookingId)
        {
            Booking booking = _dbContext.Bookings.FirstOrDefault(e => e.BookingId == bookingId);
            return booking;
        }

        public IEnumerable<Booking> GetBookingsByUserId(long userId)
        {
            IEnumerable<Booking> bookings = _dbContext.Bookings.Where(e => e.UserId == userId);
            return bookings;
        }

        public IEnumerable<Booking> GetBookingsByConcertId(long concertId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Booking> GetBookingsByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Booking AddBooking(Booking booking)
        {
            EntityEntry<Booking> e = _dbContext.Bookings.Add(booking);
            Booking b = e.Entity;
            _dbContext.SaveChanges();
            return b;
        }

        public Booking UpdateBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        public void DeleteBooking(Booking booking)
        {
            throw new NotImplementedException();
        }

        // Concert
        public IEnumerable<Concert> GetAllConcerts()
        {
            IEnumerable<Concert> concerts = _dbContext.Concerts.ToList<Concert>();
            return concerts;
        }

        public Concert GetConcertById(long concertId)
        {
            Concert concert = _dbContext.Concerts.FirstOrDefault(e => e.ConcertId == concertId);
            return concert;
        }

        public IEnumerable<Concert> GetConcertsByTitle(string title)
        {
            IEnumerable<Concert> concerts = _dbContext.Concerts.Where(e => e.Title.ToLower().Contains(title.ToLower()));
            return concerts;
        }

        public IEnumerable<Concert> GetConcertsByBlurb(string blurb)
        {
            IEnumerable<Concert> concerts = _dbContext.Concerts.Where(e => e.Blurb.ToLower().Contains(blurb.ToLower()));
            return concerts;
        }

        public IEnumerable<Concert> GetConcertsBySearch(string search)
        {
            throw new NotImplementedException();
        }

        public Concert GetConcertByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Concert GetConcertByConcertDate(long concertDateId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Concert> GetConcertsByPerformer(long performerId)
        {
            throw new NotImplementedException();
        }

        public Concert AddConcert(Concert concert)
        {
            if (concert.Performers == null || !concert.Performers.Any())
            {
                throw new InvalidOperationException();
            }
            EntityEntry<Concert> e = _dbContext.Concerts.Add(concert);
            Concert c = e.Entity;
            _dbContext.SaveChanges();
            return c;
        }

        public Concert UpdateConcert(Concert concert)
        {
            throw new NotImplementedException();
        }

        public void DeleteConcert(Concert concert)
        {
            throw new NotImplementedException();
        }


        // ConcertDate
        public IEnumerable<ConcertDate> GetAllConcertDates()
        {
            throw new NotImplementedException();
        }

        public ConcertDate GetConcertDateById(long concertDateId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ConcertDate> GetConcertDatesByConcert(long concertId)
        {
            throw new NotImplementedException();
        }

        public ConcertDate GetConcertDateByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Concert AddConcertDate(ConcertDate concertDate)
        {
            throw new NotImplementedException();
        }

        public Concert UpdateConcertDate(ConcertDate concertDate)
        {
            throw new NotImplementedException();
        }

        public void DeleteConcertDate(ConcertDate concertDate)
        {
            throw new NotImplementedException();
        }

        // Performer
        public IEnumerable<Performer> GetAllPerformers()
        {
            IEnumerable<Performer> performers = _dbContext.Performers.ToList();
            return performers;
        }

        public Performer GetPerformerById(long performerId)
        {
            Performer performer = _dbContext.Performers.FirstOrDefault(e => e.PerformerId == performerId);
            return performer;
        }

        public IEnumerable<Performer> GetPerformersByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Performer> GetPerformersByGenre(string genre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Performer> GetPerformersByBlurb(string blurb)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Performer> GetPerformersBySearch(string search)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Performer> GetPerformersByConcert(long concertId)
        {
            throw new NotImplementedException();
        }

        public Performer AddPerformer(Performer performer)
        {
            throw new NotImplementedException();
        }

        public Performer UpdatePerformer(Performer performer)
        {
            throw new NotImplementedException();
        }

        public void DeletePerformer(Performer performer)
        {
            throw new NotImplementedException();
        }

        // Seat
        public IEnumerable<Seat> GetAllSeats()
        {
            IEnumerable<Seat> seats = _dbContext.Seats.ToList<Seat>();
            return seats;
        }

        public Seat GetSeatById(long seatId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Seat> GetSeatsByDate(DateTime date)
        {
            IEnumerable<Seat> seats = _dbContext.Seats.Where(e => e.Date == date);
            return seats;
        }

        public Seat GetSeatByDateLabel(DateTime date, string label)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Seat> GetSeatsByDateIsBooked(DateTime date, Boolean isBooked)
        {
            IEnumerable<Seat> seats = _dbContext.Seats.Where(e => e.Date == date && e.IsBooked == isBooked);
            return seats;
        }

        public IEnumerable<Seat> GetSeatsByBooking(long bookingId)
        {
            throw new NotImplementedException();
        }

        public Seat AddSeat(Seat seat)
        {
            throw new NotImplementedException();
        }

        public Seat UpdateSeat(Seat seat)
        {
            throw new NotImplementedException();
        }

        public void DeleteSeat(Seat seat)
        {
            throw new NotImplementedException();
        }

        // User
        public IEnumerable<User> GetAllUsers()
        {
            IEnumerable<User> users = _dbContext.Users.ToList();
            return users;
        }

        public User GetUserByUserName(string userName)
        {
            User user = _dbContext.Users.FirstOrDefault(e => e.UserName == userName);
            return user;
        }

        public User AddUser(User user)
        {
            EntityEntry<User> e = _dbContext.Users.Add(user);
            User u = e.Entity;
            _dbContext.SaveChanges();
            return u;
        }

        public User UpdateUser(User user)
        {
            EntityEntry<User> e = _dbContext.Users.Attach(user);
            e.State = EntityState.Modified;
            User u = e.Entity;
            _dbContext.SaveChanges();
            return u;
        }

        public void DeleteUser(User user)
        {
            EntityEntry<User> e = _dbContext.Users.Attach(user);
            e.State = EntityState.Deleted;
            _dbContext.SaveChanges();
        }

        // User with hashed password
        public User AddUserHashed(string userName, string password)
        {
            User user = new User { UserName = userName, Password = password, Version = 1 };
            string hashedPassword = _passwordHasher.HashPassword(user, password);
            user.Password = hashedPassword;
            EntityEntry<User> e = _dbContext.Users.Add(user);
            User u = e.Entity;
            _dbContext.SaveChanges();
            return u;
        }

        // Authentication
        public bool ValidUserLogin(string userName, string password)
        {
            User user = _dbContext.Users.FirstOrDefault(e => e.UserName == userName);
            if (user == null)
                return false;
            else
            {
                string hashedPassword = _passwordHasher.HashPassword(user, password);
                return hashedPassword == user.Password;
            }
                
        }

        public bool ValidAdminLogin(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
