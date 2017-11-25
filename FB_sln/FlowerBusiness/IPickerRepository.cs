using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerBusiness.Domain
{
    public interface IPickerRepository
    {
        Picker RetrievePicker(string id);
        void SavePicker(Picker picker);
    }
}
