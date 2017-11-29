using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerBusiness.Domain
{
    public class Item : GenericStatus
    {
        public Flower Flowers { get; set; }

        public int amount { get; set; }

        public Item(Flower fl, int amount)
        {
            if (amount == 0)
            {
                new NullReferenceException("no flower amount specified");
            }

            Flowers = fl;
            this.amount = amount;
        }

        public void pickItem(int amount)
        {
            this.amount -= amount;

            if (this.amount == 0)
            {
                updateStatus("COMPLETE");
            }
        }
    }
}
