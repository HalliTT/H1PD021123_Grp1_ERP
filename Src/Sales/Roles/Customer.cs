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
                             string lastName,
                             uint totalOrderPrice)
                             : base(
                             creationTimestamp,
                             doneTimestamp,
                             customerId,
                             state,
                             totalOrderPrice)
        {
            this._firstName = firstName;
            this._lastName = lastName;
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
    }
}