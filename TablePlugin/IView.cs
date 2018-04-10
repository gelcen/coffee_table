using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablePlugin
{
    interface IView
    {
        TableSettings TableSettings { get; set; }
        event EventHandler BuildClick;
    }
}
