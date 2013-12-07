using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FWP
{
    public class Sanctuary
    {
        public int id {get; private set;} 
        public string name {get; private set;}

        public Sanctuary(int id, string name)
	    {
            this.id = id;
            this.name = name;
	    }
    }
}