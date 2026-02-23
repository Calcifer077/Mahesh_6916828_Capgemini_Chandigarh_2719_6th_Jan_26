internal class Program{
    static void Main(string[] args){
        int[] arr = {1, 2,3,3,4,1,4,5,1,2};

        Dictionary<int, int> dict = new Dictionary<int, int>();

        foreach(var item in arr){
            if(dict.ContainsKey(item)){
                dict[item]++;
            }else{
                dict[item] = 1;
            }
        }

        foreach(var item in dict){
            if(item.Value > 1){
                Console.WriteLine($"{item.Key} Occurs {item.Value} times");
            }
        }
    }
}