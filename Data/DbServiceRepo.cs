﻿using concert_booking_service_csharp.Models;
using concert_booking_service_csharp.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace concert_booking_service_csharp.Data
{
    public class DbServiceRepo : IServiceRepo
    {
        private readonly ServiceDbContext _dbContext;

        public DbServiceRepo(ServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Admin
        public IEnumerable<Admin> GetAllAdmins()
        {
            IEnumerable<Admin> admins = _dbContext.Admins.ToList();
            return admins;
        }

        public Admin GetAdminByUserName(string userName)
        {
            Admin admin = _dbContext.Admins.FirstOrDefault(e => e.UserName == userName);
            return admin;
        }

        public Admin AddAdmin(Admin admin)
        {
            EntityEntry<Admin> e = _dbContext.Admins.Add(admin);
            Admin a = e.Entity;
            _dbContext.SaveChanges();
            return a;
        }

        public Admin UpdateAdmin(Admin admin)
        {
            EntityEntry<Admin> e = _dbContext.Admins.Attach(admin);
            e.State = EntityState.Modified;
            Admin a = e.Entity;
            _dbContext.SaveChanges();
            return a;
        }

        public void DeleteAdmin(Admin admin)
        {
            EntityEntry<Admin> e = _dbContext.Admins.Attach(admin);
            e.State = EntityState.Deleted;
            _dbContext.SaveChanges();
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
            Seat seat = _dbContext.Seats.FirstOrDefault(e => e.Date == date && e.Label == label);
            return seat;
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
            EntityEntry<Seat> e = _dbContext.Seats.Attach(seat);
            e.State = EntityState.Modified;
            Seat s = e.Entity;
            _dbContext.SaveChanges();
            return s;
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

        // Make Booking

        public Booking MakeBooking(Booking booking, List<string> seatLabels)
        {
            //EntityEntry<Booking> bE = _dbContext.Bookings.Add(booking);
            //Booking b = bE.Entity;

            //foreach (string seatLabel in seatLabels)
            //{
            //    Seat seat = _dbContext.Seats.FirstOrDefault(e => e.Date == booking.Date && e.Label == seatLabel);
            //    seat.BookingId = b.BookingId;
            //    seat.IsBooked = true;
            //    EntityEntry<Seat> sE = _dbContext.Seats.Attach(seat);
            //    sE.State = EntityState.Modified;
            //}

            //_dbContext.SaveChanges();
            //return b;

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    // Add the booking and save changes to get the BookingId
                    EntityEntry<Booking> bE = _dbContext.Bookings.Add(booking);
                    _dbContext.SaveChanges(); // Save here to ensure BookingId is generated
                    Booking b = bE.Entity;

                    // Create a savepoint after saving the booking
                    transaction.CreateSavepoint("AfterBookingSave");

                    // Fetch all relevant seats in a single query
                    var seats = _dbContext.Seats
                        .Where(e => e.Date == booking.Date && seatLabels.Contains(e.Label))
                        .ToList();

                    foreach (var seat in seats)
                    {
                        if (seat != null)
                        {
                            seat.BookingId = b.BookingId;
                            seat.IsBooked = true;
                            _dbContext.Entry(seat).State = EntityState.Modified;
                        }
                    }

                    _dbContext.SaveChanges();
                    transaction.Commit();
                    return b;
                }
                catch (Exception)
                {
                    // Rollback to the savepoint if updating seats fails
                    transaction.RollbackToSavepoint("AfterBookingSave");
                    transaction.Rollback();
                    throw;
                }
            }
        }

        // Authentication
        public bool ValidUserLogin(string userName, string password)
        {
            User user = _dbContext.Users.FirstOrDefault(e => e.UserName == userName);
            if (user != null)
                return PasswordHasherUtil.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
            return false;
        }

        public bool ValidAdminLogin(string userName, string password)
        {
            Admin admin = _dbContext.Admins.FirstOrDefault(e => e.UserName == userName);
            if (admin != null)
                return PasswordHasherUtil.VerifyPasswordHash(password, admin.PasswordHash, admin.PasswordSalt);
            return false;
        }
    }
}
