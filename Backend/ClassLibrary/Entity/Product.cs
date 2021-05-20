using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPLClassLibTeam02.Data;

namespace WPLClassLibTeam02.Entity
{
    //Product classe. Erft over van EntityHelper
    public class Product : EntityHelper, IEntityHelper
    {
        //Info over Tabel maken
        public static class Database
        {
            public static string TableName = "Product";
            public static string PrimaryKey = Columns.ProductID;
            public static class Columns
            {
                public static string ProductID = "ProductID";
                public static string ProductcategorieID = "ProductcategorieID";
                public static string Subcategorie = "Subcategorie";
                public static string Productnaam = "Productnaam";
                public static string Omschrijving = "Omschrijving";
                public static string Specificaties = "Specificaties";
                public static string Eenheidsprijs = "Eenheidsprijs";
            }
        }

        //Constructor die ook de info over de tabel meegeeft
        public Product() : base(Database.TableName, Database.PrimaryKey)
        {

        }

        #region Properties
        private int productID;
        private int productCatergorieID;
        private string subCatergorie;
        private string productNaam;
        private string omschrijving;
        private string specificaties;
        private int eenheidsprijs;

        public int ProductID
        {
            get { return productID; }
            set
            {
                productID = value;
                UpdateSqlParameters(Database.Columns.ProductID, productID);
            }
        }

        public int ProductcategorieID
        {
            get { return productCatergorieID; }
            set
            {
                productCatergorieID = value;
                UpdateSqlParameters(Database.Columns.ProductcategorieID, productCatergorieID);
            }
        }

        public string Subcategorie
        {
            get { return subCatergorie; }
            set
            {
                subCatergorie = value;
                UpdateSqlParameters(Database.Columns.Subcategorie, subCatergorie);
            }
        }

        public string ProductNaam
        {
            get { return productNaam; }
            set
            {
                productNaam = value;
                UpdateSqlParameters(Database.Columns.Productnaam, productNaam);
            }
        }

        public string Omschrijving
        {
            get { return omschrijving; }
            set
            {
                omschrijving = value;
                UpdateSqlParameters(Database.Columns.Omschrijving, omschrijving);
            }
        }

        public string Specificaties
        {
            get { return specificaties; }
            set
            {
                specificaties = value;
                UpdateSqlParameters(Database.Columns.Specificaties, specificaties);
            }
        }

        public int Eenheidsprijs
        {
            get { return eenheidsprijs; }
            set
            {
                eenheidsprijs = value;
                UpdateSqlParameters(Database.Columns.Eenheidsprijs, eenheidsprijs);
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
