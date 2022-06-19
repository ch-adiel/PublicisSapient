using PublicisSapient.Models;
using PublicisSapient.Models.ViewModels;
using AutoMapper;

namespace PublicisSapient.Profiles
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<CreditCardRequestModel, CreditCard>();
            CreateMap<CreditCard, CreditCardRequestModel>();
        }
    }
}
