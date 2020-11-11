namespace SSD_CW_20_21.Objects
{
    class Staff
    {
        private int id;
        private string name;
        private int workingHours;
        private int deleted;

        public Staff() { }

        public Staff(int id, string name, int workingHours)
        {
            Id = id;
            Name = name;
            WorkingHours = workingHours;
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

        public int WorkingHours
        {
            get { return workingHours; }
            set { workingHours = value; }
        }

        public int Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }
    }
}
