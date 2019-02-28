using AutoMapper;
using DataAccessHive = KatlaSport.DataAccess.ProductStoreHive.StoreHive;
using DataAccessHiveSection = KatlaSport.DataAccess.ProductStoreHive.StoreHiveSection;
using DataAccessItem = KatlaSport.DataAccess.ProductStore.StoreItem;

namespace KatlaSport.Services.HiveManagement
{
    public sealed class HiveManagementMappingProfile : Profile
    {
        public HiveManagementMappingProfile()
        {
            CreateMap<DataAccessHive, HiveListItem>();
            CreateMap<DataAccessHive, Hive>();
            CreateMap<DataAccessHiveSection, HiveSectionListItem>();
            CreateMap<DataAccessHiveSection, HiveSection>();
            CreateMap<DataAccessItem, HiveSectionProduct>();
            CreateMap<UpdateHiveRequest, DataAccessHive>().ForMember(r => r.LastUpdated, opt => opt.MapFrom(p => System.DateTime.UtcNow));
            CreateMap<UpdateHiveSectionRequest, DataAccessHiveSection>()
                .ForMember(r => r.LastUpdated, opt => opt.MapFrom(p => System.DateTime.UtcNow));
            CreateMap<UpdateHiveSectionProductRequest, DataAccessItem>();
        }
    }
}
