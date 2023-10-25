using MyCollection;

namespace Lab2
{
    [TestFixture]
    public class ElementTests
    {
        private Fixture _fixture;
        private _SortedList<int, int> MySortedList;
        private SortedList<int, int> TestList;


        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            MySortedList = new _SortedList<int, int>(4);

        }
        [Test]
        public void ElementTest_Add_Empty()
        {
            TestList = new SortedList<int, int>();
            var a = _fixture.Create<KeyValuePair<int, int>>();
            MySortedList.Add(a);
            TestList.Add(a.Key, a.Value);
            for (int i = 0; i < MySortedList.Count(); i++)
            {
                Assert.That(MySortedList[i].Key, Is.EqualTo(TestList.Keys[MySortedList.Count() - i - 1]));
                Assert.That(MySortedList[i].Value, Is.EqualTo(TestList.Values[MySortedList.Count() - i - 1]));
            }
        }
        [Test]
        public void ElementTest_Add_Duplicate()
        {
            TestList = _fixture.Create<SortedList<int, int>>();
            foreach (var n in TestList)
            {
                MySortedList.Add(n.Key, n.Value);
            }
            var a = MySortedList[0];
            Assert.Throws<ArgumentException>(() => MySortedList.Add(a.Key, a.Value));
            Assert.Throws<ArgumentException>(() => TestList.Add(a.Key, a.Value));
            for (int i = 0; i < MySortedList.Count(); i++)
            {
                Assert.That(MySortedList[i].Key, Is.EqualTo(TestList.Keys[MySortedList.Count() - i - 1]));
                Assert.That(MySortedList[i].Value, Is.EqualTo(TestList.Values[MySortedList.Count() - i - 1]));
            }
        }
        [Test]
        public void ElementTest_Add_KeyValuePair()
        {
            TestList = _fixture.Create<SortedList<int, int>>();
            foreach (var n in TestList)
            {
                MySortedList.Add(n.Key, n.Value);
            }
            var a = _fixture.Create<KeyValuePair<int, int>>();
            MySortedList.Add(a);
            TestList.Add(a.Key, a.Value);
            for (int i = 0; i < MySortedList.Count(); i++)
            {
                Assert.That(MySortedList[i].Key, Is.EqualTo(TestList.Keys[MySortedList.Count() - i - 1]));
                Assert.That(MySortedList[i].Value, Is.EqualTo(TestList.Values[MySortedList.Count() - i - 1]));
            }
        }
        [Test]
        public void ElementTest_Add_KeyAndValue()
        {
            TestList = _fixture.Create<SortedList<int, int>>();
            foreach (var n in TestList)
            {
                MySortedList.Add(n.Key, n.Value);
            }
            var key = _fixture.Create<int>();
            var value = _fixture.Create<int>();

            MySortedList.Add(key, value);
            TestList.Add(key, value);
            for (int i = 0; i < MySortedList.Count(); i++)
            {
                Assert.That(MySortedList[i].Key, Is.EqualTo(TestList.Keys[MySortedList.Count() - i - 1]));
                Assert.That(MySortedList[i].Value, Is.EqualTo(TestList.Values[MySortedList.Count() - i - 1]));
            }
        }
        [Test]
        public void ElementTest_Contains_KeyValuePair()
        {
            TestList = _fixture.Create<SortedList<int, int>>();
            foreach (var n in TestList)
            {
                MySortedList.Add(n.Key, n.Value);
            }
            var InvalidElement = new KeyValuePair<int, int>(-1, -1);

            bool ContainsTrue = MySortedList.Contains(MySortedList[0]);
            bool ContainsFalse = MySortedList.Contains(InvalidElement);

            Assert.That(ContainsTrue, Is.True);
            Assert.That(ContainsFalse, Is.False);
        }
        [Test]
        public void ElementTest_Contains_Key()
        {
            TestList = _fixture.Create<SortedList<int, int>>();
            foreach (var n in TestList)
            {
                MySortedList.Add(n.Key, n.Value);
            }

            bool ContainsTrue = MySortedList.Contains(MySortedList[0].Key);
            bool ContainsFalse = MySortedList.Contains(-1);

            Assert.That(ContainsTrue, Is.True);
            Assert.That(ContainsFalse, Is.False);
        }
        [Test]
        public void ElementTest_Remove_KeyValuePair()
        {
            TestList = _fixture.Create<SortedList<int, int>>();
            foreach (var n in TestList)
            {
                MySortedList.Add(n.Key, n.Value);
            }
            var InvalidElement = new KeyValuePair<int, int>(-1, -1);


            bool ContainsTrue = MySortedList.Remove(MySortedList[0]);
            bool ContainsFalse = MySortedList.Remove(InvalidElement);

            Assert.That(ContainsTrue, Is.True);
            Assert.That(ContainsFalse, Is.False);
        }
        [Test]
        public void ElementTest_Remove_Key()
        {
            TestList = _fixture.Create<SortedList<int, int>>();
            foreach (var n in TestList)
            {
                MySortedList.Add(n.Key, n.Value);
            }

            bool ContainsTrue = MySortedList.Remove(MySortedList[0].Key);
            bool ContainsFalse = MySortedList.Remove(-1);

            Assert.That(ContainsTrue, Is.True);
            Assert.That(ContainsFalse, Is.False);
        }
        [Test]
        public void Test_Clear()
        {
            MySortedList = _fixture.Create<_SortedList<int, int>>();

            Assert.That(MySortedList.Count, Is.GreaterThan(0));
            MySortedList.Clear();
            Assert.That(MySortedList.Count, Is.EqualTo(0));
        }

    }
}