using concert_booking_service_csharp.Models;

namespace concert_booking_service_csharp.Data
{
    public interface IServiceRepo
    {
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
        IEnumerable<Concert> GetConcertsByTitleOrBlurbOrPerformer(string titleOrBlurbOrPerformer);
        Concert GetConcertByDate(DateTime date);
        Concert GetConcertByConcertDate(long concertDateId);
        IEnumerable<Concert> GetConcertsByPerformer(long performerId);
        Concert AddConcert(Concert concert);
        Concert UpdateConcert(Concert concert);
        void DeleteConcert(Concert concert);

        // ConcertDate
        IEnumerable<ConcertDate> GetAllConcertDates();
        ConcertDate GetConcertDateById(long concertDateId);
        IEnumerable<ConcertDate> GetConcertDatesByConcert(Concert concert);
        ConcertDate GetConcertDateByDate(DateTime date);
        // Performer

        // Seat

        // User
        IEnumerable<User> GetAllUsers();
        User GetUserByUserName(string userName);
        User AddUser(User user);
        
    }
}
