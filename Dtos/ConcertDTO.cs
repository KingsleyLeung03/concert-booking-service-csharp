namespace concert_booking_service_csharp.Dtos
{
    public class ConcertDTO
    {
        public long concertId {get; set;}
        public string title {get; set;}
        public string imageName {get; set;}
        public string blurb {get; set;}
        public List<DateTime> dates {get; set;}
        public List<PerformerDTO> performers {get; set;}

    }
}
