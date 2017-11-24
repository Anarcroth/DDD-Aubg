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
            pickListItems.Add(new Items(new Flowers("roses"), 5));
            pickListItems.Add(new Items(new Flowers("tulips"), 8));
        }

        public int id { get; set; }

        public List<Items> pickListItems { get; set; }

        public Employee employee { get; set; }

        public string status { get; set;  }

        public PickList(List<Items> items, int id, Employee employee, string status)
        {
            pickListItems = items;
            this.id = id;
            this.employee = employee;
            this.status = status;
        }

        public void updateStatus(string status)
        {
            if (status != this.status)
            {
                this.status = status;
            }
        }

        public void changeEmployee(Employee em)
        {
            if (em != employee)
            {
                employee = em;
            }
        }
    }
}
