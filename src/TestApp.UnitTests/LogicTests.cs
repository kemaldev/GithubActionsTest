namespace TestApp.UnitTests
{
    public class LogicTests
    {
        public class Add
        {
            [TestClass]
            public class Returns_10
            {
                [TestMethod]
                public void When_adding_5_and_5()
                {
                    // Arrange
                    int x = 5;
                    int y = 5;

                    Logic logic = new Logic();

                    // Act
                    int result = logic.Add(x, y);

                    // Assert
                    Assert.AreEqual(10, result);
                }

                [TestMethod]
                public void When_adding_8_and_2()
                {
                    // Arrange
                    int x = 8;
                    int y = 2;

                    Logic logic = new Logic();

                    // Act
                    int result = logic.Add(x, y);

                    // Assert
                    Assert.AreEqual(10, result);
                }

                [TestMethod]
                public void When_adding_minus_2_and_12()
                {
                    // Arrange
                    int x = -2;
                    int y = 12;

                    Logic logic = new Logic();

                    // Act
                    int result = logic.Add(x, y);

                    // Assert
                    Assert.AreEqual(10, result);
                }

                [TestMethod]
                public void When_adding_12_and_minus_2()
                {
                    // Arrange
                    int x = 12;
                    int y = -2;

                    Logic logic = new Logic();

                    // Act
                    int result = logic.Add(x, y);

                    // Assert
                    Assert.AreEqual(10, result);
                }
            }
        }

        public class Subtract
        {
            [TestClass]
            public class Returns_10
            {
                [TestMethod]
                public void When_subtracting_15_with_5()
                {
                    // Arrange
                    int x = 15;
                    int y = 5;

                    Logic logic = new Logic();

                    // Act
                    int result = logic.Subtract(x, y);

                    // Assert
                    Assert.AreEqual(10, result);
                }

                [TestMethod]
                public void When_subtracting_12_with_2()
                {
                    // Arrange
                    int x = 12;
                    int y = 2;

                    Logic logic = new Logic();

                    // Act
                    int result = logic.Subtract(x, y);

                    // Assert
                    Assert.AreEqual(10, result);
                }

                [TestMethod]
                public void When_subtracting_8_with_minus_2()
                {
                    // Arrange
                    int x = 8;
                    int y = -2;

                    Logic logic = new Logic();

                    // Act
                    int result = logic.Subtract(x, y);

                    // Assert
                    Assert.AreEqual(10, result);
                }

                [TestMethod]
                public void When_subtracting_minus_2_with_minus_12()
                {
                    // Arrange
                    int x = -2;
                    int y = -12;

                    Logic logic = new Logic();

                    // Act
                    int result = logic.Subtract(x, y);

                    // Assert
                    Assert.AreEqual(10, result);
                }
            }
        }
    }
}