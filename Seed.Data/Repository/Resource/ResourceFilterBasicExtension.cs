using Seed.Domain.Entitys;
using Seed.Domain.Filter;
using System.Linq;

namespace Seed.Data.Repository
{
    public static class ResourceFilterBasicExtension
    {

        public static IQueryable<Resource> WithBasicFilters(this IQueryable<Resource> queryBase, ResourceFilter filters)
        {
            var queryFilter = queryBase;

			if (filters.Ids.IsSent()) queryFilter = queryFilter.Where(_ => filters.GetIds().Contains(_.ResourceId));

            if (filters.ResourceId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.ResourceId == filters.ResourceId);
			}
            if (filters.Group.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Group.Contains(filters.Group));
			}
            if (filters.Culture.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Culture.Contains(filters.Culture));
			}
            if (filters.key.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.key.Contains(filters.key));
			}
            if (filters.value.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.value.Contains(filters.value));
			}


            return queryFilter;
        }

		
    }
}