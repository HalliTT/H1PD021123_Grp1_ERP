namespace App
{
    public enum State
    {
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
            _creationTimestamp = creationTimestamp;
            _doneTimestamp = doneTimestamp;
            _customerId = customerId;
            _state = state;
            _totalOrderPrice = totalOrderPrice;

            _cachedCustomerId = _customerId;
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
            get { return _creationTimestamp; }
        }

        protected string _doneTimestamp = null!;
        public string doneTimestamp
        {
            get { return _doneTimestamp; }
        }

        protected int _customerId;
        public int customerId
        {
            set { _customerId = value; }
            get { return _customerId; }
        }

        protected int _cachedCustomerId;
        public int cachedCustomerId
        {
            set { _cachedCustomerId = value; }
            get { return _cachedCustomerId; }
        }

        protected State _state;
        public State state
        {
            get { return _state; }
        }

        protected uint _totalOrderPrice;
        public uint totalOrderPrice
        {
            get { return _totalOrderPrice; }
        }

        public string fullName
        {
            get
            {
                var db = new Database();

                var person = db.GetPerson(_customerId);

                if (person.Capacity > 0)
                {
                    return person[0].fullName;
                }
                return "Unknown";
            }
        }
    }
}