using AutoMapper;
using LoanManagementSystem.API.Models;
using LoanManagementSystem.API.DTOs;
namespace LoanManagementSystem.API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Model → DTO
            CreateMap<Loan, LoanDto>();

// DTO → Model
            CreateMap<LoanCreateDto, Loan>();
            CreateMap<LoanUpdateDto, Loan>();
        }
    }
}
