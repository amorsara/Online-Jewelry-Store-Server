using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class ProductBLL
    {
        DBConnection dbCon;
        List<Product> listOfProducts;

        public ProductBLL()
        {
            dbCon = new DBConnection();
            listOfProducts = dbCon.GetDbSet<Product>().ToList();
        }

        public  Product[] GetAllProduct()
        {
            return listOfProducts.ToArray();
        }

        public string InsertProduct(Product product)
        {
            if (listOfProducts.Find(p => p.codeProduct == product.codeProduct) == null)
            {
                try
                {
                    dbCon.Execute<Product>(product, DBConnection.ExecuteActions.Insert);
                    return product.codeProduct.ToString();
                }
                catch (Exception ex)
                {
                    return "error";
                }
            }
            else
                return "product is exist";
        }
        public int UpdateProduct(Product product)
        {
            try
            {
                dbCon.Execute<Product>(product, DBConnection.ExecuteActions.Update);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int DeleteProduct(Product product)
        {
            try
            {
                dbCon.Execute<Product>(product, DBConnection.ExecuteActions.Delete);
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public List<Product> Buy(List<Product> listOfProducts, Clients client)
        {
            listOfProducts = listOfProducts.Where(x => x.countProduct > 0).ToList();
            //עדכון מוצרים
            List<Product> buy = new List<Product>();
            decimal sum = 0;
            foreach (Product item in listOfProducts)
            {
                Product p = GetAllProduct().Where(x => x.codeProduct == item.codeProduct).FirstOrDefault();
                if (p != null && item.countProduct <= p.countProduct)
                {
                    p.countProduct = p.countProduct - item.countProduct;
                    if (UpdateProduct(p) == 1)
                    {
                        buy.Add(item);
                        sum += p.priceProduct * item.countProduct;
                    }
                    else
                    {
                        item.countProduct = 0;
                        buy.Add(item);
                    }
                }
                else
                {
                    item.countProduct = 0;
                    buy.Add(item);
                }
            }
            //עדכון הזמנה
            if (sum > 0)
            {
                Orders order = new Orders()
                {
                    codeOrder = dbCon.GetDbSet<Orders>().Last()?.codeOrder != null ? dbCon.GetDbSet<Orders>().Last().codeOrder + 1 : 1,
                    codeClient = (int)new ClientsBLL().getClientById(client.codeClient)?.codeClient/*,*/
                    //sumOrders = sum
                };
                OrdersBLL orderBLL = new OrdersBLL();
                orderBLL.InsertOrders(order);

                //עדכון פרטים
                foreach (Product item in buy)
                {
                    if (item.countProduct > 0)
                    {
                        OrderDetails orderDetail = new OrderDetails()
                        {
                            codeOrderDetails = dbCon.GetDbSet<OrderDetails>()?.Last() != null ? dbCon.GetDbSet<OrderDetails>().Last().codeOrderDetails + 1 : 1,
                            codeOrder = order.codeOrder,
                            codeProduct = item.codeProduct,
                            Counts=item.countProduct
                        };
                        new OrderDetailsBLL().InsertOrderDetails(orderDetail);
                    }
                }
            }
            return buy;
        }
    }
}

