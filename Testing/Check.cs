namespace LeetCodePractice.Testing;

public static class Check
{
    public static void Equal<T>(T expected, T actual, string context = "")
    {
        if (!EqualityComparer<T>.Default.Equals(expected, actual))
            throw new InvalidOperationException($"{context}: expected {expected}, actual {actual}");
        Console.WriteLine($"PASS {context}");
    }

    public static void SequenceEqual<T>(IEnumerable<T> expected, IEnumerable<T> actual, string context = "")
    {
        var expectedValues = expected.ToArray();
        var actualValues = actual.ToArray();
        if (!expectedValues.SequenceEqual(actualValues))
            throw new InvalidOperationException(
                $"{context}: expected [{string.Join(", ", expectedValues)}], actual [{string.Join(", ", actualValues)}]");
        Console.WriteLine($"PASS {context}");
    }
}
