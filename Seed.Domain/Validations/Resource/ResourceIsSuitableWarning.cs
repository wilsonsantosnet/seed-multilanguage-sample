using Common.Validation;
using Seed.Domain.Entitys;
using Seed.Domain.Interfaces.Repository;
using System;

namespace Seed.Domain.Validations
{
    public class ResourceIsSuitableWarning : WarningSpecification<Resource>
    {
        public ResourceIsSuitableWarning(IResourceRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Resource>(Instance of suitable warning specification,"message for user"));
        }

    }
}
