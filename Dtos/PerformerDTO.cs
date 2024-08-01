using concert_booking_service_csharp.Enums;
using System.Xml.Linq;

namespace concert_booking_service_csharp.Dtos
{
    public class PerformerDTO : IComparable<PerformerDTO>
    {
        public long PerformerId { get; set; }
        public string Name { get; set; }
        public string ImageName { get; set; }
        public string Genre { get; set; }
        public string Blurb { get; set; }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;

            if (obj == null || GetType() != obj.GetType()) return false;

            PerformerDTO other = (PerformerDTO)obj;

            return PerformerId == other.PerformerId &&
                   Name == other.Name &&
                   ImageName == other.ImageName &&
                   Genre == other.Genre;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PerformerId, Name, ImageName, Genre);
        }

        public int CompareTo(PerformerDTO other)
        {
            return other.Name.CompareTo(Name);
        }
    }
}
