using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerBusiness.Domain
{
    public class Items : ValueObject
    {
        public Flowers Flowers { get; }

        public int amount { get; }

        public Items(Flowers fl, int amount)
        {
            this.Flowers = fl;
            this.amount = amount;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Flowers;
            yield return this.amount;
        }
    }
}
