namespace SSD_CW_20_21.Objects
{
    class Dog
    {
        private int id;
        private int ownerId;
        private string name;
        private string dob;
        private string breed;
        private string aggression;
        private string hairLength;
        private int deleted;

        public Dog() { }

        public Dog(int id, int ownerId, string name, string dob, string breed, string aggression, string hairLength, int deleted)
        {
            Id = id;
            OwnerId = ownerId;
            Name = name;
            DOB = dob;
            Breed = breed;
            Aggression = aggression;
            HairLength = hairLength;
            Deleted = deleted;
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

        public string DOB
        {
            get { return dob; }
            set { dob = value; }
        }

        public string Breed
        {
            get { return breed; }
            set { breed = value; }
        }

        public string Aggression
        {
            get { return aggression; }
            set { aggression = value; }
        }

        public string HairLength
        {
            get { return hairLength; }
            set { hairLength = value; }
        }

        public int Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }
    }
}
