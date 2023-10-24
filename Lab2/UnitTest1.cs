using MyCollection;

namespace Lab2
{
    [TestFixture]
    public class Tests
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
        public void NonEmptyListAdd()
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
        public void NonEmptyListContains()
        {
            TestList = _fixture.Create<SortedList<int, int>>();
            foreach (var n in TestList)
            {
                MySortedList.Add(n.Key, n.Value);
            }

            bool ContainsTrue = MySortedList.Contains(MySortedList[0].Key);
            Assert.That(ContainsTrue, Is.True);

            bool ContainsFalse = MySortedList.Contains(-1);
            Assert.That(ContainsFalse, Is.False);
        }
        [Test]
        public void NonEmptyListClear()
        {
            MySortedList = _fixture.Create<_SortedList<int, int>>();
            Assert.That(MySortedList.Count, Is.GreaterThan(0));
            MySortedList.Clear();
            Assert.That(MySortedList.Count, Is.EqualTo(0));
        }
        [Test]
        public void MyStack_Constructor_InitializationTest()
        {
            var TestSize = _fixture.Create<int>();
            var MySortedList = new _SortedList<int, int>(TestSize);

            Assert.That(MySortedList.values.Length, Is.EqualTo(TestSize));
            Assert.That(MySortedList.keys.Length, Is.EqualTo(TestSize));
        }

        [Test]
        public void Constructor_ArgumentNullTest()
        {
            Assert.Throws<ArgumentNullException>(() => new _SortedList<object, object>(null));
        }
        [Test]
        public void Constructor_ArgumentNegativeTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new _SortedList<object, object>(-1));
        }
    }
}