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

        public int maxBoxCapacity { get; set; }

        public PickList boxes { get; set; }

        public Pallet()
        {
            id = Guid.NewGuid().ToString();
            // For simplicity hardcode the capacity of the pallet
            maxBoxCapacity = 20;
        }

        public Pallet(string pickListId, string pickerId, PickList boxes)
        {
            id = Guid.NewGuid().ToString();
            maxBoxCapacity = 20;

            this.pickListId = pickListId;
            this.pickerId = pickerId;
          
            this.boxes = boxes;
        }
    }
}
