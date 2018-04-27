using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablePlugin
{
    /// <summary>
    /// Интерфейс для передачи TableSettings и BuildClick event 
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Свойство TableSettings
        /// </summary>
        TableSettings TableSettings { get; }

        /// <summary>
        /// Событие нажатия на кнопку "Построить столик"
        /// </summary>
        event EventHandler BuildClick;
    }
}
