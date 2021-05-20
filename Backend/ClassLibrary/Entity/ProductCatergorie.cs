using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPLClassLibTeam02.Data;

namespace WPLClassLibTeam02.Entity
{
    //ProductCategory classe. Erft over van EntityHelper
    public class ProductCatergorie : EntityHelper, IEntityHelper
    {
        //Info over Tabel maken
        public static class Database
        {
            public static string TableName = "Productcategorie";
            public static string PrimaryKey = Columns.ProductcategorieID;
            public static class Columns
            {
                public static string ProductcategorieID  = "ProductcategorieID";
                public static string Categorie  = "Categorie ";
            }
        }

        public ProductCatergorie() : base(Database.TableName, Database.PrimaryKey)
        {

        }

        #region Properties
        private int productCatergorieID;
        private string categorie;

        public int ProductcategorieID
        {
            get { return productCatergorieID; }
            set
            {
                productCatergorieID = value;
                UpdateSqlParameters(Database.Columns.ProductcategorieID, productCatergorieID);
            }
        }

        public string Categorie
        {
            get { return categorie; }
            set
            {
                categorie = value;
                UpdateSqlParameters(Database.Columns.Categorie, categorie);
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
