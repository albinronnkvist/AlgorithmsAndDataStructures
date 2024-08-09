namespace Albin.AlgorithmsAndDataStructures.Core.Other;

public static class Factorial
{
    public static int Execute(int number)
    {
        if (number is 0)
        {
            return 1;
        }
 
        return number * Execute(number - 1);
    }
}
