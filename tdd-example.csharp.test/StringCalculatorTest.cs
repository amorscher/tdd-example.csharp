


using Xunit.Sdk;

namespace tdd_example.csharp.test;

public class StringCalculatorTest
{

    [Fact (DisplayName = " one plus two equals three")]
    public void FirstTest()
    {
        //GIVEN
        var itemUnderTest = new StringCalculator();
        //WHEN
        var result = itemUnderTest.Add("1,2");
        //THEN
        Assert.Equal(3, result);

    }

}