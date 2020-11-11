namespace SSD_CW_20_21.Objects
{
    class Orders
    {
        private int id;
        private int dogId;
        private int staffId;
        private string date;
        private string time;
        private int paid;
        private int cancelled;

        public Orders()
        {

        }

        public Orders(int id, int dogId, int staffId, string date, string time, int paid)
        {
            Id = id;
            DogId = dogId;
            StaffId = staffId;
            Date = date;
            Time = time;
            Paid = paid;
            Cancelled = 0;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int DogId
        {
            get { return dogId; }
            set { dogId = value; }
        }

        public int StaffId
        {
            get { return staffId; }
            set { staffId = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        public int Paid
        {
            get { return paid; }
            set { paid = value; }
        }

        public int Cancelled
        {
            get { return cancelled; }
            set { cancelled = value; }
        }
    }
}
