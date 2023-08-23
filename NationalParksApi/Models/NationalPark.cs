namespace NationalParksApi.Models
{
    public class NationalPark
    {
        public int NationalParkId { get; set; }
        public string Name { get; set; }
        public DateOnly Established { get; set; }
        public float Area { get; set; }
        public int Visitors { get; set; }
        public string Description { get; set; }
        public string States { get; set; }
        public string Coordinates { get; set; }
    }
}