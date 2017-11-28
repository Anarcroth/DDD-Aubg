using System;
using System.Collections.Generic;

namespace FlowerBusiness.Domain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello To Flower Picking World!");

            var pickerRepo = new DummyPickerRepository();

            OrderList generalOrder = new OrderList(5);

            generalOrder.populatePickLists();

            assignPickersWork(pickerRepo.RetrievePicker("96"), generalOrder);
            assignPickersWork(pickerRepo.RetrievePicker("42"), generalOrder);

            List<Box> bin = new List<Box>(4);

            bin.Add(new Box(Guid.NewGuid().ToString(), 20, new Flower("roses")));
            bin.Add(new Box(Guid.NewGuid().ToString(), 20, new Flower("tulips")));
            bin.Add(new Box(Guid.NewGuid().ToString(), 20, new Flower("lillies")));
            bin.Add(new Box(Guid.NewGuid().ToString(), 20, new Flower("tomatoes")));

            foreach (Box b in bin)
            {
                // Our flower pickers are fans of bruteforcing their work. They go through every box 
                // and check if they can pick the flowers for their order in their pick list.
                if (pickerRepo.RetrievePicker("96").canPickFlowersFrom(b))
                {
                    pickerRepo.RetrievePicker("96").pickFlowers(b);

                }
                if (pickerRepo.RetrievePicker("42").canPickFlowersFrom(b))
                {

                    pickerRepo.RetrievePicker("42").pickFlowers(b);
                }
            }
        }

        public static void assignPickersWork(Picker picker, OrderList generalOrder)
        {
            Console.WriteLine("The two pickers have to be assigned to an order." +
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
