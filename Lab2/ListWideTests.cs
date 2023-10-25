using MyCollection;

namespace Lab2
{
    [TestFixture]
    public class ListWideTests
    {
        private Fixture _fixture;
        private _SortedList<int, int> MySortedList;
        private _SortedList<int, int> MySortedList_Initial;
        private _SortedList<int, int> MySortedList_Final;
        private SortedList<int, int> TestList;


        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();

        }

        [Test]
        public void ListWideTest_Clear()
        {
            MySortedList = _fixture.Create<_SortedList<int, int>>();

            Assert.That(MySortedList.Count, Is.GreaterThan(0));
            MySortedList.Clear();
            Assert.That(MySortedList.Count, Is.EqualTo(0));
        }
        [Test]
        public void ListWideTest_ExpandCapacity()
        {
            var InitialCapacity = _fixture.Create<int>();
            MySortedList_Initial = new _SortedList<int, int>(InitialCapacity);
            MySortedList_Final = MySortedList_Initial;

            bool InitialCapacityCheck = (InitialCapacity == MySortedList_Initial._items.Length);
            MySortedList_Final.ExpandCapacity();
            bool FinalCapacityCheck = (InitialCapacity * 2 == MySortedList_Final._items.Length);
            int l = 0;

            Assert.That(InitialCapacityCheck, Is.True);
            Assert.That(FinalCapacityCheck, Is.True);

            foreach(var n in MySortedList_Initial)
            {
                Assert.That(n, Is.EqualTo(MySortedList_Final[l]));
                l++;
            }
        }
    }
}