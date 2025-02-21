﻿using Microsoft.EntityFrameworkCore;

namespace ELEKTRA.API.Models
{
    public class CalculationContext : DbContext
    {
        public CalculationContext(DbContextOptions<CalculationContext> options)
            : base(options)
        {
        }
        public DbSet<Calculation> Calculations { get; set; }
    }
}
