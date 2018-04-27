using System;


namespace TablePlugin
{
    public class TableSettings
    {
        /// <summary>
        /// Длина стороны столешницы
        /// </summary>
        private Parameter _tabletopLength;

        /// <summary>
        /// Толщина столешницы
        /// </summary>
        private Parameter _tabletopThickness;

        /// <summary>
        /// Высота ножки 
        /// </summary>
        private Parameter _legHeight;

        /// <summary>
        /// Длина стороны ножки 
        /// </summary>
        private Parameter _legLength;

        /// <summary>
        /// Высота разделителей
        /// </summary>
        private Parameter _septumLength;

        /// <summary>
        /// Отступ разделителей от столешницы
        /// </summary>
        private Parameter _septumOffset;

        /// <summary>
        /// Скруглённые края столешницы
        /// </summary>
        private bool _roundedEdgesTabletop;

        /// <summary>
        /// Строить ли разделители? 
        /// </summary>
        private bool _withSeptums;

        /// <summary>
        /// Свойство для длины стороны столешницы
        /// </summary>
        public uint TabletopLength
        {
            get
            {
                return _tabletopLength.Value;
            }
            private set
            {
                _tabletopLength.Value = value;
            }
        }

        /// <summary>
        /// Свойство для толщины столешницы
        /// </summary>
        public uint TabletopThickness
        {
            get
            {
                return _tabletopThickness.Value;
            }
            private set
            {
                _tabletopThickness.Value = value;
            }
        }

        /// <summary>
        /// Свойство для высоты ножки
        /// </summary>
        public uint LegHeight
        {
            get
            {
                return _legHeight.Value;
            }
            private set
            {
                if(_tabletopLength.Value > 700 && value < 300)
                {
                    throw new ArgumentException("Высота ножки не может быть ниже 30 см, если длина стороны столешницы выше 70 см!");
                }
                _legHeight.Value = value;
            }
        }

        /// <summary>
        /// Свойство для длины стороны ножки
        /// </summary>
        public uint LegLength
        {
            get
            {
                return _legLength.Value;
            }
            private set
            {
                _legLength.Value = value;
            }
        }

        /// <summary>
        /// Свойство для длины разделителей
        /// </summary>
        public uint SeptumLength
        {
            get
            {
                return _septumLength.Value;
            }
            private set
            {
                _septumLength.Value = value;
            }
        }

        /// <summary>
        /// Свойство для отступа между разделителем и столешницей
        /// </summary>
        public uint SeptumOffset
        {
            get
            {
                return _septumOffset.Value;
            }
            set
            {
                _septumOffset.Value = value;
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
        /// Свойство для определения строить ли разделители
        /// </summary>
        public bool WithSeptums
        {
            get
            {
                return _withSeptums;
            }
            private set
            {
                _withSeptums = value;
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
        public TableSettings(uint tabletopLength, uint tabletopThickness, 
                             uint legHeight, uint legLength,
                             bool withSeptums, uint septumLength, uint septumOffset, 
                             bool roundedEdges)
        {
            _tabletopLength = new Parameter(500, 900, tabletopLength, "Длина стороны столешницы");
            _tabletopThickness = new Parameter(30, 100, tabletopThickness, "Толщина столешницы");
            _legHeight = new Parameter(150, 450, 200, "Высота ножек");
            LegHeight = legHeight;
            _legLength = new Parameter(30, 60, legLength, "Длина стороны основания ножки");
            _withSeptums = withSeptums;
            if (_withSeptums == true )
            {
                _septumLength = new Parameter(20, 50, septumLength, "Высота разделителей");
                _septumOffset = new Parameter(50, 100, septumOffset, "Отступ разделителей от столешницы");
            }
            RoundedEdgesTabletop = roundedEdges;
        }

    }
}
