using Seed.Domain.Entitys;
using Seed.Dto;

namespace Seed.Application.Config
{
    public class DominioToDtoProfileSeed : AutoMapper.Profile
    {

        public DominioToDtoProfileSeed()
        {
            CreateMap(typeof(Sample), typeof(SampleDto)).ReverseMap();
            CreateMap(typeof(Sample), typeof(SampleDtoSpecialized));
            CreateMap(typeof(Sample), typeof(SampleDtoSpecializedResult));
            CreateMap(typeof(Sample), typeof(SampleDtoSpecializedReport));
            CreateMap(typeof(Sample), typeof(SampleDtoSpecializedDetails));
            CreateMap(typeof(SampleType), typeof(SampleTypeDto)).ReverseMap();
            CreateMap(typeof(SampleType), typeof(SampleTypeDtoSpecialized));
            CreateMap(typeof(SampleType), typeof(SampleTypeDtoSpecializedResult));
            CreateMap(typeof(SampleType), typeof(SampleTypeDtoSpecializedReport));
            CreateMap(typeof(SampleType), typeof(SampleTypeDtoSpecializedDetails));
            CreateMap(typeof(SampleItem), typeof(SampleItemDto)).ReverseMap();
            CreateMap(typeof(SampleItem), typeof(SampleItemDtoSpecialized));
            CreateMap(typeof(SampleItem), typeof(SampleItemDtoSpecializedResult));
            CreateMap(typeof(SampleItem), typeof(SampleItemDtoSpecializedReport));
            CreateMap(typeof(SampleItem), typeof(SampleItemDtoSpecializedDetails));
            CreateMap(typeof(Resource), typeof(ResourceDto)).ReverseMap();
            CreateMap(typeof(Resource), typeof(ResourceDtoSpecialized));
            CreateMap(typeof(Resource), typeof(ResourceDtoSpecializedResult));
            CreateMap(typeof(Resource), typeof(ResourceDtoSpecializedReport));
            CreateMap(typeof(Resource), typeof(ResourceDtoSpecializedDetails));

        }

    }
}
