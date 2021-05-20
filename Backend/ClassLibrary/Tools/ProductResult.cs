using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPLClassLibTeam02.Entity;

namespace WPLClassLibTeam02.Tools
{
    public class ProductResult
    {
        public bool Succeeded { get; set; }

        public static ProductResult ConvertCSVProductToProduct(CsvProduct csvProduct)
        {
            var result = new ProductResult();
            //product maken aan de hand van csv
            try
            {
                var productCategory = CreateCategorie(csvProduct);
                var productID = CreateProduct(csvProduct, productCategory);
                CreateImage(csvProduct, productID);
                result.Succeeded = true;

                return result;
            } catch (Exception ex)
            {
                result.Succeeded = false;
                return result;
            }
           
        }

        private static int CreateCategorie(CsvProduct csvProduct)
        {
            //kijken of category al in dictionary zit en zonee, deze toevoegen
            int productCategory = -1;
            if (!ProductHelper.DictCategories.ContainsKey(csvProduct.CategoryNaam))
            {
                ProductCatergorie productCatergorie = new ProductCatergorie();
                productCatergorie.Categorie = csvProduct.CategoryNaam;
                var resultCategorie = productCatergorie.Insert();

                productCategory = resultCategorie.NewId;
                ProductHelper.DictCategories.Add(csvProduct.CategoryNaam, productCategory);
            }
            else
            {
                productCategory = ProductHelper.DictCategories[csvProduct.CategoryNaam];
            }
           
            return productCategory;
        }

        //product maken
        private static int CreateProduct(CsvProduct csvProduct, int productCategory)
        {
            Product p = new Product();           
            p.ProductcategorieID = productCategory;
            p.Subcategorie = csvProduct.SubCategory;
            p.ProductNaam = csvProduct.ProductNaam;
            p.Omschrijving = csvProduct.Omschrijving;
            p.Specificaties = csvProduct.Specificaties;
            p.Eenheidsprijs = csvProduct.Eenheidsprijs;

            var resultProduct = p.Insert();
            return resultProduct.NewId;
        }

        //Image maken
        private static void CreateImage(CsvProduct csvProduct, int productID)
        {
            var afbeeldingArray = csvProduct.Afbeeldingsnaam.Split('|');
            foreach (var afb in afbeeldingArray)
            {
                ProductAfbeelding afbeelding = new ProductAfbeelding();
                afbeelding.ProductID = productID;
                afbeelding.Afbeeldingsnaam = afb;
                afbeelding.Insert();
            }
            
        }
    }
}
