using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FlowerBusiness.Domain
{
    public class PickList : GenericStatus
    {
        public string id { get; set; }

        public List<Item> Items { get; set; }

        public Picker picker { get; set; }

        public PickList()
        {
            id = Guid.NewGuid().ToString();
            // The default size of the pick list is with 2 items in it
            Items = new List<Item>(2);
        }

        public PickList(int size)
        {
            id = Guid.NewGuid().ToString();
            Items = new List<Item>(size);
        }

        public PickList(List<Item> items, string id, Picker picker, string status)
        {
            Items = items;
            this.id = id;
            this.picker = picker;
            this.status = status;
        }

        public void changePicker(Picker picker)
        {
            if (picker != this.picker)
            {
                this.picker = picker;
            }
        }

        private bool isListTaken()
        {
            if (this.picker == null)
            {
                return false;
            }
            return true;
        }

        public void associatePickerToList(Picker picker)
        {
            if (picker == null)
            {
                new NullReferenceException("no picker specified");
            }

            if (isListTaken())
            {
                new Exception("list is already taken");
            }

            this.picker = picker;
        }

        public void checkItemAmount(Item item)
        {
            var allPicked = this.Items.All(i => i.isComplete());

            if (allPicked)
            {
                this.updateStatus("COMPLETE");
            }
        }
    }
}
