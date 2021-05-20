using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using WPLClassLibTeam02.Data;

namespace WplWebApiTeam02.Controllers
{
    //controller voor email te sturen
    [ApiController]
    [Route("[controller]")]
    public class EmailController : Controller
    {
        //post methode, kijkt of email bestaat en zoja stuurt een mail met nieuw wachtwoord aan de hand van Mailhelper Tool. Wachtwoord word ook geëncrypteerd en geupdated
        [HttpPost]
        public string Post([FromForm] Formforgotemailobject form)
        {
            string JsonString = string.Empty;
            string email = form.email;
            bool mailGestuurd = false; 
            var dt = EntityData.User.GetEmail(email);
            //kijken of email bestaat
            if (dt.Rows.Count > 0)
            {
                string email2 = dt.Rows[0][0].ToString();
                if (email.Equals(email2))
                {
                    //mail versturen zo ja
                    WPLClassLibTeam02.Tools.Mailhelper.Mailwachtwoordvergeten(email);
                    mailGestuurd = true;
                }
            }

            //bool weergeven of mail is verstuurd of niet
            JsonString = JsonConvert.SerializeObject(mailGestuurd);
            return JsonString;

        }

        //hulp object om email aan te maken
        public class Formforgotemailobject
        {
            public string email { get; set; }
        }
    }
}
