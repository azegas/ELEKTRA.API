namespace ELEKTRA.API.Models
{
    // TODO add when the calculation was made
    public class Calculation
    {
        public int Id { get; set; }
        public required string DeviceName { get; set; }
        public required double ElectricityCost { get; set; }
        public required double Watt { get; set; }
        public required double DailyCost { get; set; }

    }
}
