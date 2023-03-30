namespace App
{
    public class ExtendedSales : Sales
    {
        public ExtendedSales(Guid orderId,
                             string creationTimestamp,
                             string doneTimestamp,
                             Guid customerId,
                             State state,
                             List<OrderLine> orderLine,
                             string name,
                             uint totalOrderPrice)
                             : base(orderId,
                             creationTimestamp,
                             doneTimestamp,
                             customerId,
                             state,
                             orderLine,
                             totalOrderPrice)
        {
            this.name = name;
        }

        protected string _name = null!;
        public string name
        {
            set { _name = value; }
            get { return _name; }
        }

        protected string _lastName = null!;
        public string lastName
        {
            set { _lastName = value; }
            get { return _lastName; }
        }



    }
}