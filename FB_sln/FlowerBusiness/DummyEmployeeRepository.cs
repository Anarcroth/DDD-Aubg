using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerBusiness.Domain
{
    public class DummyEmployeeRepository : IEmployeeRepository
    {
        private Picker Martha;
        private Picker Benny;

        public DummyEmployeeRepository()
        {
            this.Martha = new Picker(96, "Martha");
            this.Benny = new Picker(42, "Benny");
        }

        public Picker RetrieveEmployee(int id)
        {
            if (id == 96)
            {
                return Martha;
            }

            if (id == 42)
            {
                return Benny;
            }

            return null;
        }

        public void SaveEmployee(Picker em)
        {

        }
    }
}
