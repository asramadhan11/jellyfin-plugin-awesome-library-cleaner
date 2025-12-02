using System.Collections.Generic;
using MediaBrowser.Model.Plugins;

namespace Jellyfin.Plugin.AwesomeLibraryCleaner.Configuration;

/// <summary>
/// Time reference for determining when media should be cleaned.
/// </summary>
public enum TimeReference
{
    /// <summary>
    /// Use the file added date.
    /// </summary>
    FileAddedDate,

    /// <summary>
    /// Use the latest file update date.
    /// </summary>
    LatestFileUpdateDate,

    /// <summary>
    /// Use the latest watch date.
    /// </summary>
    LatestWatchDate
}

/// <summary>
/// Element reference for TV shows to determine cleanup granularity.
/// </summary>
public enum ElementReference
{
    /// <summary>
    /// Clean per episode.
    /// </summary>
    Episode,

    /// <summary>
    /// Clean per season.
    /// </summary>
    Season,

    /// <summary>
    /// Clean per whole series.
    /// </summary>
    WholeSeries
}

/// <summary>
/// Configuration for a single library.
/// </summary>
public class LibrarySettings
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LibrarySettings"/> class.
    /// </summary>
    public LibrarySettings()
    {
        LibraryId = string.Empty;
        LibraryName = string.Empty;
        Enabled = false;
        TimeReferenceOption = TimeReference.FileAddedDate;
        LeavingSoonDays = 0;
        LeavingSoonCollectionName = "Leaving Soon";
        DeletionDays = 0;
        DeleteAutomation = false;
        ExcludeFavorites = true;
        ElementReferenceOption = ElementReference.WholeSeries;
    }

    /// <summary>
    /// Gets or sets the library ID.
    /// </summary>
    public string LibraryId { get; set; }

    /// <summary>
    /// Gets or sets the library name.
    /// </summary>
    public string LibraryName { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether awesome library cleaner is enabled for this library.
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    /// Gets or sets the time reference option.
    /// </summary>
    public TimeReference TimeReferenceOption { get; set; }

    /// <summary>
    /// Gets or sets the number of days before media goes into leaving soon collection (0 to disable).
    /// </summary>
    public int LeavingSoonDays { get; set; }

    /// <summary>
    /// Gets or sets the leaving soon collection name.
    /// </summary>
    public string LeavingSoonCollectionName { get; set; }

    /// <summary>
    /// Gets or sets the number of days before media is deleted.
    /// </summary>
    public int DeletionDays { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether deletion is automated.
    /// </summary>
    public bool DeleteAutomation { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether favorites should be excluded from cleanup.
    /// </summary>
    public bool ExcludeFavorites { get; set; }

    /// <summary>
    /// Gets or sets the element reference option for TV shows.
    /// </summary>
    public ElementReference ElementReferenceOption { get; set; }
}

/// <summary>
/// Plugin configuration.
/// </summary>
public class PluginConfiguration : BasePluginConfiguration
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PluginConfiguration"/> class.
    /// </summary>
    public PluginConfiguration()
    {
        // Initialize with empty library settings
        LibrarySettings = new List<LibrarySettings>();
    }

    /// <summary>
    /// Gets or sets the library settings list.
    /// </summary>
    public List<LibrarySettings> LibrarySettings { get; set; }
}
