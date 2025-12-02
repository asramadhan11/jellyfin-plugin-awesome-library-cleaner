using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jellyfin.Plugin.AwesomeLibraryCleaner.Services;

/// <summary>
/// Interface for the library cleanup service.
/// </summary>
public interface ILibraryCleanupService
{
    /// <summary>
    /// Executes the cleanup process for all configured libraries.
    /// </summary>
    /// <param name="progress">Progress reporter.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task ExecuteCleanupAsync(IProgress<double> progress, CancellationToken cancellationToken);
}
