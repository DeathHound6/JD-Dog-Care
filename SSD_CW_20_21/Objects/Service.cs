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
        private string description;
        private int time;

        public Service()
        {

        }

        public Service(int id, string description, int time)
        {
            ServiceID = id;
            Description = description;
        }

        public int ServiceID
        {
            get { return serviceID; }
            set { serviceID = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public int Time
        {
            get { return time; }
            set { time = value; }
        }
    }
}
