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
                             string firstName,
                             string lastName,
                             uint totalOrderPrice) 
                             : base (orderId,
                             creationTimestamp,
                             doneTimestamp,
                             customerId,
                             state,
                             orderLine,
                             totalOrderPrice)
        {
            this.firstName  = firstName;
            this.lastName   = lastName;
        }

        protected string _firstName = null!;
        public string firstName 
        {
            set { _firstName = value; }
            get { return _firstName; }
        }

        protected string _lastName = null!;
        public string lastName 
        {
            set { _lastName = value; }
            get { return _lastName; }
        }

        // Return a list where first and last name has been added to the Sales object
        public List<ExtendedSales> SalesWihName(List<ExtendedSales> list)
        {
            list.Add(this);

            return list;
        }

        
    }
}