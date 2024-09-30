using Strings;

(string, bool)[] words =
[
    ("Anna", true),
    ("Vincent", false),
    ("kayak", true),
    ("anal", false),
    ("super", false),
    ("racecar", true),
    ("jam", false),
    ("rotator", true),
    ("mitochondria", false)
];

if (args.Contains("--rev"))
{
    foreach (var (word, _) in words)
    {
        var expected = string.Join("", word.Reverse());
        var actual = Solution.ReverseString2(word);

        if (expected != actual)
        {
            Console.WriteLine("Reverse incorrect. Expected: {0}. Actual: {1}.", expected, actual);
            return 1;
        }
    }

    Console.WriteLine("All reverse operations are correct. Congratulations!");
}

if (args.Contains("--pal"))
{
    foreach (var (word, isPalindrome) in words)
    {
        var actual = Solution.IsPalindrome(word);
        if (actual != isPalindrome)
        {
            Console.WriteLine(
                "Incorrect. Word: {0}. Expected: {1}. Actual: {2}",
                word,
                isPalindrome,
                actual
            );
            return 1;
        }
    }

    Console.WriteLine("All palindrome calculations are correct. Congratulations!");
}
return 0;
