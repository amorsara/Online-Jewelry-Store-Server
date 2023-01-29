using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class OrderDetailsBLL
    {
        DBConnection dbCon;
        List<OrderDetails> listOfOrderDetails;
        public OrderDetailsBLL()
        {
            dbCon = new DBConnection();
            listOfOrderDetails = dbCon.GetDbSet<OrderDetails>().ToList();
        }

        public List<OrderDetails> GetAllOrderDetails()
        {
            return listOfOrderDetails;
        }
        public string InsertOrderDetails(OrderDetails ordersdetail)
        {
            if (listOfOrderDetails.Find(o => o.codeOrderDetails == ordersdetail.codeOrderDetails) == null)
            {
                try
                {
                    dbCon.Execute<OrderDetails>(ordersdetail, DBConnection.ExecuteActions.Insert);
                    return ordersdetail.codeOrder.ToString();
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
        public int UpdateOrderDetails(OrderDetails ordersdetails)
        {
            try
            {
                dbCon.Execute<OrderDetails>(ordersdetails, DBConnection.ExecuteActions.Update);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int DeleteOrderDetails(OrderDetails ordersdetails)
        {
            try
            {
                dbCon.Execute<OrderDetails>(ordersdetails, DBConnection.ExecuteActions.Delete);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

    }
}
