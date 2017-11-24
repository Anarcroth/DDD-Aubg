using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerBusiness.Domain
{
    public class Employee
    {
        public Employee()
        {
            pickedFlowers = new List<Items>(2);
        }

        public int id { get; private set; }

        public string name { get; private set; }

        public PickList List { get; set; }

        public List<Items> pickedFlowers { get; set; }

        public bool canPickFlowers(Boxes box)
        {
           foreach (Items it in List.pickListItems)
            {
                if (it.Flowers.type == box.fl.type && box.amount > it.amount)
                {
                    return true;
                }
            }
           return false;
        }

        public void pickFlowers(Boxes box)
        {
            foreach (Items it in List.pickListItems)
            {
                if (it.Flowers.type == box.fl.type && box.amount > it.amount)
                {
                    box.amount -= it.amount;
                    pickedFlowers.Add(it);
                }
            }
        }
    }
}
