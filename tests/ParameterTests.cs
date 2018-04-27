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
        [TestCase(50, 100, 60, "normal", TestName ="Parameter positive constructor test.")]
        [TestCase(2, 999, 60, "normal", TestName = "Parameter positive constructor test(min).")]
        public void ParameterConstructorPositiveTest(uint min, uint max, uint value, string name)
        {
            var parameter = new Parameter(min, max, value, name);
        }

        [Test]
        [TestCase(0, 10000, 50, "name", TestName ="Parameter constructor negative test.")]
        [TestCase(-50, -100, 60, "normal", TestName = "Parameter negative constructor test.")]
        [TestCase(6.6, 100.6, 60, "normal", TestName = "Parameter negative constructor test.")]
        [TestCase(500, 100, 60, "normal", TestName = "Parameter negative constructor test.")]
        [TestCase(50, 1000, 60, "normal", TestName = "Parameter negativeconstructor test.")]
        [TestCase(0, 100, 60, "normal", TestName = "Parameter negative constructor test.")]
        [TestCase(50, 100, 40, "normal", TestName = "Parameter negative constructor test.")]
        [TestCase(50, 100, 130, "normal", TestName = "Parameter negative constructor test.")]
        [TestCase(50, 100, -60, "normal", TestName = "Parameter negative constructor test.")]
        [TestCase(50, 100, 66.6, "normal", TestName = "Parameter negative constructor test.")]
        [TestCase(50, 100, 60, "", TestName = "Parameter negative constructor test.")]
        [TestCase(50, 100, 60, null, TestName = "Parameter negative constructor test.")]
        [TestCase(50, 100, 60, 5, TestName = "Parameter negative constructor test.")]
        public void ParameterConstructorNegativeTest(uint min, uint max, uint value, string name)
        {
            Assert.That(() =>
            {
                var parameter = new Parameter(min, max, value, name);                   
            },
            Throws.TypeOf(typeof(ArgumentException)));
        }
    }
}
