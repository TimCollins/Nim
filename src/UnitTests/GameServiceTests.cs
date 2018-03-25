using System;
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

        [Test]
        public void HeapShouldBeDecrementedWhenSpecifiedByName()
        {
            var input = "a2";

            Game.InitGame(5, 6, 7);
            Game.SaveInput(input);
            Game.ProcessInput();

            Assert.AreEqual(3, Game.HeapA);

            input = "b3";
            Game.SaveInput(input);
            Game.ProcessInput();

            Assert.AreEqual(3, Game.HeapB);

            input = "c1";
            Game.SaveInput(input);
            Game.ProcessInput();

            Assert.AreEqual(6, Game.HeapC);
        }

        [Test]
        public void ExceptionShouldBeThrownIfInvalidHeapInput()
        {
            Game.HeapInput = "Z";

            Assert.Throws<ApplicationException>(() => Game.ProcessInput());
        }

        [Test]
        public void CurrentPlayerShouldBe1ByDefaultWithInputParams()
        {
            Game.InitGame();

            Assert.AreEqual(1, Game.Player);
        }

        [Test]
        public void CurrentPlayerShouldBe1ByDefaultWithoutInputParams()
        {
            Game.InitGame(4, 5, 6);

            Assert.AreEqual(1, Game.Player);
        }

        [Test]
        public void CurrentPlayerShouldChangeIfHeapsNotEmpty()
        {
            Game.InitGame(4, 5, 6);
            Game.UpdatePlayer();

            Assert.AreEqual(2, Game.Player);

            Game.UpdatePlayer();

            Assert.AreEqual(1, Game.Player);
        }

        [Test]
        public void CurrentPlayerShouldNotChangeIfHeapsEmpty()
        {
            Game.InitGame();
            Game.HeapA = Game.HeapB = Game.HeapC = 0;

            Game.UpdatePlayer();

            Assert.AreEqual(1, Game.Player);
        }

    }
}
