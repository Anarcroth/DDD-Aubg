using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FlowerBusiness.Domain
{
    public class PickList
    {
        public int id { get; set; }

        public List<Items> pickListItems { get; set; }

        public Picker picker { get; set; }

        public string status { get; set; }
        public PickList()
        {
            // Set default id value
            status = "Not started";
            id = id.GetHashCode() + 100;
            pickListItems = new List<Items>(2);
        }

        public PickList(List<Items> items, int id, Picker picker, string status)
        {
            pickListItems = items;
            this.id = id;
            this.picker = picker;
            this.status = status;
        }

        public void updateStatus(string status)
        {
            if (status != this.status)
            {
                this.status = status;
            }
        }

        public void changeEmployee(Picker picker)
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

        public void checkItemAmount(Items item)
        {
            var allPicked = this.pickListItems.All(i => i.status == "COMPLETE");

            if (allPicked == true)
            {
                this.updateStatus("COMPLETE");
            }
        }
    }
}
