using ConsoleApp;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class GameServiceTests
    {
        [Test]
        public void DefaultHeapValuesShouldBeSetOnInit()
        {
            var game = new GameService();

            game.InitGame();

            Assert.AreEqual(game.HeapA, 3);
            Assert.AreEqual(game.HeapB, 4);
            Assert.AreEqual(game.HeapC, 5);
        }

        [Test]
        public void SpecificHeapValuesShouldBeSetOnInit()
        {
            var game = new GameService();

            game.InitGame(7, 8, 9);

            Assert.AreEqual(game.HeapA, 7);
            Assert.AreEqual(game.HeapB, 8);
            Assert.AreEqual(game.HeapC, 9);
        }

    }
}
