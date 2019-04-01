using AutoMapper;
using DomainModelDesigner.Designer.Dtos;
using DomainModelDesigner.Designer.Dtos.ApplicationAppService;
using DomainModelDesigner.Designer.Entities;
using DomainModelDesigner.Designer.EntityDtos;

namespace DomainModelDesigner.Designer
{
    public class DesignerApplicationAutoMapperProfile : Profile
    {
        public DesignerApplicationAutoMapperProfile()
        {
            CreateMap<CreateDomainDtoDetail, AddDomainEDtoDetail>();
            CreateMap<CreateDomainDto, AddDomainEDto>();
            

            CreateMap<DomainDto, DomainEntity>()
                .ForMember(p=>p.Id,opts=> opts.Ignore());

            //CreateMap<CreateAppInputDto, CreateAppEDto>()
            //    .ForMember(t => t.AppName, opts =>
            //    {
            //        opts.MapFrom(s => s.Name);
            //    })
            //    .ForMember(p => p.Domains, ops => ops.MapFrom(s => s.Domains));

            CreateMap<DomainEntity, AppEntityDtoDetail>();
            CreateMap<AppAggRoot, AppEntityDto>()
                .ForMember(t => t.Domains, opts => opts.MapFrom(s => s.DomainEntities));

            CreateMap<FieldEntity, FieldEntityDto>();
            CreateMap<ValueObjectAggRoot, ValueObjectEntityDto>();

        }
    }
}