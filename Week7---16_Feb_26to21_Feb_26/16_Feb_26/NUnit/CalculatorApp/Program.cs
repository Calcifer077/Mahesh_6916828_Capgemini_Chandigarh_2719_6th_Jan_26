namespace CalculatorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 12;
            int b = 4;

            Calculator obj= new Calculator();
            Console.WriteLine("Addition : " + obj.Add(a, b));
            Console.WriteLine("Subtraction : " + obj.Sub(a, b));
            Console.WriteLine("Multiplication : " + obj.Mult(a, b));
            Console.WriteLine("Division : " + obj.Div(a, b));
        }
    }
}
