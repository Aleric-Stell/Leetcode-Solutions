namespace LeetCodePractice.Problems.Problem0003_LongestSubstring;

public static class Tests
{
    public static void Run()
    {
        Solution solution = new Solution();

        Test(solution, "abcabcbb", 3);
        Test(solution, "bbbbb", 1);
        Test(solution, "pwwkew", 3);
        Test(solution, "", 0);
    }

    private static void Test(Solution solution, string input, int expected)
    {
        int actual = solution.LengthOfLongestSubstring(input);

        Console.WriteLine($"Input: \"{input}\"");
        Console.WriteLine($"Expected: {expected}");
        Console.WriteLine($"Actual:   {actual}");
        Console.WriteLine(actual == expected ? "PASS" : "FAIL");
        Console.WriteLine();
    }
}