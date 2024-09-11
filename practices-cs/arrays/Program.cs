// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using Arrays;

int[] case1 = [2, 4, 9, 1, 5];
int[] case2 = [2, 4553, 9, 38676, 420, 69];

var doMin = false;
var doMax = false;
var doSum = false;
var doAvg = false;
var doSort = false;

foreach (var arg in args)
{
    switch (arg)
    {
        case "--min":
            doMin = true;
            break;
        case "--max":
            doMax = true;
            break;
        case "--sum":
            doSum = true;
            break;
        case "--avg":
            doAvg = true;
            break;
        case "--sort":
            doSort = true;
            break;
    }
}

TestCase(case1);
TestCase(case2);

void TestCase(int[] testCase)
{
    var sorted = testCase.Order().ToArray();
    var min = testCase.Min();
    var max = testCase.Max();
    var sum = testCase.Sum();
    var average = (double)sum / testCase.Length;

    if (doMin)
    {
        var calcMin = Solution.Min(testCase);
        if (min != calcMin)
        {
            Console.WriteLine(
                "Calculated Min is incorrect. Expected: {0}. Actual: {1}",
                min,
                calcMin
            );
            return;
        }
    }

    if (doMax)
    {
        var calcMax = Solution.Max(testCase);
        if (max != calcMax)
        {
            Console.WriteLine(
                "Calculated Max is incorrect. Expected: {0}. Actual: {1}",
                max,
                calcMax
            );
            return;
        }
    }

    if (doSum)
    {
        var calcSum = Solution.Sum(testCase);
        if (sum != calcSum)
        {
            Console.WriteLine(
                "Calculated Sum is incorrect. Expected: {0}. Actual: {1}",
                sum,
                calcSum
            );
            return;
        }
    }

    if (doAvg)
    {
        var calcAvg = Solution.Average(testCase);
        if (average != calcAvg)
        {
            Console.WriteLine(
                "Calculated Average is incorrect. Expected: {0}. Actual: {1}",
                average,
                calcAvg
            );
            return;
        }
    }

    if (doSort)
    {
        var calcSorted = Solution.Sort(testCase);
        if (calcSorted.Length != sorted.Length)
        {
            Console.WriteLine(
                "Sort output is incorrect. Output: {0}",
                JsonSerializer.Serialize(calcSorted)
            );
        }
    }
}
