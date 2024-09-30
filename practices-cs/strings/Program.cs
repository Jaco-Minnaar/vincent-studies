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

Console.WriteLine("All words are correct. Congratulations!");
return 0;
