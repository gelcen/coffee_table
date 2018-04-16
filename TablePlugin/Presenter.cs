using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablePlugin
{
    /// <summary>
    /// Класс Презентерf
    /// </summary>
    class Presenter
    {
        /// <summary>
        /// Класс-обёртка для КОМПАСа 
        /// </summary>
        private KompasBuilder _kompasBuilder;

        /// <summary>
        /// Интерфейс для получения параметров столика
        /// </summary>
        private IView _view;

        /// <summary>
        /// Конструктор, в котором инициализируются поля класса
        /// </summary>
        /// <param name="view"></param>
        public Presenter(IView view)
        {
            _view = view;
            _view.BuildClick += new EventHandler(Build);
        }

        /// <summary>
        /// Обработчик нажатия на кнопку "Построить столик"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Build(object sender, EventArgs e)
        {
            _kompasBuilder = new KompasBuilder(_view.TableSettings);
        }
    }
}
