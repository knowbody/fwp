using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FWP
{
    public class Breed
    {
        public int id {get; private set;} 
        public string name {get; private set;}
        public Spieces spieces {get; private set;}
        public String NameWithSpieces
        {
            get { return name + " (" + spieces.name + ")"; }
        }

        public double foodCost { get; private set; }
        public String FormatedFoodCost
        {
            get { return foodCost.ToString("C2"); }
        }

        public double housCost { get; private set; }
        public String FormatedHousCost
        {
            get { return housCost.ToString("C2"); }
        }


        public Breed(int id, string name, Spieces spieces, double foodCost, double housCost)
	    {
            this.id = id;
            this.name = name;
            this.spieces = spieces;
            this.foodCost = foodCost;
            this.housCost = housCost;
	    }

    }
}