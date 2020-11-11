namespace SSD_CW_20_21.Objects
{
    class Customer
    {
        private int id;
        private string forename;
        private string surname;
        private string address;
        private string town;
        private string postcode;
        private string telNo;
        private string email;
        private int deleted;

        public Customer() { }

        public Customer(int id, string forename, string surname, string address, string town, string postcode, string telNo, string email)
        {
            Id = id;
            Forename = forename;
            Surname = surname;
            Address = address;
            Town = town;
            Postcode = postcode;
            TelNo = telNo;
            Email = email;
            Deleted = 0;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Forename
        {
            get { return forename; }
            set { forename = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Town
        {
            get { return town; }
            set { town = value; }
        }

        public string Postcode
        {
            get { return postcode; }
            set { postcode = value; }
        }

        public string TelNo
        {
            get { return telNo; }
            set { telNo = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public int Deleted
        {
            get { return deleted; }
            set { deleted = value; }
        }
    }
}
