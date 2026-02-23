internal class Program{
    static void Main(string[] args){
        int input = 54;

        for(int i = 1; i <= input; i++){
            if(input % i == 0){
                Console.WriteLine(i);
            }
        }
    }
}