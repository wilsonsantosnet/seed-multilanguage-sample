using Common.Validation;
using Seed.Domain.Entitys;
using System;

namespace Seed.Domain.Validations
{
    public class ResourceIsConsistentValidation : ValidatorSpecification<Resource>
    {
        public ResourceIsConsistentValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Resource>(Instance of is consistent specification,"message for user"));
        }

    }
}
