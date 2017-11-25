using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerBusiness.Domain
{
    class OrderList
    {
        public OrderList()
        {
            // Set default id value
            status = "Not started";
            id = id.GetHashCode() + 100;
            pickLists = new List<PickList>(2);
            pickLists.Add(new PickList());
            pickLists.Add(new PickList());
        }

        public OrderList(List<PickList> lists, int id, string status)
        {
            this.pickLists = lists;
            this.id = id;
            this.status = status;
        }

        public List<PickList> pickLists { get; set; }

        public int id { get; }

        public string status { get; set; }

        public void updateStatus(string status)
        {
            this.status = status;
        }
    }
}
