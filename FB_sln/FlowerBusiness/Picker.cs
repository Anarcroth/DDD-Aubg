using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FlowerBusiness.Domain
{
    public class Picker
    {
        public string id { get; private set; }

        public string name { get; private set; }

        public PickList pickList { get; set; }

        public Picker(string id, string name)
        {
            if (string.IsNullOrEmpty(id))
            {
                new NullReferenceException("no id specified");
            }

            if (string.IsNullOrEmpty(name))
            {
                new NullReferenceException("no name specified");
            }

            this.id = id;
            this.name = name;
        }

        public void associateListToPicker(PickList pickList)
        {
            if (pickList == null)
            {
                new Exception("no pick list specified");
            }

            this.pickList = pickList;
        }

        public bool canPickFlowersFrom(Box box)
        {
            var check = this.pickList.Items.Any(fl => fl.Flowers.type.Equals(box.flower.type));

            if (check && box.notEmpty())
            {
                return true;
            }
            return false;
        }

        public void pickFlowers(Box box)
        {
            foreach (Item item in pickList.Items)
            {
                if (item.Flowers.HasSameType(box.flower.type))
                {
                    int pickedAmount = Math.Abs(item.amount - box.flowerAmount);
                    item.pickItem(pickedAmount);

                    if (box.flowerAmount == pickedAmount)
                    {
                        box = null;
                    }
                    else
                    {
                        // Create a brand new box with a new identifier, but with the same type of flower
                        box = new Box(Guid.NewGuid().ToString(), pickedAmount, box.flower);
                    }
                }
                pickList.checkItemAmount(item);
            }
        }
    }
}
