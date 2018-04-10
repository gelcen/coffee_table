using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablePlugin
{
    public class TableSettings
    {
        /// <summary>
        /// Длина стороны столешницы
        /// </summary>
        private int _tabletopLength;

        /// <summary>
        /// Толщина столешницы
        /// </summary>
        private int _tabletopThickness;

        /// <summary>
        /// Высота ножки 
        /// </summary>
        private int _legHeight;

        /// <summary>
        /// Длина стороны ножки 
        /// </summary>
        private int _legLength;

        /// <summary>
        /// Скруглённые края столешницы
        /// </summary>
        private bool _roundedEdgesTabletop;

        /// <summary>
        /// Свойство для длины стороны столешницы
        /// </summary>
        public int TabletopLength
        {
            get
            {
                return _tabletopLength;
            }
            private set
            {
                if (value < 50 || value > 90)
                {
                    throw new ArgumentException("Длина стороны квадратной столешницы должна от 50 cм до 90 cм!");
                }
                _tabletopLength = value;
            }
        }

        /// <summary>
        /// Свойство для толщины столешницы
        /// </summary>
        public int TabletopThickness
        {
            get
            {
                return _tabletopThickness;
            }
            private set
            {
                if (value < 3 || value > 10)
                {
                    throw new ArgumentException("Толщина столешницы должна быть от 3 см до 10 см!");
                }
                _tabletopThickness = value;
            }
        }

        /// <summary>
        /// Свойство для высоты ножки
        /// </summary>
        public int LegHeight
        {
            get
            {
                return _legHeight;
            }
            private set
            {
                if (value < 15 || value > 45)
                {
                    throw new ArgumentException("Высота ножки должна быть от 15 см до 45 см!");
                }
                if(_tabletopLength > 70 && value < 30)
                {
                    throw new ArgumentException("Высота ножки не может быть ниже 30 см, если длина стороны столешницы выше 70 см!");
                }
                _legHeight = value;
            }
        }

        /// <summary>
        /// Свойство для длины стороны ножки
        /// </summary>
        public int LegLength
        {
            get
            {
                return _legLength;
            }
            private set
            {
                if (value < 3 || value > 6)
                {
                    throw new ArgumentException("Длина стороны ножки должна быть от 3 см до 6 см!");
                }
                _legLength = value;
            }
        }

        /// <summary>
        /// Свойство для скруглённости краев столешницы
        /// </summary>
        public bool RoundedEdgesTabletop
        {
            get
            {
                return _roundedEdgesTabletop;
            }
            private set
            {
                _roundedEdgesTabletop = value;
            }
        }

        /// <summary>
        /// Конструктор класса TableSettings
        /// </summary>
        /// <param name="tabletopLength"></param>
        /// <param name="tabletopThickness"></param>
        /// <param name="legHeight"></param>
        /// <param name="legLength"></param>
        /// <param name="roundedEdges"></param>
        public TableSettings(int tabletopLength, int tabletopThickness, int legHeight, int legLength, bool roundedEdges)
        {
            TabletopLength = tabletopLength;
            TabletopThickness = tabletopThickness;
            LegHeight = legHeight;
            LegLength = legLength;
            RoundedEdgesTabletop = roundedEdges;
        }

    }
}
