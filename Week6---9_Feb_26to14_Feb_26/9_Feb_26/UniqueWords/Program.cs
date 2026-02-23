namespace Couple
{
    class Program
    {
        public static bool anagram(string s1, string s2)
        {
            int[] a1 = new int[26];
            int[] a2 = new int[26];
            for(int i = 0; i < s1.Length; i++)
            {
                a1[s1[i] - 'a']++;
            }
            for (int i = 0; i < s2.Length; i++)
            {
                a2[s2[i] - 'a']++;
            }
            for (int i = 0; i < 26; i++)
            {
                if (a1[i] != a2[i])
                {
                    return false;
                }
            }
            return true;
        }

        public static void solve(string[] input, List<string> output)
        {
            for(int i = 0; i < input.Length; i++)
            {
                bool flag = true;
                for(int j = 0; j < input.Length; j++)
                {
                    if(i == j) continue;

                    if(input[i] == input[j])
                    {
                        flag = false;
                        break;
                    }
                    else
                    {
                        if(anagram(input[i], input[j]))
                        {
                            flag = false;
                            break;
                        }
                    }
                }

                if (flag)
                {
                    output.Add(input[i]);
                }
            }
        }

        static void Main(string[] args)
        {
            string[] input = {"listen", "silent", "hello", "world", "abc", "cba"};
            List<string> output = new List<string>();

            solve(input, output);

            for(int i = 0;i < output.Count; i++)
            {
                Console.WriteLine(output[i]);
            }
        }
    }
}
