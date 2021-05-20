using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPLClassLibTeam02.Entity;

namespace WPLClassLibTeam02.Tools
{
    public class ProductHelper
    {

        public static Dictionary<string, int> DictCategories = new Dictionary<string, int>();

        //maakt een product aan voor elk product in de csv
        public static void CreateProducts(IEnumerable<CsvProduct> products)
        {
            ProductResult productResult;
            foreach (CsvProduct product in products)
            {
                productResult = ProductResult.ConvertCSVProductToProduct(product);

            }
        }
    }
}
