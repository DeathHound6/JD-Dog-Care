using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSD_CW_20_21.Objects
{
    class Service
    {
        private int serviceID;
        private int serviceOption;
        private int nails;
        private int teeth;
        private int ears;

        public Service()
        {

        }

        public Service(int id, int option, int nails, int teeth, int ears)
        {
            ServiceID = id;
            ServiceOption = option;
            Nails = nails;
            Teeth = teeth;
            Ears = ears;
        }

        public int ServiceID
        {
            get { return serviceID; }
            set { serviceID = value; }
        }

        public int ServiceOption
        {
            get { return serviceOption; }
            set { serviceOption = value; }
        }

        public int Nails
        {
            get { return nails; }
            set { nails = value; }
        }

        public int Ears
        {
            get { return ears; }
            set { ears = value; }
        }

        public int Teeth
        {
            get { return teeth; }
            set { teeth = value; }
        }
    }
}
