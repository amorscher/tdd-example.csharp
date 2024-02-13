
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
        if (input == "")
        {
            return new List<int>(1) { 0 };
        }

        var delimiterSeparatedInput = this.ParseDelimiter(input);
        var numbersArray = Regex.Split(delimiterSeparatedInput.Numbers, @"" + delimiterSeparatedInput.EscapedDelimiter);

        return this.ParseNumbers(numbersArray);

    }
    record DelimiterSeparatedInput
    {
        public string EscapedDelimiter = "";
        public string Delimiter = "";
        public string Numbers = "";
    }
    private DelimiterSeparatedInput ParseDelimiter(string input)
    {
        if (input.StartsWith("//"))
        {
            var splittedInput = input.Split("\n");
            var delimiterPart = splittedInput[0];
            var numberPart = splittedInput[1];
            var delimiter = delimiterPart.Replace("//", "");

            var delimiterSeparatedInput = new DelimiterSeparatedInput
            {
                EscapedDelimiter = Regex.Escape(delimiter),
                Delimiter = delimiter,
                Numbers = numberPart
            };

            this.CheckForValidDelimiters(delimiterSeparatedInput.Numbers, delimiterSeparatedInput.Delimiter);

            return delimiterSeparatedInput;
        }




        return new DelimiterSeparatedInput
        {
            EscapedDelimiter = ",|\n",
            Delimiter = ",|\n",
            Numbers = input
        };
    }

    private void CheckForValidDelimiters(string numbers, string delimiter)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            var actChar = numbers[i];
            if (!char.IsDigit(actChar))
            {
                if (i + delimiter.Length > numbers.Length || numbers.Substring(i, delimiter.Length) != delimiter)
                {
                    throw new ArgumentException($"'{delimiter}' expected but '{actChar}' found at position {i}.");
                }
                else
                {
                    i = i + delimiter.Length - 1;
                }
            }
        }
    }

    private List<int> ParseNumbers(string[] numbersArray)
    {
        List<int> numberList = new();
        List<int> negativeNumbers = new();
        foreach (var item in numbersArray)
        {
            try
            {
                var number = Int32.Parse(item);
                
                if(number < 0){
                    negativeNumbers.Add(number);
                }

                numberList.Add(number);
            }
            catch (FormatException e)
            {
                throw new ArgumentException("Argument must be a number", e);
            }
        }

        if(negativeNumbers.Count > 0){
            throw new ArgumentException($"Negative number(s) not allowed: {String.Join(",",negativeNumbers.ToArray())}");
        }

        return numberList;

    }

}
