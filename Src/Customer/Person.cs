﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public Person(Guid id, string firstName, string lastName, string phone, string mail, Adress address, Role role, string creationTimeStamp)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phone = phone;
            this.mail = mail;
            this.address = address;
            this.role = role;
            this.creationTimeStamp = creationTimeStamp;
        }

        //Id
        protected Guid _id;
        public Guid id
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

        //// -------- MARCUS LOOK AT THIS -------- ////
        //FullName
        public string getFullName()
        {
            string fullname = firstName + " " + lastName;
            return fullname;
        }

    }
}
