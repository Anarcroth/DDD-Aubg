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

        public bool HasSameType(string type)
        {
            if (this.type.Equals(type))
            {
                return true;
            }
            return false;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.type;
        }
    }
}
