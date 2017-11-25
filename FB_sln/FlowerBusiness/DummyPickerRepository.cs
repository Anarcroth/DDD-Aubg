using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerBusiness.Domain
{
    public class DummyPickerRepository : IPickerRepository
    {
        private Picker Martha;
        private Picker Benny;

        public DummyPickerRepository()
        {
            this.Martha = new Picker("96", "Martha");
            this.Benny = new Picker("42", "Benny");
        }

        public Picker RetrievePicker(string id)
        {
            if (id.Equals("96"))
            {
                return Martha;
            }

            if (id.Equals("42"))
            {
                return Benny;
            }

            return null;
        }

        public void SavePicker(Picker em)
        {

        }
    }
}
