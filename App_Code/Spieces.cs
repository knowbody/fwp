using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FWP { 
    public class Spieces
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

	    public Spieces(int id, string name)
	    {
            this.name = name;
            this.id = id;
	    }
    }
}