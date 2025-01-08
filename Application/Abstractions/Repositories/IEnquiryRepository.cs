using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Repositories
{
    public interface IEnquiryRepository
    {
        Task AddEnquiry(Customer customer);
        Task UpdateEnquiry(Customer customer);
        Task<Customer?> GetEnquiryById(int id);
        Task<List<Customer>> GetAllEnquiry();
        Task DeleteEnquiry(int id);
    }
}
