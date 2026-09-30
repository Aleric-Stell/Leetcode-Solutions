using System.Reflection;

var suites = Assembly.GetExecutingAssembly().GetTypes()
    .Where(t => t.Name == "Tests" && t.Namespace?.StartsWith("LeetCodePractice.Problems.") == true)
    .Select(t => new { Name = t.Namespace!.Split('.').Last(),
        Run = t.GetMethod("Run", BindingFlags.Public | BindingFlags.Static, Type.EmptyTypes) })
    .Where(t => t.Run != null)
    .OrderBy(t => t.Name).ToArray();

if (args.Length == 1 && args[0] == "--list")
{
    foreach (var suite in suites) Console.WriteLine(suite.Name);
    return 0;
}

if (args.Length > 1)
{
    Console.Error.WriteLine("Usage: dotnet run -- [problem number | problem name | --list]");
    return 2;
}

var selected = suites.AsEnumerable();
if (args.Length == 1)
{
    var filter = int.TryParse(args[0], out var number)
        ? $"Problem{number:D4}_" : args[0];
    selected = selected.Where(s => s.Name.StartsWith(filter, StringComparison.OrdinalIgnoreCase));
}
var matches = selected.ToArray();
if (matches.Length == 0)
{
    Console.Error.WriteLine("No matching test suites. Use dotnet run -- --list.");
    return 2;
}

var failed = 0;
foreach (var suite in matches)
{
    Console.WriteLine($"\n=== {suite.Name} ===");
    try
    {
        suite.Run!.Invoke(null, null);
        Console.WriteLine("PASS");
    }
    catch (Exception ex)
    {
        failed++;
        Console.Error.WriteLine($"FAIL: {(ex is TargetInvocationException ? ex.InnerException : ex)?.Message}");
    }
}
Console.WriteLine($"\nSuites: {matches.Length - failed} passed, {failed} failed.");
return failed == 0 ? 0 : 1;
