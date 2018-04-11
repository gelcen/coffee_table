using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablePlugin
{
    /// <summary>
    /// Класс Презентер
    /// </summary>
    class Presenter
    {

        private KompasBuilder _kompasBuilder;

        private IView _view;

        public Presenter(IView view)
        {
            _view = view;
            _view.BuildClick += new EventHandler(Build);
        }

        private void Build(object sender, EventArgs e)
        {
            _kompasBuilder = new KompasBuilder(_view.TableSettings);
        }
    }
}
