using AutoMapper;
using DomainModelDesigner.Designer.Dtos;
using DomainModelDesigner.Designer.Entities;

namespace DomainModelDesigner.Designer
{
    public class DesignerApplicationAutoMapperProfile : Profile
    {
        public DesignerApplicationAutoMapperProfile()
        {
            CreateMap<CreateAppInputDtoDetail, DomainEntity>()
                .ForMember(p=>p.Id,opts=> opts.Ignore());

            CreateMap<CreateAppInputDto, AppAggRoot>()
                .ForMember(t => t.AppName,opts=> {
                    opts.MapFrom(s => s.Name);
                })
                .ForMember(p=>p.Id,ops=> { ops.Ignore(); })
                .ForMember(p => p.ExtraProperties, ops => { ops.Ignore(); })
                .ForMember(p => p.DomainEntities, ops => { ops.Ignore(); })
                .ForMember(p => p.ConcurrencyStamp, ops => { ops.Ignore(); });

            CreateMap<DomainEntity, SearchAppOutputDtoDetail>();


            //CreateMap<UpdateAppInputDto, AppAggRoot>()
            //    .ForMember(t => t.AppName, opts => {
            //        opts.MapFrom(s => s.Name);
            //    })
            //     .ForMember(t => t.Id, opts => {
            //         opts.MapFrom(s => s.Id);
            //     })
            //    .ForMember(p => p.ExtraProperties, ops => { ops.Ignore(); })
            //     .ForMember(p => p.DomainEntities, ops => { ops.Ignore(); })
            //   .ForMember(p => p.ConcurrencyStamp, ops => { ops.Ignore(); });
        }
    }
}