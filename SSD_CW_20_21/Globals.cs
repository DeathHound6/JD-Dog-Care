using SSD_CW_20_21.Objects;
using SSD_CW_20_21.DbAccess;

namespace SSD_CW_20_21
{
    static class Globals
    {
        public static Database database = new Database();
        public static CustomerDBAccess custAccess { get; set; }
        public static DogDBAccess dogAccess { get; set; }
        public static OrderDBAccess orderAccess { get; set; }
        public static StaffDBAccess staffAccess { get; set; }
        public static ServiceDBAccess servAccess { get; set; }

        public static void initDBAccess()
        {
            custAccess = new CustomerDBAccess(database);
            dogAccess = new DogDBAccess(database);
            orderAccess = new OrderDBAccess(database);
            staffAccess = new StaffDBAccess(database);
            servAccess = new ServiceDBAccess(database);
        }
    }
}
