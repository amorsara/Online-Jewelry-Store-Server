using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using DAL;

namespace API.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        OrdersBLL order = new OrdersBLL();
        [AcceptVerbs("GET", "POST")]
        [Route("login")]
        [HttpPost]

        public string insert(Orders o)
        {
            return order.InsertOrders(o);
        }
        [Route("delete")]
        [HttpPost]

        public int delete(Orders o)
        {
            return order.DeleteOrders(o);
        }
        [Route("update")]
        [HttpPost]

        public int update(Orders o)
        {
            return order.UpdateOrders(o);
        }

        [Route("getall")]
        [HttpGet]
        public List<Orders> getall()
        {
            return order.GetAllOrders();
        }
    }
}
