using App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1PD021123_Grp1_ERP.Product
{
    class ProductDescriprion
    {
        public string productId { get; set; } = "";

        public string productName { get; set; } = "";

        public string productDescription { get; set; } = "";

        public double salesPrice { get; set; }
        public double purchasePrice { get; set; }
        public string location { get; set; } = "";
        public double quantity { get; set; }

        public Unit unit { get; set; }

        public decimal profitInPercentage { get; set; }

        public decimal profitInDkk { get; set; }
             
        public ProductDescriprion(string productId, string productName, string productDescription, double salesPrice, double purchasePrice, string location, double quantity, Unit unit, decimal profitInPercentage, decimal profitInDkk)
        {
            this.productId = productId;
            this.productName = productName;
            this.productDescription = productDescription;
            this.salesPrice = salesPrice;
            this.purchasePrice = purchasePrice;
            this.location = location;
            this.quantity = quantity;
            this.unit = unit;
            this.profitInPercentage = profitInPercentage;
            this.profitInDkk = profitInDkk;
        }

    }
}
