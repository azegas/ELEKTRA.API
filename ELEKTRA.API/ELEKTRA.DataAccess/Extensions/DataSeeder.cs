using ELEKTRA.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ELEKTRA.DataAccess.Extensions
{
    public static class DataSeeder
    {
        public static void SeedData(this ElektraContext context)
        {
            // Ensure the database is created and migrations are applied
            context.Database.Migrate();

            // seed
            context.SeedDevices();
            context.SeedCalculations();
        }

        private static void SeedDevices(this ElektraContext context)
        {
            // Check if there are any existing entries
            if (context.Calculations.Any())
            {
                return; // DB has been seeded already
            }

            // Create sample data
            var devices = new List<Device>
            {
                new Device { DeviceName = "Saldytuvas", Watt = 350},
                new Device { DeviceName = "Mikrobange", Watt = 100},
                new Device { DeviceName = "Radiatorius", Watt = 50}
            };

            // Add to database
            context.Devices.AddRange(devices);
            context.SaveChanges();
        }

        private static void SeedCalculations(this ElektraContext context)
        {
            // Check if there are any existing entries
            if (context.Calculations.Any())
            {
                return; // DB has been seeded already
            }

            // Create sample data
            var calculations = new List<Calculation>
            {
                new Calculation { DeviceId = 1, DailyCost = 6, ElectricityCost = 0.20},
                new Calculation { DeviceId = 2, DailyCost = 9, ElectricityCost = 0.20},
                new Calculation { DeviceId = 3, DailyCost = 15, ElectricityCost = 0.20},
            };

            // Add to database
            context.Calculations.AddRange(calculations);
            context.SaveChanges();
        }
    }
}
