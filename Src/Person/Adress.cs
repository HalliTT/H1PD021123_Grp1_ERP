using System.Text;

namespace App
{
    /// 
    /// Address used in Person
    ///
    public class Address
    {
        //Constructor
        public Address(string country, string zipCode, string city, string roadName, string doorNumber)
        {
            _country = country;
            _zipCode = zipCode;
            _city = city;
            _roadName = roadName;
            _doorNumber = doorNumber;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            return sb.AppendFormat($"{_roadName}, {_doorNumber}, {_zipCode}, {_city}").ToString();
        }

        //Country
        protected string _country = null!;
        public string country
        {
            set { _country = value; }
            get { return _country; }
        }

        //Zip
        protected string _zipCode = null!;
        public string zipCode
        {
            set { _zipCode = value; }
            get { return _zipCode; }
        }

        //City
        protected string _city = null!;
        public string city
        {
            set { _city = value; }
            get { return _city; }
        }

        //Road
        protected string _roadName = null!;
        public string roadName
        {
            set { _roadName = value; }
            get { return _roadName; }
        }

        //Door
        protected string _doorNumber = null!;
        public string doorNumber
        {
            set { _doorNumber = value; }
            get { return _doorNumber; }
        }
    }
}
