using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPLClassLibTeam02.Data
{

    //Class om een Database Object aan te maken aan de hand van een sqlconnection. Moet in principe niet aangepast worden.
    class Database
    {
        private SqlConnection connection;

        //Constructor voor database, maakt gebruik van settings class
        public Database()
        {
            SqlConnectionStringBuilder sqlSB = new SqlConnectionStringBuilder();
            sqlSB.InitialCatalog = Settings.Database.DatabaseName;
            sqlSB.DataSource = Settings.Database.Server;
            sqlSB.UserID = Settings.Database.User;
            sqlSB.Password = Settings.Database.Pwd;
            connection = new SqlConnection(sqlSB.ConnectionString);
        }

        //query uitvoeren en dt returnen/error als het niet lukt
        public DataTable GetData(string query)
        {
            try
            {
                DataTable dt = new DataTable();
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter sda = new SqlDataAdapter(command);
                sda.Fill(dt);
                connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        //meer generale versie om command uit te voeren
        public void ExecuteNonquery(SqlCommand command)
        {
            try
            {
                connection.Open();
                command.Connection = connection;
                int recordsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                connection.Close();
            }
        }

        //advanced manier
        public SQLCommandResult ExecuteCommand(SqlCommand sqlCommand, EntityCommand entityCommand,Dictionary<string, object> sqlParameters)
        {
            SQLCommandResult result = new SQLCommandResult();
            try
            {
                result.EntityCommand = entityCommand;
                connection.Open();
                sqlCommand.Connection = connection;
                foreach (KeyValuePair<string, object> sqlParam in sqlParameters)
                {
                    sqlCommand.Parameters.AddWithValue($"@{sqlParam.Key}", sqlParam.Value);
                }
                if (entityCommand == EntityCommand.Read)
                {
                    SqlDataAdapter sda = new SqlDataAdapter(sqlCommand);
                    sda.Fill(result.DataTable);
                    result.Count = result.DataTable.Rows.Count;
                }
                else
                {
                    
                    if (entityCommand == EntityCommand.Insert)
                    {
                        result.NewId = Convert.ToInt32(sqlCommand.ExecuteScalar());
                    } else
                    {
                        result.Count = sqlCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
    }

}
