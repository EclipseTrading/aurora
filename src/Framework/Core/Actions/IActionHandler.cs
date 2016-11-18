using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.Core.Actions
{
    public interface IActionHandler
    {
        bool Execute(ActionEvent evt);
    }
}
