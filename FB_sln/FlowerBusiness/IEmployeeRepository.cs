using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerBusiness.Domain
{
    public interface IEmployeeRepository
    {
        Picker RetrieveEmployee(int id);
        void SaveEmployee(Picker employee);
    }
}
