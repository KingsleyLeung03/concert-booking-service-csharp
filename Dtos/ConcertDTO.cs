namespace concert_booking_service_csharp.Dtos
{
    public class ConcertDTO
    {
        public long ConcertId {get; set;}
        public string Title {get; set;}
        public string ImageName {get; set;}
        public string Blurb {get; set;}
        public List<DateTime> Dates {get; set;}
        public List<PerformerDTO> Performers {get; set;}

    }
}
