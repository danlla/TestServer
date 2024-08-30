using TestServer.Model;

namespace TestServer;

public static class Calculator
{
    public static int Sum(IEnumerable<Number> numbers) => numbers.Sum(n => n.Value);
}
