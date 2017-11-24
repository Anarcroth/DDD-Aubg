using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerBusiness.Domain
{
    public class Flowers : ValueObject
    {
        public string type { get; }

        public Flowers(string type)
        {
            this.type = type;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.type;
        }
    }
}
