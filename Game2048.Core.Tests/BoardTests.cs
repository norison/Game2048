using System.Runtime.InteropServices.ComTypes;
using Moq;
using NUnit.Framework;

namespace Game2048.Core.Tests
{
    [TestFixture]
    public class BoardTests
    {
        private static IBoard InitBoard(sbyte size, IGameRandomGenerator generator)
        {
            return new Board(generator, size);
        }

        [Test]
        public void IsSingleMoveUpValid()
        {
            var generatorMock = new Mock<IGameRandomGenerator>();
            generatorMock.Setup(m => m.GetRandomPosition(It.IsAny<int>())).Returns(4);//put initial value to cell "4" [1,0]
            generatorMock.Setup(m => m.GetRandomValue()).Returns(2); //cell Value shall be 2
            var board = InitBoard(4, generatorMock.Object);
            board.MoveUp(); //Now cell [0,0] must contains 2
            Assert.AreEqual(2, board.Get2DBoard()[0, 0].Value);
        }

        [Test]
        public void IsSingleMoveDownValid()
        {
            var generatorMock = new Mock<IGameRandomGenerator>();
            generatorMock.Setup(m => m.GetRandomPosition(It.IsAny<int>())).Returns(0);//put initial value to cell "0" [0,0]
            generatorMock.Setup(m => m.GetRandomValue()).Returns(2); //cell Value shall be 2
            var board = InitBoard(4, generatorMock.Object);
            board.MoveDown(); //Now cell [3,0] must contains 2
            Assert.AreEqual(2, board.Get2DBoard()[board.Size - 1, 0].Value);
        }

        [Test]
        public void IsSingleMoveLeftValid()
        {
            var generatorMock = new Mock<IGameRandomGenerator>();
            generatorMock.Setup(m => m.GetRandomPosition(It.IsAny<int>())).Returns(1);//put initial value to cell "1" [0,1]
            generatorMock.Setup(m => m.GetRandomValue()).Returns(2); //cell Value shall be 2
            var board = InitBoard(4, generatorMock.Object);
            board.MoveLeft(); //Now cell [0,0] must contains 2
            Assert.AreEqual(2, board.Get2DBoard()[0, 0].Value);
        }

        [Test]
        public void IsSingleMoveRightValid()
        {
            var generatorMock = new Mock<IGameRandomGenerator>();
            generatorMock.Setup(m => m.GetRandomPosition(It.IsAny<int>())).Returns(0);//put initial value to cell "4" [0,0]
            generatorMock.Setup(m => m.GetRandomValue()).Returns(2); //cell Value shall be 2
            var board = InitBoard(4, generatorMock.Object);
            board.MoveRight(); //Now cell [0,1] must contains 2
            Assert.AreEqual(2, board.Get2DBoard()[0, board.Size - 1].Value);
        }
    }
}