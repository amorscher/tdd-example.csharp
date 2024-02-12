


using Microsoft.AspNetCore.Components.Forms;
using Xunit.Sdk;

namespace tdd_example.csharp.test;

public class StringCalculatorTest
{

    [Fact(DisplayName = "String calc should be created")]
    public void TestThatStringCalcCanBeCreated()
    {
        //GIVEN
        //WHEN
        var itemUnderTest = new StringCalculator();

        //THEN
        Assert.NotNull(itemUnderTest);

    }


    [Fact]
    public void TestThat2ArgumentsAreTakenAsString()
    {
        //GIVEN
        var itemUnderTest = new StringCalculator();
        //WHEN
        itemUnderTest.Add("1,2");

        //THEN
        Assert.NotNull(itemUnderTest);

    }

    [Fact]
    public void TestThatNArgumentsAreTakenAsString()
    {
        //GIVEN
        var itemUnderTest = new StringCalculator();
        //WHEN
        var result = itemUnderTest.Add("1,2,3,4,5");

        //THEN
        Assert.Equal(1 + 2 + 3 + 4 + 5, result);

    }

    [Fact]
    public void TestThatArgumentNotANumberIsInvalid()
    {
        //GIVEN
        var itemUnderTest = new StringCalculator();

        //WHEN
        void action() => itemUnderTest.Add("1,noNumber");

        //THEN
        Assert.Throws<ArgumentException>(action);

    }

    [Fact]
    public void TestThatSumOfInputsIsReturned()
    {
        //GIVEN
        var itemUnderTest = new StringCalculator();

        //WHEN
        var result1Plus2 = itemUnderTest.Add("1,2");
        var result3Plus2 = itemUnderTest.Add("3,2");

        //THEN
        Assert.Equal(1 + 2, result1Plus2);
        Assert.Equal(3 + 2, result3Plus2);

    }


    [Fact]
    public void TestThatOneNumberAsInputIsValid()
    {
        //GIVEN
        var itemUnderTest = new StringCalculator();

        //WHEN
        var result = itemUnderTest.Add("1");

        //THEN
        Assert.Equal(1, result);
    }

    [Fact]
    public void TestThatEmptyStringReturns0()
    {
        //GIVEN
        var itemUnderTest = new StringCalculator();

        //WHEN
        var result = itemUnderTest.Add("");

        //THEN
        Assert.Equal(0, result);
    }

    [Fact]
    public void TestThatNewlineCanBeUsedAsDelimiter()
    {
        //GIVEN
        var itemUnderTest = new StringCalculator();

        //WHEN
        var result = itemUnderTest.Add("1\n2\n3");

        //THEN
        Assert.Equal(1 + 2 + 3, result);
    }

    [Fact]
    public void TestThatNewlineAndCommaCanBeUsedAsDelimiter()
    {
        //GIVEN
        var itemUnderTest = new StringCalculator();

        //WHEN
        var result = itemUnderTest.Add("1\n2,3");

        //THEN
        Assert.Equal(1 + 2 + 3, result);
    }



    [Fact]
    public void TestThatSingleMixedDelimitersCanBeUsedAsDelimiter()
    {
        //GIVEN
        var itemUnderTest = new StringCalculator();

        //WHEN
        var resultSemicolon = itemUnderTest.Add("//;\n1;2;3");
        var resultPipe = itemUnderTest.Add("//|\n1|2|3");

        //THEN
        Assert.Equal(1 + 2 + 3, resultSemicolon);
        Assert.Equal(1 + 2 + 3, resultPipe);
    }

    [Fact]
    public void TestThatMultiDelimitersCanBeUsedAsDelimiter()
    {
        //GIVEN
        var itemUnderTest = new StringCalculator();

        //WHEN
        var result = itemUnderTest.Add("//Sep\n1Sep2Sep3");

        //THEN
        Assert.Equal(1 + 2 + 3, result);
    }


    [Fact]
    public void TestThatUsingWrongSingleDelimiterThrowsException()
    {
        //GIVEN
        var itemUnderTest = new StringCalculator();

        //WHEN
        void action() => itemUnderTest.Add("//|\n1|2,3");

        //THEN
        ArgumentException exception = Assert.Throws<ArgumentException>(action);
        Assert.Equal("'|' expected but ',' found at position 3.", exception.Message);
        

    }

        [Fact]
    public void TestThatUsingWrongMultiDelimiterThrowsException()
    {
        //GIVEN
        var itemUnderTest = new StringCalculator();

        //WHEN
        void action() => itemUnderTest.Add("//Sep\n1Sep2,3");

        //THEN
        ArgumentException exception = Assert.Throws<ArgumentException>(action);
        Assert.Equal("'Sep' expected but ',' found at position 5.", exception.Message);
        

    }

}