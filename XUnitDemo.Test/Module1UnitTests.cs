namespace XUnitDemo.Test
{
    public class Module1UnitTests
    {
        // fact attribute makes the method open for unit testing
        [Fact]
        public void Task_Add_TwoNumber()
        {
            // Arrange
            var num1 = 2.9;
            var num2 = 3.1;
            var expectedValue = 6;
            // Act
            var sum = Module1.Add(num1, num2);
            // Assert
            Assert.Equal(expectedValue, sum, 1);
        }
        [Fact]
        public void Task_Subtract_TwoNumber()
        {
            // Arrange
            var num1 = 2.9;
            var num2 = 3.1;
            var expectedValue = -0.2;
            // Act
            var sub = Module1.Subtract(num1, num2);
            // Assert
            Assert.Equal(expectedValue, sub, 1);
        }
        [Fact]
        public void Task_Multiply_TwoNumber()
        {
            // Arrange
            var num1 = 2.9;
            var num2 = 3.1;
            var expectedValue = 8.99;
            // Act
            var mult = Module1.Multiply(num1, num2);
            // Assert
            Assert.Equal(expectedValue, mult, 2);
        }



        [Fact]
        public void Task_Divide_TwoNumber()
        {
            // Arrange
            var num1 = 2.9;
            var num2 = 3.1;
            var expectedValue = 0.94; // Rounded value
                                      // Act
            var div = Module1.Divide(num1, num2);
            // Assert
            Assert.Equal(expectedValue, div, 2);
        }


        // Test for addition using Theory and InlineData
        [Theory]
        [InlineData(2.9, 3.1, 6.0)]
        [InlineData(-1.5, 1.5, 0.0)]
        [InlineData(0, 0, 0)]
        public void Task_Add_TwoNumbers(double num1, double num2, double expectedValue)
        {
            // Act
            var sum = Module1.Add(num1, num2);
            // Assert
            Assert.Equal(expectedValue, sum, 1);
        }

        // Test for subtraction using Theory and InlineData
        [Theory]
        [InlineData(2.9, 3.1, -0.2)]
        [InlineData(5.0, 3.0, 2.0)]
        [InlineData(-1.0, -1.0, 0.0)]
        public void Task_Subtract_TwoNumbers(double num1, double num2, double expectedValue)
        {
            // Act
            var sub = Module1.Subtract(num1, num2);
            // Assert
            Assert.Equal(expectedValue, sub, 1);
        }

        // Test for multiplication using Theory and InlineData
        [Theory]
        [InlineData(2.9, 3.1, 8.99)]
        [InlineData(0, 5.0, 0)]
        [InlineData(-2, 3, -6)]
        public void Task_Multiply_TwoNumbers(double num1, double num2, double expectedValue)
        {
            // Act
            var mult = Module1.Multiply(num1, num2);
            // Assert
            Assert.Equal(expectedValue, mult, 2);
        }

        // Test for division using Theory and InlineData
        [Theory]
        [InlineData(2.9, 3.1, 0.94)]
        [InlineData(5.0, 2.0, 2.5)]
        [InlineData(0, 1, 0)]
        public void Task_Divide_TwoNumbers(double num1, double num2, double expectedValue)
        {
            // Act
            var div = Module1.Divide(num1, num2);
            // Assert
            Assert.Equal(expectedValue, div, 2);
        }
    }
}