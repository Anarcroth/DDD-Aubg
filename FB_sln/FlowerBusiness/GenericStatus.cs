using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerBusiness.Domain
{
    public abstract class GenericStatus
    {
        public string status { get; protected set; }

        public GenericStatus()
        {
            status = "INCOMPLETE";
        }

        public bool isComplete()
        {
            if (status == "COMPLETE")
            {
                return true;
            }
            return false;
        }
        public void updateStatus(string status)
        {
            if (this.status != status)
            {
                this.status = status;
            }
        }

    }
}
