﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:2.0.50727.3074
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'This class was auto-generated by the StronglyTypedResourceBuilder
    'class via a tool like ResGen or Visual Studio.
    'To add or remove a member, edit your .ResX file then rerun ResGen
    'with the /str option, or rebuild your VS project.
    '''<summary>
    '''  A strongly-typed resource class, for looking up localized strings, etc.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Returns the cached ResourceManager instance used by this class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("Ember_Media_Manager.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Overrides the current thread's CurrentUICulture property for all
        '''  resource lookups using this strongly typed resource class.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        Friend ReadOnly Property actor_silhouette() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("actor_silhouette", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property Logo() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Logo", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;center&gt;&lt;b&gt;Movie List&lt;/b&gt;&lt;/center&gt;&lt;/br&gt;.
        '''</summary>
        Friend ReadOnly Property MediaListLogo() As String
            Get
                Return ResourceManager.GetString("MediaListLogo", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to 
        '''&lt;/body&gt;
        '''&lt;/html&gt;.
        '''</summary>
        Friend ReadOnly Property MovieListFooter() As String
            Get
                Return ResourceManager.GetString("MovieListFooter", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;html&gt;
        '''&lt;head&gt;
        '''&lt;style type=&quot;text/css&quot;&gt;
        '''&lt;!--
        '''body {background: #FFFFFF; /* The background of the page will be colored white */}
        '''a:link {color: #000000; /* All unvisited links will be colored black */ }
        '''a:visited {color: #FF9900; /* All visited links will be colored tan */ }
        '''a:active {color: #FF0000; /* All active links will be colored red */}
        '''a:hover {color: #0000FF; background: #FFFF00;}
        '''/* When the mouse pointer is over the link the link will be colored blue
        '''and the background color of the link wi [rest of string was truncated]&quot;;.
        '''</summary>
        Friend ReadOnly Property MovieListHeader() As String
            Get
                Return ResourceManager.GetString("MovieListHeader", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to .
        '''</summary>
        Friend ReadOnly Property MovieListTableCol() As String
            Get
                Return ResourceManager.GetString("MovieListTableCol", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;/table&gt;
        '''&lt;/center&gt;.
        '''</summary>
        Friend ReadOnly Property MovieListTableEnd() As String
            Get
                Return ResourceManager.GetString("MovieListTableEnd", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to .
        '''</summary>
        Friend ReadOnly Property MovieListTableHeader() As String
            Get
                Return ResourceManager.GetString("MovieListTableHeader", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to .
        '''</summary>
        Friend ReadOnly Property MovieListTableRowEnd() As String
            Get
                Return ResourceManager.GetString("MovieListTableRowEnd", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to .
        '''</summary>
        Friend ReadOnly Property MovieListTableRowStart() As String
            Get
                Return ResourceManager.GetString("MovieListTableRowStart", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Looks up a localized string similar to &lt;center&gt;
        '''&lt;table class=&quot;emm_table&quot;&gt;
        '''&lt;tr&gt;
        '''&lt;th style=&quot;text-align:left; &quot;&gt;Title&lt;/th&gt;
        '''&lt;th style=&quot;text-align:center;&quot;&gt;Year&lt;/th&gt;
        '''&lt;th style=&quot;text-align:center;&quot;&gt;Video&lt;/th&gt;
        '''&lt;th style=&quot;text-align:center;&quot;&gt;Audio&lt;/th&gt;&lt;/tr&gt;.
        '''</summary>
        Friend ReadOnly Property MovieListTableStart() As String
            Get
                Return ResourceManager.GetString("MovieListTableStart", resourceCulture)
            End Get
        End Property
        
        Friend ReadOnly Property overlay() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("overlay", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property overlay2() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("overlay2", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property Play_Icon() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Play_Icon", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property Splash() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Splash", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property star() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("star", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property starhalf() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("starhalf", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        Friend ReadOnly Property television() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("television", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        Friend ReadOnly Property Wizard() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Wizard", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
    End Module
End Namespace
