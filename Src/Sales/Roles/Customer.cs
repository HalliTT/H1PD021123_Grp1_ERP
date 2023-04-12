namespace App
{
    public class ExtendedSales : Sales
    {
        public ExtendedSales(
                             string creationTimestamp,
                             string doneTimestamp,
                             int customerId,
                             State state,
                             string name,
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