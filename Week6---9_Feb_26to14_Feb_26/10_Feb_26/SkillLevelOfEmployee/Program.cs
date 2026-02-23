using System;
using System.Linq;

namespace SkillLevelOfEmployee;

internal class TeamStrength
{
    public static long MaxTotalStrength(int[] skills, int[] teamSizes)
    {
        Array.Sort(skills);
        Array.Sort(teamSizes);

        int left = 0;
        int right = skills.Length - 1;
        long totalStrength = 0;

        foreach (int size in teamSizes)
        {
            int maxSkill = skills[right--];
            int minSkill = skills[left];

            totalStrength += minSkill + maxSkill;

            // Consume the remaining (size - 1) members from the left
            left += size - 1;
        }

        return totalStrength;
    }

    // Example usage
    public static void Main()
    {
        int[] skills = { 1, 3, 5, 2, 4, 6 };
        int[] teamSizes = { 2, 3, 1 };

        Console.WriteLine(MaxTotalStrength(skills, teamSizes));
    }
}
