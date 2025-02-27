namespace ELEKTRA.DataAccess.Models
{
    // TODO add when the calculation was made
    public class Calculation
    {
        public long Id { get; set; }

        public required long DeviceId { get; set; }  // Required foreign key property

        public Device Device { get; set; } // Required reference navigation to parent

        public required double ElectricityCost { get; set; }
        
        public required double DailyCost { get; set; }
    }
}
