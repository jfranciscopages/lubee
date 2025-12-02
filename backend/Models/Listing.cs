namespace lubee.Models
{
    public class Listing
    {
        public int Id { get; set; }
        public string PropertyType { get; set; }
        public string OperationType { get; set; }
        public string Description { get; set; }
        public int Rooms { get; set; }
        public double SquareMeters { get; set; }
        public int Age { get; set; }
        public string Coordinates { get; set; }
        public List<string> Images { get; set; } = new();
    }
}
