using Albin.AlgorithmsAndDataStructures.Core.DataStructures;

namespace Albin.AlgorithmsAndDataStructures.UnitTests.DataStructures;

public class DequeTests
{
    [Theory]
    [InlineData("madam", true)]
    [InlineData("racecar", true)]
    [InlineData("deified", true)]
    [InlineData("civic", true)]
    [InlineData("radar", true)]
    [InlineData("level", true)]
    [InlineData("palindrome", false)]
    [InlineData("hello", false)]
    [InlineData("world", false)]
    public void Deque_Should_Identify_Palindromes_Correctly(string word, bool expected)
    {
        var deque = new Deque<char>();

        foreach (char c in word)
        {
            deque.AddLast(c);
        }

        bool isPalindrome = true;
        while (deque.Count > 1)
        {
            if (deque.RemoveFirst() != deque.RemoveLast())
            {
                isPalindrome = false;
                break;
            }
        }

        isPalindrome.Should().Be(expected);
    }
}
