using Common.Domain.Base;
using Common.Domain.Interfaces;
using Common.Domain.Model;
using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using Seed.Domain.Interfaces.Repository;
using Seed.Domain.Validations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Seed.Domain.Services
{
    public class ResourceServiceBase : ServiceBase<Resource>
    {
        protected readonly IResourceRepository _rep;
        protected readonly IValidatorSpecification<Resource> _validation;
        protected readonly IWarningSpecification<Resource> _warning;


        public ResourceServiceBase(IResourceRepository rep, IValidatorSpecification<Resource> validation, IWarningSpecification<Resource> warning, ICache cache, CurrentUser user)
            : base(cache)
        {
            this._rep = rep;
            this._user = user;
            this._validation = validation;
            this._warning = warning;
        }

        public virtual async Task<Resource> GetOne(ResourceFilter filters)
        {
            return await this._rep.GetById(filters);
        }

        public virtual async Task<IEnumerable<Resource>> GetByFilters(ResourceFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return await this._rep.ToListAsync(queryBase);
        }

        public virtual Task<PaginateResult<Resource>> GetByFiltersPaging(ResourceFilter filters)
        {
            var queryBase = this._rep.GetBySimplefilters(filters);
            return this._rep.PagingAndDefineFields(filters, queryBase);
        }

        public override void Remove(Resource resource)
        {
            this._rep.Remove(resource);
        }

        public virtual Summary GetSummary(PaginateResult<Resource> paginateResult)
        {
            return new Summary
            {
                Total = paginateResult.TotalCount,
				PageSize = paginateResult.PageSize,
            };
        }

        public virtual ValidationSpecificationResult GetDomainValidation(FilterBase filters = null)
        {
            return this._validationResult;
        }

        public virtual ConfirmEspecificationResult GetDomainConfirm(FilterBase filters = null)
        {
            return this._validationConfirm;
        }

        public virtual WarningSpecificationResult GetDomainWarning(FilterBase filters = null)
        {
            return this._validationWarning;
        }

        public override async Task<Resource> Save(Resource resource, bool questionToContinue = false)
        {
			var resourceOld = await this.GetOne(new ResourceFilter { ResourceId = resource.ResourceId, QueryOptimizerBehavior = "OLD" });
			var resourceOrchestrated = await this.DomainOrchestration(resource, resourceOld);

            if (questionToContinue)
            {
                if (this.Continue(resourceOrchestrated, resourceOld) == false)
                    return resourceOrchestrated;
            }

            return this.SaveWithValidation(resourceOrchestrated, resourceOld);
        }

        public override async Task<Resource> SavePartial(Resource resource, bool questionToContinue = false)
        {
            var resourceOld = await this.GetOne(new ResourceFilter { ResourceId = resource.ResourceId, QueryOptimizerBehavior = "OLD" });
			var resourceOrchestrated = await this.DomainOrchestration(resource, resourceOld);

            if (questionToContinue)
            {
                if (this.Continue(resourceOrchestrated, resourceOld) == false)
                    return resourceOrchestrated;
            }

            return SaveWithOutValidation(resourceOrchestrated, resourceOld);
        }

        protected override Resource SaveWithOutValidation(Resource resource, Resource resourceOld)
        {
            resource = this.SaveDefault(resource, resourceOld);
			this._cacheHelper.ClearCache();

			if (!resource.IsValid())
			{
				this._validationResult = resource.GetDomainValidation();
				this._validationWarning = resource.GetDomainWarning();
				return resource;
			}

            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Alterado com sucesso."
            };
            
            return resource;
        }

		protected override Resource SaveWithValidation(Resource resource, Resource resourceOld)
        {
            if (!this.IsValid(resource))
				return resource;
            
            resource = this.SaveDefault(resource, resourceOld);
            this._validationResult = new ValidationSpecificationResult
            {
                Errors = new List<string>(),
                IsValid = true,
                Message = "Inserido com sucesso."
            };

            this._cacheHelper.ClearCache();
            return resource;
        }
		
		protected virtual bool IsValid(Resource entity)
        {
            var isValid = true;
            if (!this.DataAnnotationIsValid() || !entity.IsValid())
            {
                if (this._validationResult.IsNull())
                    this._validationResult = entity.GetDomainValidation();
                else
                    this._validationResult.Merge(entity.GetDomainValidation());

                if (this._validationWarning.IsNull())
                    this._validationWarning = entity.GetDomainWarning();
                else
                    this._validationWarning.Merge(entity.GetDomainWarning());

                isValid = false;
            }

            this.Specifications(entity);
            if (!this._validationResult.IsValid)
                isValid = false;

            return isValid;
        }

		protected virtual void Specifications(Resource resource)
        {
            this._validationResult  = this._validationResult.Merge(this._validation.Validate(resource));
			this._validationWarning  = this._validationWarning.Merge(this._warning.Validate(resource));
        }

        protected virtual Resource SaveDefault(Resource resource, Resource resourceOld)
        {
			

            var isNew = resourceOld.IsNull();			
            if (isNew)
                resource = this.AddDefault(resource);
            else
				resource = this.UpdateDefault(resource);

            return resource;
        }
		
        protected virtual Resource AddDefault(Resource resource)
        {
            resource = this._rep.Add(resource);
            return resource;
        }

		protected virtual Resource UpdateDefault(Resource resource)
        {
            resource = this._rep.Update(resource);
            return resource;
        }
				
		public virtual async Task<Resource> GetNewInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Resource.ResourceFactory().GetDefaultInstance(model, user);
            });
         }

		public virtual async Task<Resource> GetUpdateInstance(dynamic model, CurrentUser user)
        {
            return await Task.Run(() =>
            {
                return new Resource.ResourceFactory().GetDefaultInstance(model, user);
            });
         }
    }
}
