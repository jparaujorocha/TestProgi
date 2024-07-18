using AutoMapper;

namespace BidCalculationTool.Services.Mapping {
    public class VehicleProfile : Profile{
        public VehicleProfile() {
            CreateMap<VehicleDto, Vehicle>()
                .ForMember(dest => dest.IdType, opt => opt.MapFrom(src => (int)src.Type))
                .ReverseMap();
        }
    }
}
