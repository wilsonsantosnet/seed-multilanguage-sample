using Common.Domain.Base;
using Common.Domain.CompositeKey;
using Common.Domain.Model;
using System;

namespace Seed.Domain.Filter
{
    public class SampleDashFilterBase : FilterBase
    {



        public override string CompositeKey(CurrentUser user) {
            return CompositeKeyExtensions.CompositeKey(this, $"{user.GetSubjectId<int>()}");
        }

    }
}
