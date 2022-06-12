using AutoMapper;
using Planetas.API.Models;
using Planetas.ApplicationCore.Dtos;
using Planetas.ApplicationCore.Helpers;

namespace Planetas.API.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<HazardousAsteroidDto, HazardousAsteroid>()
               .ForMember(vm => vm.Name, dto => dto.MapFrom(dto => dto.Name))
               .ForMember(vm => vm.Date, dto => dto.MapFrom(dto => dto.CloseApproachData.FirstOrDefault().CloseApproachDate))
               .ForMember(vm => vm.Speed, dto => dto.MapFrom(dto => dto.CloseApproachData.FirstOrDefault().RelativeVelocity.KilometersPerHour))
               .ForMember(vm => vm.Diameter, dto => dto.MapFrom(dto => AverageHelper.DecimalAverage(dto.EstimatedDiameter.Kilometers.MaxEstimatedDiameter, dto.EstimatedDiameter.Kilometers.MinEstimatedDiameter)))
               .ForMember(vm => vm.Planet, dto => dto.MapFrom(dto => dto.CloseApproachData.FirstOrDefault().OrbitingBody));
        }
    }
}
