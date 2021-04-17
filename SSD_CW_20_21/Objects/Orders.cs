namespace SSD_CW_20_21.Objects
{
    class Orders
    {
        private int id;
        private int serviceID;
        private int dogId;
        private int staffId;
        private string date;
        private string startTime;
        private int ears;
        private int teeth;
        private int nails;
        private int roomID;
        private int paid;
        private int cancelled;

        public Orders()
        {

        }

        public Orders(int id, int serv, int dogId, int staffId, string date, string startTime, int ears, int teeth, int nails, int roomID, int paid)
        {
            Id = id;
            ServiceID = serv;
            DogId = dogId;
            StaffId = staffId;
            Date = date;
            StartTime = startTime;
            Ears = ears;
            Teeth = teeth;
            Nails = nails;
            Paid = paid;
            Cancelled = 0;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int ServiceID
        {
            get { return serviceID; }
            set { serviceID = value; }
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

        public string StartTime
        {
            get { return startTime; }
            set { startTime = value; }
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

        public int Nails
        {
            get { return nails; }
            set { nails = value; }
        }

        public int RoomID
        {
            get { return roomID; }
            set { roomID = value; }
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
