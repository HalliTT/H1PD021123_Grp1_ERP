namespace App
{
    public enum State 
    {
        None,
        Created,
        Approved,
        Packaged,
        Done,
    }

    public class Sales
    {
        public Sales(uint orderNumber, 
                   string creationTimestamp, 
                   string doneTimestamp, 
                   string customerNumber,
                   State state,
                   List<OrderLine> orderLine,
                   uint totalOrderPrice) 
        {
            this.orderNumber         = orderNumber;
            this.creationTimestamp   = creationTimestamp;
            this.doneTimestamp       = doneTimestamp;
            this.customerNumber      = customerNumber;
            this.state               = state;
            this.orderLine           = orderLine;
            this.totalOrderPrice     = totalOrderPrice;
        }

        protected uint _orderNumber;
        public uint orderNumber
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

        protected List<OrderLine> _orderLine = null!;
        public List<OrderLine> orderLine
        {
            set { _orderLine = value; }
            get { return _orderLine; }
        }

        protected uint _totalOrderPrice;
        public uint totalOrderPrice
        {
            set { _totalOrderPrice = value; }
            get { return _totalOrderPrice; }
        }
    }
}