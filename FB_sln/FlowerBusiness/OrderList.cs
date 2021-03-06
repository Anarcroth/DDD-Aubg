﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FlowerBusiness.Domain
{
    class OrderList : GenericStatus
    {
        // Used to simulate a random generation of orders and items
        private static readonly Random rnd = new Random();

        public List<PickList> pickLists { get; set; }

        public string id { get; }

        public OrderList()
        {
            id = Guid.NewGuid().ToString();
            // Default size number of the order list is with 2 pick lists
            pickLists = new List<PickList>(2);
            pickLists.Add(new PickList());
            pickLists.Add(new PickList());
        }

        public OrderList(int size)
        {
            pickLists = new List<PickList>(size);
            for (int n = 0; n < size; n++)
            {
                // For all means and purposes, just populate the list with random numbers from 1 to 10, as to simulate a normal order of flowers
                pickLists.Add(new PickList(rnd.Next(1, 11)));
            }
        }

        public OrderList(List<PickList> lists, string id, string status)
        {
            pickLists = lists;
            this.id = id;
            this.status = status;
        }

        public void updateStatus()
        {
            var allDone = pickLists.All(i => i.isComplete());

            if (allDone)
            {
                updateStatus("COMPLETE");
            }
        }

        public void populatePickLists()
        {
            string[] flowerTypes = { "roses", "tulips", "lillies", "tomatoes" };

            foreach (PickList list in pickLists)
            {
                for (int n = 0; n < list.Items.Capacity; n++)
                {
                    list.Items.Add(new Item(new Flower(flowerTypes[rnd.Next(0, flowerTypes.Length)]), rnd.Next(1, 6)));
                }
            }
        }
    }
}
