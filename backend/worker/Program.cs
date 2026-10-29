using DotnetNative.Core.Cache;
using DotnetNative.Core.Config;
using DotnetNative.Worker;

namespace DotnetNative.Worker;

public static class WorkerProgram
{
    public static async Task Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Configuration.AddDotEnv();

        var settings = Settings.From(builder.Configuration);
        builder.Services.AddSingleton(settings);
        builder.Services.AddSingleton(new RedisConnection(settings, commandTimeoutMs: 10_000));
        builder.Services.AddSingleton<JobTasks>();
        builder.Services.AddHostedService<JobWorker>();

        await builder.Build().RunAsync();
    }
}
