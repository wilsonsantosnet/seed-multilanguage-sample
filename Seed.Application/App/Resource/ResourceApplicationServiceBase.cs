using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Dto;
using Seed.Application.Interfaces;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using Seed.Domain.Interfaces.Services;
using Seed.Dto;
using System.Threading.Tasks;
using Common.Domain.Model;
using System.Collections.Generic;
using AutoMapper;

namespace Seed.Application
{
    public class ResourceApplicationServiceBase : ApplicationServiceBase<Resource, ResourceDto, ResourceFilter>, IResourceApplicationService
    {
        protected readonly ValidatorAnnotations<ResourceDto> _validatorAnnotations;
        protected readonly IResourceService _service;
        protected readonly CurrentUser _user;

        public ResourceApplicationServiceBase(IResourceService service, IUnitOfWork uow, ICache cache, CurrentUser user, IMapper mapper) :
            base(service, uow, cache, mapper, user)
        {
            base.SetTagNameCache("Resource");
            this._validatorAnnotations = new ValidatorAnnotations<ResourceDto>();
            this._service = service;
			this._user = user;
        }

       protected override async Task<Resource> MapperDtoToDomain<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as ResourceDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = this._service.GetNewInstance(_dto, this._user);
				return domain;
			});
        }

		protected override async Task<IEnumerable<Resource>> MapperDtoToDomain<TDS>(IEnumerable<TDS> dtos)
        {
			var domains = new List<Resource>();
			foreach (var dto in dtos)
			{
				var _dto = dto as ResourceDtoSpecialized;
				this._validatorAnnotations.Validate(_dto);
				this._serviceBase.AddDomainValidation(this._validatorAnnotations.GetErros());
				var domain = await this._service.GetNewInstance(_dto, this._user);
				domains.Add(domain);
			}
			return domains;
			
        }


        protected override async Task<Resource> AlterDomainWithDto<TDS>(TDS dto)
        {
			return await Task.Run(() =>
            {
				var _dto = dto as ResourceDto;
				var domain = this._service.GetUpdateInstance(_dto, this._user);
				return domain;
			});
        }



    }
}
