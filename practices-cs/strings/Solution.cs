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

        for (int i = word.Length - 1; i >= 0; i--)
        {
            var letter = word [i];
            var newS = s + letter;
             s = newS;
        }
        return s;
    }
}
