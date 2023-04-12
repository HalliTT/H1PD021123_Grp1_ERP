namespace App
{
    public class OrderLine
    {
        public OrderLine(int ordersId,
                         int productId,
                         int amount)
        {
            this.ordersId = ordersId;
            this.productId = productId;
            this.amount = amount;
        }

        //OrderId
        protected int _ordersId;
        public int ordersId
        {
            set { _ordersId = value; }
            get { return _ordersId; }
        }

        //ProductId
        protected int _productId;
        public int productId
        {
            set { _productId = value; }
            get { return _productId; }
        }

        //Amount
        protected int _amount;
        public int amount
        {
            set { _amount = value; }
            get { return _amount; }
        }

    }
}