using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerBusiness.Domain
{
    public interface IEmployeeRepository
    {
        Employee RetrieveEmployee(int id);

        void SaveEmployee(Employee employee);
    }
}
