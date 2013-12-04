using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Breed
{
    public string name { get; private set; }
    private Spieces spieces;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

	public Breed(string name)
	{
        this.name = name;
	}
}