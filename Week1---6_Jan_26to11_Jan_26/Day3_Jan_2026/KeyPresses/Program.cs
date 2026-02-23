namespace KeyPresses
{
    internal class Program
    {
        public int count = 0;
        public void Question()
        {
            count++;

            String x = Console.ReadLine();
            if (x[x.Length - 1] >= '0' && x[x.Length - 1] <= '9')
            {
                Question();
            }
            else
            {
                Console.WriteLine("Not allowed");
            }
        }

        static void Main(string[] args)
        {
            Program obj = new Program();
            Console.WriteLine("Enter any key from 0 - 9: ");
            obj.Question(); 
            Console.WriteLine(obj.count - 1);
        }
    }
}
