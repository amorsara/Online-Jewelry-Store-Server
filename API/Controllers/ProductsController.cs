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
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        ProductBLL productP = new ProductBLL();
        [AcceptVerbs("GET", "POST")]
        [Route("insert")]
        [HttpPost]

        public string insert(Product p)
        {
            return productP.InsertProduct(p);
        }
        [Route("delete")]
        [HttpPost]

        public int delete(Product p)
        {
            return productP.DeleteProduct(p);
        }
        [Route("update")]
        [HttpPost]

        public int update(Product p)
        {
            return productP.UpdateProduct(p);
        }

        [Route("getall")]
        [HttpGet]
        public Product[] getall()
        {
            return productP.GetAllProduct();
        }

        [Route("buy")]
        [HttpPost]
        public List<Product> Buy(ListToBuy listToBuy)
        {
            List<Product> products = listToBuy.listOfProducts.Select(x => new Product
            {
                priceProduct=x.priceProduct,
                materialProduct=x.materialProduct,
                countProduct = x.countProduct,
                codeProduct = x.codeProduct,
                nameProduct = x.nameProduct,
                colorProduct=x.colorProduct,
                descriptionProduct=x.descriptionProduct
               
            }).ToList();
            Clients client = new Clients()
            {
                codeClient = listToBuy.client.codeClient,
                IdClient = listToBuy.client.IdClient,
                nameClient = listToBuy.client.nameClient,
                PasswordClient = listToBuy.client.PasswordClient,
                phoneClient=listToBuy.client.phoneClient
            };
            List<Product> p = productP.Buy(products, client).Select(x => new Product
            {
                countProduct = x.countProduct,
                codeProduct = x.codeProduct,
                nameProduct = x.nameProduct,
                colorProduct = x.colorProduct,
                priceProduct = x.priceProduct
            }).ToList();

            return p;
        }
    }

}


