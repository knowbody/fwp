using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FWP
{
    public class Staff
    {
        public int id {get; private set;} 
        public string firstName {get; private set;}
        public string lastName { get; private set; }
        public string email { get; private set; }
        public string pass { get; private set; }

        public Staff(int id, string firstName, string lastName, string email, string pass)
	    {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.pass = pass;
	    }
    }
}