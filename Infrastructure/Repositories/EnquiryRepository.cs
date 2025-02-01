using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.DTOs;
using Domain.Entities;
using Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EnquiryRepository : IEnquiryRepository
    {
        private readonly ILogger<EnquiryRepository> _logger;
        private ITravelDBContext _dbContext;
        public EnquiryRepository(ITravelDBContext dbContext, ILogger<EnquiryRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task AddEnquiry(Customer customer)
        {
            _logger.LogInformation("REPO LOG : Adding customer enquiry.");
            await _dbContext.Customer.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateEnquiry(Customer customer)
        {
            _logger.LogInformation("REPO LOG : Updating customer enquiry.");
            _dbContext.Customer.Update(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Customer?> GetEnquiryById(int id)
        {
            _logger.LogInformation($"REPO LOG : Fetching enquiry details of ID:{id}.");
            return await _dbContext.Customer
                .AsNoTracking()
                .AsSplitQuery()
                .Include(c => c.TravelDetails)
                .Include(c => c.CustomerPreferences)
                .Include(c => c.PackagePreference)
                .Include(c => c.OtherInformation)
                .Include(c => c.SpecialRequirements)
                .FirstOrDefaultAsync(c => c.CustomerId == id);
        }

        public async Task<List<Customer>> GetAllEnquiry()
        {
            _logger.LogInformation("REPO LOG : Getting all customer enquiry.");
            return await _dbContext.Customer
                .AsNoTracking()
                .AsSplitQuery()
                .Include(c => c.TravelDetails)
                .Include(c => c.CustomerPreferences)
                .Include(c => c.PackagePreference)
                .Include(c => c.OtherInformation)
                .Include(c => c.SpecialRequirements)
                .ToListAsync();
        }

        public async Task DeleteEnquiry(int id)
        {
            _logger.LogInformation($"REPO LOG : Deleting enquiry details of ID:{id}.");
            var enquiry = await _dbContext.Customer.FindAsync(id);
            if (enquiry != null)
            {
                _dbContext.Customer.Remove(enquiry);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
