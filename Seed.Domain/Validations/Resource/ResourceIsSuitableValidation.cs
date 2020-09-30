using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class ResourceIsSuitableValidation : ValidatorSpecification<Resource>
    {
        public ResourceIsSuitableValidation(IResourceRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Resource>(Instance of is suitable,"message for user"));
        }

    }
}
