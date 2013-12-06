using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FWP
{
    public class Pet
    {
        public int id {get; private set;} 
        public string name {get; private set;}
        public Breed breed {get; private set;}
        public Spieces spieces { get; private set; }
        public int sanctuary {get; private set;}
        public String sanctuaryName
        {
            get { return sanctuaryIntToString(sanctuary); }
        }

        public int age { get; private set; }
        public String ageString
        {
            get { return age + " Years"; }
        }

        public int gender { get; private set; }
        public String genderString
        {
            get { return genderIntToString(gender); }
        }

        public double weight { get; private set; }
        public String weightKg
        {
            get { return weight + " Kg"; }
        }

        public DateTime rescueD { get; private set; }
        public String RescueDShort
        {
            get { return rescueD.ToShortDateString(); }
        }

        public double bills { get; private set; } 
        public String FormatedBills
        {
            get { return bills.ToString("C2"); }
        }

        public string picturePath { get; private set; }
        public String pictureUrl
        {
            get { return ""; }
        }

        public Pet(int id, string name, Breed breed, Spieces spieces, int sanctuary, int age, int gender, double weight, double bills, DateTime rescueD, string picturePath)
	    {
            this.id = id;
            this.name = name;
            this.breed = breed;
            this.spieces = spieces;
            this.sanctuary = sanctuary;
            this.age = age;
            this.gender = gender;
            this.weight = weight;
            this.bills = bills;
            this.rescueD = rescueD;
            this.picturePath = picturePath;
	    }

        public static String genderIntToString(int gender) {
            return (gender == 1) ? "Male" : "Female";
        }

        public static String sanctuaryIntToString(int sanctuaryId)
        {
            switch (sanctuaryId)
            {
                case 1:
                    return "Sanctuary 1";
                case 2:
                    return "Sanctuary 2";
                case 3:
                    return "Sanctuary 3";
            }
            return "";
        }
    }
}