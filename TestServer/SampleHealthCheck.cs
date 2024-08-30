using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace TestServer;

public sealed class SampleHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default) => Task.FromResult(HealthCheckResult.Healthy());
}
