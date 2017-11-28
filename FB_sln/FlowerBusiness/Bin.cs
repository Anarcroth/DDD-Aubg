using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FlowerBusiness.Domain
{
    class Bin
    {
        public string id { get; set; }

        public List<Box> boxes { get; set; }

        public int maxCapacity { get; set; }

        public Bin()
        {
            id = Guid.NewGuid().ToString();

            boxes = new List<Box>(5);
            boxes.Add(new Box(Guid.NewGuid().ToString(), 20, new Flower("roses")));
            boxes.Add(new Box(Guid.NewGuid().ToString(), 20, new Flower("tulips")));
            boxes.Add(new Box(Guid.NewGuid().ToString(), 20, new Flower("lillies")));
            boxes.Add(new Box(Guid.NewGuid().ToString(), 20, new Flower("tomatoes")));

            maxCapacity = 80;
        }

        public Bin(int size)
        {
            id = Guid.NewGuid().ToString();

            string[] flowerTypes = { "roses", "tulips", "lillies", "tomatoes" };
            boxes = new List<Box>(size);
            for (int n = 0; n < size; n++)
            {
                int amount = new Random().Next(1, 20);

                maxCapacity += amount;

                boxes.Add(new Box(Guid.NewGuid().ToString(), 
                    amount,
                    new Flower(flowerTypes[new Random().Next(0, flowerTypes.Length)])));
            }
        }

        public bool isFull()
        {
            if (maxCapacity == boxes.Sum(b => b.flowerAmount))
            {
                return true;
            }
            return false;
        }

        public void updateStorage()
        {
            boxes.ForEach(b => b.flowerAmount -= 1);
        }
    }
}
