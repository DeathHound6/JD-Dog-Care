﻿namespace SSD_CW_20_21.Objects
{
    class Orders
    {
        private int id;
        private int dogId;
        private int staffId;
        private string date;
        private string startTime;
        private string endTime;
        private int paid;
        private int cancelled;

        public Orders()
        {

        }

        public Orders(int id, int dogId, int staffId, string date, string startTime, string endTime, int paid)
        {
            Id = id;
            DogId = dogId;
            StaffId = staffId;
            Date = date;
            StartTime = startTime;
            EndTime = endTime;
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

        public string StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        public string EndTime
        {
            get { return endTime; }
            set { endTime = value; }
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
