namespace SSD_CW_20_21.Objects
{
    class Staff
    {
        private int id;
        private string name;
        private string workingDays;
        private string startLunch;
        private string endLunch;
        private int partial;
        private int deleted;

        public Staff() { }

        public Staff(int id, string name, string workingDays, string startLunch, string endLunch, int partial)
        {
            Id = id;
            Name = name;
            WorkingDays = workingDays;
            StartLunch = startLunch;
            EndLunch = endLunch;
            Partial = partial;
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

        public string StartLunch
        {
            get { return startLunch; }
            set { startLunch = value; }
        }

        public string EndLunch
        {
            get { return endLunch; }
            set { endLunch = value; }
        }

        public int Partial
        {
            get { return partial; }
            set { partial = value; }
        }

        public int Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }
    }
}
