namespace ELEKTRA.DataAccess.Models
{
    public class Device
    {
        public long Id { get; set; }

        public required string DeviceName { get; set; }

        public required double Watt { get; set; }
        public Calculation? Calculation { get; set; } // Reference navigation to child
    }
}
