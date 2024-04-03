using AutoMapper;
using onlineRetail.Model;

namespace onlineRetail.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            // source,destination
            CreateMap<CreateOrder, Order>(); 
        }
    }
}
