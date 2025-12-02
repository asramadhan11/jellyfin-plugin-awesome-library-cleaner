// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

// StyleCop suppressions for model classes
[assembly: SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "Multiple related types in same file is acceptable for models", Scope = "type", Target = "~T:Jellyfin.Plugin.AwesomeLibraryCleaner.Configuration.LibrarySettings")]
[assembly: SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:File may only contain a single type", Justification = "Multiple related types in same file is acceptable for models")]

// Code analysis suppressions for DTOs
[assembly: SuppressMessage("Design", "CA2227:Collection properties should be read only", Justification = "DTOs require settable properties for deserialization")]
[assembly: SuppressMessage("Design", "CA1002:Do not expose generic lists", Justification = "DTOs use List for JSON serialization compatibility")]

// Security analysis - Admin-only API with authorization
[assembly: SuppressMessage("Security", "CA3003:Review code for file path injection vulnerabilities", Justification = "API is admin-only with RequiresElevation authorization", Scope = "member", Target = "~M:Jellyfin.Plugin.AwesomeLibraryCleaner.Api.LibraryCleanupController.DeleteItemWithSymlinkAsync(System.String)~System.Threading.Tasks.Task")]
