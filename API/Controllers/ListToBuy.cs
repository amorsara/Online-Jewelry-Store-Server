using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using BLL;

namespace API.Controllers
{
    public class ListToBuy
    {
        public List<Product> listOfProducts { get; set; }
        public Clients client { get; set; }
    }
}