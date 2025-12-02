using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jellyfin.Data.Enums;
using Jellyfin.Plugin.AwesomeLibraryCleaner.Services;
using MediaBrowser.Model.Tasks;
using Microsoft.Extensions.Logging;

namespace Jellyfin.Plugin.AwesomeLibraryCleaner.ScheduledTasks;

/// <summary>
/// Scheduled task for library cleanup operations.
/// </summary>
public class LibraryCleanupTask : IScheduledTask
{
    private readonly ILogger<LibraryCleanupTask> _logger;
    private readonly ILibraryCleanupService _cleanupService;

    /// <summary>
    /// Initializes a new instance of the <see cref="LibraryCleanupTask"/> class.
    /// </summary>
    /// <param name="logger">Instance of the <see cref="ILogger{LibraryCleanupTask}"/> interface.</param>
    /// <param name="cleanupService">Instance of the <see cref="ILibraryCleanupService"/> interface.</param>
    public LibraryCleanupTask(
        ILogger<LibraryCleanupTask> logger,
        ILibraryCleanupService cleanupService)
    {
        _logger = logger;
        _cleanupService = cleanupService;
    }

    /// <inheritdoc />
    public string Name => "Awesome Library Cleaner";

    /// <inheritdoc />
    public string Key => "AwesomeLibraryCleanerTask";

    /// <inheritdoc />
    public string Description => "Manages leaving soon and to delete collections for old media based on configured rules.";

    /// <inheritdoc />
    public string Category => "Library";

    /// <inheritdoc />
    public async Task ExecuteAsync(IProgress<double> progress, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting Awesome Library Cleaner task");

        try
        {
            progress.Report(0);
            await _cleanupService.ExecuteCleanupAsync(progress, cancellationToken).ConfigureAwait(false);
            progress.Report(100);

            _logger.LogInformation("Awesome Library Cleaner task completed successfully");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error executing Awesome Library Cleaner task");
            throw;
        }
    }

    /// <inheritdoc />
    public IEnumerable<TaskTriggerInfo> GetDefaultTriggers()
    {
        // Run daily at 3 AM
        return new[]
        {
            new TaskTriggerInfo
            {
                Type = TaskTriggerInfoType.DailyTrigger,
                TimeOfDayTicks = TimeSpan.FromHours(3).Ticks
            }
        };
    }
}
