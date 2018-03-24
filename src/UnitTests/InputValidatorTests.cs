using ConsoleApp;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class InputValidatorTests
    {
        public GameService Game { get; set; }

        [SetUp]
        public void Setup()
        {
            Game = new GameService();
            Game.InitGame();
        }

        [Test]
        public void EmptyInputShouldReturnFalse()
        {
            var input = string.Empty;

            Assert.IsFalse(Game.IsValidInput(input));
        }

        [Test]
        public void NullInputShouldReturnFalse()
        {
            Assert.IsFalse(Game.IsValidInput(null));
        }

        [Test]
        public void FewerThanTwoCharactersShouldReturnFalse()
        {
            var input = "a";

            Assert.IsFalse(Game.IsValidInput(input));
        }

        [Test]
        public void GreaterThanTwoCharactersShouldReturnFalse()
        {
            var input = "abcd";

            Assert.IsFalse(Game.IsValidInput(input));
        }

        [Test]
        public void TheFirstCharMustBeAValidHeapName()
        {
            // Valid heaps are just A, B or C
            Assert.IsFalse(Game.IsValidInput("D"));
            Assert.IsFalse(Game.IsValidInput("Z"));
            Assert.IsFalse(Game.IsValidInput("17"));
            Assert.IsFalse(Game.IsValidInput("-2"));
        }

        [Test]
        public void TheSecondCharMustBeAValidAmount()
        {
            Assert.IsFalse(Game.IsValidInput("a0"));
            Assert.IsFalse(Game.IsValidInput("b17"));
            Assert.IsTrue(Game.IsValidInput("c2"));
        }

        [Test]
        public void HeapNamesAreNotCaseSensitive()
        {
            Assert.IsTrue(Game.IsValidInput("a2"));
            Assert.IsTrue(Game.IsValidInput("A2"));
            Assert.IsTrue(Game.IsValidInput("b1"));
            Assert.IsTrue(Game.IsValidInput("b3"));
            Assert.IsTrue(Game.IsValidInput("c1"));
            Assert.IsTrue(Game.IsValidInput("C2"));
        }

        [Test]
        public void AmountMustBeGreaterThanOrEqualToRemainder()
        {
            Game.HeapA = 2;
            Assert.IsTrue(Game.IsValidInput("a2"));

            Game.HeapB = 1;
            Assert.IsFalse(Game.IsValidInput("B2"));

            Game.HeapC = 3;
            Assert.IsTrue(Game.IsValidInput("c1"));
        }
       
    }
}
