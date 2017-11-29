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

        public PickList pickList { get; private set; }

        public List<Item> currentOrder { get; set; }

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
            currentOrder = new List<Item>(pickList.Items.Count);
        }

        public bool canPickFlowersFrom(Box box)
        {
            var check = pickList.Items.Any(fl => fl.Flowers.type.Equals(box.flower.type));

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
                // QUESTION 1 : This form of logic works if these steps are followed, that is - first we have to update the box amount and then we pick the item
                // and if we reverse the statements, the boxes won't be updated. Is this a bad form of logic to have such a strict workflow? Should we change the logic
                // so that it doesn't matter if we call the box.update or the it.pick method?

                // QUESTION 2 : This whole method is called `pickFlowersFrom(Box box)` which infers that a picker is taking something from a box, but should the logic
                // for decrementing the size of the box be in this method? Should the box logic be in the main program driver? From one side, this method might do
                // more than one thing -> i.e. pick flowers from a box, but the method name infers that it does this. The same goes for the checking of the pick list amount,
                // it's only a check, but should that check be done in the main driver? The whole problem is that if we were to update the box and do the check outside of this
                // method, we have to return a list of the items we want to work with, which means that the driver program has to handle this structure. In general it also
                // makes some sense to these checks/updated here, but I guess that this is a grey area and it's hard to decide where should this piece of logic be put.
                // This also might infer that the handling of the flowers and items might not be optimal if we HAVE to return a list of them in order to do the checks/updates somewhere else.
                // But since this is a test run, how else are we to handle the random generation of the flowers and items?

                // appologies for the long quesiton.
                box.updateSize(it.amount);
                currentOrder.Add(it);
                it.pickItem(it.amount);
                pickList.checkItemAmount(it);
            });
        }

        public bool completedPickList()
        {
            if (pickList.isComplete())
            {
                return true;
            }
            return false;
        }

        public void organizePickList()
        {
            List<Item> group = currentOrder.GroupBy(it => it.Flowers.type).Select(g => new Item
            {
                Flowers = g.First().Flowers,
                status = g.First().status,
                amount = g.Sum(c => c.amount),
            }).ToList();

            foreach(Item i in group)
            {
                Console.WriteLine(i.amount + " -- " + i.Flowers.type + " " + i.status);
            }
        }
    }
}
