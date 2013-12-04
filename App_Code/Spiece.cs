using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Spieces
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

	public Spieces(string name)
	{
        this.name = name;
	}
}