using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPLClassLibTeam02.Tools
{
   public static class FileHelper
   {
        //file inlezen en validation aanroepen
        public static FileResult OpenFile()
        {
            FileResult result = new FileResult();
            var ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Oefeningen";
            if (ofd.ShowDialog() == true)
            {
                var fileLines = File.ReadAllLines(ofd.FileName);
                result = FileValidation(fileLines);
            }
            return result;
        }

        //methode om CSVproduct aan te maken aan de hand van csv bestand
        private static FileResult FileValidation(string[] fileLines)
        {
            FileResult result = new FileResult();
            if (fileLines != null && fileLines.Length > 0)
            {
                
                    result.Succeeded = true;
                    CsvProduct csvData;
                    for (int i = 0; i < fileLines.Length; i++)
                    {
                    csvData = new CsvProduct();
                    var data = fileLines[i].Split(';');
                    csvData.CategoryNaam = data[0];
                    csvData.SubCategory = data[1];
                    csvData.ProductNaam = data[2];
                    csvData.Omschrijving = data[3];
                    csvData.Specificaties = data[4];
                    csvData.Eenheidsprijs = Convert.ToInt32(data[5]);
                    csvData.Afbeeldingsnaam = data[6];

                    result.AddObject(csvData);
                    }
                
            }
            return result;
        }
   }


    //hulp klasse
   public class FileResult
   {
        private List<CsvProduct> objectRows = new List<CsvProduct>();
        public bool Succeeded { get; set; }
        public IEnumerable<CsvProduct> CsvObjectRows => objectRows;
        public void AddObject(CsvProduct csvData)
        {
            objectRows.Add(csvData);
        }
   }

    //hulp klasse
    public class CsvProduct
   {
        public string ProductNaam { get; set; }
        public string CategoryNaam { get; set; }
        public string SubCategory { get; set; }
        public string Omschrijving { get; set; }
        public string Specificaties  { get; set; }
        public int Eenheidsprijs { get; set; }
        public string Afbeeldingsnaam { get; set; }
   }

   

   

}
