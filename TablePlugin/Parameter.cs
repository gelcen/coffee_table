using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TablePlugin
{
    /// <summary>
    /// "Тип данных" для хранения параметров столика
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Имя параметра
        /// </summary>
        private string _name;
        /// <summary>
        /// Поле для хранения значения
        /// </summary>
        private uint _value;

        /// <summary>
        /// Поле для хранения максимального возмножного значения
        /// </summary>
        private uint _max;

        /// <summary>
        /// Поле для хранения минимального возмножного значения
        /// </summary>
        private uint _min;

        /// <summary>
        /// Константа для хранения минимума у полей
        /// </summary>
        private const uint _possibleMin = 10;

        /// <summary>
        /// Константа для хранения максимума у полей
        /// </summary>
        private const uint _possibleMax = 1000;

        /// <summary>
        /// Свойство для минимума
        /// </summary>
        public uint Min
        {
            get
            {
                return _min;
            }
            set
            {
                if (value < _possibleMin)
                {
                    throw new ArgumentException(String.Format(
                        "Минимальное возможное значения для этого поля равно {0}",
                        _possibleMin));
                }
                if (value > _possibleMax)
                {
                    throw new ArgumentException(String.Format(
                        "Максимальное возможное значения для этого поля равно {0}",
                        _possibleMax));
                }
                if (value > Max)
                {
                    throw new ArgumentException(
                        "Минимальное значение не может быть больше максимального!");
                }
                _min = value;
                if (_value < _min)
                {
                    _value = _min;
                }
            }
        }

        /// <summary>
        /// Свойство для максимума
        /// </summary>
        public uint Max
        {
            get
            {
                return _max;
            }
            set
            {
                if (value < _possibleMin)
                {
                    throw new ArgumentException(String.Format(
                        "Минимальное возможное значения для этого поля равно {0}",
                        _possibleMin));
                }
                if (value > _possibleMax)
                {
                    throw new ArgumentException(String.Format(
                        "Максимальное возможное значения для этого поля равно {0}",
                        _possibleMax));
                }
                if (value < Min)
                {
                    throw new ArgumentException(
                        "Максимальное значение не может быть меньше минимального!");
                }
                _max = value;
                if (_value > _max)
                {
                    _value = _max;
                }
            }

        }

        /// <summary>
        /// Свойство для самого значения
        /// </summary>
        public uint Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value > Max)
                {
                    throw new ArgumentException(String.Format
                        ("Значение параметра \"" + Name + "\" не может быть больше {0}!", Max));
                }
                if (value < Min)
                {
                    throw new ArgumentException(String.Format
                        ("Значение параметра \"" + Name + "\" не может быть меньше {0}!", Min));
                }
                _value = value;
            }
        }

        /// <summary>
        /// Свойство для имени параметра
        /// </summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value == null || value == "")
                {
                    throw new ArgumentException("Значение поля Name не может быть пустой строкой!");
                }
                _name = value;
            }
        }

        /// <summary>
        /// Конструктор параметра
        /// </summary>
        /// <param name="min">Минимум</param>
        /// <param name="max">Максимум</param>
        /// <param name="value">Значение</param>
        /// <param name="name">Имя параметра</param>
        public Parameter(uint min, uint max, uint value, string name)
        {
            Name = name;
            Max = max;
            Min = min;
            Value = value;
        }
    }
}
