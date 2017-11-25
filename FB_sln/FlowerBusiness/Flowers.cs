using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerBusiness.Domain
{
    public class Flower : ValueObject
    {
        public string type { get; }

        public Flower(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                new NullReferenceException("no flower type specified");
            }

            this.type = type;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.type;
        }
    }
}
