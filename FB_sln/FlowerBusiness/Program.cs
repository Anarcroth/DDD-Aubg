using System;
using System.Collections.Generic;

namespace FlowerBusiness.Domain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello To Flower Picking World!\n");

            var pickerRepo = new DummyPickerRepository();

            OrderList generalOrder = new OrderList(5);

            generalOrder.populatePickLists();

            assignPickersWork(pickerRepo.RetrievePicker("96"), generalOrder);
            assignPickersWork(pickerRepo.RetrievePicker("42"), generalOrder);

            Bin bin = new Bin();

            foreach (Box b in bin.boxes)
            {
                // Our flower pickers are fans of bruteforcing their work. They go through every box 
                // and check if they can pick the flowers for their order in their pick list.
                if (pickerRepo.RetrievePicker("96").canPickFlowersFrom(b))
                {
                    pickerRepo.RetrievePicker("96").pickFlowersFrom(b);
                }
                if (pickerRepo.RetrievePicker("42").canPickFlowersFrom(b))
                {
                    pickerRepo.RetrievePicker("42").pickFlowersFrom(b);
                }
            }

            if (pickerRepo.RetrievePicker("96").completedPickList())
            {
                //pickerRepo.RetrievePicker("96").packageFlowers();
            }

            // Before closing the shift, update the status of the Order List
            generalOrder.updateStatus();

            Console.WriteLine("\nThe end of the shift is here. The order list is " + generalOrder.status + " and the status of the orders are: ");

            foreach (PickList pl in generalOrder.pickLists)
            {
                Console.WriteLine(pl.id + " -- " + pl.status);
            }

            Console.WriteLine("\nThe storage is with these items left.\n");

            foreach (Box b in bin.boxes)
            {
                Console.WriteLine(b.id + " -- " + b.flower.type + " -- " + b.flowerAmount);
            }
            
        }

        public static void assignPickersWork(Picker picker, OrderList generalOrder)
        {
            Console.WriteLine("\nThe two pickers have to be assigned to an order.\n" +
                "From the 5 pick lists, which one should " + picker.name + " be assigned to?\n");

            int indexOfList = int.Parse(Console.ReadLine());

            if (indexOfList > generalOrder.pickLists.Count)
            {
                new Exception("The selected pick list doesn't exist");
            }

            generalOrder.pickLists[indexOfList].associatePickerToList(picker);
            picker.associateListToPicker(generalOrder.pickLists[indexOfList]);
        }
    }
}
