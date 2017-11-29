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

        public void pickFlowersFrom(Box box)
        {
            List<Item> itemsToPick = pickList.Items.FindAll(it => it.Flowers.HasSameType(box.flower.type) && !it.isComplete());

            itemsToPick.ForEach(it =>
            {
                box.updateSize(it.amount);
                it.pickItem(it.amount);
                pickList.checkItemAmount(it);
            });
        }

        public bool completedPickList()
        {
            if (pickList.isComplete())
            {
                return false;
            }
            return false;
        }

        public void packageFlowers()
        {
            //TODO create new pallet and fill it with the flowers
        }
    }
}
