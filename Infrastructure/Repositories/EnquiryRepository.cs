using Application.Abstractions;
using Application.Abstractions.Repositories;
using Application.DTOs;
using Domain.Entities;
using Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EnquiryRepository : IEnquiryRepository
    {
        private ITravelDBContext _dbContext;
        public EnquiryRepository(ITravelDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddEnquiry(Customer customer)
        {
            await _dbContext.Customer.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateEnquiry(Customer customer)
        {
            _dbContext.Customer.Update(customer);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Customer?> GetEnquiryById(int id)
        {
            return await _dbContext.Customer.FindAsync(id);
        }

        public async Task<List<Customer>> GetAllEnquiry()
        {
            return await _dbContext.Customer.ToListAsync();
        }

        public async Task DeleteEnquiry(int id)
        {
            var enquiry = await _dbContext.Customer.FindAsync(id);
            if (enquiry != null)
            {
                _dbContext.Customer.Remove(enquiry);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
