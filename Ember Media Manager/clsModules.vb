﻿
Option Strict Off
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Public Interface EmberExternalModule
    Sub Enable()
    Sub Disable()
    Sub Setup()
    Sub Init(ByRef emm As Object)
    ReadOnly Property ModuleName() As String
    ReadOnly Property ModuleVersion() As String
End Interface

Public Interface EmberScraperModule
    Sub Setup()
    Function ExecFase1(ByVal MovieTitle As String, ByVal Id As String) As ArrayList
    Function ExecFase2(ByVal MovieTitle As String, ByVal Id As String) As Media.Movie
    Function ExecPost(ByVal Movie As Media.Movie) As Media.Movie
    ReadOnly Property ModuleName() As String
    ReadOnly Property ModuleVersion() As String
    ReadOnly Property IsScraper() As Boolean
    ReadOnly Property IsPostScraper() As Boolean
End Interface

Public Class EmberModules
    Class _EmberAPI
        Private _MenuMediaList As System.Windows.Forms.ContextMenuStrip
        Private _MediaList As System.Windows.Forms.DataGridView
        Public EmberAPP As Object = frmMain
        Public DB As Object = Master.DB
        Public FileDelete As New FileManip.Delete
        Public AppPAth As Object = Master.AppPath
        Sub New()
            _MenuMediaList = frmMain.mnuMediaList
            _MediaList = frmMain.dgvMediaList
        End Sub
        Public ReadOnly Property MenuMediaList() As System.Windows.Forms.ContextMenuStrip
            Get
                Return _MenuMediaList
            End Get
        End Property
        Public ReadOnly Property MediaList() As System.Windows.Forms.DataGridView
            Get
                Return _MediaList
            End Get
        End Property
    End Class
    <XmlRoot("EmberModule")> _
    Class _XMLEmberModuleClass
        Public Enabled As Boolean
        Public AssemblyName As String
    End Class
    Class _externalProcessorModuleClass
        Public ProcessorModule As Object
        Public Enabled As Boolean
        Public AssemblyName As String
    End Class
    Class _externalScraperModuleClass
        Public ProcessorModule As Object
        Public Enabled As Boolean
        Public AssemblyName As String
        Public IsScraper As Boolean
        Public IsPostScraper As Boolean
    End Class

    Public EmberAPI As New _EmberAPI
    Public externalProcessorModules As New List(Of _externalProcessorModuleClass)
    Public externalScrapersModules As New List(Of _externalScraperModuleClass)
    Private moduleLocation As String = Path.Combine(Master.AppPath, "Modules")

    Public Sub loadModules()

        If Directory.Exists(moduleLocation) Then
            'Assembly to load the file
            Dim assembly As System.Reflection.Assembly
            'For each .dll file in the module directory
            For Each file As String In System.IO.Directory.GetFiles(moduleLocation, "*.dll")
                'Load the assembly
                assembly = System.Reflection.Assembly.LoadFrom(file)
                'Loop through each of the assemeblies type
                For Each fileType As Type In assembly.GetTypes
                    Try
                        'Activate the located module
                        Dim t As Type = fileType.GetInterface("EmberExternalModule")
                        If Not t Is Nothing Then
                            Dim ProcessorModule As New Object
                            ProcessorModule = Activator.CreateInstance(fileType)
                            'Add the activated module to the arraylist
                            Dim _externalProcessorModule As New _externalProcessorModuleClass
                            _externalProcessorModule.ProcessorModule = ProcessorModule
                            _externalProcessorModule.AssemblyName = Path.GetFileName(file)
                            For Each i In Master.eSettings.EmberModules
                                If i.AssemblyName = _externalProcessorModule.AssemblyName Then
                                    _externalProcessorModule.Enabled = i.Enabled
                                End If
                            Next
                            externalProcessorModules.Add(_externalProcessorModule)
                            ProcessorModule.Init(EmberAPI)
                            If _externalProcessorModule.Enabled Then
                                ProcessorModule.Enable()
                            Else
                                ProcessorModule.Disable()
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Next
            Next
        End If
    End Sub

    Public Sub loadScrapersModules()
        If Directory.Exists(moduleLocation) Then
            'Assembly to load the file
            Dim assembly As System.Reflection.Assembly
            'For each .dll file in the module directory
            For Each file As String In System.IO.Directory.GetFiles(moduleLocation, "*.dll")
                'Load the assembly
                assembly = System.Reflection.Assembly.LoadFrom(file)
                'Loop through each of the assemeblies type
                For Each fileType As Type In assembly.GetTypes
                    Try
                        'Activate the located module
                        Dim t As Type = fileType.GetInterface("EmberScraperModule")
                        If Not t Is Nothing Then
                            Dim ProcessorModule As New Object
                            ProcessorModule = Activator.CreateInstance(fileType)
                            'Add the activated module to the arraylist
                            Dim _externalScraperModule As New _externalScraperModuleClass
                            _externalScraperModule.ProcessorModule = ProcessorModule
                            _externalScraperModule.AssemblyName = Path.GetFileName(file)
                            For Each i In Master.eSettings.EmberModules
                                If i.AssemblyName = _externalScraperModule.AssemblyName Then
                                    _externalScraperModule.Enabled = i.Enabled
                                End If
                            Next
                            externalScrapersModules.Add(_externalScraperModule)
                        End If
                    Catch ex As Exception
                    End Try
                Next
            Next
        End If
    End Sub

    Dim WithEvents ModulesMenu As New System.Windows.Forms.ToolStripMenuItem
    Sub New()
        ModulesMenu.Text = "Modules Settings"
        frmMain.EditToolStripMenuItem.DropDownItems.Add(ModulesMenu)
        loadModules()
        loadScrapersModules()
    End Sub
    Private Sub ModulesMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModulesMenu.Click
        Dim modulesSetup As New dlgModuleSettings
        For Each _externalProcessorModule In externalProcessorModules
            Dim li As ListViewItem = modulesSetup.lstModules.Items.Add(_externalProcessorModule.ProcessorModule.ModuleName())
            If _externalProcessorModule.Enabled Then
                li.SubItems.Add("Enabled")
            Else
                li.SubItems.Add("Disabled")
            End If
            li.SubItems.Add("Disabled")
            li.Tag = _externalProcessorModule.AssemblyName
        Next
        modulesSetup.ModulesManager = Me
        modulesSetup.ShowDialog()
    End Sub
    Public Sub RunModuleSetup(ByVal ModuleAssembly As String)
        For Each _externalProcessorModule In externalProcessorModules
            If _externalProcessorModule.AssemblyName = ModuleAssembly Then
                _externalProcessorModule.ProcessorModule.Setup()
            End If
        Next
    End Sub
    Public Sub SetModuleEnable(ByVal ModuleAssembly As String, ByVal value As Boolean)
        For Each _externalProcessorModule In externalProcessorModules
            If _externalProcessorModule.AssemblyName = ModuleAssembly Then
                _externalProcessorModule.Enabled = value
                If value = True Then
                    _externalProcessorModule.ProcessorModule.Enable()
                Else
                    _externalProcessorModule.ProcessorModule.Disable()
                End If
            End If
        Next
    End Sub
    Public Sub SaveSettings()
        Dim tmpForXML As New List(Of _XMLEmberModuleClass)

        For Each _externalProcessorModule As _externalProcessorModuleClass In externalProcessorModules
            Dim t As New _XMLEmberModuleClass
            t.AssemblyName = _externalProcessorModule.AssemblyName
            t.Enabled = _externalProcessorModule.Enabled
            tmpForXML.Add(t)
        Next
        Master.eSettings.EmberModules = tmpForXML
        Master.eSettings.Save()
    End Sub
End Class