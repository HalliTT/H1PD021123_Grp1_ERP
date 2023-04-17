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
        public Sales(string creationTimestamp,
                     string doneTimestamp,
                     int customerId,
                     State state,
                     uint totalOrderPrice)
        {
            this.creationTimestamp = creationTimestamp;
            this.doneTimestamp = doneTimestamp;
            this.customerId = customerId;
            this.state = state;
            this.totalOrderPrice = totalOrderPrice;
        }

        protected int _id;
        public int id
        {
            set { _id = value; }
            get { return _id; }
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

        protected int _customerId;
        public int customerId
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

        public string fullName
        {
            get {
                var db = new Database();
                
                var person = db.GetPerson(this._customerId);

                if (person.Capacity > 0)
                {
                    return person[0].fullName;
                }

                return "Unknown";
            }
        }

        protected uint _totalOrderPrice;
        public uint totalOrderPrice
        {
            set { _totalOrderPrice = value; }
            get { return _totalOrderPrice; }
        }
    }
}