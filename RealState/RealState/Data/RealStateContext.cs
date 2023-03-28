using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RealState.Models;

namespace RealState.Data
{
    public class RealStateContext : DbContext
    {
        public RealStateContext (DbContextOptions<RealStateContext> options)
            : base(options)
        {
        }
        
        public DbSet<RealState.Models.Inscription> Inscription { get; set; } = default!;

        public DbSet<RealState.Models.Cne> Cne { get; set; } = default!;
        
        public DbSet<RealState.Models.Localization> Localization { get; set; } = default!;
        
        public DbSet<RealState.Models.Enajenante> Enajenante { get; set; } = default!;
        
        public DbSet<RealState.Models.Adquiriente> Adquiriente { get; set; } = default!;
    }
}
