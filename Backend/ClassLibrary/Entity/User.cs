using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPLClassLibTeam02.Entity
{

    //user klasse gebruikt om user objecten te maken en deze dan te gebruiken voor in de database
    public class User
    {
        public User()
        {

        }
        public User(string email, string password, string naam, string voornaam, string country, string adres, int postcode)
        {
            this.emailadres = email;
            this.password = password;
            this.naam = naam;
            this.voornaam = voornaam;
            this.country = country;
            this.adres = adres;
            this.postcode = postcode;
        }

        public string emailadres { get; set; }
        public string password { get; set; }
        public string naam { get; set; }
        public string voornaam { get; set; }
        public string country { get; set; }
        public string adres { get; set; }
        public int postcode { get; set; }

    }

   
}
