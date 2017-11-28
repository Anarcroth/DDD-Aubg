using System;

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

            Box box1 = new Box("1", 20, new Flower("roses"));
            Box box2 = new Box("2", 20, new Flower("tulips"));
            Box box4 = new Box("3", 20, new Flower("lillies"));
            Box box3 = new Box("4", 20, new Flower("tomatoes"));

            if (pickerRepo.RetrievePicker("96").canPickFlowers(box1) == true)
            {
                pickerRepo.RetrievePicker("96").pickFlowers(box1);
            }

            if (pickerRepo.RetrievePicker("96").canPickFlowers(box2) == true)
            {
                pickerRepo.RetrievePicker("96").pickFlowers(box2);
            }

            if (pickerRepo.RetrievePicker("42").canPickFlowers(box2) == true)
            {
                pickerRepo.RetrievePicker("42").pickFlowers(box2);
            }

            Console.WriteLine("is pick list 0 complete : " + generalOrder.pickLists[0].status);        

            Console.WriteLine("Box 1 has this many flowers now " + box1.flowerAmount + " and they are " + box1.flower.type);
            Console.WriteLine("Box 2 has this many flowers now " + box2.flowerAmount + " and they are " + box2.flower.type);
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
            picker.associatePickerToList(generalOrder.pickLists[indexOfList]);
        }
    }
}
