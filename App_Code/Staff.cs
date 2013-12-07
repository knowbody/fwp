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
        public String FullName
        {
            get { return firstName + " " + lastName; }
        }

        public string email { get; private set; }
        public string pass { get; private set; }
        public int access { get; private set; }
        public String AccessLevelName
        {
            get { return accessLevelIntToStr(access); }
        }

        public Staff(int id, string firstName, string lastName, string email, string pass, int access)
	    {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.pass = pass;
            this.access = access;
	    }

        private String accessLevelIntToStr(int access)
        {
            switch (access)
            {
                case 1:
                    return "Administrator";
                case 2:
                    return "Moderator";
                default:
                    return "Dirty Alien";
            }
        }
    }
}