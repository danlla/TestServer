using TestServer;
using TestServer.Model;

namespace TestServerTests;

public class CalculatorTest
{
    [Fact]
    public void Sum()
    {
        var numbers = new List<Number>
        {
            new() { Id = 0, Value = 0 },
            new() { Id = 0, Value = 1 },
            new() { Id = 0, Value = 2 }
        };

        var expectedSum = 3;

        var sum = Calculator.Sum(numbers);

        Assert.Equal(expectedSum, sum);
    }

    [Fact]
    public void SumNegative()
    {
        var numbers = new List<Number>
        {
            new() { Id = 0, Value = -1 },
            new() { Id = 0, Value = -2 },
            new() { Id = 0, Value = -3 }
        };

        var expectedSum = -6;

        var sum = Calculator.Sum(numbers);

        Assert.Equal(expectedSum, sum);
    }

    [Fact]
    public void SumManyNumbers()
    {
        var numbers = new List<Number>();

        for (var i = 0; i < 100; i++)
            numbers.Add(new Number { Id = 0, Value = i });

        var expectedSum = 4950;

        var sum = Calculator.Sum(numbers);

        Assert.Equal(expectedSum, sum);
    }
}