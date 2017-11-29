using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerBusiness.Domain
{
    class Pallet
    {
        public string id { get; set; }

        public string pickListId { get; set; }

        public string pickerId { get; set; }

        public int maxCapacity { get; set; }

        public List<Item> order { get; set; }

        public Pallet()
        {
            id = Guid.NewGuid().ToString();
            // For simplicity hardcode the capacity of the pallet
            maxCapacity = 20;
        }

        public Pallet(string pickListId, string pickerId, List<Item> order)
        {
            id = Guid.NewGuid().ToString();
            maxCapacity = 20;

            this.pickListId = pickListId;
            this.pickerId = pickerId;

            if (maxCapacity < order.Count)
            {
                new Exception("The pallet cannot hold this many items");
            }
          
            this.order = order;
        }
    }
}
