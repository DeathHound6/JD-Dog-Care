namespace SSD_CW_20_21.Objects
{
    class Staff
    {
        private int id;
        private string name;
        private string workingDays;
        private int deleted;

        public Staff() { }

        public Staff(int id, string name, string workingDays)
        {
            Id = id;
            Name = name;
            WorkingDays = workingDays;
            Deleted = 0;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string WorkingDays
        {
            get { return workingDays; }
            set { workingDays = value; }
        }

        public int Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }
    }
}
