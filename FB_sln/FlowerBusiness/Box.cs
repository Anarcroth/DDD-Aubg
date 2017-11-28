using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerBusiness.Domain
{
    public class Box
    {
        public Flower flower { get; set; }

        public int flowerAmount { get; set; }

        public string id { get; set; }
        public Box(string id, int flowerAmount, Flower flower)
        {
            if (flower == null)
            {
                new NullReferenceException("no flower specified");
            }

            if (string.IsNullOrEmpty(id))
            {
                new NullReferenceException("no id specified");
            }

            if (flowerAmount <= 0)
            {
                new NullReferenceException("no flower amount specified");
            }

            this.id = id;
            this.flowerAmount = flowerAmount;
            this.flower = flower;
        }

        public bool notEmpty()
        {
            if (flowerAmount > 0)
            {
                return true;
            }
            return false;
        }
    }
}
