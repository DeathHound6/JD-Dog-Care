namespace SSD_CW_20_21.Objects
{
    class Dog
    {
        private int id;
        private int ownerId;
        private string name;
        private string breed;
        private string size;
        private int deleted;

        public Dog() { }

        public Dog(int id, int ownerId, string name, string breed, string size)
        {
            Id = id;
            OwnerId = ownerId;
            Name = name;
            Breed = breed;
            Size = size;
            Deleted = 0;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int OwnerId
        {
            get { return ownerId; }
            set { ownerId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Breed
        {
            get { return breed; }
            set { breed = value; }
        }

        public string Size
        {
            get { return size; }
            set { size = value; }
        }

        public int Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }
    }
}
