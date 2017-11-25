using System;

namespace FlowerBusiness.Domain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello To Flower Picking World!");

            OrderList generalOrder = new OrderList();

            var emRepo = new DummyPickerRepository();

            generalOrder.pickLists[0].pickListItems.Add(new Items(new Flower("roses"), 5));
            generalOrder.pickLists[0].pickListItems.Add(new Items(new Flower("tulips"), 8));
            generalOrder.pickLists[1].pickListItems.Add(new Items(new Flower("roses"), 10));
            generalOrder.pickLists[1].pickListItems.Add(new Items(new Flower("tulips"), 15));

            generalOrder.pickLists[0].associatePickerToList(emRepo.RetrievePicker("96"));
            emRepo.RetrievePicker("96").associatePickerToList(generalOrder.pickLists[0]);
            generalOrder.pickLists[1].associatePickerToList(emRepo.RetrievePicker("42"));
            emRepo.RetrievePicker("42").associatePickerToList(generalOrder.pickLists[1]);

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
