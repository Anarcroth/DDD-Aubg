using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerBusiness.Domain
{
    public class PickList
    {
        public PickList()
        {
            // Set default id value
            status = "Not started";
            id = id.GetHashCode() + 100;
            pickListItems = new List<Items>(2);
            pickListItems.Add(new Items(new Flower("roses"), 5));
            pickListItems.Add(new Items(new Flower("tulips"), 8));
        }

        public int id { get; set; }

        public List<Items> pickListItems { get; set; }

        public Picker picker { get; set; }

        public string status { get; set;  }

        public PickList(List<Items> items, int id, Picker employee, string status)
        {
            pickListItems = items;
            this.id = id;
            this.picker = employee;
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

        public void associatePickerToList(Picker picker)
        {
            if (picker == null)
            {
                new NullReferenceException("no picker specified");
            }

            this.picker = picker;
        }
    }
}
