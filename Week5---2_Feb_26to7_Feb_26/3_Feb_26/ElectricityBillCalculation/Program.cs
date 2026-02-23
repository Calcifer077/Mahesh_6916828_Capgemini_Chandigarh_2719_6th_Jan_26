namespace ElectricityBillCalculation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input1 = "AAAAA12345";
            string input2 = "AAAAA23456";
            int rate = 4;

            int output = 0;

            // extract first input 5 characters
            string firstInput = input1.Substring(5);
            // extract second input 5 characters
            string secondInput = input2.Substring(5);

            // convert to int
            int firstInt = Convert.ToInt32(firstInput);
            int secondInt = Convert.ToInt32(secondInput);

            // calculate difference
            int difference = secondInt - firstInt;

            // calculate output
            output = difference * rate;

            Console.WriteLine(output);
        }
    }
}