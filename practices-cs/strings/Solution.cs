namespace Strings;

public static class Solution
{
    public static bool IsPalindrome(string word)
    {
        var w = word.ToLower();

        // Vincent's solution here
        if (ReverseString(w) != w)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public static string ReverseString(string word)
    {
        // Vincent's solution here
        var s = "";

        int i = word.Length - 1;
        while (i >= 0)
        {
            var letter = word[i];
            var newS = s + letter;
            s = newS;

            i = i - 1;
        }
        return s;
    }

    public static string ReverseString2(string word)
    {
        var s = "";

        int i = 0;
        while (i < word.Length)
        {
            // Complete here

            i = i + 1;
        }
        return s;
    }
}
