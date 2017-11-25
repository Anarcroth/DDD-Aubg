using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerBusiness.Domain
{
    public class Items
    {
        public Flower Flowers { get; set; }

        public int amount { get; set; }

        public string status { get; set; }

        public Items(Flower fl, int amount)
        {
            if (amount == 0)
            {
                new NullReferenceException("no flower amount specified");
            }

            this.Flowers = fl;
            this.amount = amount;

            status = "INCOMPLETE";
        }

        public void pickItem(int amount)
        {
            this.amount -= amount;

            if (this.amount == 0)
            {
                updateStatus("COMPLETE");
            }
        }

        private void updateStatus(string status)
        {
            if (this.status != status)
            {
                this.status = status;
            }
        }
    }
}
