using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<TravelDetails, TravelDetailsDto>().ReverseMap();
            CreateMap<CustomerPreferences, CustomerPreferencesDto>().ReverseMap();
            CreateMap<PackagePreference, PackagePreferenceDto>().ReverseMap();
            CreateMap<SpecialRequirements, SpecialRequirementsDto>().ReverseMap();
            CreateMap<OtherInformation, OtherInformationDto>().ReverseMap();
        }
    }
}
