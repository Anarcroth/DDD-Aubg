using System;

namespace FlowerBusiness.Domain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello To Flower Picking World!");

            var emRepo = new DummyEmployeeRepository();

            OrderList generalOrder = new OrderList();

            emRepo.RetrieveEmployee(96).List = generalOrder.pickLists[0];
            emRepo.RetrieveEmployee(42).List = generalOrder.pickLists[1];

            Boxes box1 = new Boxes(1, false, 20, new Flowers("roses"));
            Boxes box2 = new Boxes(2, false, 20, new Flowers("tulips"));
            
            if (box1.isScanned == false && box2.isScanned == false)
            {
                if (emRepo.RetrieveEmployee(96).canPickFlowers(box1) == true)
                {
                    emRepo.RetrieveEmployee(96).pickFlowers(box1);
                    //box1.isScanned = true;
                }

                if (emRepo.RetrieveEmployee(42).canPickFlowers(box2) == true)
                {
                    emRepo.RetrieveEmployee(42).pickFlowers(box2);
                    //box2.isScanned = true;
                }
            }

            Console.WriteLine("Martha has " + emRepo.RetrieveEmployee(96).pickedFlowers[0].Flowers.type);
            Console.WriteLine("She has this many roses: " + emRepo.RetrieveEmployee(96).pickedFlowers[0].amount);

            Console.WriteLine("Benny has " + emRepo.RetrieveEmployee(42).pickedFlowers[0].Flowers.type);
            Console.WriteLine("He has this many tulips: " + emRepo.RetrieveEmployee(42).pickedFlowers[0].amount);

            Console.WriteLine("Box 1 has this many flowers now " + box1.amount + " and they are " + box1.fl.type);
            Console.WriteLine("Box 2 has this many flowers now " + box2.amount + " and they are " + box2.fl.type);
        }
    }
}
