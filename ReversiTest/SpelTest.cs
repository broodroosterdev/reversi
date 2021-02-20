using NUnit.Framework;
using ReversiRestApi;

namespace ReversiTest
{
    [TestFixture]
    public class SpelTest
    {
        // geen kleur = 0
        // Wit = 1
        // Zwart = 2
        [Test]
        public void ZetMogelijk_BuitenBord_ReturnFalse()
        {
            // Arrange
            Game game = new Game();
            //   0 1 2 3 4 5 6 7
            //                  v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            //                   <
            // Act
            game.Turn = Color.White;
            var actual = game.MovePossible(8, 8);
            // Assert
            Assert.IsFalse(actual);
        }
        [Test]
        public void ZetMogelijk_StartSituatieZet23Zwart_ReturnTrue()
        {
            // Arrange
            Game game = new Game();
            //   0 1 2 3 4 5 6 7
            //         v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 2 0 0 0 0 <
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.Black;
            var actual = game.MovePossible(2, 3);
            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void ZetMogelijk_StartSituatieZet23Wit_ReturnFalse()
        {
            // Arrange
            Game game = new Game();
            //   0 1 2 3 4 5 6 7
            //         v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 1 0 0 0 0 <
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.White;
            var actual = game.MovePossible(2, 3);
            // Assert
            Assert.IsFalse(actual);
        }
        [Test]
        public void ZetMogelijk_ZetAanDeRandBoven_ReturnTrue()
        {
            // Arrange
            Game game = new Game();
            game.Board[1, 3] = Color.White;
            game.Board[2, 3] = Color.White;
            //   0 1 2 3 4 5 6 7
            //         v
            // 0 0 0 0 2 0 0 0 0 <
            // 1 0 0 0 1 0 0 0 0
            // 2 0 0 0 1 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.Black;
            var actual = game.MovePossible(0, 3);
            // Assert
            Assert.IsTrue(actual);
        }

        [Test]
        public void ZetMogelijk_ZetAanDeRandBoven_ReturnFalse()
        {
            // Arrange
            Game game = new Game();
            game.Board[1, 3] = Color.White;
            game.Board[2, 3] = Color.White;
            //   0 1 2 3 4 5 6 7
            //         v
            // 0 0 0 0 1 0 0 0 0 <
            // 1 0 0 0 1 0 0 0 0
            // 2 0 0 0 1 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.White;
            var actual = game.MovePossible(0, 3);
            // Assert
            Assert.IsFalse(actual);
        }
        [Test]
        public void ZetMogelijk_ZetAanDeRandBovenEnTotBenedenReedsGevuld_ReturnTrue()
        {
            // Arrange
            Game game = new Game();
            game.Board[1, 3] = Color.White;
            game.Board[2, 3] = Color.White;
            game.Board[3, 3] = Color.White;
            game.Board[4, 3] = Color.White;
            game.Board[5, 3] = Color.White;
            game.Board[6, 3] = Color.White;
            game.Board[7, 3] = Color.Black;
            //   0 1 2 3 4 5 6 7
            //         v
            // 0 0 0 0 2 0 0 0 0 <
            // 1 0 0 0 1 0 0 0 0
            // 2 0 0 0 1 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 1 1 0 0 0
            // 5 0 0 0 1 0 0 0 0
            // 6 0 0 0 1 0 0 0 0
            // 7 0 0 0 2 0 0 0 0
            // Act
            game.Turn = Color.Black;
            var actual = game.MovePossible(0, 3);
            // Assert
            Assert.IsTrue(actual);
        }
        [Test]
        public void ZetMogelijk_ZetAanDeRandBovenEnTotBenedenReedsGevuld_ReturnFalse()
        {
            // Arrange
            Game game = new Game();
            game.Board[1, 3] = Color.White;
            game.Board[2, 3] = Color.White;
            game.Board[3, 3] = Color.White;
            game.Board[4, 3] = Color.White;
            game.Board[5, 3] = Color.White;
            game.Board[6, 3] = Color.White;
            game.Board[7, 3] = Color.White;
            //   0 1 2 3 4 5 6 7
            //         v
            // 0 0 0 0 2 0 0 0 0 <
            // 1 0 0 0 1 0 0 0 0
            // 2 0 0 0 1 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 1 1 0 0 0
            // 5 0 0 0 1 0 0 0 0
            // 6 0 0 0 1 0 0 0 0
            // 7 0 0 0 1 0 0 0 0
            // Act
            game.Turn = Color.Black;
            var actual = game.MovePossible(0, 3);
            // Assert
            Assert.IsFalse(actual);
        }
        [Test]
        public void ZetMogelijk_ZetAanDeRandRechts_ReturnTrue()
        {
            // Arrange
            Game game = new Game();
            game.Board[4, 5] = Color.White;
            game.Board[4, 6] = Color.White;
            //   0 1 2 3 4 5 6 7
            //                 v
            // 0 0 0 0 2 0 0 0 0
            // 1 0 0 0 1 0 0 0 0
            // 2 0 0 0 1 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 1 1 2 <
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.Black;
            var actual = game.MovePossible(4, 7);
            // Assert
            Assert.IsTrue(actual);
        }
        [Test]
        public void ZetMogelijk_ZetAanDeRandRechts_ReturnFalse()
        {
            // Arrange
            Game game = new Game();
            game.Board[4, 5] = Color.White;
            game.Board[4, 6] = Color.White;
            //   0 1 2 3 4 5 6 7
            //                 v
            // 0 0 0 0 1 0 0 0 0
            // 1 0 0 0 1 0 0 0 0
            // 2 0 0 0 1 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 1 1 1 <
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.White;
            var actual = game.MovePossible(4, 7);
            // Assert
            Assert.IsFalse(actual);
        }
        [Test]
        public void ZetMogelijk_ZetAanDeRandRechtsEnTotLinksReedsGevuld_ReturnTrue()
        {
            // Arrange
            Game game = new Game();
            game.Board[4, 0] = Color.Black;
            game.Board[4, 1] = Color.White;
            game.Board[4, 2] = Color.White;
            game.Board[4, 3] = Color.White;
            game.Board[4, 4] = Color.White;
            game.Board[4, 5] = Color.White;
            game.Board[4, 6] = Color.White;
            //   0 1 2 3 4 5 6 7
            //                 v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 2 1 1 1 1 1 1 2 <
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.Black;
            var actual = game.MovePossible(4, 7);
            // Assert
            Assert.IsTrue(actual);
        }
        [Test]
        public void ZetMogelijk_ZetAanDeRandRechtsEnTotLinksReedsGevuld_ReturnFalse()
        {
            // Arrange
            Game game = new Game();
            game.Board[4, 0] = Color.Black;
            game.Board[4, 1] = Color.White;
            game.Board[4, 2] = Color.White;
            game.Board[4, 3] = Color.White;
            game.Board[4, 4] = Color.White;
            game.Board[4, 5] = Color.White;
            game.Board[4, 6] = Color.White;
            //   0 1 2 3 4 5 6 7
            //                 v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 2 1 1 1 1 1 1 1 <
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.White;
            var actual = game.MovePossible(4, 7);
            // Assert
            Assert.IsFalse(actual);
        }
        // 0 1 2 3 4 5 6 7
        //
        // 0 0 0 0 0 0 0 0 0
        // 1 0 0 0 0 0 0 0 0
        // 2 0 0 0 0 0 0 0 0
        // 3 0 0 0 1 2 0 0 0
        // 4 0 0 0 2 1 0 0 0
        // 5 0 0 0 0 0 0 0 0
        // 6 0 0 0 0 0 0 0 0
        // 7 0 0 0 0 0 0 0 0
        [Test]
        public void ZetMogelijk_StartSituatieZet22Wit_ReturnFalse()
        {
            // Arrange
            Game game = new Game();
            //   0 1 2 3 4 5 6 7
            //       v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 1 0 0 0 0 0 <
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.White;
            var actual = game.MovePossible(2, 2);
            // Assert
            Assert.IsFalse(actual);
        }
        [Test]
        public void ZetMogelijk_StartSituatieZet22Zwart_ReturnFalse()
        {
            // Arrange
            Game game = new Game();
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 2 0 0 0 0 0 <
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.Black;
            var actual = game.MovePossible(2, 2);
            // Assert
            Assert.IsFalse(actual);
        }
        [Test]
        public void ZetMogelijk_ZetAanDeRandRechtsBoven_ReturnTrue()
        {
            // Arrange
            Game game = new Game();
            game.Board[2, 5] = Color.Black;
            game.Board[1, 6] = Color.Black;
            game.Board[5, 2] = Color.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 1 <
            // 1 0 0 0 0 0 0 2 0
            // 2 0 0 0 0 0 2 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 1 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.White;
            var actual = game.MovePossible(0, 7);
            // Assert
            Assert.IsTrue(actual);
        }
        [Test]
        public void ZetMogelijk_ZetAanDeRandRechtsBoven_ReturnFalse()
        {
            // Arrange
            Game game = new Game();
            game.Board[2, 5] = Color.Black;
            game.Board[1, 6] = Color.Black;
            game.Board[5, 2] = Color.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 2 <
            // 1 0 0 0 0 0 0 2 0
            // 2 0 0 0 0 0 2 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 1 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.Black;
            var actual = game.MovePossible(0, 7);
            // Assert
            Assert.IsFalse(actual);
        }
        [Test]
        public void ZetMogelijk_ZetAanDeRandRechtsOnder_ReturnTrue()
        {
            // Arrange
            Game game = new Game();
            game.Board[2, 2] = Color.Black;
            game.Board[5, 5] = Color.White;
            game.Board[6, 6] = Color.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 2 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 1 0 0
            // 6 0 0 0 0 0 0 1 0
            // 7 0 0 0 0 0 0 0 2 <
            // Act
            game.Turn = Color.Black;
            var actual = game.MovePossible(7, 7);
            // Assert
            Assert.IsTrue(actual);
        }
        [Test]
        public void ZetMogelijk_ZetAanDeRandRechtsOnder_ReturnFalse()
        {
            // Arrange
            Game game = new Game();
            game.Board[2, 2] = Color.Black;
            game.Board[5, 5] = Color.White;
            game.Board[6, 6] = Color.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0 <
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 2 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 1 0 0
            // 6 0 0 0 0 0 0 1 0
            // 7 0 0 0 0 0 0 0 1
            // Act
            game.Turn = Color.White;
            var actual = game.MovePossible(7, 7);
            // Assert
            Assert.IsFalse(actual);
        }
        [Test]
        public void ZetMogelijk_ZetAanDeRandLinksBoven_ReturnTrue()
        {
            // Arrange
            Game game = new Game();
            game.Board[1, 1] = Color.White;
            game.Board[2, 2] = Color.White;
            game.Board[5, 5] = Color.Black;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 2 0 0 0 0 0 0 0 <
            // 1 0 1 0 0 0 0 0 0
            // 2 0 0 1 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 2 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.Black;
            var actual = game.MovePossible(0, 0);
            // Assert
            Assert.IsTrue(actual);
        }
        [Test]
        public void ZetMogelijk_ZetAanDeRandLinksBoven_ReturnFalse()
        {
            // Arrange
            Game game = new Game();
            game.Board[1, 1] = Color.White;
            game.Board[2, 2] = Color.White;
            game.Board[5, 5] = Color.Black;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 1 0 0 0 0 0 0 0 <
            // 1 0 1 0 0 0 0 0 0
            // 2 0 0 1 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 2 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.White;
            var actual = game.MovePossible(0, 0);
            // Assert
            Assert.IsFalse(actual);
        }
        [Test]
        public void ZetMogelijk_ZetAanDeRandLinksOnder_ReturnTrue()
        {
            // Arrange
            Game game = new Game();
            game.Board[2, 5] = Color.White;
            game.Board[5, 2] = Color.Black;
            game.Board[6, 1] = Color.Black;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 1 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 2 0 0 0 0 0
            // 6 0 2 0 0 0 0 0 0
            // 7 1 0 0 0 0 0 0 0 <
            // Act
            game.Turn = Color.White;
            var actual = game.MovePossible(7, 0);
            // Assert
            Assert.IsTrue(actual);
        }
        [Test]
        public void ZetMogelijk_ZetAanDeRandLinksOnder_ReturnFalse()
        {
            // Arrange
            Game game = new Game();
            game.Board[2, 5] = Color.White;
            game.Board[5, 2] = Color.Black;
            game.Board[6, 1] = Color.Black;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0 <
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 1 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 2 0 0 0 0 0
            // 6 0 2 0 0 0 0 0 0
            // 7 2 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.Black;
            var actual = game.MovePossible(7, 0);
            // Assert
            Assert.IsFalse(actual);
        }
        //---------------------------------------------------------------------------
        [Test]
        public void DoeZet_BuitenBord_ReturnFalse()
        {
            // Arrange
            Game game = new Game();
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // 1 <
            // Act
            game.Turn = Color.White;
            var actual = game.DoMove(8, 8);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Color.White, game.Board[3, 3]);
            Assert.AreEqual(Color.White, game.Board[4, 4]);
            Assert.AreEqual(Color.Black, game.Board[3, 4]);
            Assert.AreEqual(Color.Black, game.Board[4, 3]);
            Assert.AreEqual(Color.White, game.Turn);
        }
        [Test]
        public void DoeZet_StartSituatieZet23Zwart_ReturnTrue()
        {
            // Arrange
            Game game = new Game();
            // 0 1 2 3 4 5 6 7
            //       v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 2 0 0 0 0 <
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.Black;
            var actual = game.DoMove(2, 3);
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Color.Black, game.Board[2, 3]);
            Assert.AreEqual(Color.Black, game.Board[3, 3]);
            Assert.AreEqual(Color.Black, game.Board[4, 3]);
            Assert.AreEqual(Color.White, game.Turn);
        }

        [Test]
        public void DoeZet_StartSituatieZet23Wit_ReturnFalse()
        {
            // Arrange
            Game game = new Game();
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 1 0 0 0 0 <
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.White;
            var actual = game.DoMove(2, 3);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Color.White, game.Board[3, 3]);
            Assert.AreEqual(Color.White, game.Board[4, 4]);
            Assert.AreEqual(Color.Black, game.Board[3, 4]);
            Assert.AreEqual(Color.Black, game.Board[4, 3]);
            Assert.AreEqual(Color.None, game.Board[2, 3]);
            Assert.AreEqual(Color.White, game.Turn);
        }
        [Test]
        public void DoeZet_ZetAanDeRandBoven_ReturnTrue()
        {
            // Arrange
            Game game = new Game();
            game.Board[1, 3] = Color.White;
            game.Board[2, 3] = Color.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 2 0 0 0 0 <
            // 1 0 0 0 1 0 0 0 0
            // 2 0 0 0 1 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.Black;
            var actual = game.DoMove(0, 3);
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Color.Black, game.Board[0, 3]);
            Assert.AreEqual(Color.Black, game.Board[1, 3]);
            Assert.AreEqual(Color.Black, game.Board[2, 3]);
            Assert.AreEqual(Color.Black, game.Board[3, 3]);
            Assert.AreEqual(Color.Black, game.Board[4, 3]);
            Assert.AreEqual(Color.White, game.Turn);
        }
        [Test]
        public void DoeZet_ZetAanDeRandBoven_ReturnFalse()
        {
            // Arrange
            Game game = new Game();
            game.Board[1, 3] = Color.White;
            game.Board[2, 3] = Color.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 1 0 0 0 0 <
            // 1 0 0 0 1 0 0 0 0
            // 2 0 0 0 1 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.White;
            var actual = game.DoMove(0, 3);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Color.White, game.Board[3, 3]);
            Assert.AreEqual(Color.White, game.Board[4, 4]);
            Assert.AreEqual(Color.Black, game.Board[3, 4]);
            Assert.AreEqual(Color.Black, game.Board[4, 3]);
            Assert.AreEqual(Color.White, game.Board[1, 3]);
            Assert.AreEqual(Color.White, game.Board[2, 3]);
            Assert.AreEqual(Color.None, game.Board[0, 3]);
        }
        [Test]
        public void DoeZet_ZetAanDeRandBovenEnTotBenedenReedsGevuld_ReturnTrue()
        {
            // Arrange
            Game game = new Game();
            game.Board[1, 3] = Color.White;
            game.Board[2, 3] = Color.White;
            game.Board[3, 3] = Color.White;
            game.Board[4, 3] = Color.White;
            game.Board[5, 3] = Color.White;
            game.Board[6, 3] = Color.White;
            game.Board[7, 3] = Color.Black;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 2 0 0 0 0 <
            // 1 0 0 0 1 0 0 0 0
            // 2 0 0 0 1 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 1 1 0 0 0
            // 5 0 0 0 1 0 0 0 0
            // 6 0 0 0 1 0 0 0 0
            // 7 0 0 0 2 0 0 0 0
            // Act
            game.Turn = Color.Black;
            var actual = game.DoMove(0, 3);
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Color.Black, game.Board[0, 3]);
            Assert.AreEqual(Color.Black, game.Board[1, 3]);
            Assert.AreEqual(Color.Black, game.Board[2, 3]);
            Assert.AreEqual(Color.Black, game.Board[3, 3]);
            Assert.AreEqual(Color.Black, game.Board[4, 3]);
            Assert.AreEqual(Color.Black, game.Board[5, 3]);
            Assert.AreEqual(Color.Black, game.Board[6, 3]);
            Assert.AreEqual(Color.Black, game.Board[7, 3]);
        }
        [Test]
        public void DoeZet_ZetAanDeRandBovenEnTotBenedenReedsGevuld_ReturnFalse()
        {
            // Arrange
            Game game = new Game();
            game.Board[1, 3] = Color.White;
            game.Board[2, 3] = Color.White;
            game.Board[3, 3] = Color.White;
            game.Board[4, 3] = Color.White;
            game.Board[5, 3] = Color.White;
            game.Board[6, 3] = Color.White;
            game.Board[7, 3] = Color.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 2 0 0 0 0 <
            // 1 0 0 0 1 0 0 0 0
            // 2 0 0 0 1 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 1 1 0 0 0
            // 5 0 0 0 1 0 0 0 0
            // 6 0 0 0 1 0 0 0 0
            // 7 0 0 0 1 0 0 0 0
            // Act
            game.Turn = Color.Black;
            var actual = game.DoMove(0, 3);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Color.White, game.Board[3, 3]);
            Assert.AreEqual(Color.White, game.Board[4, 4]);
            Assert.AreEqual(Color.Black, game.Board[3, 4]);
            Assert.AreEqual(Color.White, game.Board[4, 3]);
            Assert.AreEqual(Color.White, game.Board[1, 3]);
            Assert.AreEqual(Color.White, game.Board[2, 3]);
            Assert.AreEqual(Color.None, game.Board[0, 3]);
        }
        [Test]
        public void DoeZet_ZetAanDeRandRechts_ReturnTrue()
        {
            // Arrange
            Game game = new Game();
            game.Board[4, 5] = Color.White;
            game.Board[4, 6] = Color.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 1 1 2 <
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.Black;
            var actual = game.DoMove(4, 7);
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Color.Black, game.Board[4, 3]);
            Assert.AreEqual(Color.Black, game.Board[4, 4]);
            Assert.AreEqual(Color.Black, game.Board[4, 5]);
            Assert.AreEqual(Color.Black, game.Board[4, 6]);
            Assert.AreEqual(Color.Black, game.Board[4, 7]);
        }
        [Test]
        public void DoeZet_ZetAanDeRandRechts_ReturnFalse()
        {
            // Arrange
            Game game = new Game();
            game.Board[4, 5] = Color.White;
            game.Board[4, 6] = Color.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 1 0 0 0 0
            // 1 0 0 0 1 0 0 0 0
            // 2 0 0 0 1 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 1 1 1 <
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.White;
            var actual = game.DoMove(4, 7);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Color.White, game.Board[3, 3]);
            Assert.AreEqual(Color.White, game.Board[4, 4]);
            Assert.AreEqual(Color.Black, game.Board[3, 4]);
            Assert.AreEqual(Color.Black, game.Board[4, 3]);
            Assert.AreEqual(Color.White, game.Board[4, 5]);
            Assert.AreEqual(Color.White, game.Board[4, 6]);
            Assert.AreEqual(Color.None, game.Board[4, 7]);
        }
        [Test]
        public void DoeZet_ZetAanDeRandRechtsEnTotLinksReedsGevuld_ReturnTrue()
        {
            // Arrange
            Game game = new Game();
            game.Board[4, 0] = Color.Black;
            game.Board[4, 1] = Color.White;
            game.Board[4, 2] = Color.White;
            game.Board[4, 3] = Color.White;
            game.Board[4, 4] = Color.White;
            game.Board[4, 5] = Color.White;
            game.Board[4, 6] = Color.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 2 1 1 1 1 1 1 2 <
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.Black;
            var actual = game.DoMove(4, 7);
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Color.Black, game.Board[4, 0]);
            Assert.AreEqual(Color.Black, game.Board[4, 1]);
            Assert.AreEqual(Color.Black, game.Board[4, 2]);
            Assert.AreEqual(Color.Black, game.Board[4, 3]);
            Assert.AreEqual(Color.Black, game.Board[4, 4]);
            Assert.AreEqual(Color.Black, game.Board[4, 5]);
            Assert.AreEqual(Color.Black, game.Board[4, 6]);
            Assert.AreEqual(Color.Black, game.Board[4, 7]);
        }
        [Test]
        public void DoeZet_ZetAanDeRandRechtsEnTotLinksReedsGevuld_ReturnFalse()
        {
            // Arrange
            Game game = new Game();
            game.Board[4, 0] = Color.Black;
            game.Board[4, 1] = Color.White;
            game.Board[4, 2] = Color.White;
            game.Board[4, 3] = Color.White;
            game.Board[4, 4] = Color.White;
            game.Board[4, 5] = Color.White;
            game.Board[4, 6] = Color.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 2 1 1 1 1 1 1 1 <
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.White;
            var actual = game.DoMove(4, 7);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Color.White, game.Board[3, 3]);
            Assert.AreEqual(Color.White, game.Board[4, 4]);
            Assert.AreEqual(Color.Black, game.Board[3, 4]);
            Assert.AreEqual(Color.White, game.Board[4, 3]);
            Assert.AreEqual(Color.Black, game.Board[4, 0]);
            Assert.AreEqual(Color.White, game.Board[4, 1]);
            Assert.AreEqual(Color.White, game.Board[4, 2]);
            Assert.AreEqual(Color.White, game.Board[4, 5]);
            Assert.AreEqual(Color.White, game.Board[4, 6]);
            Assert.AreEqual(Color.None, game.Board[4, 7]);
        }
        // 0 1 2 3 4 5 6 7
        //
        // 0 0 0 0 0 0 0 0 0
        // 1 0 0 0 0 0 0 0 0
        // 2 0 0 0 0 0 0 0 0
        // 3 0 0 0 1 2 0 0 0
        // 4 0 0 0 2 1 0 0 0
        // 5 0 0 0 0 0 0 0 0
        // 6 0 0 0 0 0 0 0 0
        // 7 0 0 0 0 0 0 0 0
        [Test]
        public void DoeZet_StartSituatieZet22Wit_ReturnFalse()
        {
            // Arrange
            Game game = new Game();
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 1 0 0 0 0 0 <
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.White;
            var actual = game.DoMove(2, 2);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Color.White, game.Board[3, 3]);
            Assert.AreEqual(Color.White, game.Board[4, 4]);
            Assert.AreEqual(Color.Black, game.Board[3, 4]);
            Assert.AreEqual(Color.Black, game.Board[4, 3]);
            Assert.AreEqual(Color.None, game.Board[2, 2]);
        }
        [Test]
        public void DoeZet_StartSituatieZet22Zwart_ReturnFalse()
        {
            // Arrange
            Game game = new Game();
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 2 0 0 0 0 0 <
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.Black;
            var actual = game.DoMove(2, 2);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Color.White, game.Board[3, 3]);
            Assert.AreEqual(Color.White, game.Board[4, 4]);
            Assert.AreEqual(Color.Black, game.Board[3, 4]);
            Assert.AreEqual(Color.Black, game.Board[4, 3]);
            Assert.AreEqual(Color.None, game.Board[2, 2]);
        }
        [Test]
        public void DoeZet_ZetAanDeRandRechtsBoven_ReturnTrue()
        {
            // Arrange
            Game game = new Game();
            game.Board[2, 5] = Color.Black;
            game.Board[1, 6] = Color.Black;
            game.Board[5, 2] = Color.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 1 <
            // 1 0 0 0 0 0 0 2 0
            // 2 0 0 0 0 0 2 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 1 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.White;
            var actual = game.DoMove(0, 7);
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Color.White, game.Board[5, 2]);
            Assert.AreEqual(Color.White, game.Board[4, 3]);
            Assert.AreEqual(Color.White, game.Board[3, 4]);
            Assert.AreEqual(Color.White, game.Board[2, 5]);
            Assert.AreEqual(Color.White, game.Board[1, 6]);
            Assert.AreEqual(Color.White, game.Board[0, 7]);
        }
        [Test]
        public void DoeZet_ZetAanDeRandRechtsBoven_ReturnFalse()
        {
            // Arrange
            Game game = new Game();
            game.Board[2, 5] = Color.Black;
            game.Board[1, 6] = Color.Black;
            game.Board[5, 2] = Color.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 2 <
            // 1 0 0 0 0 0 0 2 0
            // 2 0 0 0 0 0 2 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 1 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.Black;
            var actual = game.DoMove(0, 7);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Color.White, game.Board[3, 3]);
            Assert.AreEqual(Color.White, game.Board[4, 4]);
            Assert.AreEqual(Color.Black, game.Board[3, 4]);
            Assert.AreEqual(Color.Black, game.Board[4, 3]);
            Assert.AreEqual(Color.Black, game.Board[1, 6]);
            Assert.AreEqual(Color.Black, game.Board[2, 5]);
            Assert.AreEqual(Color.White, game.Board[5, 2]);
            Assert.AreEqual(Color.None, game.Board[0, 7]);
        }
        [Test]
        public void DoeZet_ZetAanDeRandRechtsOnder_ReturnTrue()
        {
            // Arrange
            Game game = new Game();
            game.Board[2, 2] = Color.Black;
            game.Board[5, 5] = Color.White;
            game.Board[6, 6] = Color.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 2 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 1 0 0
            // 6 0 0 0 0 0 0 1 0
            // 7 0 0 0 0 0 0 0 2 <
            // Act
            game.Turn = Color.Black;
            var actual = game.DoMove(7, 7);
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Color.Black, game.Board[2, 2]);
            Assert.AreEqual(Color.Black, game.Board[3, 3]);
            Assert.AreEqual(Color.Black, game.Board[4, 4]);
            Assert.AreEqual(Color.Black, game.Board[5, 5]);
            Assert.AreEqual(Color.Black, game.Board[6, 6]);
            Assert.AreEqual(Color.Black, game.Board[7, 7]);
        }

        [Test]
        public void DoeZet_ZetAanDeRandRechtsOnder_ReturnFalse()
        {
            // Arrange
            Game game = new Game();
            game.Board[2, 2] = Color.Black;
            game.Board[5, 5] = Color.White;
            game.Board[6, 6] = Color.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 2 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 1 0 0
            // 6 0 0 0 0 0 0 1 0
            // 7 0 0 0 0 0 0 0 1 <
            // Act
            game.Turn = Color.White;
            var actual = game.DoMove(7, 7);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Color.White, game.Board[3, 3]);
            Assert.AreEqual(Color.White, game.Board[4, 4]);
            Assert.AreEqual(Color.Black, game.Board[3, 4]);
            Assert.AreEqual(Color.Black, game.Board[4, 3]);
            Assert.AreEqual(Color.Black, game.Board[2, 2]);
            Assert.AreEqual(Color.White, game.Board[5, 5]);
            Assert.AreEqual(Color.White, game.Board[6, 6]);
            Assert.AreEqual(Color.None, game.Board[7, 7]);
        }
        [Test]
        public void DoeZet_ZetAanDeRandLinksBoven_ReturnTrue()
        {
            // Arrange
            Game game = new Game();
            game.Board[1, 1] = Color.White;
            game.Board[2, 2] = Color.White;
            game.Board[5, 5] = Color.Black;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 2 0 0 0 0 0 0 0 <
            // 1 0 1 0 0 0 0 0 0
            // 2 0 0 1 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 2 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.Black;
            var actual = game.DoMove(0, 0);
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Color.Black, game.Board[0, 0]);
            Assert.AreEqual(Color.Black, game.Board[1, 1]);
            Assert.AreEqual(Color.Black, game.Board[2, 2]);
            Assert.AreEqual(Color.Black, game.Board[3, 3]);
            Assert.AreEqual(Color.Black, game.Board[4, 4]);
            Assert.AreEqual(Color.Black, game.Board[5, 5]);
        }
        [Test]
        public void DoeZet_ZetAanDeRandLinksBoven_ReturnFalse()
        {
            // Arrange
            Game game = new Game();
            game.Board[1, 1] = Color.White;
            game.Board[2, 2] = Color.White;
            game.Board[5, 5] = Color.Black;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 1 0 0 0 0 0 0 0 <
            // 1 0 1 0 0 0 0 0 0
            // 2 0 0 1 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 2 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            // Act
            game.Turn = Color.White;
            var actual = game.DoMove(0, 0);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Color.White, game.Board[3, 3]);
            Assert.AreEqual(Color.White, game.Board[4, 4]);
            Assert.AreEqual(Color.Black, game.Board[3, 4]);
            Assert.AreEqual(Color.Black, game.Board[4, 3]);
            Assert.AreEqual(Color.White, game.Board[1, 1]);
            Assert.AreEqual(Color.White, game.Board[2, 2]);
            Assert.AreEqual(Color.Black, game.Board[5, 5]);
            Assert.AreEqual(Color.None, game.Board[0, 0]);
        }
        [Test]
        public void DoeZet_ZetAanDeRandLinksOnder_ReturnTrue()
        {
            // Arrange
            Game game = new Game();
            game.Board[2, 5] = Color.White;
            game.Board[5, 2] = Color.Black;
            game.Board[6, 1] = Color.Black;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 1 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 2 0 0 0 0 0
            // 6 0 2 0 0 0 0 0 0
            // 7 1 0 0 0 0 0 0 0 <
            // Act
            game.Turn = Color.White;
            var actual = game.DoMove(7, 0);
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Color.White, game.Board[7, 0]);
            Assert.AreEqual(Color.White, game.Board[6, 1]);
            Assert.AreEqual(Color.White, game.Board[5, 2]);
            Assert.AreEqual(Color.White, game.Board[4, 3]);
            Assert.AreEqual(Color.White, game.Board[3, 4]);
            Assert.AreEqual(Color.White, game.Board[2, 5]);
        }
        [Test]
        public void DoeZet_ZetAanDeRandLinksOnder_ReturnFalse()
        {
            // Arrange
            Game game = new Game();
            game.Board[2, 5] = Color.White;
            game.Board[5, 2] = Color.Black;
            game.Board[6, 1] = Color.Black;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 1 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 2 0 0 0 0 0
            // 6 0 2 0 0 0 0 0 0
            // 7 2 0 0 0 0 0 0 0 <
            // Act
            game.Turn = Color.Black;
            var actual = game.DoMove(7, 0);
            // Assert
            Assert.IsFalse(actual);
            Assert.AreEqual(Color.White, game.Board[3, 3]);
            Assert.AreEqual(Color.White, game.Board[4, 4]);
            Assert.AreEqual(Color.Black, game.Board[3, 4]);
            Assert.AreEqual(Color.Black, game.Board[4, 3]);
            Assert.AreEqual(Color.White, game.Board[2, 5]);
            Assert.AreEqual(Color.Black, game.Board[5, 2]);
            Assert.AreEqual(Color.Black, game.Board[6, 1]);
            Assert.AreEqual(Color.None, game.Board[7, 7]);
            Assert.AreEqual(Color.None, game.Board[7, 0]);
        }
        [Test]
        public void Pas_ZwartAanZetGeenZetMogelijk_ReturnTrueEnWisselBeurt()
        {
            // Arrange (zowel wit als zwart kunnen niet meer)
            Game game = new Game();
            game.Board[0, 0] = Color.White;
            game.Board[0, 1] = Color.White;
            game.Board[0, 2] = Color.White;
            game.Board[0, 3] = Color.White;
            game.Board[0, 4] = Color.White;
            game.Board[0, 5] = Color.White;
            game.Board[0, 6] = Color.White;
            game.Board[0, 7] = Color.White;
            game.Board[1, 0] = Color.White;
            game.Board[1, 1] = Color.White;
            game.Board[1, 2] = Color.White;
            game.Board[1, 3] = Color.White;
            game.Board[1, 4] = Color.White;
            game.Board[1, 5] = Color.White;
            game.Board[1, 6] = Color.White;
            game.Board[1, 7] = Color.White;
            game.Board[2, 0] = Color.White;
            game.Board[2, 1] = Color.White;
            game.Board[2, 2] = Color.White;
            game.Board[2, 3] = Color.White;
            game.Board[2, 4] = Color.White;
            game.Board[2, 5] = Color.White;
            game.Board[2, 6] = Color.White;
            game.Board[2, 7] = Color.White;
            game.Board[3, 0] = Color.White;
            game.Board[3, 1] = Color.White;
            game.Board[3, 2] = Color.White;
            game.Board[3, 3] = Color.White;
            game.Board[3, 4] = Color.White;
            game.Board[3, 5] = Color.White;
            game.Board[3, 6] = Color.White;
            game.Board[3, 7] = Color.None;
            game.Board[4, 0] = Color.White;
            game.Board[4, 1] = Color.White;
            game.Board[4, 2] = Color.White;
            game.Board[4, 3] = Color.White;
            game.Board[4, 4] = Color.White;
            game.Board[4, 5] = Color.White;
            game.Board[4, 6] = Color.None;
            game.Board[4, 7] = Color.None;
            game.Board[5, 0] = Color.White;
            game.Board[5, 1] = Color.White;
            game.Board[5, 2] = Color.White;
            game.Board[5, 3] = Color.White;
            game.Board[5, 4] = Color.White;
            game.Board[5, 5] = Color.White;
            game.Board[5, 6] = Color.None;
            game.Board[5, 7] = Color.Black;
            game.Board[6, 0] = Color.White;
            game.Board[6, 1] = Color.White;
            game.Board[6, 2] = Color.White;
            game.Board[6, 3] = Color.White;
            game.Board[6, 4] = Color.White;
            game.Board[6, 5] = Color.White;
            game.Board[6, 6] = Color.White;
            game.Board[6, 7] = Color.None;
            game.Board[7, 0] = Color.White;
            game.Board[7, 1] = Color.White;
            game.Board[7, 2] = Color.White;
            game.Board[7, 3] = Color.White;
            game.Board[7, 4] = Color.White;
            game.Board[7, 5] = Color.White;
            game.Board[7, 6] = Color.White;
            game.Board[7, 7] = Color.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 1 1 1 1 1 1 1 1
            // 1 1 1 1 1 1 1 1 1
            // 2 1 1 1 1 1 1 1 1
            // 3 1 1 1 1 1 1 1 0
            // 4 1 1 1 1 1 1 0 0
            // 5 1 1 1 1 1 1 0 2
            // 6 1 1 1 1 1 1 1 0
            // 7 1 1 1 1 1 1 1 1
            // Act
            game.Turn = Color.Black;
            var actual = game.Pass();
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Color.White, game.Turn);
        }
        [Test]
        public void Pas_WitAanZetGeenZetMogelijk_ReturnTrueEnWisselBeurt()
        {
            // Arrange (zowel wit als zwart kunnen niet meer)
            Game game = new Game();
            game.Board[0, 0] = Color.White;
            game.Board[0, 1] = Color.White;
            game.Board[0, 2] = Color.White;
            game.Board[0, 3] = Color.White;
            game.Board[0, 4] = Color.White;
            game.Board[0, 5] = Color.White;
            game.Board[0, 6] = Color.White;
            game.Board[0, 7] = Color.White;
            game.Board[1, 0] = Color.White;
            game.Board[1, 1] = Color.White;
            game.Board[1, 2] = Color.White;
            game.Board[1, 3] = Color.White;
            game.Board[1, 4] = Color.White;
            game.Board[1, 5] = Color.White;
            game.Board[1, 6] = Color.White;
            game.Board[1, 7] = Color.White;
            game.Board[2, 0] = Color.White;
            game.Board[2, 1] = Color.White;
            game.Board[2, 2] = Color.White;
            game.Board[2, 3] = Color.White;
            game.Board[2, 4] = Color.White;
            game.Board[2, 5] = Color.White;
            game.Board[2, 6] = Color.White;
            game.Board[2, 7] = Color.White;
            game.Board[3, 0] = Color.White;
            game.Board[3, 1] = Color.White;
            game.Board[3, 2] = Color.White;
            game.Board[3, 3] = Color.White;
            game.Board[3, 4] = Color.White;
            game.Board[3, 5] = Color.White;
            game.Board[3, 6] = Color.White;
            game.Board[3, 7] = Color.None;
            game.Board[4, 0] = Color.White;
            game.Board[4, 1] = Color.White;
            game.Board[4, 2] = Color.White;
            game.Board[4, 3] = Color.White;
            game.Board[4, 4] = Color.White;
            game.Board[4, 5] = Color.White;
            game.Board[4, 6] = Color.None;
            game.Board[4, 7] = Color.None;
            game.Board[5, 0] = Color.White;
            game.Board[5, 1] = Color.White;
            game.Board[5, 2] = Color.White;
            game.Board[5, 3] = Color.White;
            game.Board[5, 4] = Color.White;
            game.Board[5, 5] = Color.White;
            game.Board[5, 6] = Color.None;
            game.Board[5, 7] = Color.Black;
            game.Board[6, 0] = Color.White;
            game.Board[6, 1] = Color.White;
            game.Board[6, 2] = Color.White;
            game.Board[6, 3] = Color.White;
            game.Board[6, 4] = Color.White;
            game.Board[6, 5] = Color.White;
            game.Board[6, 6] = Color.White;
            game.Board[6, 7] = Color.None;
            game.Board[7, 0] = Color.White;
            game.Board[7, 1] = Color.White;
            game.Board[7, 2] = Color.White;
            game.Board[7, 3] = Color.White;
            game.Board[7, 4] = Color.White;
            game.Board[7, 5] = Color.White;
            game.Board[7, 6] = Color.White;
            game.Board[7, 7] = Color.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 1 1 1 1 1 1 1 1
            // 1 1 1 1 1 1 1 1 1
            // 2 1 1 1 1 1 1 1 1
            // 3 1 1 1 1 1 1 1 0
            // 4 1 1 1 1 1 1 0 0
            // 5 1 1 1 1 1 1 0 2
            // 6 1 1 1 1 1 1 1 0
            // 7 1 1 1 1 1 1 1 1
            // Act
            game.Turn = Color.White;
            var actual = game.Pass();
            // Assert
            Assert.IsTrue(actual);
            Assert.AreEqual(Color.Black, game.Turn);
        }
        [Test]
        public void Afgelopen_GeenZetMogelijk_ReturnTrue()
        {
            // Arrange (zowel wit als zwart kunnen niet meer)
            Game game = new Game();
            game.Board[0, 0] = Color.White;
            game.Board[0, 1] = Color.White;
            game.Board[0, 2] = Color.White;
            game.Board[0, 3] = Color.White;
            game.Board[0, 4] = Color.White;
            game.Board[0, 5] = Color.White;
            game.Board[0, 6] = Color.White;
            game.Board[0, 7] = Color.White;
            game.Board[1, 0] = Color.White;
            game.Board[1, 1] = Color.White;
            game.Board[1, 2] = Color.White;
            game.Board[1, 3] = Color.White;
            game.Board[1, 4] = Color.White;
            game.Board[1, 5] = Color.White;
            game.Board[1, 6] = Color.White;
            game.Board[1, 7] = Color.White;
            game.Board[2, 0] = Color.White;
            game.Board[2, 1] = Color.White;
            game.Board[2, 2] = Color.White;
            game.Board[2, 3] = Color.White;
            game.Board[2, 4] = Color.White;
            game.Board[2, 5] = Color.White;
            game.Board[2, 6] = Color.White;
            game.Board[2, 7] = Color.White;
            game.Board[3, 0] = Color.White;
            game.Board[3, 1] = Color.White;
            game.Board[3, 2] = Color.White;
            game.Board[3, 3] = Color.White;
            game.Board[3, 4] = Color.White;
            game.Board[3, 5] = Color.White;
            game.Board[3, 6] = Color.White;
            game.Board[3, 7] = Color.None;
            game.Board[4, 0] = Color.White;
            game.Board[4, 1] = Color.White;
            game.Board[4, 2] = Color.White;
            game.Board[4, 3] = Color.White;
            game.Board[4, 4] = Color.White;
            game.Board[4, 5] = Color.White;
            game.Board[4, 6] = Color.None;
            game.Board[4, 7] = Color.None;
            game.Board[5, 0] = Color.White;
            game.Board[5, 1] = Color.White;
            game.Board[5, 2] = Color.White;
            game.Board[5, 3] = Color.White;
            game.Board[5, 4] = Color.White;
            game.Board[5, 5] = Color.White;
            game.Board[5, 6] = Color.None;
            game.Board[5, 7] = Color.Black;
            game.Board[6, 0] = Color.White;
            game.Board[6, 1] = Color.White;
            game.Board[6, 2] = Color.White;
            game.Board[6, 3] = Color.White;
            game.Board[6, 4] = Color.White;
            game.Board[6, 5] = Color.White;
            game.Board[6, 6] = Color.White;
            game.Board[6, 7] = Color.None;
            game.Board[7, 0] = Color.White;
            game.Board[7, 1] = Color.White;
            game.Board[7, 2] = Color.White;
            game.Board[7, 3] = Color.White;
            game.Board[7, 4] = Color.White;
            game.Board[7, 5] = Color.White;
            game.Board[7, 6] = Color.White;
            game.Board[7, 7] = Color.White;
            // 0 1 2 3 4 5 6 7
            // v
            // 0 1 1 1 1 1 1 1 1
            // 1 1 1 1 1 1 1 1 1
            // 2 1 1 1 1 1 1 1 1
            // 3 1 1 1 1 1 1 1 0
            // 4 1 1 1 1 1 1 0 0
            // 5 1 1 1 1 1 1 0 2
            // 6 1 1 1 1 1 1 1 0
            // 7 1 1 1 1 1 1 1 1
            // Act
            game.Turn = Color.White;
            var actual = game.Ended();
            // Assert
            Assert.IsTrue(actual);
        }
        [Test]
        public void Afgelopen_GeenZetMogelijkAllesBezet_ReturnTrue()
        {
            // Arrange (zowel wit als zwart kunnen niet meer)
            Game game = new Game();
            game.Board[0, 0] = Color.White;
            game.Board[0, 1] = Color.White;
            game.Board[0, 2] = Color.White;
            game.Board[0, 3] = Color.White;
            game.Board[0, 4] = Color.White;
            game.Board[0, 5] = Color.White;
            game.Board[0, 6] = Color.White;
            game.Board[0, 7] = Color.White;
            game.Board[1, 0] = Color.White;
            game.Board[1, 1] = Color.White;
            game.Board[1, 2] = Color.White;
            game.Board[1, 3] = Color.White;
            game.Board[1, 4] = Color.White;
            game.Board[1, 5] = Color.White;
            game.Board[1, 6] = Color.White;
            game.Board[1, 7] = Color.White;
            game.Board[2, 0] = Color.White;
            game.Board[2, 1] = Color.White;
            game.Board[2, 2] = Color.White;
            game.Board[2, 3] = Color.White;
            game.Board[2, 4] = Color.White;
            game.Board[2, 5] = Color.White;
            game.Board[2, 6] = Color.White;
            game.Board[2, 7] = Color.White;
            game.Board[3, 0] = Color.White;
            game.Board[3, 1] = Color.White;
            game.Board[3, 2] = Color.White;
            game.Board[3, 3] = Color.White;
            game.Board[3, 4] = Color.White;
            game.Board[3, 5] = Color.White;
            game.Board[3, 6] = Color.White;
            game.Board[3, 7] = Color.White;
            game.Board[4, 0] = Color.White;
            game.Board[4, 1] = Color.White;
            game.Board[4, 2] = Color.White;
            game.Board[4, 3] = Color.White;
            game.Board[4, 4] = Color.White;
            game.Board[4, 5] = Color.White;
            game.Board[4, 6] = Color.Black;
            game.Board[4, 7] = Color.Black;
            game.Board[5, 0] = Color.White;
            game.Board[5, 1] = Color.White;
            game.Board[5, 2] = Color.White;
            game.Board[5, 3] = Color.White;
            game.Board[5, 4] = Color.White;
            game.Board[5, 5] = Color.White;
            game.Board[5, 6] = Color.Black;
            game.Board[5, 7] = Color.Black;
            game.Board[6, 0] = Color.White;
            game.Board[6, 1] = Color.White;
            game.Board[6, 2] = Color.White;
            game.Board[6, 3] = Color.White;
            game.Board[6, 4] = Color.White;
            game.Board[6, 5] = Color.White;
            game.Board[6, 6] = Color.White;
            game.Board[6, 7] = Color.Black;
            game.Board[7, 0] = Color.White;
            game.Board[7, 1] = Color.White;
            game.Board[7, 2] = Color.White;
            game.Board[7, 3] = Color.White;
            game.Board[7, 4] = Color.White;
            game.Board[7, 5] = Color.White;
            game.Board[7, 6] = Color.White;
            game.Board[7, 7] = Color.White;
            // 0 1 2 3 4 5 6 7
            //
            // 0 1 1 1 1 1 1 1 1
            // 1 1 1 1 1 1 1 1 1
            // 2 1 1 1 1 1 1 1 1
            // 3 1 1 1 1 1 1 1 2
            // 4 1 1 1 1 1 1 2 2
            // 5 1 1 1 1 1 1 2 2
            // 6 1 1 1 1 1 1 1 2
            // 7 1 1 1 1 1 1 1 1
            // Act
            game.Turn = Color.White;
            var actual = game.Ended();
            // Assert
            Assert.IsTrue(actual);
        }
        [Test]
        public void Afgelopen_WelZetMogelijk_ReturnFalse()
        {
            // Arrange
            Game game = new Game();
            // 0 1 2 3 4 5 6 7
            //
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            //
            // Act
            game.Turn = Color.White;
            var actual = game.Ended();
            // Assert
            Assert.IsFalse(actual);
        }
        [Test]
        public void OverwegendeKleur_Gelijk_ReturnKleurGeen()
        {
            // Arrange
            Game game = new Game();
            // 0 1 2 3 4 5 6 7
            //
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 0 0 0 0 0
            // 3 0 0 0 1 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            //
            // Act
            var actual = game.DominantColor();
            // Assert
            Assert.AreEqual(Color.None, actual);
        }
        [Test]
        public void OverwegendeKleur_Zwart_ReturnKleurZwart()
        {
            // Arrange
            Game game = new Game();
            game.Board[2, 3] = Color.Black;
            game.Board[3, 3] = Color.Black;
            game.Board[4, 3] = Color.Black;
            game.Board[3, 4] = Color.Black;
            game.Board[4, 4] = Color.White;
            // 0 1 2 3 4 5 6 7
            //
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 2 0 0 0 0
            // 3 0 0 0 2 2 0 0 0
            // 4 0 0 0 2 1 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            //
            // Act
            var actual = game.DominantColor();
            // Assert
            Assert.AreEqual(Color.Black, actual);
        }
        [Test]
        public void OverwegendeKleur_Wit_ReturnKleurWit()
        {
            // Arrange
            Game game = new Game();
            game.Board[2, 3] = Color.White;
            game.Board[3, 3] = Color.White;
            game.Board[4, 3] = Color.White;
            game.Board[3, 4] = Color.White;
            game.Board[4, 4] = Color.Black;
            // 0 1 2 3 4 5 6 7
            //
            // 0 0 0 0 0 0 0 0 0
            // 1 0 0 0 0 0 0 0 0
            // 2 0 0 0 1 0 0 0 0
            // 3 0 0 0 1 1 0 0 0
            // 4 0 0 0 1 2 0 0 0
            // 5 0 0 0 0 0 0 0 0
            // 6 0 0 0 0 0 0 0 0
            // 7 0 0 0 0 0 0 0 0
            //
            // Act
            var actual = game.DominantColor();
            // Assert
            Assert.AreEqual(Color.White, actual);
        }
    }
}
    