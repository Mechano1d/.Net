using MyCollection;

namespace Lab2
{
    [TestFixture]
    public class ConstructorTests
    {
        [Test]
        public void ConstructorTest_ArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() => new _SortedList<object, object>(null));
        }
        [Test]
        public void ConstructorTest_ArgumentNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new _SortedList<object, object>(-1));
        }
        [Test]
        public void ConstructorTest_ArgumentZero()
        {
            var MyList = new _SortedList<object, object>(0);
            Assert.That(MyList._items.Length, Is.EqualTo(0));
        }
        [Test]
        public void ConstructorTest_ArgumentValid()
        {
            var MyList =  new _SortedList<object, object>(10);
            Assert.That(MyList._items.Length, Is.EqualTo(10));
        }
    }
}