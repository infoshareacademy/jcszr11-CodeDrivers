using AutoMapper;
using CodeDriversMVC.Helpers;
using CodeDriversMVC.Models;

namespace CodeDriversMVC.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReservationViewModel, ReservationRequestModel>()
                .ForMember(dest => dest.TotalReservationPrice, opt => opt.MapFrom(model => PriceCalculationHelper.CalculateTotalPrice(model.ReservationFrom, model.ReservationTo, model.PricePerDay)));
            CreateMap<ReservationRequestModel, ReservationResultModel>();

        }
    }
}
