


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
    public void TestThatMoreThan2ArgumentsAreInvalid()
    {
        //GIVEN
        var itemUnderTest = new StringCalculator();

        //WHEN
        Action action = () => itemUnderTest.Add("1,2,3");

        //THEN
        Assert.Throws<ArgumentException>(action);

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
        Assert.Equal(1+2, result1Plus2);
        Assert.Equal(3+2, result3Plus2);

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

}