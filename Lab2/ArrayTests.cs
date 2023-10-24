using MyCollection;

namespace Lab2
{
    [TestFixture]
    public class ArrayTests
    {
        private Fixture _fixture;
        private _SortedList<int, int> MySortedList;
        private SortedList<int, int> TestList;


        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            MySortedList = new _SortedList<int, int>(4);
            TestList = _fixture.Create<SortedList<int, int>>();
            foreach (var n in TestList)
            {
                MySortedList.Add(n);
            }
        }

        [Test]
        public void ArrayTest_SameSizeArray()
        {
            var SameSizeArray = new int[MySortedList.size];

            MySortedList.CopyTo(SameSizeArray, 0);
        }
        [Test]
        public void EventTest_ElementRemoved()
        {
            bool EventTriggered = false;
            var element = _fixture.Create<KeyValuePair<int, int>>();


            MySortedList.RemoveElement += (sender, e) => EventTriggered = true;
            MySortedList.Add(element);
            MySortedList.Remove(element);

            Assert.IsTrue(EventTriggered);


        }
        [Test]
        public void EventTest_ClearArray()
        {
            bool EventTriggered = false;
            TestList = _fixture.Create<SortedList<int, int>>();


            MySortedList.ClearArray += (sender, e) => EventTriggered = true;
            MySortedList.Clear();

            Assert.IsTrue(EventTriggered);


        }
    }
}