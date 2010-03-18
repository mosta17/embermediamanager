Imports System.IO
Imports System.Xml.Linq

Imports Microsoft.VisualBasic

Imports EmberScraperModule.XMLScraper.ScraperLib

Namespace XMLScraper
    Namespace ScraperXML

        Public NotInheritable Class ScraperInfo
            Implements IComparable(Of ScraperInfo)

#Region "Fields"

            Private _adultcontent As Boolean
            Private _filename As String
            Private _hassecondarysearch As Boolean
            Private _scrapercache As String
            Private _scrapercontent As ScraperContent
            Private _scraperdate As String
            Private _scraperframework As String
            Private _scraperlanguage As String
            Private _scrapername As String
            Private _scraperpath As String
            Private _scraperthumb As String
            Private _settings As ScraperSettings

#End Region 'Fields

#Region "Constructors"

            Public Sub New()
                Me.Clear()
            End Sub

#End Region 'Constructors

#Region "Properties"

            Public Property AdultContent() As Boolean
                Get
                    Return Me._adultcontent
                End Get
                Set(ByVal value As Boolean)
                    Me._adultcontent = Value
                End Set
            End Property

            Public Property FileName() As String
                Get
                    Return Me._filename
                End Get
                Private Set(ByVal value As String)
                    Me._filename = Value
                End Set
            End Property

            Public Property HasSecondarySearch() As Boolean
                Get
                    Return Me._hassecondarysearch
                End Get
                Private Set(ByVal value As Boolean)
                    Me._hassecondarysearch = Value
                End Set
            End Property

            Public Property ScraperContent() As ScraperContent
                Get
                    Return Me._scrapercontent
                End Get
                Private Set(ByVal value As ScraperContent)
                    Me._scrapercontent = value
                End Set
            End Property

            Public Property ScraperDate() As String
                Get
                    Return Me._scraperdate
                End Get
                Private Set(ByVal value As String)
                    Me._scraperdate = Value
                End Set
            End Property

            Public Property ScraperFramework() As String
                Get
                    Return Me._scraperframework
                End Get
                Private Set(ByVal value As String)
                    Me._scraperframework = Value
                End Set
            End Property

            Public Property ScraperLanguage() As String
                Get
                    Return Me._scraperlanguage
                End Get
                Private Set(ByVal value As String)
                    Me._scraperlanguage = Value
                End Set
            End Property

            Public Property ScraperName() As String
                Get
                    Return Me._scrapername
                End Get
                Private Set(ByVal value As String)
                    Me._scrapername = Value
                End Set
            End Property

            Public Property ScraperPath() As String
                Get
                    Return Me._scraperpath
                End Get
                Private Set(ByVal value As String)
                    Me._scraperpath = value
                End Set
            End Property

            Public Property ScraperThumb() As String
                Get
                    Return Me._scraperthumb
                End Get
                Private Set(ByVal value As String)
                    Me._scraperthumb = value
                End Set
            End Property

            Public Property Settings() As ScraperSettings
                Get
                    Return Me._settings
                End Get
                Set(ByVal value As ScraperSettings)
                    Me._settings = value
                End Set
            End Property

            Friend Property ScraperCache() As String
                Get
                    Return Me._scrapercache
                End Get
                Set(ByVal value As String)
                    Me._scrapercache = Value
                End Set
            End Property

#End Region 'Properties

#Region "Methods"

            Public Sub Clear()
                Me._adultcontent = False
                Me._filename = String.Empty
                Me._hassecondarysearch = False
                Me._scrapercache = String.Empty
                Me._scrapercontent = ScraperLib.ScraperContent.movies
                Me._scraperdate = String.Empty
                Me._scraperframework = String.Empty
                Me._scraperlanguage = String.Empty
                Me._scrapername = String.Empty
                Me._scraperpath = String.Empty
                Me._settings = New ScraperSettings
                Me._scraperthumb = String.Empty
            End Sub

            Public Function CompareTo(ByVal other As ScraperInfo) As Integer Implements IComparable(Of ScraperInfo).CompareTo
                If IsNothing(Me) Then
                    If IsNothing(other) Then
                        Return 0
                    Else
                        Return 1
                    End If
                Else
                    If IsNothing(other) Then
                        Return -1
                    Else
                        Return Me._scrapername.CompareTo(other._scrapername)
                    End If
                End If
            End Function

            Friend Function Load(ByVal doc As XDocument, ByVal xmlPath As String) As Boolean
                If IsNothing(doc) Then
                    Return False
                End If

                Me._scraperpath = xmlPath

                Dim tempscraper As New GenericScraper()
                tempscraper.Load(doc)

                Me._filename = Path.GetFileName(xmlPath)

                Me._scrapername = doc.Root.Attribute("name").Value
                Me._scrapercontent = CType([Enum].Parse(GetType(ScraperContent), doc.Root.Attribute("content").Value), ScraperContent)

                Me._settings = tempscraper.InternalGetSettings()

                Me._hassecondarysearch = tempscraper.Parser.HasFunction("CreateArtistSearchUrl") OrElse tempscraper.Parser.HasFunction("CreateConsoleSearchUrl")

                If Not IsNothing(doc.Root.Attribute("thumb")) Then
                    Dim thumb As String = doc.Root.Attribute("thumb").Value
                    If Not String.IsNullOrEmpty(thumb) Then
                        Me._scraperthumb = Path.Combine(Path.GetDirectoryName(xmlPath), thumb)
                    End If
                End If

                If Not IsNothing(doc.Root.Attribute("framework")) Then
                    Me._scraperframework = doc.Root.Attribute("framework").Value
                End If

                If Not IsNothing(doc.Root.Attribute("date")) Then
                    Me._scraperdate = doc.Root.Attribute("date").Value
                End If

                If Not IsNothing(doc.Root.Attribute("language")) Then
                    Me._scraperlanguage = doc.Root.Attribute("language").Value
                End If

                Me._adultcontent = False

                If Not IsNothing(doc.Root.Attribute("adult")) Then
                    Dim adult As String = doc.Root.Attribute("adult").Value
                    If adult = "true" OrElse adult = "yes" Then
                        Me._adultcontent = True
                    End If
                End If

                Return True
            End Function

#End Region 'Methods

        End Class

    End Namespace
End Namespace