using Seed.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Seed.Domain.Entitys
{
    public class Resource : ResourceBase
    {

        public Resource()
        {

        }

		 public Resource(int resourceid, string group, string culture, string key, string value) : base(resourceid, group, culture, key, value) { }


		public class ResourceFactory : ResourceFactoryBase
        {
            public Resource GetDefaultInstance(dynamic data, CurrentUser user)
            {
				return GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            base._validationResult = base._validationResult.Merge(new ResourceIsConsistentValidation().Validate(this));
            return base._validationResult.IsValid;
        }
        
    }
}
