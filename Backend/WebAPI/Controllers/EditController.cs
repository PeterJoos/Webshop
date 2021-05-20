using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WPLClassLibTeam02.Data;
using WPLClassLibTeam02.Entity;
using WPLClassLibTeam02.Tools;

namespace WplWebApiTeam02.Controllers
{

    //Controller voor de Edit pagina
    [ApiController]
    [Route("[controller]")]
    public class EditController : Controller
    {
        
       //post methode, zoekt data op aan de hand van email en geeft deze terug als Json
        [HttpPost]
        public string Post([FromForm] FormEditObject form)
        {
            string email = form.email;
            string JsonString = string.Empty;
            User user = new User();
            var dt = EntityData.Edit.Get(email);
            if (dt.Rows.Count > 0)
            {
                user.emailadres = dt.Rows[0][0].ToString();
                string encryptedPassword = dt.Rows[0][1].ToString();
                user.password = EncryptionTool.Decrypt(encryptedPassword);
                user.naam = dt.Rows[0][2].ToString();
                user.voornaam = dt.Rows[0][3].ToString();
                user.country = dt.Rows[0][4].ToString();
                user.adres = dt.Rows[0][5].ToString();
                user.postcode = Convert.ToInt32(dt.Rows[0][6]);
            }
            JsonString = JsonConvert.SerializeObject(user);
               
            return JsonString;
            
        }


        //put methode voor het binnenhalen van de nieuwe waardes in deze in de database te steken. Controleert ook af alle waardes goed zijn ingevuld en of email al bestaat.
        //Returnt bools als json
        [HttpPut]
        public string Put([FromForm] FormEditObject form)
        {
            bool editSucces = false;
            bool emailExist = false;
            bool[] array = new bool[2];
            string JsonString = string.Empty;
            string oldemail = form.oldemail;
            int postcode = 0;
            int.TryParse(form.postcode, out postcode);

            User user = new User(form.email, form.password, form.naam, form.voornaam, form.country, form.adres, postcode);
            user.password = EncryptionTool.Crypt(user.password);

            //kijken of veld leeg is
            if (user.naam == null || user.voornaam == null || user.emailadres == null || user.adres == null || user.postcode == 0
               || user.country == null || user.password == null)
            {
                
            }
            else
            {
                editSucces = true;
                var dt = EntityData.User.GetEmail(user.emailadres);
                //kijken of email al bestaat
                if (dt.Rows.Count > 0)
                {
                    string email2 = dt.Rows[0][0].ToString();
                    if (user.emailadres.Equals(email2))
                    {
                        emailExist = true;
                    }
                }
                else
                {
                    emailExist = false;
                    EntityData.Edit.Update(user, oldemail);
                }
            }
            //bools returnen
            array[0] = editSucces;
            array[1] = emailExist;
            JsonString = JsonConvert.SerializeObject(array);
            return JsonString;
        }

    }

    //gebruiken om een editobject aan te maken
    public class FormEditObject
    {

        public string oldemail { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string naam { get; set; }
        public string voornaam { get; set; }
        public string country { get; set; }
        public string adres { get; set; }
        public string  postcode { get; set; }

    }
}
