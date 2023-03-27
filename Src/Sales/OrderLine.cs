namespace App
{
    public class OrderLine
    {
        public OrderLine(string id, 
                         Product product, 
                         uint quantity, 
                         string salesId, 
                         string productId)
        {
            this.id         = id;
            this.product    = product;
            this.quantity   = quantity;
            this.salesId    = salesId;
            this.productId  = productId;
        }

        protected string _id;
        public string id
        {
            set { _id = value; }
            get { return _id; }
        }

        protected Product _product;
        public Product product
        {
            set { _product = value; }
            get { return _product; }
        }

        protected uint _quantity;
        public uint quantity
        {
            set { _quantity = value; }
            get { return _quantity; }
        }

        protected string _salesId;
        public string salesId
        {
            set { _salesId = value; }
            get { return _salesId; }
        }

        protected string _productId;
        public string productId
        {
            set { _productId = value; }
            get { return _productId; }
        }
        
    }   
}