using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TablePlugin; 

namespace tests
{
    /// <summary>
    /// Тесты для класса Parameter
    /// </summary>
    [TestFixture]
    class ParameterTests
    {
        [Test]
        [TestCase(50, 100, 60, "normal", 
            TestName = "Parameter positive constructor test(avg). ")]
        [TestCase(11, 999, 60, "normal", 
            TestName = "Parameter positive constructor test(min and max).")]
        public void ParameterConstructorPositiveTest(int min, int max, int value, string name)
        {
            var parameter = new Parameter(Convert.ToUInt32(min), Convert.ToUInt32(max),
                Convert.ToUInt32(value), name);
        }

        [Test]
        [TestCase(1, 10000, 50, "name",
            TestName = "Parameter constructor negative test. (Too big max)")]
        //[TestCase(6.6, 100.6, 60, "normal",
        //    TestName = "Parameter negative constructor test. (Float min n max)")]
        [TestCase(500, 100, 60, "normal",
            TestName = "Parameter negative constructor test. (Min bigger than max)")]
        [TestCase(0, 100, 60, "normal",
            TestName = "Parameter negative constructor test. (Min is 0)")]
        [TestCase(50, 100, 40, "normal",
            TestName = "Parameter negative constructor test. (Value less than min)")]
        [TestCase(50, 100, 130, "normal",
            TestName = "Parameter negative constructor test. (Value bigger than max)")]
        //[TestCase(50, 100, 66.6, "normal",
        //    TestName = "Parameter negative constructor test. (Float value)")]
        [TestCase(50, 100, 60, "",
            TestName = "Parameter negative constructor test. (Empty name)")]
        [TestCase(50, 100, 60, null,
            TestName = "Parameter negative constructor test. (Name is null)")]
        //[TestCase(50, 100, 60, 5,
        //    TestName = "Parameter negative constructor test. (Name is number)")]
        public void ParameterConstructorNegativeTest(int min, int max, int value, string name)
        {
            Assert.That(() =>
            {
                var parameter = new Parameter(Convert.ToUInt32(min), Convert.ToUInt32(max),
                    Convert.ToUInt32(value), name);                   
            },
            Throws.TypeOf(typeof(ArgumentException)));
        }

        [Test]
        [TestCase(-50, -100, 60, "normal",
            TestName = "Parameter negative constructor test. (Negative min n max)")]
        [TestCase(50, 100, -60, "normal",
            TestName = "Parameter negative constructor test. (Value is negative)")]
        public void ParameterConstructorNegTest(int min, int max, int value, string name)
        {
            Assert.That(() =>
            {
                var parameter = new Parameter(Convert.ToUInt32(min), Convert.ToUInt32(max),
                    Convert.ToUInt32(value), name);
            },
            Throws.TypeOf(typeof(OverflowException)));
        }
    }
}
