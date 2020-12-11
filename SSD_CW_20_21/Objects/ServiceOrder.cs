namespace SSD_CW_20_21.Objects
{
    class ServiceOrder
    {
        private int orderID;
        private int serviceID;

        public ServiceOrder()
        {

        }

        public ServiceOrder(int orderID, int serviceID)
        {
            OrderID = orderID;
            ServiceID = serviceID;
        }

        public int OrderID
        {
            get { return orderID; }
            set { orderID = value; }
        }

        public int ServiceID
        {
            get { return serviceID; }
            set { serviceID = value; }
        }
    }
}
