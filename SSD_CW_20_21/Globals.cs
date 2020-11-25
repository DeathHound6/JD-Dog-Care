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
        
        public static double extraNailsMinute { get; } = 10.0;
        public static double extraTeethMinute { get; } = 10.0;
        public static double extraEarsMinute { get; } = 5.0;
        public static double firstTimeMinute { get; } = 15.0;

        public static double extraNailsPrice { get; } = 2.50;
        public static double extraTeethPrice { get; } = 3.00;
        public static double extraEarsPrice { get; } = 2.00;
    }
}
