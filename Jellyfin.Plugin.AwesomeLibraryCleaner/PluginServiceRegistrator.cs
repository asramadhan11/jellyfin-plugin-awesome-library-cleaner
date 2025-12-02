using Jellyfin.Plugin.AwesomeLibraryCleaner.Services;
using MediaBrowser.Controller;
using MediaBrowser.Controller.Plugins;
using Microsoft.Extensions.DependencyInjection;

namespace Jellyfin.Plugin.AwesomeLibraryCleaner;

/// <summary>
/// Plugin service registrator for dependency injection.
/// </summary>
public class PluginServiceRegistrator : IPluginServiceRegistrator
{
    /// <inheritdoc />
    public void RegisterServices(IServiceCollection serviceCollection, IServerApplicationHost applicationHost)
    {
        serviceCollection.AddSingleton<ILibraryCleanupService, LibraryCleanupService>();
    }
}
