using Prometheus;

namespace TestServer;

public static class Counters
{
    public static readonly Counter TestCounter = Metrics.CreateCounter("test_counter", "This is test counter. Delete numbers to inc it");
}
