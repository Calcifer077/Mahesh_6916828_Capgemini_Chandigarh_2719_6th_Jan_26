namespace AnagramCheck
{
    internal class Program
    {
        public static bool isAna(string s1, string s2)
        {
            int[] arr1 = new int[26];
            int[] arr2 = new int[26];

            foreach(var item in s1)
            {
                arr1[item - 'a']++;
            }

            foreach(var item in s2)
            {
                arr2[item - 'a']++; 
            }

            for(int i = 0; i < 26; i++)
            {
                if(arr1[i] != arr2[i]) return false;
            }

            return true;
        }

        public static void check(string[] arr)
        {
            for(int i = 0; i < arr.Length; i++)
            {
                for(int  j = i + 1; j < arr.Length; j++)
                {
                    if(!isAna(arr[i], arr[j]))
                    {
                        Console.WriteLine("false");
                        return;
                    }
                }
            }

            Console.WriteLine("true");
        }

        static void Main(string[] args)
        {
            string[] arr = {"dusty", "study", "dust", "stydy"};

            check(arr);
        }
    }
}
