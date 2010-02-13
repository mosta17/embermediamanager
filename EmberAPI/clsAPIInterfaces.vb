﻿Public Class Interfaces
    ' Interfaces for external Modules
    Public Interface EmberExternalModule
        Sub Enable()
        Sub Disable()
        Sub Setup()
        Sub Init(ByRef emm As ModulesManager.EmberRuntimeObjects)
        ReadOnly Property ModuleName() As String
        ReadOnly Property ModuleVersion() As String
    End Interface

    Public Interface EmberScraperModule
        Sub Setup()
        'Title or Id must be field in
        'Movie is byref because some scrapper may run to update only some fields (defined in Scraper Setup)
        'Options is byref to allow field blocking in scraper chain
        Function Scraper(ByRef Movie As EmberAPI.MediaContainers.Movie, ByRef Options As Structures.ScrapeOptions) As Boolean
        Function PostScraper(ByRef Movie As EmberAPI.MediaContainers.Movie) As Boolean
        ReadOnly Property ModuleName() As String
        ReadOnly Property ModuleVersion() As String
        ReadOnly Property IsScraper() As Boolean
        ReadOnly Property IsPostScraper() As Boolean
    End Interface
End Class
