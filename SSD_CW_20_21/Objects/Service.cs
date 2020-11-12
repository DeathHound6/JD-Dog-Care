namespace SSD_CW_20_21.Objects
{
    class Service
    {
        private int orderID;
        private int option;
        private int teeth;
        private int ears;
        private int nails;

        public Service()
        {

        }

        public Service(int orderID, int option, int nails, int ears, int teeth)
        {
            OrderID = orderID;
            Option = option;
            Option = option;
            Nails = nails;
            Ears = ears;
        }

        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }

        public int Option
        {
            get { return option; }
            set { option = value; }
        }

        public int Nails
        {
            get { return nails; }
            set { nails = value; }
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
    }
}
