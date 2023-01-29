using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Convert
{
    class Product
    {
        public Product() { }
        public int codeProduct { get; set; }
        public String nameProduct { get; set; }
        public String colorProduct { get; set; }
        public String materialProduct { get; set; }
        public int countProduct { get; set; }
        public int priceProduct { get; set; }
        public String descriptionProduct { get; set; }
    }
}
