using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerBusiness.Domain
{
    public class Boxes
    {
        public Boxes(int id, bool isScanned, int amount, Flowers fl)
        {
            this.id = id;
            this.amount = amount;
            this.fl = fl;
            this.isScanned = isScanned;
        }

        public Flowers fl { get; set; }

        public int amount { get; set; }

        public int id { get; set; }

        public bool isScanned { get; set; }
    }
}
