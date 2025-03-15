namespace ELEKTRA.DataAccess.Entities
{
    public class Calculation
    {
        public long Id { get; set; }

        public required string DeviceName { get; set; }

        public required double Watts { get; set; }

        public required double Kilowatts { get; set; }

        public required double ElectricityCost { get; set; }

        public required double HourlyCost { get; set; }

        public required double DailyCost { get; set; }

        public required double WeeklyCost { get; set; }

        public required double MonthlyCost { get; set; }

        public required double YearlyCost { get; set; }
    }
}
