using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class ResourceOrderCustomExtension
    {

        public static IQueryable<Resource> OrderByDomain(this IQueryable<Resource> queryBase, ResourceFilter filters)
        {
            return queryBase.OrderBy(_ => _.ResourceId);
        }

    }
}

