namespace App
{
    public class OrderLine
    {
        public OrderLine(Guid id,
                         Product product,
                         uint quantity,
                         Guid salesId,
                         Guid productId)
        {
            this.id = id;
            this.product = product;
            this.quantity = quantity;
            this.salesId = salesId;
            this.productId = productId;
        }

        protected Guid _id;
        public Guid id
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

        protected Guid _salesId;
        public Guid salesId
        {
            set { _salesId = value; }
            get { return _salesId; }
        }

        protected Guid _productId;
        public Guid productId
        {
            set { _productId = value; }
            get { return _productId; }
        }

    }
}