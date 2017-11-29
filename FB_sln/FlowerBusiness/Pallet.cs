using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerBusiness.Domain
{
    class Pallet
    {
        public string id { get; set; }

        public int maxBoxCapacity { get; set; }

        public List<Box> boxes { get; set; }

        public Pallet()
        {
            id = Guid.NewGuid().ToString();
            // For simplicity hardcode the capacity of the pallet
            maxBoxCapacity = 20;
        }

        public Pallet(List<Box> boxes)
        {
            id = Guid.NewGuid().ToString();
            maxBoxCapacity = 20;

            if (maxBoxCapacity < boxes.Count)
            {
                new Exception("The pallet cannot hold this many boxes");
            }

            this.boxes = boxes;
        }
    }
}
