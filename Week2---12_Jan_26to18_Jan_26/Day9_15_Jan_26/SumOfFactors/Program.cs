namespace SumOfFactors {
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = 15;
            int output = 0;
            
            if(input < 0)
            {
                output = -1;
            }else if(input > 32627)
            {
                output = -2;
            }
            else
            { 
                for(int i = 1; i <= input; i++)
                {
                    if(input % i == 0)
                    {
                        output += i;
                    }
                }
            }

            Console.WriteLine("Input is: " + input);
            Console.WriteLine("Output is: " + output);
        }
    }    
}