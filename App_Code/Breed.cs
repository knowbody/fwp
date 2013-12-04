using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Breed
{
    public int id;
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string spieceName;
    public string SpieceName
    {
        get { return spieceName; }
        set { spieceName = value; }
    }

    private Spieces spieces;
    public Spieces Spieces
    {
        get { return spieces; }
        set { spieces = value; }
    }

	public Breed(int id, string name, Spieces spieces)
	{
        this.id = id;
        this.name = name;
        this.spieces = spieces;
        this.spieceName = spieces.Name;
	}
}