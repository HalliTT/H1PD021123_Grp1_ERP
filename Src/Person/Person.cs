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
                      string email,
                      Address address,
                      Role role)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.phone = phone;
            this.email = email;
            this.address = address;
            this.role = role;

            // Creation timestamp is equal to GetLastPurchase(), 
            // since user will created when purchase has been made.
            if (role == Role.Customer)
            {
                this._creationTimeStamp = GetLastPurchase();
            }
            else
            {
                this._creationTimeStamp = DateTime.Now.ToString();
            }

            this._fullName = GetFullName();
        }

        public Person() {}

        protected int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        protected string _firstName;
        public string firstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        protected string _lastName;
        public string lastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        protected string _phone;
        public string phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        protected string _email;
        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        protected Address _address;
        public Address address
        {
            get { return _address; }
            set { _address = value; }

        }

        public string addressRoadName
        {
            get { return address.roadName; }
        }

        public string addressDoorNumber
        {
            get { return address.doorNumber; }
        }

        public string addressZipCode
        {
            get { return address.zipCode; }
        }

        public string addressCity
        {
            get { return address.city; }
        }

        protected Role _role;
        public Role role
        {
            get { return _role; }
            set { _role = value; }
        }

        protected string _creationTimeStamp;
        public string creationTimeStamp
        {
            get { return _creationTimeStamp; }
            set { _creationTimeStamp = value; }
        }

        public string lastPurchase
        {
            get { return GetLastPurchase(); }
        }

        protected string _fullName;

        public string fullName
        {
            get { return _fullName; }
        }

        public string GetFullName()
        {
            return this.firstName + " " + this.lastName;
        }

        public string GetLastPurchase()
        {
            var db = new Database();
            var orders = db.GetOrder();

            var lastPurchase = this.creationTimeStamp;

            foreach (var order in orders)
            {
                if (order.customerId == this.id)
                {
                    creationTimeStamp = order.creationTimestamp;
                }
            }

            return lastPurchase;
        }
    }
}
