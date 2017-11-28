using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerBusiness.Domain
{
    class Bin
    {
        public string id { get; set; }

        public List<Box> boxes { get; set; }

        public Bin()
        {
            id = Guid.NewGuid().ToString();

            boxes = new List<Box>(5);
            boxes.Add(new Box(Guid.NewGuid().ToString(), 20, new Flower("roses")));
            boxes.Add(new Box(Guid.NewGuid().ToString(), 20, new Flower("tulips")));
            boxes.Add(new Box(Guid.NewGuid().ToString(), 20, new Flower("lillies")));
            boxes.Add(new Box(Guid.NewGuid().ToString(), 20, new Flower("tomatoes")));
        }

        public Bin(int size)
        {
            id = Guid.NewGuid().ToString();

            string[] flowerTypes = { "roses", "tulips", "lillies", "tomatoes" };
            boxes = new List<Box>(size);
            for (int n = 0; n < size; n++)
            {
                boxes.Add(new Box(Guid.NewGuid().ToString(), 
                    new Random().Next(1, 20),
                    new Flower(flowerTypes[new Random().Next(0, flowerTypes.Length)])));
            }
        }
    }
}
