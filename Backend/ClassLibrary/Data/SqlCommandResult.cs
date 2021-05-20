using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPLClassLibTeam02.Data
{
    //hulpKlasse voor EntityHelper
    public class SQLCommandResult
    {
        public SQLCommandResult()
        {
            Count = 0;
            NewId = -1;
            DataTable = new DataTable();
        }
        public int NewId { get; set; }
        public int Count { get; set; }
        public EntityCommand EntityCommand { get; set; }
        public DataTable DataTable { get; set; }
    }
}
