using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface ITravelDBContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<TravelDetails> TravelDetails { get; set; }
        public DbSet<CustomerPreferences> CustomerPreferences { get; set; }
        public DbSet<PackagePreference> PackagePreferences { get; set; }
        public DbSet<SpecialRequirements> SpecialRequirements { get; set; }
        public DbSet<OtherInformation> OtherInformation { get; set; }

        Task<int> SaveChangesAsync ( CancellationToken cancellationToken = default );
    }
}
