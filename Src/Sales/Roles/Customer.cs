namespace App
{
    public class Customer : Sales
    {
        public Customer(
                             string creationTimestamp,
                             string doneTimestamp,
                             int customerId,
                             State state,
                             string firstName,
                             uint totalOrderPrice)
                             : base(
                             creationTimestamp,
                             doneTimestamp,
                             customerId,
                             state,
                             totalOrderPrice)
        {
            this.name = name;
        }

        protected string _name = null!;
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
    }
}