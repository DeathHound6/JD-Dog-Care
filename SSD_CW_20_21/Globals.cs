using SSD_CW_20_21.Objects;
using SSD_CW_20_21.DbAccess;

namespace SSD_CW_20_21
{
    static class Globals
    {
        public static Database database { get; } = new Database();
        public static CustomerDBAccess custAccess { get; } = new CustomerDBAccess(database);
        public static DogDBAccess dogAccess { get; } = new DogDBAccess(database);
        public static OrderDBAccess orderAccess { get; } = new OrderDBAccess(database);
        public static StaffDBAccess staffAccess { get; } = new StaffDBAccess(database);
        public static ServiceDBAccess serviceAccess { get; } = new ServiceDBAccess(database);
        public static ServiceOrderDBAccess serviceOrderAccess { get; } = new ServiceOrderDBAccess(database);
        
        public static int extraNailsMinute { get; } = 10;
        public static int extraTeethMinute { get; } = 10;
        public static int extraEarsMinute { get; } = 5;
        public static int firstTimeMinute { get; } = 15;

        public static double extraNailsPrice { get; } = 4.50;
        public static double extraTeethPrice { get; } = 5.50;
        public static double extraEarsPrice { get; } = 4.00;

        public static double shortCoatPrice { get; } = 0.50;
        public static double mediumCoatPrice { get; } = 1.00;
        public static double longCoatPrice { get; } = 1.50;

        public static double calcCost(Orders order, Service serv, bool adding = false)
        {
            double cost = serv.Cost;
            if (order.Ears == 1) cost += extraEarsPrice;
            if (order.Nails == 1) cost += extraNailsPrice;
            if (order.Teeth == 1) cost += extraTeethPrice;
            Dog dog = dogAccess.getDogById(order.DogId);
            if (dog.HairLength == "Short") cost += shortCoatPrice;
            else if (dog.HairLength == "Medium") cost += mediumCoatPrice;
            else if (dog.HairLength == "Long") cost += longCoatPrice;
            if (adding) cost += 5.00; // first time cost
            return cost;
        }
    }
}
