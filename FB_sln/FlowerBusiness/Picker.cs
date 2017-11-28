using System;
using System.Collections.Generic;
using System.Text;

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

        public void associatePickerToList(PickList pickList)
        {
            if (pickList == null)
            {
                new Exception("no pick list specified");
            }

            this.pickList = pickList;
        }

        public bool canPickFlowers(Box box)
        {
           foreach (Items it in pickList.pickListItems)
            {
                if (it.Flowers.HasSameType(box.flower.type) && box.flowerAmount > it.amount)
                {
                    return true;
                }
            }
           return false;
        }

        public void pickFlowers(Box box)
        {
            foreach (Items it in pickList.pickListItems)
            {
                if (it.Flowers.HasSameType(box.flower.type) && box.flowerAmount > it.amount)
                {
                    box.flowerAmount -= it.amount;
                    it.pickItem(it.amount);
                }

                pickList.checkItemAmount(it);
            }
        }
    }
}
