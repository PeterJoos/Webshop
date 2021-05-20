using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPLClassLibTeam02.Data;
using WPLClassLibTeam02.Tools;

namespace WplWebApiTeam02.Controllers
{
    //controller voor user
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        //get methode om gegevens van user te krijgen. Wordt niet gebruikt
        [HttpGet]
        public string Get()
        {
            string JsonString = string.Empty;
            JsonString = JsonConvert.SerializeObject(EntityData.User.Get());
            return JsonString;

        }

        //methode om user te creëren in database als alle velden zijn ingevuld en mail nog niet bezet is. Anders signaal sturen
        [HttpPost]
        public string Create([FromForm] FormUserObject form)
        {
            
            bool everyThingIsFilledIn = false;
            bool Emailexist = true;
            WPLClassLibTeam02.Entity.User user = new WPLClassLibTeam02.Entity.User();
            user.voornaam = form.FirstName;
            user.naam = form.LastName;
            user.emailadres = form.Email;
            user.adres = form.Adress;
            int postcode = 0;
            int.TryParse(form.PostalCode, out postcode);
            user.postcode = postcode;
            user.country = form.Country;
            user.password = form.Password;
           

            if (user.naam == null|| user.voornaam == null || user.emailadres == null || user.adres == null || user.postcode == 0 
                || user.country == null || user.password == null)
            {
            } else
            {
                everyThingIsFilledIn = true;
                user.password = EncryptionTool.Crypt(user.password);
                var dt = EntityData.User.GetEmail(user.emailadres);
                if (dt.Rows.Count > 0)
                {
                    string email2 = dt.Rows[0][0].ToString();
                    if (user.emailadres.Equals(email2))
                    {
                        Emailexist = true;
                    }
                }
                else
                {
                    EntityData.User.Insert(user);
                    Emailexist = false;
                }
            }


            string JsonString = string.Empty;
            bool[] array = new bool[2];
            array[0] = everyThingIsFilledIn;
            array[1] = Emailexist;
            JsonString = JsonConvert.SerializeObject(array);
            return JsonString;
        }

        public class FormUserObject
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Adress { get; set; }
            public string PostalCode { get; set; }
            public string Country { get; set; }
            public string Password { get; set; }
        }

    }
}
