using System;

namespace FlowerBusiness.Domain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello To Flower Picking World!");

            var emRepo = new DummyPickerRepository();

            OrderList generalOrder = new OrderList(5);

            generalOrder.populatePickLists();

            Console.WriteLine("The two pickers have to be assigned to an order." +
                "From the 5 pick lists, which one should " + emRepo.RetrievePicker("96") + " be assigned to?\n");

            int indexOfList = int.Parse(Console.ReadLine());

            if (indexOfList > generalOrder.pickLists.Count)
            {
                new Exception("The selected pick list doesn't exist");
            }

            generalOrder.pickLists[indexOfList].associatePickerToList(emRepo.RetrievePicker("96"));
            emRepo.RetrievePicker("96").associatePickerToList(generalOrder.pickLists[indexOfList]);


            Console.WriteLine("The two pickers have to be assigned to an order." +
                "From the 5 pick lists, which one should " + emRepo.RetrievePicker("42") + " be assigned to?\n");

            indexOfList = int.Parse(Console.ReadLine());

            if (indexOfList > generalOrder.pickLists.Count)
            {
                new Exception("The selected pick list doesn't exist");
            }

            generalOrder.pickLists[indexOfList].associatePickerToList(emRepo.RetrievePicker("42"));
            emRepo.RetrievePicker("42").associatePickerToList(generalOrder.pickLists[indexOfList]);

            Box box1 = new Box("1", 20, new Flower("roses"));
            Box box2 = new Box("2", 20, new Flower("tulips"));

            if (emRepo.RetrievePicker("96").canPickFlowers(box1) == true)
            {
                emRepo.RetrievePicker("96").pickFlowers(box1);
            }

            if (emRepo.RetrievePicker("96").canPickFlowers(box2) == true)
            {
                emRepo.RetrievePicker("96").pickFlowers(box2);
            }

            if (emRepo.RetrievePicker("42").canPickFlowers(box2) == true)
            {
                emRepo.RetrievePicker("42").pickFlowers(box2);
            }

            Console.WriteLine("is pick list 0 complete : " + generalOrder.pickLists[0].status);        

            Console.WriteLine("Box 1 has this many flowers now " + box1.flowerAmount + " and they are " + box1.flower.type);
            Console.WriteLine("Box 2 has this many flowers now " + box2.flowerAmount + " and they are " + box2.flower.type);
        }
    }
}
