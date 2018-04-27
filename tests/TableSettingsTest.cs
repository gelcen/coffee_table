using NUnit.Framework;
using TablePlugin;
using System;

namespace tests
{
    /// <summary>
    /// Тесты для класса TableSettings
    /// </summary>
    [TestFixture]
    public class TableSettingsTest
    {
        [Test]
        [TestCase(600, 50, 300, 50, true, 30, 60, TestName = "Positive TableSettings construct test.")]
        [TestCase(900, 100, 450, 60, true, 50, 100, TestName = "Positive TableSettings construct test (max).")]
        [TestCase(500, 30, 150, 30, true, 20, 50, TestName = "Positive TableSettings construct test (min).")]
        [TestCase(600, 50, 300, 50, false, 30, 60, TestName = "Positive TableSettings construct test without septums.")]
        public void TableSettingsConstructPosTest(uint tabletopLength, uint tabletopThickness, uint legHeight, uint legLength,
            bool withSeptums, uint septumLength, uint septumOffset)
        {
            var tableSettings = new TableSettings(tabletopLength, tabletopThickness, legHeight, legLength,
                withSeptums, septumLength, septumOffset, true);
        }

        [Test]
        [TestCase(1000, 50, 300, 50, true, 30, 60, TestName = "TableSettings negative test(TabletopLength).")]
        [TestCase(300, 50, 300, 50, true, 30, 60, TestName = "TableSettings negative test(TabletoLength).")]
        [TestCase(600.0, 50, 300, 50, true, 30, 60, TestName = "TableSettings negative test(TabletopLength).")]
        [TestCase(0, 50, 300, 50, true, 30, 60, TestName = "TableSettings negative test(TabletopLength).")]
        [TestCase(-1, 50, 300, 50, true, 30, 60, TestName = "TableSettings negative test(TabletopLength).")]
        [TestCase(uint.MaxValue, 50, 300, 50, true, 30, 60, TestName = "TableSettings negative test(TabletopLength).")]
        [TestCase(uint.MinValue, 50, 300, 50, true, 30, 60, TestName = "TableSettings negative test(TabletopLength).")]

        [TestCase(600, 500, 300, 50, true, 30, 60, TestName = "TableSettings negative test(TabletopThickness).")]
        [TestCase(600, 0, 300, 50, true, 30, 60, TestName = "TableSettings negative test(TabletopThickness -).")]
        [TestCase(600, -50, 300, 50, true, 30, 60, TestName = " TableSettings negative test(TabletopThickness).")]
        [TestCase(600, 1, 300, 50, true, 30, 60, TestName = "TableSettings negative test(TabletopThickness).")]
        [TestCase(600, 50.0, 300, 50, true, 30, 60, TestName = "TableSettings negative test(TabletopThickness).")]
        [TestCase(600, uint.MaxValue, 300, 50, true, 30, 60, TestName = "TableSettings negative test(TabletopThickness).")]
        [TestCase(600, uint.MinValue, 300, 50, true, 30, 60, TestName = "TableSettings negative test(TabletopThickness).")]

        [TestCase(600, 50, 3000, 50, true, 30, 60, TestName = "TableSettings negative test(LegHeight).")]
        [TestCase(600, 50, 30, 50, true, 30, 60, TestName = "TableSettings negative test(LegHeight).")]
        [TestCase(600, 50, 0, 50, true, 30, 60, TestName = " TableSettings negative test(LegHeight dependency from TabletopLength).")]
        [TestCase(600, 50, -30, 50, true, 30, 60, TestName = "TableSettings negative test(LegHeight).")]
        [TestCase(600, 50, 30.3, 50, true, 30, 60, TestName = "TableSettings negative test(LegHeight).")]
        [TestCase(600, 50, uint.MaxValue, 50, true, 30, 60, TestName = "TableSettings negative test(LegHeight).")]
        [TestCase(600, 50, uint.MinValue, 50, true, 30, 60, TestName = "TableSettings negative test(LegHeight).")]

        [TestCase(600, 50, 300, 500, true, 30, 60, TestName = "Positive TableSettings negative test(LegLength).")]
        [TestCase(600, 50, 300, 0, true, 30, 60, TestName = "Positive TableSettings negative test(LegLength).")]
        [TestCase(600, 50, 300, 1, true, 30, 60, TestName = "Positive TableSettings negative test(LegLength).")]
        [TestCase(600, 50, 300, -50, true, 30, 60, TestName = "Positive TableSettings negative test(LegLength).")]
        [TestCase(600, 50, 300, 50.55, true, 30, 60, TestName = "Positive TableSettings negative test(LegLength).")]
        [TestCase(600, 50, 300, uint.MinValue, true, 30, 60, TestName = "Positive TableSettings negative test(LegLength).")]
        [TestCase(600, 50, 300, uint.MaxValue, true, 30, 60, TestName = "Positive TableSettings negative test(LegLength).")]

        [TestCase(600, 50, 300, 50, true, 300, 60, TestName = "Positive TableSettings negative test(SeptumLength).")]
        [TestCase(600, 50, 300, 50, true, 0, 60, TestName = "Positive TableSettings negative test(SeptumLength).")]
        [TestCase(600, 50, 300, 50, true, 1, 60, TestName = "Positive TableSettings negative test(SeptumLength).")]
        [TestCase(600, 50, 300, 50, true, -30, 60, TestName = "Positive TableSettings negative test(SeptumLength).")]
        [TestCase(600, 50, 300, 50, true, 30.33, 60, TestName = "Positive TableSettings negative test(SeptumLength).")]
        [TestCase(600, 50, 300, 50, true, uint.MaxValue, 60, TestName = "Positive TableSettings negative test(SeptumLength).")]
        [TestCase(600, 50, 300, 50, true, uint.MinValue, 60, TestName = "Positive TableSettings negative test(SeptumLength).")]

        [TestCase(600, 50, 300, 50, true, 30, 6000, TestName = "Positive TableSettings negative test(SeptumOffset).")]
        [TestCase(600, 50, 300, 50, true, 30, 0, TestName = "Positive TableSettings negative test(SeptumOffset).")]
        [TestCase(600, 50, 300, 50, true, 30, 1.6, TestName = "Positive TableSettings negative test(SeptumOffset).")]
        [TestCase(600, 50, 300, 50, true, 30, 1, TestName = "Positive TableSettings negative test(SeptumOffset).")]
        [TestCase(600, 50, 300, 50, true, 30, uint.MinValue, TestName = "Positive TableSettings negative test(SeptumOffset).")]
        [TestCase(600, 50, 300, 50, true, 30, uint.MaxValue, TestName = "Positive TableSettings negative test(SeptumOffset).")]
        [TestCase(600, 50, 300, 50, true, 30, -6000, TestName = "Positive TableSettings negative test(SeptumOffset).")]

        
        [TestCase(800, 50, 300, 50, true, 30, 60, TestName = "TableSettings negative test(LegLength).")]

        [TestCase(6000, 500, 3000, 500, true, 3000, 6000, TestName = "TableSettings negative test. All parameters.")]
        [TestCase(-6000, -500, -3000, -500, true, -3000, -6000, TestName = "TableSettings negative test. All parameters.")]
        [TestCase(6000.8, 500.8, 3000.8, 500.8, true, 3000.8, 6000.8, TestName = "TableSettings negative test. All parameters.")]
        [TestCase(0, 0, 0, 0, true, 0, 0, TestName = "TableSettings negative test. All parameters.")]
        [TestCase(1, 1, 1, 1, true, 1, 1, TestName = "TableSettings negative test. All parameters.")]
        [TestCase(uint.MinValue, uint.MinValue, uint.MinValue, uint.MinValue, true, uint.MinValue, uint.MinValue, TestName = "TableSettings negative test. All parameters.")]
        [TestCase(uint.MaxValue, uint.MaxValue, uint.MaxValue, uint.MaxValue, true, uint.MaxValue, uint.MaxValue, TestName = "TableSettings negative test. All parameters.")]


        public void TableSettingsConstructNegTest(uint tabletopLength, uint tabletopThickness, uint legHeight, uint legLength,
            bool withSeptums, uint septumLength, uint septumOffset)
        {
            Assert.That(() =>
            {
                 var tableSettings = new TableSettings(tabletopLength, tabletopThickness, legHeight, legLength, 
                     withSeptums, septumLength, septumOffset, true);
            },
            Throws.TypeOf(typeof(ArgumentException)));
        }

    }
}