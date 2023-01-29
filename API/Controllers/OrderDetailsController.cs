using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    [RoutePrefix("api/orderdetails")]
    public class OrderDetailsController : ApiController
    {
        OrderDetailsBLL orderdetails = new OrderDetailsBLL();
        [AcceptVerbs("GET", "POST")]
        [Route("login")]
        [HttpPost]

        public string insert(OrderDetails o)
        {
            return orderdetails.InsertOrderDetails(o);
        }
        [Route("delete")]
        [HttpPost]

        public int delete(OrderDetails o)
        {
            return orderdetails.DeleteOrderDetails(o);
        }
        [Route("update")]
        [HttpPost]

        public int update(OrderDetails o)
        {
            return orderdetails.UpdateOrderDetails(o);
        }

        [Route("getall")]
        [HttpGet]
        public List<OrderDetails> getall()
        {
            return orderdetails.GetAllOrderDetails();
        }

    }
}
