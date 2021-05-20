using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WPLClassLibTeam02.Data
{
    public class EntityHelper
    {
        public EntityHelper(string tableName, string pkey)
        {
            TableName = tableName;
            PrimaryKey = pkey;
            Database = new Database();
            SqlParameters = new Dictionary<string, object>();
            if (TableName == null || TableName.Length == 0)
            {
                throw new Exception("TableName is missing -- Create static string in your Entity class and pass by your constructor!");
            }
            if (PrimaryKey == null || PrimaryKey.Length == 0)
            {
            throw new Exception("PrimaryKey is missing -- Create static string in your Entity class and pass by your constructor!");
            }
        }

        private Database Database { get; set; }
        private Dictionary<string, object> SqlParameters;
        protected string TableName { get; set; }
        protected string PrimaryKey { get; set; }
        public void UpdateSqlParameters(string key, object parameter)
        {
            if (SqlParameters.ContainsKey(key))
            {
                SqlParameters[key] = parameter;
            }
            else
            {
                SqlParameters.Add(key, parameter);
            }
        }


        //insert method
        #region Insert
        private string InsertFields { get; set; }
        private string InsertParams { get; set; }
        private void InsertHelper()
        {
            InsertFields = "";
            InsertParams = "";
            foreach (KeyValuePair<string, object> kvp in SqlParameters)
            {
                if (!(kvp.Key == PrimaryKey))
                {
                    if (InsertFields.Length > 0)
                    {
                        InsertFields += ",";
                        InsertParams += ",";
                    }
                    InsertFields += kvp.Key;
                    InsertParams += $"@{kvp.Key}";
                }
            }
        }

        protected SQLCommandResult InsertRecord()
        {
            var result = new SQLCommandResult();
            try
            {
                InsertHelper();
                var insertCommando = $"INSERT INTO {TableName}({ InsertFields}) VALUES({ InsertParams}); SELECT scope_identity(); ";
                SqlCommand command = new SqlCommand();
                command.CommandText = insertCommando;
                result = Database.ExecuteCommand(command,
                EntityCommand.Insert, SqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception("InsertRecord", ex);
            }
            return result;
        }
        #endregion

        //update method
        #region Update
        private void UpdateHelper()
        {
            UpdateParams = "";
            foreach (KeyValuePair<string, object> kvp in SqlParameters)
            {
                if (!(kvp.Key == PrimaryKey))
                {
                    if (UpdateParams.Length > 0)
                    {
                        UpdateParams += ",";
                    }
                    UpdateParams += $"{kvp.Key}=@{kvp.Key}";
                }
            }
        }
        private string UpdateParams { get; set; }
        protected SQLCommandResult UpdateRecord()
        {
            var result = new SQLCommandResult();
            try
            {
                UpdateHelper();
                var updateCommando = $"UPDATE {TableName} SET {UpdateParams}WHERE { PrimaryKey} = { SqlParameters[PrimaryKey]}";
            SqlCommand command = new SqlCommand();
                command.CommandText = updateCommando;
                result = Database.ExecuteCommand(command,
                EntityCommand.Update, SqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception("UpdateRecord", ex);
            }
            return result;
        }
        protected SQLCommandResult DeleteRecord()
        {
            var result = new SQLCommandResult();
            try
            {
                UpdateHelper();
                var updateCommando = $"DELETE FROM {TableName} WHERE { PrimaryKey} = { SqlParameters[PrimaryKey]}";
                SqlCommand command = new SqlCommand();
                command.CommandText = updateCommando;
                result = Database.ExecuteCommand(command,
                EntityCommand.Delete, SqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception("DeleteRecord", ex);
            }
            return result;
        }
        #endregion

        //read method
        #region Read
        protected SQLCommandResult GetRecords()
        {
            var result = new SQLCommandResult();
            try
            {
                var selectCommando = $"SELECT * FROM {TableName} ";
                SqlCommand command = new SqlCommand();
                command.CommandText = selectCommando;
                result = Database.ExecuteCommand(command, EntityCommand.Read,
                SqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception("GetRecords", ex);
            }
            return result;
        }

        protected SQLCommandResult GetRecord()
        {
            var result = new SQLCommandResult();
            try
            {
                var selectCommando = $"SELECT * FROM {TableName} WHERE{ PrimaryKey} = { SqlParameters[PrimaryKey]}";
            SqlCommand command = new SqlCommand();
                command.CommandText = selectCommando;
                result = Database.ExecuteCommand(command, EntityCommand.Read,
                SqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception("GetRecord", ex);
            }
            return result;
        }

        protected SQLCommandResult GetRecord(int id)
        {
            var result = new SQLCommandResult();
            try
            {
                var selectCommando = $"SELECT * FROM {TableName} WHERE{ PrimaryKey} = id";
            SqlCommand command = new SqlCommand();
                command.CommandText = selectCommando;
                result = Database.ExecuteCommand(command, EntityCommand.Read,
                SqlParameters);
            }
            catch (Exception ex)
            {
                throw new Exception("GetRecord", ex);
            }
            return result;
        }
        #endregion

    }

    public enum EntityCommand
    {
        Insert = 0,
        Update = 1,
        Delete = 2,
        Read = 3
    }
    }






