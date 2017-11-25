using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerBusiness.Domain
{
    public class Box
    {
        public Box(string id, bool isScanned, int amount, Flower fl)
        {
            if (fl == null)
            {
                new NullReferenceException("no flower specified");
            }

            if (string.IsNullOrEmpty(id))
            {
                new NullReferenceException("no id specified");
            }

            if (amount <= 0)
            {
                new NullReferenceException("no amount specified");
            }

            this.id = id;
            this.amount = amount;
            this.fl = fl;
            this.isScanned = isScanned;
        }

        public Flower fl { get; set; }

        public int amount { get; set; }

        public string id { get; set; }

        public bool isScanned { get; set; }
    }
}
