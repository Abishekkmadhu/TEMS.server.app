﻿using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Services
{
    public interface IEnquiryService
    {
        IEnumerable<CustomerDto> GetAllEnquiryService(List<Customer?> customers);
        Customer AddEnquiryService(CustomerDto customer);
    }
}
