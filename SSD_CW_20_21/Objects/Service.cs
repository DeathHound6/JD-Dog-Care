namespace SSD_CW_20_21.Objects
{
    class Service
    {
        private int serviceID;
        private string description;
        private int time;
        private double cost;

        public Service()
        {

        }

        public Service(int id, string description, int time, double cost)
        {
            ServiceID = id;
            Description = description;
            Time = time;
            Cost = cost;
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

        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }
    }
}
