using ConsoleApp;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class GameServiceTests
    {
        public GameService Game { get; set; }

        [SetUp]
        public void Setup()
        {
            Game = new GameService();
        }

        [Test]
        public void DefaultHeapValuesShouldBeSetOnInit()
        {
            Game.InitGame();

            Assert.AreEqual(Game.HeapA, 3);
            Assert.AreEqual(Game.HeapB, 4);
            Assert.AreEqual(Game.HeapC, 5);
        }

        [Test]
        public void SpecificHeapValuesShouldBeSetOnInit()
        {
            Game.InitGame(7, 8, 9);

            Assert.AreEqual(Game.HeapA, 7);
            Assert.AreEqual(Game.HeapB, 8);
            Assert.AreEqual(Game.HeapC, 9);
        }

        [Test]
        public void AllHeapsAreEmptyWhenEachValueIsZero()
        {
            Game.InitGame(0, 0, 0);

            Assert.IsTrue(Game.AllHeapsEmpty());

            Game.InitGame(1, 2, 3);

            Assert.IsFalse(Game.AllHeapsEmpty());
        }

    }
}
