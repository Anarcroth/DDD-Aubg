using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerBusiness.Domain
{
    public class Items : ValueObject
    {
        public Flower Flowers { get; }

        public int amount { get; }

        public Items(Flower fl, int amount)
        {
            if (amount == null || amount == 0)
            {
                new NullReferenceException("no amount specified");
            }

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
