using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public class ResourceMap : ResourceMapBase
    {
        public ResourceMap(EntityTypeBuilder<Resource> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Resource> type)
        {

        }

    }
}