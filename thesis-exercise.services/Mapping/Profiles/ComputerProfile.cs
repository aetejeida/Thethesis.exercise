using AutoMapper;
using thesis_exercise.data;
using thesis_exercise.model.DTOs;
using thesis_exercise.model.Models;

namespace thesis_exercise.services.Mapping.Profiles
{
    public class ComputerProfile : Profile
    {
        public ComputerProfile() 
        {
            CreateMap<ComputerDTO, Computer>()
                .ForMember(des => des.ComputerUsbPorts, opt => opt.MapFrom(src => src.UsbPortsIds.Select(uId => new ComputerUsbPort { UsbPortId = uId })));
            CreateMap<Computer, ComputerDTO>()
                .ForMember(des => des.UsbPortsIds, opt => opt.MapFrom(src => src.ComputerUsbPorts.Select(uId => uId.Id).ToList()));
            CreateMap<ComputerDetail, ComputerDetailDTO>();
            CreateMap<Catalog, CatalogDTO>().ReverseMap();
            CreateMap<Catologs, CatalogsDTO>().ReverseMap();
        }
    }
}
