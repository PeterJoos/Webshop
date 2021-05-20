using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WPLClassLibTeam02.Tools
{

    //klasse om mails te versturen
    public static class Mailhelper
    {
        //maakt een mailobject aan en verstuurt deze dan
        private static void TestMail(string mailto, string emailBody, string subject)
        {

            MailMessage mailMessage = new MailMessage("fitlabs2021@gmail.com", mailto);
            mailMessage.Subject = subject;
            mailMessage.Body = emailBody;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential() { UserName = "fitlabs2021@gmail.com", Password = "Pxlteam02" };
            smtpClient.EnableSsl = true; smtpClient.Send(mailMessage);
        }

        //functie om nieuw wachtwoord te verzoeken, encrypteren en opslaan in database. roept daarna testmail aan om mail te versturen.
        public static void Mailwachtwoordvergeten(string mailto)
        {
            string nieuwWachtwoord = GeneratePaswoord();//update databank met het nieuwe wachtwoord gekoppeld aan de email emailTo
            string encryptedWachtwoord = EncryptionTool.Crypt(nieuwWachtwoord);
            Data.EntityData.Emailcheck.UpdateWachtwoord(encryptedWachtwoord, mailto);
            string emailBody = $"Wachtwoord : {nieuwWachtwoord}";
            string subject = "Wachtwoord vergeten ?";
            TestMail(mailto, emailBody, subject);
        }


        //genereert een random wachtwoord
        private static string GeneratePaswoord()
        {
            Random r = new Random();
            int randomGetal = 0;
            string pwd = "";
            string test = "abcdefghijklmnopqrstuvwxyz0123456789!#ABCDEFGHIJKLMNOPQRSTUVWXYZ99";
            do
            {
                randomGetal = r.Next(0, test.Length - 1);
                pwd += test.Substring(randomGetal, 1);
            }
            while (pwd.Length < 9);
            return pwd;
        }
    }
}
