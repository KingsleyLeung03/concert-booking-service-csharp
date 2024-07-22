using concert_booking_service_csharp.Enums;

namespace concert_booking_service_csharp.Dtos
{
    public class PerformerDTO
    {
        public long performerId { get; set; }
        public string name { get; set; }
        public string imageName { get; set; }
        public Genre genre { get; set; }
        public string blurb { get; set; }
    }
}
