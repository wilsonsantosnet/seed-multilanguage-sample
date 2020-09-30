using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Entitys
{
    public class ResourceBase : DomainBase
    {
        public ResourceBase()
        {

        }

		public ResourceBase(int resourceid, string group, string culture, string key, string value) 
        {
            this.ResourceId = resourceid;
            this.Group = group;
            this.Culture = culture;
            this.key = key;
            this.value = value;

        }


		public class ResourceFactoryBase
        {
            public virtual Resource GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new Resource(data.ResourceId,
                                        data.Group,
                                        data.Culture,
                                        data.key,
                                        data.value);



				construction.SetConfirmBehavior(data.ConfirmBehavior);
				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public virtual int ResourceId { get; protected set; }
        public virtual string Group { get; protected set; }
        public virtual string Culture { get; protected set; }
        public virtual string key { get; protected set; }
        public virtual string value { get; protected set; }



    }
}
