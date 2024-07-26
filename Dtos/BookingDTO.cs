namespace concert_booking_service_csharp.Dtos
{
    public class BookingDTO
    {
        public long ConcertId { get; set; }
        public DateTime Date { get; set; }
        public List<SeatDTO> Seats { get; set; }

    }
}
