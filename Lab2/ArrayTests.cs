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
            int l = 0;

            for (int i = 0; i < MySortedList.Count; i++)
            {
                Assert.That(MySortedList[i].Value, Is.EqualTo(SameSizeArray[l]));
                l++;
            }
        }
        [Test]
        public void ArrayTest_DifferentSizeArray_NoOffset()
        {
            var IndexOffset = _fixture.Create<int>();
            IndexOffset %= MySortedList.Count;
            var SameSizeArray = new int[MySortedList.Count + IndexOffset];

            MySortedList.CopyTo(SameSizeArray, 0);
            int l = 0;

            for (int i = 0; i < MySortedList.Count; i++)
            {
                Assert.That(MySortedList[i].Value, Is.EqualTo(SameSizeArray[l]));
                l++;
            }
        }
        [Test]
        public void ArrayTest_DifferentSizeArray_Offset()
        {
            var IndexOffset = _fixture.Create<int>();
            IndexOffset %= MySortedList.Count;
            var SameSizeArray = new int[MySortedList.Count + IndexOffset];

            MySortedList.CopyTo(SameSizeArray, IndexOffset);
            int l = IndexOffset;

            for (int i = 0; i < MySortedList.Count; i++)
            {
                Assert.That(MySortedList[i].Value, Is.EqualTo(SameSizeArray[l]));
                l++;
            }
        }
        [Test]
        public void ArrayTest_ArrayTooSmall()
        {
            var SmallArray = new int[MySortedList.Count - 1];

            Assert.Throws<ArgumentException>(() => MySortedList.CopyTo(SmallArray, 0));
        }
        [Test]
        public void ArrayTest_InvalidIndex()
        {
            var Array = new int[MySortedList.Count];

            Assert.Throws<ArgumentOutOfRangeException>(() => MySortedList.CopyTo(Array, -1));
        }
        [Test]
        public void ArrayTest_NullArray()
        {
            int[] NullArray = null;

            Assert.Throws<ArgumentNullException>(() => MySortedList.CopyTo(NullArray, 0));
        }
    }
}