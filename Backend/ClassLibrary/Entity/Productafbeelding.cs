using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPLClassLibTeam02.Data;

namespace WPLClassLibTeam02.Entity
{
    //ProductAfbeelding classe. Erft over van EntityHelper
    public class ProductAfbeelding : EntityHelper, IEntityHelper
    {
        //Info over Tabel maken
        public static class Database
        {
            public static string TableName = "Productafbeelding";
            public static string PrimaryKey = Columns.ProductafbeeldingID ;
            public static class Columns
            {
                public static string ProductafbeeldingID  = "ProductafbeeldingID ";
                public static string ProductID = "ProductID ";
                public static string Afbeeldingsnaam = "Afbeeldingsnaam ";
            }
        }

        public ProductAfbeelding() : base(Database.TableName, Database.PrimaryKey)
        {

        }

        #region Properties
        private int productafbeeldingID;
        private int productID;
        private string afbeeldingsnaam;

        public int ProductafbeeldingID
        {
            get { return productafbeeldingID; }
            set
            {
                productafbeeldingID = value;
                UpdateSqlParameters(Database.Columns.ProductafbeeldingID, productafbeeldingID);
            }
        }

        public int ProductID
        {
            get { return productID; }
            set
            {
                productID = value;
                UpdateSqlParameters(Database.Columns.ProductID, productID);
            }
        }

        public string Afbeeldingsnaam
        {
            get { return afbeeldingsnaam; }
            set
            {
                afbeeldingsnaam = value;
                UpdateSqlParameters(Database.Columns.Afbeeldingsnaam, afbeeldingsnaam);
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