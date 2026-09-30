using LeetCodePractice.Testing;

namespace LeetCodePractice.Problems.Problem0003_LongestSubstring;

public static class Tests
{
    public static void Run()
    {
        var solution = new Solution();
        var cases = new (string Input, int Expected)[]
        {
            ("", 0),
            ("a", 1),
            ("abcabcbb", 3),
            ("bbbbb", 1),
            ("pwwkew", 3),
            ("abba", 2),
            ("dvdf", 3),
            (" ", 1)
        };
        var failures = new List<string>();
        foreach (var (input, expected) in cases)
        {
            try
            {
                Check.Equal(expected, solution.LengthOfLongestSubstring(input), $"Input: \"{input}\"");
            }
            catch (Exception ex)
            {
                failures.Add(ex.Message);
                Console.Error.WriteLine($"FAIL {ex.Message}");
            }
        }
        if (failures.Count > 0)
            throw new InvalidOperationException($"{failures.Count} case(s) failed.");
    }
}
