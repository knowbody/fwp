using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FWP 
{ 
    public class Spieces
    {
        public int id {get; private set;}
        public string name { get; private set; }

	    public Spieces(int id, string name)
	    {
            this.name = name;
            this.id = id;
	    }
    }
}