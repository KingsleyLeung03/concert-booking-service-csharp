using concert_booking_service_csharp.Enums;
using System.Xml.Linq;

namespace concert_booking_service_csharp.Dtos
{
    public class PerformerDTO : IComparable<PerformerDTO>
    {
        public long performerId { get; set; }
        public string name { get; set; }
        public string imageName { get; set; }
        public Genre genre { get; set; }
        public string blurb { get; set; }

        public override bool Equals(object obj)
        {
            if (this == obj) return true;

            if (obj == null || GetType() != obj.GetType()) return false;

            PerformerDTO other = (PerformerDTO)obj;

            return performerId == other.performerId &&
                   name == other.name &&
                   imageName == other.imageName &&
                   genre == other.genre;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(performerId, name, imageName, genre);
        }

        public int CompareTo(PerformerDTO other)
        {
            return other.name.CompareTo(name);
        }
    }
}
