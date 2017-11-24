using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerBusiness.Domain
{
    public class DummyEmployeeRepository : IEmployeeRepository
    {
        private Employee Martha;
        private Employee Benny;

        public DummyEmployeeRepository()
        {
            this.Martha = new Employee();
            this.Benny = new Employee();
        }

        public Employee RetrieveEmployee(int id)
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

        public void SaveEmployee(Employee em)
        {

        }
    }
}
