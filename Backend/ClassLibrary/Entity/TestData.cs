using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPLClassLibTeam02.Entity
{

    //useless klasse, voorbeeld
    public class TestData
    {
        //CREATE TABLE tblTestData(testdataid int IDENTITY(1,1) PRIMARY KEY,
        //tekst varchar(255) NOT NULL,datum datetime,getal int)
        public int TestDataId { get; set; }
        public string Tekst { get; set; }
        public DateTime Datum { get; set; }
        public int Getal { get; set; }
    }
}
