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

    Public Structure ScraperResult
        Public Cancelled As Boolean
        Public breakChain As Boolean
    End Structure

    Public Interface EmberMovieScraperModule
        Function testSetupScraper(ByRef p As System.Windows.Forms.Panel) As Integer
        Sub SetupScraper()
        Sub SetupPostScraper()
        'Sub SetupTVScraper()
        'Sub SetupTVPostScraper()
        Sub Init()
        'Movie is byref because some scrapper may run to update only some fields (defined in Scraper Setup)
        'Options is byref to allow field blocking in scraper chain
        Function Scraper(ByRef DBMovie As EmberAPI.Structures.DBMovie, ByRef ScrapeType As EmberAPI.Enums.ScrapeType, ByRef Options As Structures.ScrapeOptions) As ScraperResult
        Function PostScraper(ByRef DBMovie As EmberAPI.Structures.DBMovie, ByVal ScrapeType As EmberAPI.Enums.ScrapeType) As ScraperResult
        Function SelectImageOfType(ByRef DBMovie As EmberAPI.Structures.DBMovie, ByVal _DLType As EmberAPI.Enums.ImageType, ByRef pResults As Containers.ImgResult, Optional ByVal _isEdit As Boolean = False) As ScraperResult
        Function DownloadTrailer(ByRef DBMovie As EmberAPI.Structures.DBMovie, ByRef sURL As String) As ScraperResult
        Function GetMovieStudio(ByRef DBMovie As EmberAPI.Structures.DBMovie, ByRef sStudio As List(Of String)) As ScraperResult
        ReadOnly Property ModuleName() As String
        ReadOnly Property ModuleVersion() As String
        ReadOnly Property IsScraper() As Boolean
        ReadOnly Property IsTVScraper() As Boolean
        ReadOnly Property IsPostScraper() As Boolean
        Event ScraperUpdateMediaList(ByVal col As Integer, ByVal v As Boolean)
    End Interface
    Public Interface EmberTVScraperModule
        Function testSetupScraper(ByRef p As System.Windows.Forms.Panel) As Integer
        Sub SetupScraper()
        Sub SetupPostScraper()
        Sub Init()
        'Movie is byref because some scrapper may run to update only some fields (defined in Scraper Setup)
        'Options is byref to allow field blocking in scraper chain
        'Function Scraper(ByRef DBTV As EmberAPI.Structures.DBTV, ByRef ScrapeType As EmberAPI.Enums.ScrapeType, ByRef Options As Structures.ScrapeOptions) As ScraperResult
        Function Scraper(ByVal ShowID As Integer, ByVal ShowTitle As String, ByVal TVDBID As String, ByVal Lang As String, ByVal Options As Structures.TVScrapeOptions) As ScraperResult
        Function ScrapeEpisode(ByVal ShowID As Integer, ByVal ShowTitle As String, ByVal TVDBID As String, ByVal iEpisode As Integer, ByVal iSeason As Integer, ByVal Lang As String, ByVal Options As Structures.TVScrapeOptions) As ScraperResult
        Function PostScraper(ByRef DBTV As EmberAPI.Structures.DBTV, ByVal ScrapeType As EmberAPI.Enums.ScrapeType) As ScraperResult
        Function ChangeEpisode(ByVal ShowID As Integer, ByVal TVDBID As String, ByRef epDet As MediaContainers.EpisodeDetails) As ScraperResult
        Function GetSingleEpisode(ByVal ShowID As Integer, ByVal TVDBID As String, ByVal Season As Integer, ByVal Episode As Integer, ByVal Options As Structures.TVScrapeOptions, ByRef epDetails As MediaContainers.EpisodeDetails) As ScraperResult
        Function SaveImages() As ScraperResult
        Function GetLangs(ByVal sMirror As String, ByRef Langs As List(Of Containers.TVLanguage)) As ScraperResult
        ReadOnly Property ModuleName() As String
        ReadOnly Property ModuleVersion() As String
        ReadOnly Property IsScraper() As Boolean
        ReadOnly Property IsPostScraper() As Boolean

        Event TVScraperEvent(ByVal eType As EmberAPI.Enums.ScraperEventType, ByVal iProgress As Integer, ByVal Parameter As Object)
    End Interface


End Class
