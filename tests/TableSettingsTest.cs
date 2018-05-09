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
        [TestCase(600, 50, 300, 50, true, 30, 60, 
            TestName = "Positive TableSettings construct test. (avg)")]
        [TestCase(900, 100, 450, 60, true, 50, 100, 
            TestName = "Positive TableSettings construct test (max).")]
        [TestCase(500, 30, 150, 30, true, 20, 50, 
            TestName = "Positive TableSettings construct test (min).")]
        [TestCase(600, 50, 300, 50, false, 30, 60, 
            TestName = "Positive TableSettings construct test without septums.")]
        public void TableSettingsConstructPosTest(int tabletopLength, int tabletopThickness, 
                                                  int legHeight, int legLength,
                                                  bool withSeptums, int septumLength, int septumOffset)
        {
            var tableSettings = new TableSettings(Convert.ToUInt32(tabletopLength), Convert.ToUInt32(tabletopThickness),
                                                  Convert.ToUInt32(legHeight), Convert.ToUInt32(legLength),
                         withSeptums, Convert.ToUInt32(septumLength), Convert.ToUInt32(septumOffset), true);
        }

        [Test]
        [TestCase(1000, 50, 300, 50, true, 30, 60, 
            TestName = "TableSettings negative test(TabletopLength too big).")]
        [TestCase(300, 50, 300, 50, true, 30, 60, 
            TestName = "TableSettings negative test(TabletoLength too little).")]

        [TestCase(0, 50, 300, 50, true, 30, 60, 
            TestName = "TableSettings negative test(TabletopLength is 0).")]
        
        
        [TestCase(600, 500, 300, 50, true, 30, 60, 
            TestName = "TableSettings negative test(TabletopThickness too big).")]
        [TestCase(600, 0, 300, 50, true, 30, 60, 
            TestName = "TableSettings negative test(TabletopThickness is 0).")]
        [TestCase(600, 1, 300, 50, true, 30, 60, 
            TestName = "TableSettings negative test(TabletopThickness is too little).")]

        
        [TestCase(600, 50, 3000, 50, true, 30, 60, 
            TestName = "TableSettings negative test(LegHeight is too big).")]
        [TestCase(600, 50, 30, 50, true, 30, 60, 
            TestName = "TableSettings negative test(LegHeight is little).")]
        [TestCase(600, 50, 0, 50, true, 30, 60, 
            TestName = " TableSettings negative test(LegHeight is 0).")]

        
        [TestCase(600, 50, 300, 500, true, 30, 60, 
            TestName = "Positive TableSettings negative test(LegLength is too big).")]
        [TestCase(600, 50, 300, 0, true, 30, 60, 
            TestName = "Positive TableSettings negative test(LegLength is 0).")]
        [TestCase(600, 50, 300, 1, true, 30, 60, 
            TestName = "Positive TableSettings negative test(LegLength is too little).")]

        
        [TestCase(600, 50, 300, 50, true, 300, 60, 
            TestName = "Positive TableSettings negative test(SeptumLength is too big).")]
        [TestCase(600, 50, 300, 50, true, 0, 60, 
            TestName = "Positive TableSettings negative test(SeptumLength is 0).")]
        [TestCase(600, 50, 300, 50, true, 1, 60, 
            TestName = "Positive TableSettings negative test(SeptumLength is too little).")]

        

        [TestCase(600, 50, 300, 50, true, 30, 6000, 
            TestName = "Positive TableSettings negative test(SeptumOffset too big).")]
        [TestCase(600, 50, 300, 50, true, 30, 0, 
            TestName = "Positive TableSettings negative test(SeptumOffset is 0).")]
        [TestCase(600, 50, 300, 50, true, 30, 1, 
            TestName = "Positive TableSettings negative test(SeptumOffset is too little).")]
        
       
        [TestCase(800, 50, 289, 50, true, 30, 60, 
            TestName = "TableSettings negative test(LegHeight cannot be under 300 if TabletopLength is higher than 700).")]

        [TestCase(6000, 500, 3000, 500, true, 3000, 6000, 
            TestName = "TableSettings negative test. All parameters are too big.")]
        [TestCase(0, 0, 0, 0, true, 0, 0, 
            TestName = "TableSettings negative test. All parameters are 0.")]
        [TestCase(1, 1, 1, 1, true, 1, 1, 
            TestName = "TableSettings negative test. All parameters are too little.")]
         
        public void ConstructNegTest(int tabletopLength, int tabletopThickness, 
                                                  int legHeight, int legLength,
                                                  bool withSeptums, int septumLength, int septumOffset)
        {
            Assert.That(() =>
            {
                 var tableSettings = new TableSettings(Convert.ToUInt32(tabletopLength), Convert.ToUInt32(tabletopThickness),
                     Convert.ToUInt32(legHeight), Convert.ToUInt32(legLength), 
                     withSeptums, Convert.ToUInt32(septumLength), Convert.ToUInt32(septumOffset), true);
            },
            Throws.TypeOf(typeof(ArgumentException)));
        }

        [Test]
        [TestCase(uint.MinValue, uint.MinValue, uint.MinValue, uint.MinValue, true, uint.MinValue, uint.MinValue,
            TestName = "TableSettings negative test. All parameters are uint.MinValue.")]
        [TestCase(uint.MaxValue, uint.MaxValue, uint.MaxValue, uint.MaxValue, true, uint.MaxValue, uint.MaxValue,
            TestName = "TableSettings negative test. All parameters are uint.MaxValue.")]
        public void ConstructNegativeTest(uint tabletopLength, uint tabletopThickness,
                                                  uint legHeight, uint legLength,
                                                  bool withSeptums, uint septumLength, uint septumOffset)
        {
            Assert.That(() =>
            {
                var tableSettings = new TableSettings(tabletopLength, tabletopThickness,
                                                      legHeight, legLength,
                                                      withSeptums, septumLength, septumOffset, true);
            },
            Throws.TypeOf(typeof(ArgumentException)));
        }

        [Test]                
        [TestCase(uint.MaxValue, 50, 300, 50, true, 30, 60,
            TestName = "TableSettings negative test(TabletopLength is uint.Max).")]
        [TestCase(uint.MinValue, 50, 300, 50, true, 30, 60,
            TestName = "TableSettings negative test(TabletopLength is uint.Min).")]
        public void ConstructNegTabletopTest(uint tabletopLength, int tabletopThickness,
                                                  int legHeight, int legLength,
                                                  bool withSeptums, int septumLength, int septumOffset)
        {
            Assert.That(() =>
            {
                var tableSettings = new TableSettings(tabletopLength, Convert.ToUInt32(tabletopThickness),
                    Convert.ToUInt32(legHeight), Convert.ToUInt32(legLength),
                    withSeptums, Convert.ToUInt32(septumLength), Convert.ToUInt32(septumOffset), true);
            },
            Throws.TypeOf(typeof(ArgumentException)));
        }

        [Test]
        [TestCase(600, uint.MaxValue, 300, 50, true, 30, 60,
            TestName = "TableSettings negative test(TabletopThickness is uint.Max).")]
        [TestCase(600, uint.MinValue, 300, 50, true, 30, 60,
            TestName = "TableSettings negative test(TabletopThickness is uint.MinValue).")]
        public void ConstructNegTablethickTest(int tabletopLength, uint tabletopThickness,
                                                  int legHeight, int legLength,
                                                  bool withSeptums, int septumLength, int septumOffset)
        {
            Assert.That(() =>
            {
                var tableSettings = new TableSettings(Convert.ToUInt32(tabletopLength), tabletopThickness,
                    Convert.ToUInt32(legHeight), Convert.ToUInt32(legLength),
                    withSeptums, Convert.ToUInt32(septumLength), Convert.ToUInt32(septumOffset), true);
            },
            Throws.TypeOf(typeof(ArgumentException)));
        }

        [Test]
        [TestCase(600, 50, uint.MaxValue, 50, true, 30, 60,
            TestName = "TableSettings negative test(LegHeight is uint.MaxValue).")]
        [TestCase(600, 50, uint.MinValue, 50, true, 30, 60,
            TestName = "TableSettings negative test(LegHeight is uint.MinValue).")]
        public void ConstructNegLegHTest(int tabletopLength, int tabletopThickness,
                                                  uint legHeight, int legLength,
                                                  bool withSeptums, int septumLength, int septumOffset)
        {
            Assert.That(() =>
            {
                var tableSettings = new TableSettings(Convert.ToUInt32(tabletopLength), Convert.ToUInt32(tabletopThickness),
                    legHeight, Convert.ToUInt32(legLength),
                    withSeptums, Convert.ToUInt32(septumLength), Convert.ToUInt32(septumOffset), true);
            },
            Throws.TypeOf(typeof(ArgumentException)));
        }

        [Test]
        [TestCase(600, 50, 300, uint.MinValue, true, 30, 60,
            TestName = "Positive TableSettings negative test(LegLength is uint.MinValue).")]
        [TestCase(600, 50, 300, uint.MaxValue, true, 30, 60,
            TestName = "Positive TableSettings negative test(LegLength is uint.MaxValue).")]
        public void ConstructNegLegLTest(int tabletopLength, int tabletopThickness,
                                                  int legHeight, uint legLength,
                                                  bool withSeptums, int septumLength, int septumOffset)
        {
            Assert.That(() =>
            {
                var tableSettings = new TableSettings(Convert.ToUInt32(tabletopLength), Convert.ToUInt32(tabletopThickness),
                    Convert.ToUInt32(legHeight), legLength,
                    withSeptums, Convert.ToUInt32(septumLength), Convert.ToUInt32(septumOffset), true);
            },
            Throws.TypeOf(typeof(ArgumentException)));
        }

        [Test]
        [TestCase(600, 50, 300, 50, true, uint.MaxValue, 60,
            TestName = "Positive TableSettings negative test(SeptumLength is uint.MaxValue).")]
        [TestCase(600, 50, 300, 50, true, uint.MinValue, 60,
            TestName = "Positive TableSettings negative test(SeptumLength is uint.MinValue).")]
        public void ConstructNegSeptumLTest(int tabletopLength, int tabletopThickness,
                                                  int legHeight, int legLength,
                                                  bool withSeptums, uint septumLength, int septumOffset)
        {
            Assert.That(() =>
            {
                var tableSettings = new TableSettings(Convert.ToUInt32(tabletopLength), Convert.ToUInt32(tabletopThickness),
                    Convert.ToUInt32(legHeight), Convert.ToUInt32(legLength),
                    withSeptums, septumLength, Convert.ToUInt32(septumOffset), true);
            },
            Throws.TypeOf(typeof(ArgumentException)));
        }

        [Test]
        [TestCase(600, 50, 300, 50, true, 30, uint.MinValue,
            TestName = "TableSettings negative test(SeptumOffset is uint.MinValue).")]
        [TestCase(600, 50, 300, 50, true, 30, uint.MaxValue,
            TestName = "TableSettings negative test(SeptumOffset is uint.MaxValue).")]
        public void ConstructNegSeptumLTest(int tabletopLength, int tabletopThickness,
                                                  int legHeight, int legLength,
                                                  bool withSeptums, int septumLength, uint septumOffset)
        {
            Assert.That(() =>
            {
                var tableSettings = new TableSettings(Convert.ToUInt32(tabletopLength), Convert.ToUInt32(tabletopThickness),
                    Convert.ToUInt32(legHeight), Convert.ToUInt32(legLength),
                    withSeptums, Convert.ToUInt32(septumLength), septumOffset, true);
            },
            Throws.TypeOf(typeof(ArgumentException)));
        }

        [Test]
        [TestCase(-1, 50, 300, 50, true, 30, 60,
            TestName = "TableSettings negative test(TabletopLength is negative).")]
        [TestCase(-6000, -500, -3000, -500, true, -3000, -6000,
            TestName = "TableSettings negative test. All parameters are negative.")]
        [TestCase(600, 50, 300, 50, true, 30, -60,
            TestName = "Positive TableSettings negative test(SeptumOffset is negative).")]
        [TestCase(600, 50, 300, 50, true, -30, 60,
            TestName = "Positive TableSettings negative test(SeptumLength is negative).")]
        [TestCase(600, 50, 300, -50, true, 30, 60,
            TestName = "Positive TableSettings negative test(LegLength is negative).")]
        [TestCase(600, 50, -30, 50, true, 30, 60,
            TestName = "TableSettings negative test(LegHeight is negative).")]
        [TestCase(600, -50, 300, 50, true, 30, 60,
            TestName = " TableSettings negative test(TabletopThickness is negative).")]
        public void ConstructNegNegTest(int tabletopLength, int tabletopThickness,
                                                  int legHeight, int legLength,
                                                  bool withSeptums, int septumLength, int septumOffset)
        {
            Assert.That(() =>
            {
                var tableSettings = new TableSettings(Convert.ToUInt32(tabletopLength), Convert.ToUInt32(tabletopThickness),
                    Convert.ToUInt32(legHeight), Convert.ToUInt32(legLength),
                    withSeptums, Convert.ToUInt32(septumLength), Convert.ToUInt32(septumOffset), true);
            },
            Throws.TypeOf(typeof(OverflowException)));
        }
    }
}