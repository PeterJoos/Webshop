using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPLClassLibTeam02.Data;

namespace WPLClassLibTeam02.Entity
{
    //useless klass, voorbeeld
    public class TestChildData : EntityHelper, IEntityHelper
    {
        public static class Database
        {
            public static string TableName = "tbltestchilddata";
            public static string PrimaryKey = Columns.TestChildDataId;
            public static class Columns
            {
                public static string TestChildDataId = "testchilddataid";
                public static string TestDataId = "testdataid";
                public static string ChildData = "childdata";
            }
        }
        

        public TestChildData() : base(Database.TableName, Database.PrimaryKey)
        {

        }

        #region Properties
        private int testChildDataID;
        private int testDataID;
        private string childData;
        public int TestChildDataID
        {
            get { return testChildDataID; }
            set
            {
                testChildDataID = value;
                UpdateSqlParameters(Database.Columns.TestChildDataId, testChildDataID);
            }
        }
        public int TestDataID
        {
            get { return testDataID; }
            set
            {
                testDataID = value;
                UpdateSqlParameters(Database.Columns.TestDataId, testDataID);
            }
        }
        public string ChildData
        {
            get { return childData; }
            set
            {
                childData = value;
                UpdateSqlParameters(Database.Columns.ChildData, childData);
            }
        }
        #endregion

        #region interface methods
        public SQLCommandResult Insert()
        {
            return InsertRecord();
        }
        public SQLCommandResult Update()
        {
            return UpdateRecord();
        }
        public SQLCommandResult Delete()
        {
            return DeleteRecord();
        }
        public SQLCommandResult Read()
        {
            return GetRecords();
        }
        #endregion
    }
}

