namespace App
{
    public enum Role
    {
        Customer,
        Admin,
    };

    public class Person
    {
        //Constructor
        public Person(
                      string firstName,
                      string lastName,
                      string phone,
                      string mail,
                      Adress address,
                      Role role,
                      string creationTimeStamp)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phone = phone;
            this.mail = mail;
            this.address = address;
            this.role = role;
            this.creationTimeStamp = creationTimeStamp;

            this._creationTimeStamp = getLastPurchase();
            this._fullName = getFullName();
        }

        public Person()
        {
            this._fullName = getFullName();
        }

        //Id
        protected int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        //Name
        protected string _firstName;
        public string firstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        //Last Name
        protected string _lastName;
        public string lastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        //Phone
        protected string _phone;
        public string phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        //Email
        protected string _mail;
        public string mail
        {
            get { return _mail; }
            set { _mail = value; }
        }

        //Adress
        protected Adress _adress;
        public Adress address
        {
            get { return _adress; }
            set { _adress = value; }
        }

        //Role
        protected Role _role;
        public Role role
        {
            get { return _role; }
            set { _role = value; }
        }

        //creationTimeStamp
        protected string _creationTimeStamp;
        public string creationTimeStamp
        {
            get { return _creationTimeStamp; }
            set { _creationTimeStamp = value; }
        }

        protected string _lastPurchase;
        public string lastPurchase
        {
            get { return _lastPurchase; }
            set
            {
                var db = new Database();
                var orders = db.GetOrder();

                foreach (var order in orders)
                {
                    if (order.customerId == this.id)
                    {
                        _lastPurchase = order.creationTimestamp;
                    }
                }
            }
        }

        protected string _fullName;

        public string fullName
        {
            get { return _fullName; }
        }

        public string getFullName()
        {
            return this.firstName + " " + this.lastName;
        }

        public string getLastPurchase()
        {
            var db = new Database();
            var orders = db.GetOrder();

            var creationTimeStamp = this.creationTimeStamp;

            foreach (var order in orders)
            {
                if (order.customerId == this.id)
                {
                    creationTimeStamp = order.creationTimestamp;
                }
            }

            return creationTimeStamp;
        }
    }
}
