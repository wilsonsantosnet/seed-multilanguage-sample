using Common.Domain.Model;
using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class ResourceFilterCustomExtension
    {

        public static IQueryable<Resource> WithCustomFilters(this IQueryable<Resource> queryBase, ResourceFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<Resource> WithLimitTenant(this IQueryable<Resource> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

