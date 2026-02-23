internal class Program{
    static void Main(string[] args){
        int a = 10, b = 20, c = 30;

        Console.WriteLine(Math.Pow(a, 3) + (Math.Pow(a, 2) * b) + 2 * (Math.Pow(a ,2) * b) + 2* a * Math.Pow(b, 2) + Math.Pow(b, 3) + Math.Pow(b, 2) * a); // a^2
    }
}