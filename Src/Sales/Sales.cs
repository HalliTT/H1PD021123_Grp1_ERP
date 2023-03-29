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
        public Sales(Guid orderId,
                   string creationTimestamp,
                   string doneTimestamp,
                   Guid customerId,
                   State state,
                   List<OrderLine> orderLine,
                   uint totalOrderPrice)
        {
            this.orderId = orderId;
            this.creationTimestamp = creationTimestamp;
            this.doneTimestamp = doneTimestamp;
            this.customerId = customerId;
            this.state = state;
            this.orderLine = orderLine;
            this.totalOrderPrice = totalOrderPrice;
        }

        protected Guid _orderId;
        public Guid orderId
        {
            set { _orderId = value; }
            get { return _orderId; }
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

        protected Guid _customerId;
        public Guid customerId
        {
            set { _customerId = value; }
            get { return _customerId; }
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