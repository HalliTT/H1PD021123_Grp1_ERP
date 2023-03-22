namespace App.Sales
{
    enum State 
    {
        None,
        Created,
        Approved,
        Packaged,
        Done,
    }

    class Sales
    {
        public Sales(string _orderNumber, 
                   string _creationTimestamp, 
                   string _doneTimestamp, 
                   string _customerNumber,
                   State _state,
                   List<Product> _orderList,
                   uint totalOrderPrice) 
        {
            orderNumber         = _orderNumber;
            creationTimestamp   = _creationTimestamp;
            doneTimestamp       = _doneTimestamp;
            customerNumber      = _customerNumber;
            state               = _state;
            orderList           = _orderList;
            totalOrderPrice     = _totalOrderPrice;
        }

        protected string _orderNumber = null!;
        public string orderNumber
        {
            set { _orderNumber = value; }
            get { return _orderNumber; }
        }

        protected string _creationTimestamp = null!;
        public string creationTimestamp
        {
            set { _creationTimestamp = value; }
            get { return _creationTimestamp; }
        }

        protected string _doneTimestamp = null!;
        public string doneTimestamp
        {
            set { _doneTimestamp = value; }
            get { return _doneTimestamp; }
        }

        protected string _customerNumber = null!;
        public string customerNumber
        {
            set { _customerNumber = value; }
            get { return _customerNumber; }
        }

        protected State _state;
        public State state
        {
            set { _state = value; }
            get { return _state; }
        }

        protected List<Product> _orderList;
        public List<Product> orderList
        {
            set { _orderList = value; }
            get { return _orderList; }
        }

        protected uint _totalOrderPrice;
        public uint totalOrderPrice
        {
            set { _totalOrderPrice = value; }
            get { return _totalOrderPrice; }
        }
    }
}