using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

namespace FWP
{
    public class DBConnectivity
    {
        // Database connection handling
        private static OleDbConnection GetConnection()
        {
            string connString;
            connString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "App_Data/FWP.accdb";
            return new OleDbConnection(connString);
        }

        // Add new spieces to database
        public static Boolean addSpieces(string name)
        {
            OleDbConnection myConnection = GetConnection();
            string myQuery = "INSERT INTO spieces (name) VALUES (?)";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
            myCommand.Parameters.Add("@name", OleDbType.VarWChar, 50).Value = name;

            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return false;
            }
            finally
            {
                // if (myConnection != null)    <-- I think that's how we should do close connection
                myConnection.Close();
            }
        }

        // Add new breed to database
        public static Boolean addBreed(string[,] breedData)
        {
            OleDbConnection myConnection = GetConnection();
            string myQuery = "INSERT INTO breeds (name, spieces_id, food_cost, housing_cost) VALUES (?, ?, ?, ?)";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
            myCommand.Parameters.Add("@name", OleDbType.VarWChar, 50).Value = breedData[0, 1];
            myCommand.Parameters.Add("@spieces_id", OleDbType.Integer, 5).Value = breedData[1, 1];
            myCommand.Parameters.Add("@food_cost", OleDbType.Double, 5).Value = breedData[2, 1];
            myCommand.Parameters.Add("@housing_cost", OleDbType.Double, 5).Value = breedData[3, 1];

            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return false;
            }
            finally
            {
                myConnection.Close();
            }
        }

        // Add new pet to database
        public static Boolean addPet(string[,] petData)
        {
            OleDbConnection myConnection = GetConnection();
            string myQuery = "INSERT INTO pets (name, breed_id, spieces_id, sanctuary_id, age, gender, weight, bills, rescue_date, picture_path) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
            myCommand.Parameters.Add("@name", OleDbType.VarWChar, 50).Value = petData[0, 1];
            myCommand.Parameters.Add("@breed_id", OleDbType.Integer, 5).Value = petData[1, 1];
            myCommand.Parameters.Add("@spieces_id", OleDbType.Integer, 5).Value = petData[2, 1];
            myCommand.Parameters.Add("@sanctuary_id", OleDbType.Integer, 5).Value = petData[3, 1];
            myCommand.Parameters.Add("@age", OleDbType.Integer, 3).Value = petData[4, 1];
            myCommand.Parameters.Add("@gender", OleDbType.Integer, 1).Value = petData[5, 1];
            myCommand.Parameters.Add("@weight", OleDbType.Double, 5).Value = petData[6, 1];
            myCommand.Parameters.Add("@bills", OleDbType.Double, 5).Value = petData[7, 1];
            myCommand.Parameters.Add("@rescue_date", OleDbType.DBDate).Value = petData[8, 1];
            myCommand.Parameters.Add("@picture_path", OleDbType.VarWChar, 50).Value = petData[9, 1];

            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return false;
            }
            finally
            {
                myConnection.Close();
            }
        }

        // Add new breed to database
        public static Boolean addStaff(string[,] staffData)
        {
            OleDbConnection myConnection = GetConnection();
            string myQuery = "INSERT INTO staff (first_name, last_name, email, pass, access) VALUES (?, ?, ?, ?, ?)";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
            myCommand.Parameters.Add("@first_name", OleDbType.VarWChar, 50).Value = staffData[0, 1];
            myCommand.Parameters.Add("@last_name", OleDbType.VarWChar, 50).Value = staffData[1, 1];
            myCommand.Parameters.Add("@email", OleDbType.VarWChar, 50).Value = staffData[2, 1];
            myCommand.Parameters.Add("@pass", OleDbType.VarWChar, 50).Value = staffData[3, 1];
            myCommand.Parameters.Add("@access", OleDbType.Integer, 1).Value = staffData[4, 1];

            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return false;
            }
            finally
            {
                myConnection.Close();
            }
        }

        // Delete pet in the DB
        public static void DeletePet(string id)
        {
            OleDbConnection myConnection = GetConnection();

            string myQuery = "DELETE FROM pets WHERE ID = ?";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
            myCommand.Parameters.Add("@ID", OleDbType.Integer, 5).Value = id;

            try
            {
                myConnection.Open();
                myCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
            }
            finally
            {
                myConnection.Close();
            }
        }

        // Delete spieces in the DB
        public static void DeleteSpieces(string id)
        {
            OleDbConnection myConnection = GetConnection();

            string myQuery = "DELETE FROM spieces WHERE ID = ?";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
            myCommand.Parameters.Add("@ID", OleDbType.Integer, 5).Value = id;

            try
            {
                myConnection.Open();
                myCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
            }
            finally
            {
                myConnection.Close();
            }
        }

        // Delete breed in the DB
        public static void DeleteBreed(string id)
        {
            OleDbConnection myConnection = GetConnection();

            string myQuery = "DELETE FROM breeds WHERE ID = ?";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
            myCommand.Parameters.Add("@ID", OleDbType.Integer, 5).Value = id;

            try
            {
                myConnection.Open();
                myCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
            }
            finally
            {
                myConnection.Close();
            }
        }

        // Delete staff memeber in the DB
        public static void DeleteStaff(string id)
        {
            OleDbConnection myConnection = GetConnection();

            string myQuery = "DELETE FROM staff WHERE ID = ?";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
            myCommand.Parameters.Add("@ID", OleDbType.Integer, 5).Value = id;

            try
            {
                myConnection.Open();
                myCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
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
                if (spiece.id == spieceId)
                {
                    return spiece;
                }
            }
            return null;
        }

        // Search for the specific sanctuary by ID
        public static Sanctuary FindSanctuary(List<Sanctuary> sanctuaries, int id)
        {
            foreach (var sanctuary in sanctuaries)
            {
                if (sanctuary.id == id)
                {
                    return sanctuary;
                }
            }
            return null;
        }

        // Search for the specific breed by ID
        public static Breed FindBreed(List<Breed> breeds, int breedId)
        {
            foreach (var breed in breeds)
            {
                if (breed.id == breedId)
                {
                    return breed;
                }
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

        // Method that returns a list of Sanctuary objects with the details from the DB
        public static List<Sanctuary> LoadSanctuaries()
        {
            List<Sanctuary> sancuaries = new List<Sanctuary>();
            OleDbConnection myConnection = GetConnection();

            string myQuery = "SELECT * FROM sanctuaries";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Sanctuary sanctuary = new Sanctuary(int.Parse(myReader["id"].ToString()), myReader["name"].ToString());
                    sancuaries.Add(sanctuary);
                }
                return sancuaries;
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

        // Method that returns a list of Staff objects with the details from the DB
        public static List<Staff> LoadStaff()
        {
            List<Staff> staffs = new List<Staff>();
            OleDbConnection myConnection = GetConnection();

            string myQuery = "SELECT * FROM staff";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    Staff staff = new Staff(int.Parse(myReader["id"].ToString()), myReader["first_name"].ToString(), myReader["last_name"].ToString(), myReader["email"].ToString(), myReader["pass"].ToString(), int.Parse(myReader["access"].ToString()));
                    staffs.Add(staff);
                }
                return staffs;
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

        // Method that returns a list of Breeds objects with the details from the DB
        public static List<Breed> LoadBreeds(string by = "", string id = "")
        {
            List<Breed> breeds = new List<Breed>();
            OleDbConnection myConnection = GetConnection();

            string myQuery = "";
            OleDbCommand myCommand;

            // Deciding how to load breeds
            switch (by)
            {
                case "spieces":
                    myQuery = "SELECT * FROM breeds WHERE spieces_id = ?";
                    myCommand = new OleDbCommand(myQuery, myConnection);
                    myCommand.Parameters.Add("@spieces_id", OleDbType.Integer, 5).Value = id;
                    break;
                default:
                    myQuery = "SELECT * FROM breeds";
                    myCommand = new OleDbCommand(myQuery, myConnection);
                    break;
            }

            

            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();

                List<Spieces> spieces = LoadSpieces();

                while (myReader.Read())
                {
                    Spieces spiece = FindSpieces(spieces, int.Parse(myReader["spieces_id"].ToString()));
                    Breed breed = new Breed(int.Parse(myReader["id"].ToString()), myReader["name"].ToString(), spiece, double.Parse(myReader["food_cost"].ToString()), double.Parse(myReader["housing_cost"].ToString()));
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

        // Method that returns a list of Clients objects with the details from the DB
        public static List<Client> LoadClient()
        {
            List<Client> clients = new List<Client>();
            OleDbConnection myConnection = GetConnection();

            string myQuery = "SELECT DISTINCT * FROM Client WHERE Fame = 'True'";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    Client client = new Client(int.Parse(myReader["ID"].ToString()), myReader["Name"].ToString(),
                                          myReader["Email"].ToString(), myReader["Address"].ToString(),
                                          myReader["Telephone"].ToString(), DateTime.Parse(myReader["Ddate"].ToString()),
                                          myReader["Donation"].ToString(), myReader["Country"].ToString(),
                                          myReader["Fame"].ToString());
                    clients.Add(client);
                }
                return clients;
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

        public static List<Client> LoadDonations()
        {
            List<Client> clients = new List<Client>();
            OleDbConnection myConnection = GetConnection();

            string myQuery = "SELECT * FROM Client";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {
                    Client client = new Client(int.Parse(myReader["ID"].ToString()), myReader["Name"].ToString(),
                                          myReader["Email"].ToString(), myReader["Address"].ToString(),
                                          myReader["Telephone"].ToString(), DateTime.Parse(myReader["Ddate"].ToString()),
                                          myReader["Donation"].ToString(), myReader["Country"].ToString(),
                                          myReader["Fame"].ToString());
                    clients.Add(client);
                }
                return clients;
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

        // Method that returns a list of Pets objects with the details from the DB
        public static List<Pet> LoadPets(string by = "", string id = "")
        {
            List<Pet> pets = new List<Pet>();
            OleDbConnection myConnection = GetConnection();

            string myQuery = "";
            OleDbCommand myCommand;

            // Deciding how to load pets (if there is adoption date in db - don't show the pet)
            switch (by)
            {
                case "breed":
                    myQuery = "SELECT * FROM pets WHERE breed_id = ? AND adoption_date IS NULL";
                    myCommand = new OleDbCommand(myQuery, myConnection);
                    myCommand.Parameters.Add("@breed_id", OleDbType.Integer, 5).Value = id;
                    break;
                case "spieces":
                    myQuery = "SELECT * FROM pets WHERE spieces_id = ? AND adoption_date IS NULL";
                    myCommand = new OleDbCommand(myQuery, myConnection);
                    myCommand.Parameters.Add("@spieces_id", OleDbType.Integer, 5).Value = id;
                    break;
                case "sanctuary":
                    myQuery = "SELECT * FROM pets WHERE sanctuary_id = ? AND adoption_date IS NULL";
                    myCommand = new OleDbCommand(myQuery, myConnection);
                    myCommand.Parameters.Add("@sanctuary_id", OleDbType.Integer, 5).Value = id;
                    break;
                case "pet": // find particular pet based on ID
                    myQuery = "SELECT * FROM pets WHERE ID = ? AND adoption_date IS NULL";
                    myCommand = new OleDbCommand(myQuery, myConnection);
                    myCommand.Parameters.Add("@ID", OleDbType.Integer, 5).Value = id;
                    break;
                default:
                    myQuery = "SELECT * FROM pets";
                    myCommand = new OleDbCommand(myQuery, myConnection);
                    break;
            }

            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();

                List<Breed> breeds = LoadBreeds();
                List<Spieces> spieces = LoadSpieces();
                List<Sanctuary> sanctuaries = LoadSanctuaries();

                while (myReader.Read())
                {
                    Breed breed = FindBreed(breeds, int.Parse(myReader["breed_id"].ToString()));
                    Spieces spiece = FindSpieces(spieces, int.Parse(myReader["spieces_id"].ToString()));
                    Sanctuary sanctuary = FindSanctuary(sanctuaries, int.Parse(myReader["sanctuary_id"].ToString()));

                    if (breed != null && spiece != null)
                    {
                        Pet pet = new Pet(int.Parse(myReader["id"].ToString()),
                                          myReader["name"].ToString(),
                                          breed,
                                          spiece,
                                          sanctuary,
                                          int.Parse(myReader["age"].ToString()),
                                          int.Parse(myReader["gender"].ToString()),
                                          double.Parse(myReader["weight"].ToString()),
                                          double.Parse(myReader["bills"].ToString()),
                                          DateTime.Parse(myReader["rescue_date"].ToString()),
                                          myReader["picture_path"].ToString()
                                    );
                        pets.Add(pet);
                    }

                }
                return pets;
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



        // Method that checks login details
        public static Staff login(string email, string password)
        {
            OleDbConnection myConnection = GetConnection();
            string myQuery =  "SELECT * FROM staff WHERE email = ? AND pass = ?";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
            myCommand.Parameters.Add("@email", OleDbType.VarWChar, 50).Value = email;
            myCommand.Parameters.Add("@pass", OleDbType.VarWChar, 50).Value = password;

            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();

                if (myReader.HasRows) {
                    while (myReader.Read())
                    {
                        return new Staff(int.Parse(myReader["id"].ToString()), myReader["first_name"].ToString(), myReader["last_name"].ToString(), myReader["email"].ToString(), myReader["pass"].ToString(), int.Parse(myReader["access"].ToString()));
                    }
                    return null;
                }
                else
                {
                    return null;
                }
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

        // Method that check if staff email is unique
        public static Boolean checkEmailUnique(string email)
        {
            OleDbConnection myConnection = GetConnection();
            string myQuery = "SELECT ID FROM staff WHERE email = ?";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
            myCommand.Parameters.Add("@email", OleDbType.VarWChar, 50).Value = email;

            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();

                if (myReader.HasRows)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return true;
            }
            finally
            {
                myConnection.Close();
            }
        }

        public static Client addClient(string name, string email, string address, string tel, DateTime date, string money, string country, string fame)
        {
            OleDbConnection myConnection = GetConnection();
            string myQuery = "INSERT INTO Client (Name, Email, Address, Telephone, Ddate, Donation, Country, Fame) VALUES ('" + name + "', '" + email + "', '" + address + "', '" + tel + "', '" + date + "', '" + money + "', '" + country + "', '" + fame + "')";
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

        public static double getMoney()
        {
            double money = 0;

            OleDbConnection myConnection = GetConnection();
            string myQuery = "SELECT Donation FROM Client";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);

            try
            {
                myConnection.Open();
                OleDbDataReader myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    money += (double.Parse(myReader["Donation"].ToString()));
                }
                return money;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
                return money;
            }
            finally
            {
                myConnection.Close();
            }
        }


        public static void adoptPet(string id, DateTime adoDate)
        {
            OleDbConnection myConnection = GetConnection();

            string myQuery = "UPDATE pets SET adoption_date=\"" + adoDate + "\" WHERE ID = ?";
            OleDbCommand myCommand = new OleDbCommand(myQuery, myConnection);
            myCommand.Parameters.Add("@ID", OleDbType.Integer, 5).Value = id;

            try
            {
                myConnection.Open();
                myCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in DBHandler", ex);
            }
            finally
            {
                myConnection.Close();
            }
        }
    }
}