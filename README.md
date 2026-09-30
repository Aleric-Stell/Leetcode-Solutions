# LeetCode Practice — C#

Solve problems in VS Code, run your own test cases locally, and keep each problem and its history visible on GitHub.

## Setup

Install the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0), [Git](https://git-scm.com/downloads), and [VS Code](https://code.visualstudio.com/) with Microsoft's C# extension.

```sh
git clone https://github.com/Aleric-Stell/Leetcode-Solutions.git
cd Leetcode-Solutions
code .
```

Run these commands from the repository folder:

| Task | Command |
| --- | --- |
| List problems | `dotnet run -- --list` |
| Test Problem 3 | `dotnet run -- 3` |
| Test by folder name | `dotnet run -- Problem0003_LongestSubstring` |
| Test all problems | `dotnet run` |

This project uses a small console test runner, not `dotnet test`. Exit code 0 means all selected suites passed, 1 means a test suite failed, and 2 means an invalid selection or command. Local tests cover only the cases you add; submit on LeetCode too for its hidden tests.

## Each problem

Keep a folder under `Problems` named `ProblemNNNN_Name`, containing:

- `Solution.cs`: your implementation.
- `Tests.cs`: example and edge-case checks.
- `README.md`: link to the original problem, status, approach, complexity, and lessons learned.

Use a unique namespace for each problem. The runner discovers public static `Tests.Run()` methods automatically, so you never need to edit `Program.cs` to add a problem.

Example scaffold (replace the method and cases to match the problem):

```csharp
// Problems/Problem0123_Name/Solution.cs
namespace LeetCodePractice.Problems.Problem0123_Name;
public class Solution
{
    public int Solve(int input) => throw new NotImplementedException();
}
```

```csharp
// Problems/Problem0123_Name/Tests.cs
using LeetCodePractice.Testing;
namespace LeetCodePractice.Problems.Problem0123_Name;
public static class Tests
{
    public static void Run()
    {
        var solution = new Solution();
        Check.Equal(2, solution.Solve(1), "Replace this illustrative test");
    }
}
```

Use `Check.SequenceEqual` for ordered arrays, or custom checks when multiple answers are valid. A test must throw on failure; merely printing FAIL will not fail the runner.

## Daily workflow

1. Read the original problem and create its folder.
2. Add examples and edge cases before solving.
3. Write your solution; run just that problem while debugging.
4. Record your approach and time/space complexity in its README.
5. Commit meaningful progress and push:

```sh
git add Problems
git commit -m "Solve problem 0003 and add edge cases"
git push
```

GitHub Actions builds and runs all discovered suites on pushes and pull requests. An unfinished problem can make the overall check red; that is honest feedback, not proof the runner is broken. Problem 3 currently returns 0 and is intentionally unfinished.

For LeetCode submission, copy the Solution class without its local namespace. Add shared ListNode/TreeNode helpers locally when needed; LeetCode provides those types for relevant problems.

## Progress

| Problem | Status | Source / notes |
| --- | --- | --- |
| 0003 — Longest Substring Without Repeating Characters | In progress | [Files](Problems/Problem0003_LongestSubstring) |

This repository is public. Keep notes free of private information. Generated `bin` and `obj` files are ignored for new additions; older tracked build files may still appear until removed from Git's index.
