using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Seed.Domain.Entitys;

namespace Seed.Data.Map
{
    public abstract class ResourceMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Resource> type);

        public ResourceMapBase(EntityTypeBuilder<Resource> type)
        {
            
            type.ToTable("Resource");
            type.Property(t => t.ResourceId).HasColumnName("ResourceId");
           

            type.Property(t => t.Group).HasColumnName("Group").HasColumnType("varchar(50)");
            type.Property(t => t.Culture).HasColumnName("Culture").HasColumnType("varchar(6)");
            type.Property(t => t.key).HasColumnName("key").HasColumnType("varchar(150)");
            type.Property(t => t.value).HasColumnName("value").HasColumnType("varchar(150)");


            type.HasKey(d => new { d.ResourceId, }); 

			CustomConfig(type);
        }
		
    }
}