using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

public class DBConnectivity
{
    // Database connection handling
    private static OleDbConnection GetConnection()
    {
        string connString;
        //  change to your connection string in the following line
        connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "FWP.accdb";
        return new OleDbConnection(connString);
    }

    /**
     * Add new spieces to database and return inserted spiece as object
    **/
    public static Spieces addSpieces(string name)
    {
        OleDbConnection myConnection = GetConnection();
        string myQuery = "INSERT INTO spieces (name) VALUES ('" + name + "')";
        OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception in DBHandler", ex);
        }
        finally
        {
            myConnection.Close();
        }
        return null;
    }

    /**
     * Add new breed to database and return inserted breed as object
    **/
    public static Breed addBreed(string name, int spiecesId)
    {
        OleDbConnection myConnection = GetConnection();
        string myQuery = "INSERT INTO breeds (name, spieces_id) VALUES ('" + name + "', '" + spiecesId + "')";
        OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception in DBHandler", ex);
        }
        finally
        {
            myConnection.Close();
        }
        return null;
    }

    // Method that returns a list of Spieces objects with the details from the DB
    public static List<Spieces> LoadSpieces()
    {
        List<Spieces> spieces = new List<Spieces>();
        OleDbConnection myConnection = GetConnection();

        string myQuery = "SELECT id, name FROM spieces";
        OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

        try
        {
            myConnection.Open();
            OleDbDataReader myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                Spieces spiece = new Spieces(int.Parse(myReader["id"].ToString()), myReader["name"].ToString());
                spieces.Add(spiece);
            }
            return spieces;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception in DBHandler", ex);
            return null;
        }
        finally
        {
            myConnection.Close();
        }
    }

    // Search for the specific spieces by ID
    public static Spieces FindSpieces(List<Spieces> spieces, int spieceId)
    {
        foreach (var spiece in spieces)
        {
            if (spiece.Id == spieceId)
            {
                return spiece;
            }
        }
        return null;
    }

    // Method that returns a list of Breeds objects with the details from the DB
    public static List<Breed> LoadBreeds()
    {
        List<Breed> breeds = new List<Breed>();
        OleDbConnection myConnection = GetConnection();

        string myQuery = "SELECT id, spieces_id, name FROM breeds";
        OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

        try
        {
            myConnection.Open();
            OleDbDataReader myReader = myCommand.ExecuteReader();

            List<Spieces> spieces = LoadSpieces();

            while (myReader.Read())
            {
                Spieces spiece = FindSpieces(spieces, int.Parse(myReader["id"].ToString()));
                Breed breed = new Breed(int.Parse(myReader["id"].ToString()), myReader["name"].ToString(), spiece);
                breeds.Add(breed);
            }
            return breeds;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception in DBHandler", ex);
            return null;
        }
        finally
        {
            myConnection.Close();
        }
    }
}