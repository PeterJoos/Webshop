using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPLClassLibTeam02.Data;
using WPLClassLibTeam02.Entity;

namespace WplWebApiTeam02.Controllers
{
    //Controller voor de Product pagina
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        [HttpGet]
        // Data ophalen uit de klassen Prodcut, ProductAfbeelding & Productcategorie & opsturen naar de front-end.
        public string Get()
        {            
            string JsonString = string.Empty;
            Product product = new Product();
            var resultProduct = product.Read();
            ProductAfbeelding productAfbeelding = new ProductAfbeelding();
            var resultAfbeelding = productAfbeelding.Read();
            ProductCatergorie productCategorie = new ProductCatergorie();
            var resultCategorie = productCategorie.Read();

            SQLCommandResult[] data = { resultProduct, resultAfbeelding, resultCategorie };

            JsonString = JsonConvert.SerializeObject(data);
            return JsonString;
        }
    }
}
