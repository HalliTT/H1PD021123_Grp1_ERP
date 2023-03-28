using App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1PD021123_Grp1_ERP.Product
{
    class ProductList
    {
        public string productId { get; set; } = "";
        public string name { get; set; } = "";
        public double purchasePrice { get; set; }
        public double salesPrice { get; set; } 
        public string location { get; set; } = "";
        public string amountInStock { get; set; } = "";
        public Unit unit { get; set; } 

    }
}
