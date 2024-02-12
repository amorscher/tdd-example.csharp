
using System;
using System.Text.RegularExpressions;
/*
* A simple string calculator
*/

public class StringCalculator
{

    static void Main(string[] args)
    {
        // is empty for our example
    }

    public StringCalculator()
    {

    }
    public int Add(string numbers)
    {
        var parsedNumbers = this.ParseInput(numbers);
        return parsedNumbers.Sum();
    }

    private List<int> ParseInput(string input)
    {
        if(input == ""){
            return new List<int>(1){0};
        }
        
        var numbersArray = Regex.Split(input,@",|\n");
        
        List<int> numberList = new();
        foreach (var item in numbersArray)
        {
            try
            {
                numberList.Add(Int32.Parse(item));
            }
            catch (FormatException e)
            {
                throw new ArgumentException("Argument must be a number", e);
            }
        }

        return numberList;

    }


}
