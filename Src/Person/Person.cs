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
            _firstName = firstName;
            _lastName = lastName;
            _phone = phone;
            _email = email;
            _address = address;
            _role = role;

            // Creation timestamp is equal to GetLastPurchase(), 
            // since user will created when purchase has been made.
            if (role == Role.Customer)
            {
                _creationTimeStamp = GetLastPurchase();
            }
            else
            {
                _creationTimeStamp = DateTime.Now.ToString();
            }

            _fullName = GetFullName();
        }

        public Person(
                      int id,
                      string firstName,
                      string lastName,
                      string phone,
                      string email,
                      Address address,
                      Role role,
                      string creationTimeStamp)
        {
            _id = id;
            _firstName = firstName;
            _lastName = lastName;
            _phone = phone;
            _email = email;
            _address = address;
            _role = role;
            _creationTimeStamp = creationTimeStamp;

            // Creation timestamp is equal to GetLastPurchase(), 
            // since user will created when purchase has been made.
            if (role == Role.Customer)
            {
                _creationTimeStamp = GetLastPurchase();
            }
            else
            {
                _creationTimeStamp = DateTime.Now.ToString();
            }

            _fullName = GetFullName();
        }

        protected int _id;
        public int id
        {
            set { _id = value; }
            get { return _id; }
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

        protected string _phone = null!;
        public string phone
        {
            set { _phone = value; }
            get { return _phone; }
        }

        protected string _email = null!;
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }

        protected Address _address = null!;
        public Address address
        {
            set { _address = value; }
            get { return _address; }
        }

        public string addressAsStr
        {
            get { return address.ToString(); }
        }

        public string addressRoadName
        {
            set { address.roadName = value; }
            get { return address.roadName; }
        }

        public string addressDoorNumber
        {
            set { address.doorNumber = value; }
            get { return address.doorNumber; }
        }

        public string addressZipCode
        {
            set { address.zipCode = value; }
            get { return address.zipCode; }
        }

        public string addressCity
        {
            set { address.city = value; }
            get { return address.city; }
        }

        public string addressCountry
        {
            set { address.country = value; }
            get { return address.country; }
        }

        protected Role _role;
        public Role role
        {
            get { return _role; }
        }

        protected string _creationTimeStamp = null!;
        public string creationTimeStamp
        {
            get { return _creationTimeStamp; }
            set { _creationTimeStamp = value; }
        }

        public string lastPurchase
        {
            get { return GetLastPurchase(); }
        }

        protected string _fullName = null!;

        public string fullName
        {
            get { return _fullName; }
        }

        public string GetFullName()
        {
            return _firstName + " " + _lastName;
        }

        public string GetLastPurchase()
        {
            var db = new Database();
            var orders = db.GetOrder();

            var lastPurchase = _creationTimeStamp;

            foreach (var order in orders)
            {
                if (order.customerId == _id)
                {
                    _creationTimeStamp = order.creationTimestamp;
                }
            }

            return lastPurchase;
        }
    }
}
