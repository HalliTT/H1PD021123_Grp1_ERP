namespace App
{
    public class OrderLine
    {
        public OrderLine(int ordersId,
                         int productId,
                         int amount)
        {
            _ordersId = ordersId;
            _productId = productId;
            _amount = amount;
        }

        protected int _Id;
        public int Id
        {
            set { _Id = value; }
            get { return _Id; }
        }

        protected int _ordersId;
        public int ordersId
        {
            get { return _ordersId; }
        }

        protected int _productId;
        public int productId
        {
            get { return _productId; }
        }

        protected int _amount;
        public int amount
        {
            get { return _amount; }
        }

    }
}