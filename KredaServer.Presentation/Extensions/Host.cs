namespace KredaServer.Presentation.Extensions;

public static class WebHostBuilderExtensionsHost
{
    public static ConfigureWebHostBuilder AddHostConfig(this ConfigureWebHostBuilder builder)
    {
        builder.ConfigureKestrel(options =>
        {
            options.ListenAnyIP(5000);
        });

        return builder;
    }
}