using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPLClassLibTeam02.Data
{
    public interface IEntityHelper
    {
        SQLCommandResult Insert();
        SQLCommandResult Update();
        SQLCommandResult Delete();
        SQLCommandResult Read();
    }
}
