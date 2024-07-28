using concert_booking_service_csharp.Models;

namespace concert_booking_service_csharp.Data
{
    public interface IServiceRepo
    {
        // Admin
        IEnumerable<Admin> GetAllAdmins();
        Admin GetAdminByUserName(string userName);
        Admin AddAdmin(Admin admin);
        Admin UpdateAdmin(Admin admin);
        void DeleteAdmin(Admin admin);

        // Booking
        IEnumerable<Booking> GetAllBookings();
        Booking GetBookingById(long bookingId);
        IEnumerable<Booking> GetBookingsByUserId(long userId);
        IEnumerable<Booking> GetBookingsByConcertId(long concertId);
        IEnumerable<Booking> GetBookingsByDate(DateTime date);
        Booking AddBooking(Booking booking);
        Booking UpdateBooking(Booking booking);
        void DeleteBooking(Booking booking);

        // Concert
        IEnumerable<Concert> GetAllConcerts();
        Concert GetConcertById(long concertId);
        IEnumerable<Concert> GetConcertsByTitle(string title);
        IEnumerable<Concert> GetConcertsByBlurb(string blurb);
        IEnumerable<Concert> GetConcertsBySearch(string search);
        Concert GetConcertByDate(DateTime date);
        Concert GetConcertByConcertDate(long concertDateId);
        IEnumerable<Concert> GetConcertsByPerformer(long performerId);
        Concert AddConcert(Concert concert);
        Concert UpdateConcert(Concert concert);
        void DeleteConcert(Concert concert);

        // ConcertDate
        IEnumerable<ConcertDate> GetAllConcertDates();
        ConcertDate GetConcertDateById(long concertDateId);
        IEnumerable<ConcertDate> GetConcertDatesByConcert(long concertId);
        ConcertDate GetConcertDateByDate(DateTime date);
        Concert AddConcertDate(ConcertDate concertDate);
        Concert UpdateConcertDate(ConcertDate concertDate);
        void DeleteConcertDate(ConcertDate concertDate);

        // Performer
        IEnumerable<Performer> GetAllPerformers();
        Performer GetPerformerById(long performerId);
        IEnumerable<Performer> GetPerformersByName(string name);
        IEnumerable<Performer> GetPerformersByGenre(string genre);
        IEnumerable<Performer> GetPerformersByBlurb(string blurb);
        IEnumerable<Performer> GetPerformersBySearch(string search);
        IEnumerable<Performer> GetPerformersByConcert(long concertId);
        Performer AddPerformer(Performer performer);
        Performer UpdatePerformer(Performer performer);
        void DeletePerformer(Performer performer);

        // Seat
        IEnumerable<Seat> GetAllSeats();
        Seat GetSeatById(long seatId);
        IEnumerable<Seat> GetSeatsByDate(DateTime date);
        Seat GetSeatByDateLabel(DateTime date,  string label);
        IEnumerable<Seat> GetSeatsByDateIsBooked(DateTime date, Boolean isBooked);
        IEnumerable<Seat> GetSeatsByBooking(long bookingId);
        Seat AddSeat(Seat seat);
        Seat UpdateSeat(Seat seat);
        void DeleteSeat(Seat seat);

        // User
        IEnumerable<User> GetAllUsers();
        User GetUserByUserName(string userName);
        User AddUser(User user);
        User UpdateUser(User user);
        void DeleteUser(User user);

        // Make Booking
        Booking MakeBooking(Booking booking, List<Seat> seats);

        // Authentication
        bool ValidUserLogin(string userName, string password);
        bool ValidAdminLogin(string userName, string password);

    }
}
