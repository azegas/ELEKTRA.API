using ELEKTRA.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ELEKTRA.API.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CalculationContext context)
        {
            // Ensure the database is created and migrations are applied
            context.Database.Migrate();

            // Check if there are any existing entries
            if (context.Calculations.Any())
            {
                return; // DB has been seeded already
            }

            // Create sample data
            var calculations = new List<Calculation>
            {
                new Calculation { DeviceName = "Laptop", ElectricityCost = 0.15, Watt = 60, DailyCost = 0.09 },
                new Calculation { DeviceName = "TV", ElectricityCost = 0.20, Watt = 100, DailyCost = 0.24 },
                new Calculation { DeviceName = "Fridge", ElectricityCost = 0.12, Watt = 150, DailyCost = 0.43 },
                new Calculation { DeviceName = "Washing Machine", ElectricityCost = 0.18, Watt = 500, DailyCost = 2.16 },
                new Calculation { DeviceName = "Air Conditioner", ElectricityCost = 0.25, Watt = 2000, DailyCost = 12.00 }
            };

            // Add to database
            context.Calculations.AddRange(calculations);
            context.SaveChanges();
        }
    }
}
