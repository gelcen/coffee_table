using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablePlugin
{
    class Presenter
    {

        private KompasBuilder _kompasBuilder;

        private IView _view;

        public Presenter(IView view)
        {
            _view = view;
            _view.BuildClick += new EventHandler(Build);
            _kompasBuilder = new KompasBuilder();
        }

        private void Build(object sender, EventArgs e)
        {
            TableSettings TableSettings = _view.TableSettings;

        }
    }
}
