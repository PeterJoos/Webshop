using Microsoft.AspNetCore.Mvc;
using WPLClassLibTeam02.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPLClassLibTeam02.Tools;

namespace WplWebApiTeam02.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //post methode om te kijken of wachtwoord een email matchen. Returnt een bool met of het lukt of niet
        [HttpPost]
        public String Post([FromForm] FormLoginObject form)
        {
            
            string email = form.email;
            string password1 = form.password;
            password1 = EncryptionTool.Crypt(password1);
            var dt = EntityData.User.GetPassword(email);
            bool result = false;
            //kijken of email bestaat en zoja, of geëncrypteerde wachtwoorden matchen
            if (dt.Rows.Count > 0)
            {
                string password2 = dt.Rows[0][0].ToString();
                if (password1.Equals(password2))
                {
                    result = true;
                }
            }
         return JsonConvert.SerializeObject(result);

        }
    }

    //hulp object voor login
    public class FormLoginObject
    {
        public string email { get; set; }

        public string password { get; set; }
    }
}
