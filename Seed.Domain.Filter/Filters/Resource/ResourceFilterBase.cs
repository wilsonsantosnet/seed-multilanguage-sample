using Common.Domain.Base;
using Common.Domain.CompositeKey;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Filter
{
    public class ResourceFilterBase : FilterBase
    {

        public virtual int ResourceId { get; set;} 
        public virtual string Group { get; set;} 
        public virtual string Culture { get; set;} 
        public virtual string key { get; set;} 
        public virtual string value { get; set;} 


        public override string CompositeKey(CurrentUser user) {
            return CompositeKeyExtensions.CompositeKey(this, $"{user.GetSubjectId<int>()}");
        }

    }
}
