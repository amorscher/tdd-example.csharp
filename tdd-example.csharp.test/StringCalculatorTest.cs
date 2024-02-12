


using Xunit.Sdk;

namespace tdd_example.csharp.test;

public class StringCalculatorTest
{

    [Fact (DisplayName = "String calc should be created")]
    public void TestThatStringCalcCanBeCreated()
    {
        //GIVEN
        //WHEN
        var itemUnderTest = new StringCalculator();
        
        //THEN
        Assert.NotNull(itemUnderTest);

    }

}