using SSD_CW_20_21.Objects;

namespace SSD_CW_20_21.DbAccess
{
    class ServiceOrderDBAccess
    {
        private Database DB;

        public ServiceOrderDBAccess(Database db)
        {
            DB = db;
        }

        public Service getServiceById(int id)
        {
            return Globals.serviceAccess.getServiceById(id);
        }

        public Orders getOrderById(int id)
        {
            return Globals.orderAccess.getOrderById(id);
        }
    }
}
