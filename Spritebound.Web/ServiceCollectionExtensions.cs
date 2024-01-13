namespace ToolBX.Spritebound.Web;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds services necessary to use Spritebound.Web services. Do not use if you are using AutoInject.
    /// </summary>
    public static IServiceCollection AddSpriteboundWeb(this IServiceCollection services, AutoInjectOptions? options = null)
    {
        return services.AddAutoInjectServices(Assembly.GetExecutingAssembly(), options);
    }
}