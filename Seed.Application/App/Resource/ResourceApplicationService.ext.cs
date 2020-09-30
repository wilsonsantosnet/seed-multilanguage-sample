using Common.Domain.Interfaces;
using Seed.Application.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using Seed.Domain.Interfaces.Services;
using Seed.Dto;
using System.Linq;
using System.Collections.Generic;
using Common.Domain.Base;
using Common.Domain.Model;
using AutoMapper;

namespace Seed.Application
{
    public class ResourceApplicationService : ResourceApplicationServiceBase
    {

        public ResourceApplicationService(IResourceService service, IUnitOfWork uow, ICache cache, CurrentUser user, IMapper mapper) :
            base(service, uow, cache, user, mapper)
        {
  
        }

        protected override System.Collections.Generic.IEnumerable<TDS> MapperDomainToResult<TDS>(FilterBase filter, PaginateResult<Resource> dataList)
        {
            return base.MapperDomainToResult<ResourceDtoSpecializedResult>(filter, dataList) as IEnumerable<TDS>;
        }


    }
}
