using System;
using System.Linq;

namespace HardPalindrome
{
    internal class Program
    {
        public static bool IsPalindrome(string word)
        {
            return word.SequenceEqual(word.Reverse());
        }

        public static (bool result, string chars) HardPalindrome(string word, int k)
        {
            if (word.Length <= 1 || k == 0)
                return (IsPalindrome(word), ""); // Check if the remaining string is already a palindrome.

            for (var i = 0; i < word.Length; i++)
            {
                var newWord = word.Remove(i, 1);
                if (IsPalindrome(newWord))
                {
                    return (true, word[i].ToString());
                }
                else
                {
                    var (result, chars) = HardPalindrome(newWord, k - 1);
                    if (result)
                    {
                        return (true, chars + " " + word[i]);
                    }
                }
            }

            return (false, "");
        }

        static void Main(string[] args)
        {
            var result = HardPalindrome("watedrrfetawx", 3);
            if (result.result)
            {
                Console.WriteLine("You can make a palindrome by removing characters: " + result.chars);
            }
            else
            {
                Console.WriteLine("You cannot make a palindrome with the given constraints.");
            }
        }
    }
}
