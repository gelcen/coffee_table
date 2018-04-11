using Kompas6API5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablePlugin
{
    class KompasBuilder
    {
        private KompasObject _kompas = null;

        public KompasBuilder(TableSettings tableSettings)
        {
            if (_kompas == null)
            {
                Type t = Type.GetTypeFromProgID("Kompas.Application.5");
                _kompas = (KompasObject)Activator.CreateInstance(t);
                _kompas.Visible = true;
            }
        }
    }
}
