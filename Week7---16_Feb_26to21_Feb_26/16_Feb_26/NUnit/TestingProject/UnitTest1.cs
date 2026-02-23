namespace CalculatorApp.Tests
{
    [TestFixture]
    public class Tests
    {
        private Calculator calc;

        [SetUp]
        public void Setup()
        {
            calc = new Calculator();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void Add_TwoNumbers_ReturnsSum()
        {
            // Arrange
            int a = 4, b = 3;
            
            // Act
            int result = calc.Add(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void Subtract_TwoNumbers_ReturnsDifference()
        {
            // Arrange
            int a = 4, b = 3;

            // Act
            int result = calc.Sub(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Multiply_TwoNumbers_ReturnsProduct()
        {
            // Arrange
            int a = 4, b = 3;

            // Act
            int result = calc.Mult(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(12));
        }

        [Test]
        public void Divide_TwoNumbers_ReturnsDivision()
        {
            // Arrange
            int a = 4, b = 4;

            // Act
            int result = calc.Div(a, b);

            // Assert
            Assert.That(result, Is.EqualTo(1));
        }
    }
}
