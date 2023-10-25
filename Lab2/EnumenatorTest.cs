using MyCollection;

namespace Lab2
{
    [TestFixture]
    public class EnumenatorTests
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
        public void EventTest_ElementAdded()
        {
            TestList = _fixture.Create<SortedList<int, int>>();
            foreach (var n in TestList)
            {
                MySortedList.Add(n.Key, n.Value);
            }

            int l = 0;
            var MyEnum = MySortedList.GetEnumerator();

            while(MyEnum.MoveNext())
            {
                Assert.That(MyEnum.Current.Key, Is.EqualTo(TestList.Keys[TestList.Count - l - 1]));
                Assert.That(MyEnum.Current.Value, Is.EqualTo(TestList.Values[TestList.Count - l - 1]));
                l++;
            }
        }
        [Test]
        public void EventTest_Reset()
        {
            MySortedList = _fixture.Create<_SortedList<int, int>>();

            var MyEnum = MySortedList.GetEnumerator();
            bool NonZeroCheck;

            while (MyEnum.MoveNext())
            {}
            NonZeroCheck = (MyEnum.Current.Value != MySortedList[0].Value && MyEnum.Current.Key != MySortedList[0].Key);
            MyEnum.Reset();

            Assert.That(NonZeroCheck, Is.EqualTo(true));
            Assert.That(MyEnum.Current, Is.EqualTo(MySortedList[0]));
        }
    }
}