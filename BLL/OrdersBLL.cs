using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class OrdersBLL
    {
        DBConnection dbCon;
        List<Orders> listOfOrders;
        public OrdersBLL()
        {
            dbCon = new DBConnection();
            listOfOrders = dbCon.GetDbSet<Orders>().ToList();
        }

        public List<Orders> GetAllOrders()
        {
            return listOfOrders;
        }
        public string InsertOrders(Orders order)
        {
            if (listOfOrders.Find(o => o.codeOrder == order.codeOrder) == null)
            {
                try
                {
                    dbCon.Execute<Orders>(order, DBConnection.ExecuteActions.Insert);
                    return order.codeOrder.ToString();
                }
                catch (Exception ex)
                {
                    return "error";
                }
            }
            else
            {
                return "order is exist";
            }

        }
        public int UpdateOrders(Orders orders)
        {
            try
            {
                dbCon.Execute<Orders>(orders, DBConnection.ExecuteActions.Update);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int DeleteOrders(Orders orders)
        {
            try
            {
                dbCon.Execute<Orders>(orders, DBConnection.ExecuteActions.Delete);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
    }
}
