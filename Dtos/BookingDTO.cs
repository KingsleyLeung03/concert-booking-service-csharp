namespace concert_booking_service_csharp.Dtos
{
    public class BookingDTO
    {
        public long concertId { get; set; }
        public DateTime date { get; set; }
        public List<SeatDTO> seats { get; set; }

    }
}
