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
    [RoutePrefix("api/clients")]
    public class ClientsController : ApiController
    {
        ClientsBLL client = new ClientsBLL();
        [AcceptVerbs("GET","POST")]

        [Route("insert")]
        [HttpPost]
        public string insert(Clients c)
        {
            return client.InsertClient(c);
        }

        [Route("delete")]
        [HttpPost]
        public int delete(Clients c)
        {
            return client.DeleteClients(c);
        }

        [Route("update")]
        [HttpPost]
        public int update(Clients c)
        {
            return client.UpdateClients(c);
        }

        [Route("getall")]
        [HttpGet]
        public List<Clients> getall()
        {
            return client.GetAllClients();
        }

        [Route("login/{name}/{password}")]
        [HttpGet]
        public int login(string name,string password)
        {
            return client.login(name,password);
        }

   
    }
}
