using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPLClassLibTeam02.Data
{
    public class EntityData
    {

        //testclasse, kan je negeren
        public static class TestData
        {
            public static DataTable Get()
            {
                Database db = new Database();
                return db.GetData("select * from tblTestData");
            }
            public static void Insert(Entity.TestData testData)
            {
                Database db = new Database();
                db.ExecuteNonquery(InsertData(testData));
            }
            public static void Update(Entity.TestData testData, int id)
            {
                Database db = new Database();
                db.ExecuteNonquery(UpdateData(testData, id));
            }
            public static void Delete(int id)
            {
                Database db = new Database();
                db.ExecuteNonquery(DeleteData(id));
            } 
            private static SqlCommand InsertData(Entity.TestData testData)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO tblTestData (tekst, datum, Getal) Values (@tekst, @datum, @Getal)";
                command.Parameters.AddWithValue("@tekst", testData.Tekst);
                command.Parameters.AddWithValue("@datum", testData.Datum);
                command.Parameters.AddWithValue("@getal", testData.Getal);
                return command;
            }
            private static SqlCommand UpdateData(Entity.TestData testData, int testDataId)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = $"UPDATE tblTestData SET tekst=@tekst, datum=@datum, getal=@Getal WHERE testdataid={testDataId}";
                command.Parameters.AddWithValue("@tekst", testData.Tekst);
                command.Parameters.AddWithValue("@datum", testData.Datum);
                command.Parameters.AddWithValue("@getal", testData.Getal);
                return command;
            }
            private static SqlCommand DeleteData(int id)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = $"DELETE FROM tblTestData WHERE testdataid = {id}";
                return command;
            }
        }

        //classe voor de usercontroller
        public static class User
        {
            //get all from user
            public static DataTable Get()
            {
                Database database = new Database();
                return database.GetData("select * from Users");
            }

            //vraagt wachtwoord op aan de hand van email
            public static DataTable GetPassword(string email)
            {
                Database database = new Database();
                return database.GetData($"select password from Users where emailadres = '{email}'");

            }


            //controleert of email bestaat in de database
            public static DataTable GetEmail(string email)
            {
                Database database = new Database();
                return database.GetData($"select emailadres from Users where emailadres = '{email}'");
            }

            //insert aan de hand van user Object
            public static void Insert(Entity.User user)
            {
                Database database = new Database();
                database.ExecuteNonquery(InsertData(user));
            }

            //testfunctie
            public static void Update(Entity.TestData testData, int id)
            {
                Database db = new Database();
                db.ExecuteNonquery(UpdateData(testData, id));
            }

            //testfunctie
            public static void Delete(int id)
            {
                Database db = new Database();
                db.ExecuteNonquery(DeleteData(id));
            }

            //maakt een commanda aan da hand van het user object en geeft deze terug
            private static SqlCommand InsertData(Entity.User user)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO Users (naam, voornaam, emailadres, password, adres, postcode, country) Values (@naam, @voornaam, @email, @password, @adres, @postcode, @country)";
                command.Parameters.AddWithValue("@naam", user.naam);
                command.Parameters.AddWithValue("@voornaam", user.voornaam);
                command.Parameters.AddWithValue("@email", user.emailadres);
                command.Parameters.AddWithValue("@password", user.password);
                command.Parameters.AddWithValue("@adres", user.adres);
                command.Parameters.AddWithValue("@postcode", user.postcode);
                command.Parameters.AddWithValue("@country", user.country);

                return command;
            }

            //testfunctie
            private static SqlCommand UpdateData(Entity.TestData testData, int testDataId)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = $"UPDATE tblTestData SET tekst=@tekst, datum=@datum, getal=@Getal WHERE testdataid={testDataId}";
                command.Parameters.AddWithValue("@tekst", testData.Tekst);
                command.Parameters.AddWithValue("@datum", testData.Datum);
                command.Parameters.AddWithValue("@getal", testData.Getal);
                return command;
            }

            //testfunctie
            private static SqlCommand DeleteData(int id)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = $"DELETE FROM tblTestData WHERE testdataid = {id}";
                return command;
            }
        }

        //classe voor editcontroller
        public static class Edit
        {
            public static DataTable Get(string email)
            {
                Database database = new Database();
                return database.GetData($"select * from Users where emailadres = '{email}'");

            }

            public static void Update(Entity.User user, string oldemail)
            {
                Database database = new Database();
                database.ExecuteNonquery(UpdateData(user, oldemail));
            }

            private static SqlCommand UpdateData(Entity.User user, string oldemail)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = $"UPDATE Users SET emailadres=@emailadres, password=@password, naam=@naam, voornaam=@voornaam, country =@country,adres = @adres, postcode = @postcode WHERE emailadres='{oldemail}'";
                command.Parameters.AddWithValue("@emailadres", user.emailadres);
                command.Parameters.AddWithValue("@password", user.password);
                command.Parameters.AddWithValue("@naam", user.naam);
                command.Parameters.AddWithValue("@voornaam", user.voornaam);
                command.Parameters.AddWithValue("@country", user.country);
                command.Parameters.AddWithValue("@adres", user.adres);
                command.Parameters.AddWithValue("@postcode", user.postcode);
                return command;
            }

        }

        //classe voor emailcontroller
        public static class Emailcheck
        {
            public static bool Checkemail(string email)
            {
                Database db = new Database();
               var dt =  db.GetData($"select emailadres FROM users WHERE emailadres = '{email}'");
                bool result = false;
                if (dt.Rows.Count > 0 )
                {
                    result = true;
                }
                return result;
            }

            public static void UpdateWachtwoord(string wachtwoord, string email)
            {
                Database database = new Database();
                database.ExecuteNonquery(UpdatePassword(wachtwoord, email));
            }

            private static SqlCommand UpdatePassword(string wachtwoord, string email)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = $"UPDATE Users SET password=@wachtwoord WHERE emailadres=@email";
                command.Parameters.AddWithValue("@wachtwoord", wachtwoord);
                command.Parameters.AddWithValue("@email", email);
                return command;
            }
        }

    }
}

