using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablePlugin;

namespace tests
{
    /// <summary>
    /// Тесты для класса TableSettings
    /// </summary>
    [TestFixture]
    public class TableSettingsTest
    {
        [Test]
        [TestCase(60, 5, 30, 5, TestName = "Positive TableSettings construct test.")]
        [TestCase(90, 10, 45, 6, TestName = "Positive TableSettings construct test (max).")]
        [TestCase(50, 3, 15, 3, TestName = "Positive TableSettings construct test (min).")]
        public void TableSettingsConstructPosTest(int tabletopLength, int tabletopThickness, int legHeight, int legLength)
        {
            var tableSettings = new TableSettings(tabletopLength, tabletopThickness, legHeight, legLength, true);
        }

        [Test]
        [TestCase(100, 5, 30, 5, TestName = "Positive TableSettings negative test(TabletopLength).")]
        [TestCase(0, 5, 30, 5, TestName = "Positive TableSettings negative test(TabletopLength).")]
        [TestCase(-100, 5, 30, 5, TestName = "Positive TableSettings negative test(TabletopLength).")]
        [TestCase(60, 111, 30, 5, TestName = "Positive TableSettings negative test(TabletopThickness).")]
        [TestCase(100, -5, 30, 5, TestName = "Positive TableSettings negative test(TabletopThickness -).")]
        [TestCase(100, 1, 30, 5, TestName = "Positive TableSettings negative test(TabletopThickness).")]
        [TestCase(60, 5, 300, 5, TestName = "Positive TableSettings negative test(LegHeight).")]
        [TestCase(60, 5, -300, 5, TestName = "Positive TableSettings negative test(LegHeight).")]
        [TestCase(75, 5, 20, 5, TestName = "Positive TableSettings negative test(LegHeight dependency from TabletopLength).")]
        [TestCase(60, 5, 30, 145, TestName = "Positive TableSettings negative test(LegLength).")]
        [TestCase(60, 5, 30, -145, TestName = "Positive TableSettings negative test(LegLength).")]
        [TestCase(60, 5, 30, 0, TestName = "Positive TableSettings negative test(LegLength).")]
        [TestCase(600, 500, 300, 145, TestName = "Positive TableSettings negative test.")]
        [TestCase(1, 1, 1, 1, TestName = "Positive TableSettings negative test(LegLength).")]
        [TestCase(-60, -5, -30, -145, TestName = "Positive TableSettings negative test(LegLength).")]
        [TestCase(600, 5, 30, 145, TestName = "Positive TableSettings negative test(LegLength).")]
        public void TableSettingsConstructNegTest(int tabletopLength, int tabletopThickness, int legHeight, int legLength)
        {
            Assert.That(() =>
            {
                var tableSettings = new TableSettings(tabletopLength, tabletopThickness, legHeight, legLength, true);
            },
            Throws.TypeOf(typeof(ArgumentException)));
        }
    }
}