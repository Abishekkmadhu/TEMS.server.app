using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Presistence
{
    public class TravelDBContext : DbContext
    {
        public TravelDBContext(DbContextOptions<TravelDBContext> options)
        : base(options)
        {
        }
            
        public DbSet<Customer> Customer { get; set; }
        public DbSet<TravelDetails> TravelDetails { get; set; }
        public DbSet<CustomerPreferences> CustomerPreferences { get; set; }
        public DbSet<PackagePreference> PackagePreferences { get; set; }
        public DbSet<SpecialRequirements> SpecialRequirements { get; set; }
        public DbSet<OtherInformation> OtherInformation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId);

            modelBuilder.Entity<TravelDetails>()
                .HasKey(td => td.TravelDetailsId);

            modelBuilder.Entity<CustomerPreferences>()
                .HasKey(cp => cp.CustomerPreferencesId);

            modelBuilder.Entity<PackagePreference>()
                .HasKey(pp => pp.PackagePreferenceId);

            modelBuilder.Entity<SpecialRequirements>()
                .HasKey(sr => sr.SpecialRequirementsId);

            modelBuilder.Entity<OtherInformation>()
                .HasKey(oi => oi.OtherInformationId);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.TravelDetails)
                .WithOne(c => c.Customer)
                .HasForeignKey<TravelDetails>(c => c.CustomerId);

            modelBuilder.Entity<Customer>()
                .HasOne(cp => cp.CustomerPreferences)
                .WithOne(c => c.Customer)
                .HasForeignKey<CustomerPreferences>(cp => cp.CustomerId);

            modelBuilder.Entity<Customer>()
                .HasOne(pp => pp.PackagePreference)
                .WithOne(c => c.Customer)
                .HasForeignKey<PackagePreference>(pp => pp.CustomerId);

            modelBuilder.Entity<Customer>()
                .HasOne(sp => sp.SpecialRequirements)
                .WithOne(c => c.Customer)
                .HasForeignKey<SpecialRequirements>(sp => sp.CustomerId);

            modelBuilder.Entity<Customer>()
                .HasOne(oi => oi.OtherInformation)
                .WithOne(c => c.Customer)
                .HasForeignKey<OtherInformation>(oi => oi.CustomerId);
        }
    }
}
