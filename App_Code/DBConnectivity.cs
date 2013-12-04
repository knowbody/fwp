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
     * Add new breed to database and return inserted breed as object
    **/
    public static Spieces addBreed(string name)
    {
        OleDbConnection myConnection = GetConnection();
        string myQuery = "INSERT INTO Breeds (name) VALUES ('" + name + "')";
        OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

        try
        {
            myConnection.Open();
            myCommand.ExecuteNonQuery();
            return new Spieces(name);
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

    // Method that returns a list of Author objects with the details from the DB
    public static List<Spieces> LoadSpieces()
    {
        List<Spieces> spieces = new List<Spieces>();
        OleDbConnection myConnection = GetConnection();

        string myQuery = "SELECT name FROM Breeds";
        OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

        try
        {
            myConnection.Open();
            OleDbDataReader myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                Spieces spiece = new Spieces(myReader["name"].ToString());
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
}