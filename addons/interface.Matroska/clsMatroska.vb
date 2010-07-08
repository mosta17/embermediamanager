﻿Imports EBML
Imports System.IO

Public Class Matroska
    Private _semantic As EbmlSemantic
    Private _doc As EbmlDocument
    Private _filename As String
    'Private _strean As Stream

    Public Sub New()
        _semantic = New EbmlSemantic
        SetupMatroskaSemantic(_semantic)
    End Sub

    Public Sub New(ByVal filename As String, Optional ByVal loadPayLoad As Boolean = False)
        Me.New()
        LoadMKV(filename, loadPayLoad)
    End Sub

    Public Function LoadMKV(ByVal filename As String, Optional ByVal loadPayLoad As Boolean = False) As Boolean
        _filename = filename
        Using fs As New FileStream(filename, FileMode.Open)
            _doc = New EbmlDocument(loadPayLoad, _semantic, fs)
        End Using
        Return True
    End Function

    Public ReadOnly Property EBMLRootElements() As List(Of EbmlElement)
        Get
            Return _doc.RootElements
        End Get
    End Property

    Public ReadOnly Property EBMLSemantic() As EbmlSemantic
        Get
            Return _semantic
        End Get
    End Property



    Public Function IsMatroska() As Boolean
        Return (_doc.GetValueUniqueElement("DocType").ToString = "matroska")
    End Function




    Private Sub SetupMatroskaSemantic(ByVal semantic As EbmlSemantic)
        semantic.AddSemantic(&H18538067, GetType(EbmlContainerElement), "Segment")
        semantic.AddSemantic(&H114D9B74, GetType(EbmlContainerElement), "SeekHead", True)
        semantic.AddSemantic(&H4DBB, GetType(EbmlContainerElement), "Seek", True)
        semantic.AddSemantic(&H53AB, GetType(EbmlBinaryElement), "SeekID")
        semantic.AddSemantic(&H53AC, GetType(EbmlUIntElement), "SeekPosition")
        semantic.AddSemantic(&H1549A966, GetType(EbmlContainerElement), "Info")
        semantic.AddSemantic(&H73A4, GetType(EbmlBinaryElement), "SegmentUID")
        semantic.AddSemantic(&H7384, GetType(EbmlStringElement), "SegmentFilename")
        semantic.AddSemantic(&H3CB923, GetType(EbmlBinaryElement), "PrevUID")
        semantic.AddSemantic(&H3C83AB, GetType(EbmlStringElement), "PrevFilename")
        semantic.AddSemantic(&H3EB923, GetType(EbmlBinaryElement), "NextUID")
        semantic.AddSemantic(&H3E83BB, GetType(EbmlStringElement), "NextFilename")
        semantic.AddSemantic(&H4444, GetType(EbmlBinaryElement), "SegmentFamily")
        semantic.AddSemantic(&H6924, GetType(EbmlContainerElement), "ChapterTranslate")
        semantic.AddSemantic(&H69FC, GetType(EbmlUIntElement), "ChapterTranslateEditionUID")
        semantic.AddSemantic(&H69BF, GetType(EbmlUIntElement), "ChapterTranslateCodec")
        semantic.AddSemantic(&H69A5, GetType(EbmlUIntElement), "ChapterTranslateID")
        semantic.AddSemantic(&H2AD7B1, GetType(EbmlUIntElement), "TimecodeScale")
        semantic.AddSemantic(&H4489, GetType(EbmlFloatElement), "Duration")
        semantic.AddSemantic(&H4461, GetType(EbmlDateElement), "DateUTC")
        semantic.AddSemantic(&H7BA9, GetType(EbmlStringElement), "Title")
        semantic.AddSemantic(&H4D80, GetType(EbmlStringElement), "MuxingApp")
        semantic.AddSemantic(&H5741, GetType(EbmlStringElement), "WritingApp")
        semantic.AddSemantic(&H1F43B675, GetType(EbmlContainerElement), "Cluster", True)
        semantic.AddSemantic(&HE7, GetType(EbmlUIntElement), "Timecode")
        semantic.AddSemantic(&H5854, GetType(EbmlContainerElement), "SilentTracks")
        semantic.AddSemantic(&H58D7, GetType(EbmlUIntElement), "SilentTrackNumber")
        semantic.AddSemantic(&HA7, GetType(EbmlUIntElement), "Position")
        semantic.AddSemantic(&HAB, GetType(EbmlUIntElement), "PrevSize")
        semantic.AddSemantic(&HA3, GetType(EbmlBinaryElement), "SimpleBlock", True)
        semantic.AddSemantic(&HA0, GetType(EbmlContainerElement), "BlockGroup")
        semantic.AddSemantic(&HA1, GetType(EbmlBinaryElement), "Block", True)
        semantic.AddSemantic(&HA2, GetType(EbmlBinaryElement), "BlockVirtual", True)
        semantic.AddSemantic(&H75A1, GetType(EbmlContainerElement), "BlockAdditions")
        semantic.AddSemantic(&HA6, GetType(EbmlContainerElement), "BlockMore")
        semantic.AddSemantic(&HEE, GetType(EbmlUIntElement), "BlockAddID")
        semantic.AddSemantic(&HA5, GetType(EbmlBinaryElement), "BlockAdditional", True)
        semantic.AddSemantic(&H9B, GetType(EbmlUIntElement), "BlockDuration")
        semantic.AddSemantic(&HFA, GetType(EbmlUIntElement), "ReferencePriority")
        semantic.AddSemantic(&HFB, GetType(EbmlSIntElement), "ReferenceBlock")
        semantic.AddSemantic(&HFD, GetType(EbmlSIntElement), "ReferenceVirtual")
        semantic.AddSemantic(&HA4, GetType(EbmlBinaryElement), "CodecState")
        semantic.AddSemantic(&H8E, GetType(EbmlContainerElement), "Slices")
        semantic.AddSemantic(&HE8, GetType(EbmlContainerElement), "TimeSlice")
        semantic.AddSemantic(&HCC, GetType(EbmlUIntElement), "LaceNumber")
        semantic.AddSemantic(&HCD, GetType(EbmlUIntElement), "FrameNumber")
        semantic.AddSemantic(&HCB, GetType(EbmlUIntElement), "BlockAdditionID")
        semantic.AddSemantic(&HCE, GetType(EbmlUIntElement), "Delay")
        semantic.AddSemantic(&HCF, GetType(EbmlUIntElement), "Duration")
        semantic.AddSemantic(&HAF, GetType(EbmlBinaryElement), "EncryptedBlock")
        semantic.AddSemantic(&H1654AE6B, GetType(EbmlContainerElement), "Tracks")
        semantic.AddSemantic(&HAE, GetType(EbmlContainerElement), "TrackEntry")
        semantic.AddSemantic(&HD7, GetType(EbmlUIntElement), "TrackNumber")
        semantic.AddSemantic(&H73C5, GetType(EbmlUIntElement), "TrackUID")
        semantic.AddSemantic(&H83, GetType(EbmlUIntElement), "TrackType")
        semantic.AddSemantic(&HB9, GetType(EbmlUIntElement), "FlagEnabled")
        semantic.AddSemantic(&H88, GetType(EbmlUIntElement), "FlagDefault")
        semantic.AddSemantic(&H55AA, GetType(EbmlUIntElement), "FlagForced")
        semantic.AddSemantic(&H9C, GetType(EbmlUIntElement), "FlagLacing")
        semantic.AddSemantic(&H6DE7, GetType(EbmlUIntElement), "MinCache")
        semantic.AddSemantic(&H6DF8, GetType(EbmlUIntElement), "MaxCache")
        semantic.AddSemantic(&H23E383, GetType(EbmlUIntElement), "DefaultDuration")
        semantic.AddSemantic(&H23314F, GetType(EbmlFloatElement), "TrackTimecodeScale")
        semantic.AddSemantic(&H537F, GetType(EbmlSIntElement), "TrackOffset")
        semantic.AddSemantic(&H55EE, GetType(EbmlUIntElement), "MaxBlockAdditionID")
        semantic.AddSemantic(&H536E, GetType(EbmlStringElement), "Name")
        semantic.AddSemantic(&H22B59C, GetType(EbmlStringElement), "Language")
        semantic.AddSemantic(&H86, GetType(EbmlStringElement), "CodecID")
        semantic.AddSemantic(&H63A2, GetType(EbmlBinaryElement), "CodecPrivate")
        semantic.AddSemantic(&H258688, GetType(EbmlStringElement), "CodecName")
        semantic.AddSemantic(&H7446, GetType(EbmlUIntElement), "AttachmentLink")
        semantic.AddSemantic(&H3A9697, GetType(EbmlStringElement), "CodecSettings")
        semantic.AddSemantic(&H3B4040, GetType(EbmlStringElement), "CodecInfoURL")
        semantic.AddSemantic(&H26B240, GetType(EbmlStringElement), "CodecDownloadURL")
        semantic.AddSemantic(&HAA, GetType(EbmlUIntElement), "CodecDecodeAll")
        semantic.AddSemantic(&H6FAB, GetType(EbmlUIntElement), "TrackOverlay")
        semantic.AddSemantic(&H6624, GetType(EbmlContainerElement), "TrackTranslate")
        semantic.AddSemantic(&H66FC, GetType(EbmlUIntElement), "TrackTranslateEditionUID")
        semantic.AddSemantic(&H66BF, GetType(EbmlUIntElement), "TrackTranslateCodec")
        semantic.AddSemantic(&H66A5, GetType(EbmlUIntElement), "TrackTranslateTrackID")
        semantic.AddSemantic(&HE0, GetType(EbmlContainerElement), "Video")
        semantic.AddSemantic(&H9A, GetType(EbmlUIntElement), "FlagInterlaced")
        semantic.AddSemantic(&H53B8, GetType(EbmlUIntElement), "StereoMode")
        semantic.AddSemantic(&HB0, GetType(EbmlUIntElement), "PixelWidth")
        semantic.AddSemantic(&HBA, GetType(EbmlUIntElement), "PixelHeight")
        semantic.AddSemantic(&H54AA, GetType(EbmlUIntElement), "PixelCropBottom")
        semantic.AddSemantic(&H54BB, GetType(EbmlUIntElement), "PixelCropTop")
        semantic.AddSemantic(&H54CC, GetType(EbmlUIntElement), "PixelCropLeft")
        semantic.AddSemantic(&H54DD, GetType(EbmlUIntElement), "PixelCropRight")
        semantic.AddSemantic(&H54B0, GetType(EbmlUIntElement), "DisplayWidth")
        semantic.AddSemantic(&H54BA, GetType(EbmlUIntElement), "DisplayHeight")
        semantic.AddSemantic(&H54B2, GetType(EbmlUIntElement), "DisplayUnit")
        semantic.AddSemantic(&H54B3, GetType(EbmlUIntElement), "AspectRatioType")
        semantic.AddSemantic(&H2EB524, GetType(EbmlBinaryElement), "ColourSpace")
        semantic.AddSemantic(&H2FB523, GetType(EbmlFloatElement), "GammaValue")
        semantic.AddSemantic(&H2383E3, GetType(EbmlFloatElement), "FrameRate")
        semantic.AddSemantic(&HE1, GetType(EbmlContainerElement), "Audio")
        semantic.AddSemantic(&HB5, GetType(EbmlFloatElement), "SamplingFrequency")
        semantic.AddSemantic(&H78B5, GetType(EbmlFloatElement), "OutputSamplingFrequency")
        semantic.AddSemantic(&H9F, GetType(EbmlUIntElement), "Channels")
        semantic.AddSemantic(&H7D7B, GetType(EbmlBinaryElement), "ChannelPositions")
        semantic.AddSemantic(&H6264, GetType(EbmlUIntElement), "BitDepth")
        semantic.AddSemantic(&H6D80, GetType(EbmlContainerElement), "ContentEncodings")
        semantic.AddSemantic(&H6240, GetType(EbmlContainerElement), "ContentEncoding")
        semantic.AddSemantic(&H5031, GetType(EbmlUIntElement), "ContentEncodingOrder")
        semantic.AddSemantic(&H5032, GetType(EbmlUIntElement), "ContentEncodingScope")
        semantic.AddSemantic(&H5033, GetType(EbmlUIntElement), "ContentEncodingType")
        semantic.AddSemantic(&H5034, GetType(EbmlContainerElement), "ContentCompression")
        semantic.AddSemantic(&H4254, GetType(EbmlUIntElement), "ContentCompAlgo")
        semantic.AddSemantic(&H4255, GetType(EbmlBinaryElement), "ContentCompSettings")
        semantic.AddSemantic(&H5035, GetType(EbmlContainerElement), "ContentEncryption")
        semantic.AddSemantic(&H47E1, GetType(EbmlUIntElement), "ContentEncAlgo")
        semantic.AddSemantic(&H47E2, GetType(EbmlBinaryElement), "ContentEncKeyID")
        semantic.AddSemantic(&H47E3, GetType(EbmlBinaryElement), "ContentSignature")
        semantic.AddSemantic(&H47E4, GetType(EbmlBinaryElement), "ContentSigKeyID")
        semantic.AddSemantic(&H47E5, GetType(EbmlUIntElement), "ContentSigAlgo")
        semantic.AddSemantic(&H47E6, GetType(EbmlUIntElement), "ContentSigHashAlgo")
        semantic.AddSemantic(&H1C53BB6B, GetType(EbmlContainerElement), "Cues", True)
        semantic.AddSemantic(&HBB, GetType(EbmlContainerElement), "CuePoint")
        semantic.AddSemantic(&HB3, GetType(EbmlUIntElement), "CueTime")
        semantic.AddSemantic(&HB7, GetType(EbmlContainerElement), "CueTrackPositions")
        semantic.AddSemantic(&HF7, GetType(EbmlUIntElement), "CueTrack")
        semantic.AddSemantic(&HF1, GetType(EbmlUIntElement), "CueClusterPosition")
        semantic.AddSemantic(&H5378, GetType(EbmlUIntElement), "CueBlockNumber")
        semantic.AddSemantic(&HEA, GetType(EbmlUIntElement), "CueCodecState")
        semantic.AddSemantic(&HDB, GetType(EbmlContainerElement), "CueReference")
        semantic.AddSemantic(&H96, GetType(EbmlUIntElement), "CueRefTime")
        semantic.AddSemantic(&H97, GetType(EbmlUIntElement), "CueRefCluster")
        semantic.AddSemantic(&H535F, GetType(EbmlUIntElement), "CueRefNumber")
        semantic.AddSemantic(&HEB, GetType(EbmlUIntElement), "CueRefCodecState")
        semantic.AddSemantic(&H1941A469, GetType(EbmlContainerElement), "Attachments")
        semantic.AddSemantic(&H61A7, GetType(EbmlContainerElement), "AttachedFile")
        semantic.AddSemantic(&H467E, GetType(EbmlStringElement), "FileDescription")
        semantic.AddSemantic(&H466E, GetType(EbmlStringElement), "FileName")
        semantic.AddSemantic(&H4660, GetType(EbmlStringElement), "FileMimeType")
        semantic.AddSemantic(&H465C, GetType(EbmlBinaryElement), "FileData")
        semantic.AddSemantic(&H46AE, GetType(EbmlUIntElement), "FileUID")
        semantic.AddSemantic(&H4675, GetType(EbmlBinaryElement), "FileReferral")
        semantic.AddSemantic(&H1043A770, GetType(EbmlContainerElement), "Chapters")
        semantic.AddSemantic(&H45B9, GetType(EbmlContainerElement), "EditionEntry")
        semantic.AddSemantic(&H45BC, GetType(EbmlUIntElement), "EditionUID")
        semantic.AddSemantic(&H45BD, GetType(EbmlUIntElement), "EditionFlagHidden")
        semantic.AddSemantic(&H45DB, GetType(EbmlUIntElement), "EditionFlagDefault")
        semantic.AddSemantic(&H45DD, GetType(EbmlUIntElement), "EditionFlagOrdered")
        semantic.AddSemantic(&HB6, GetType(EbmlContainerElement), "ChapterAtom")
        semantic.AddSemantic(&H73C4, GetType(EbmlUIntElement), "ChapterUID")
        semantic.AddSemantic(&H91, GetType(EbmlUIntElement), "ChapterTimeStart")
        semantic.AddSemantic(&H92, GetType(EbmlUIntElement), "ChapterTimeEnd")
        semantic.AddSemantic(&H98, GetType(EbmlUIntElement), "ChapterFlagHidden")
        semantic.AddSemantic(&H4598, GetType(EbmlUIntElement), "ChapterFlagEnabled")
        semantic.AddSemantic(&H6E67, GetType(EbmlBinaryElement), "ChapterSegmentUID")
        semantic.AddSemantic(&H6EBC, GetType(EbmlBinaryElement), "ChapterSegmentEditionUID")
        semantic.AddSemantic(&H63C3, GetType(EbmlUIntElement), "ChapterPhysicalEquiv")
        semantic.AddSemantic(&H8F, GetType(EbmlContainerElement), "ChapterTrack")
        semantic.AddSemantic(&H89, GetType(EbmlUIntElement), "ChapterTrackNumber")
        semantic.AddSemantic(&H80, GetType(EbmlContainerElement), "ChapterDisplay")
        semantic.AddSemantic(&H85, GetType(EbmlStringElement), "ChapString")
        semantic.AddSemantic(&H437C, GetType(EbmlStringElement), "ChapLanguage")
        semantic.AddSemantic(&H437E, GetType(EbmlStringElement), "ChapCountry")
        semantic.AddSemantic(&H6944, GetType(EbmlContainerElement), "ChapProcess")
        semantic.AddSemantic(&H6955, GetType(EbmlUIntElement), "ChapProcessCodecID")
        semantic.AddSemantic(&H450D, GetType(EbmlBinaryElement), "ChapProcessPrivate")
        semantic.AddSemantic(&H6911, GetType(EbmlContainerElement), "ChapProcessCommand")
        semantic.AddSemantic(&H6922, GetType(EbmlUIntElement), "ChapProcessTime")
        semantic.AddSemantic(&H6933, GetType(EbmlBinaryElement), "ChapProcessData")
        semantic.AddSemantic(&H1254C367, GetType(EbmlContainerElement), "Tags")
        semantic.AddSemantic(&H7373, GetType(EbmlContainerElement), "Tag")
        semantic.AddSemantic(&H63C0, GetType(EbmlContainerElement), "Targets")
        semantic.AddSemantic(&H68CA, GetType(EbmlUIntElement), "TargetTypeValue")
        semantic.AddSemantic(&H63CA, GetType(EbmlStringElement), "TargetType")
        semantic.AddSemantic(&H63C5, GetType(EbmlUIntElement), "TrackUID")
        semantic.AddSemantic(&H63C9, GetType(EbmlUIntElement), "EditionUID")
        semantic.AddSemantic(&H63C4, GetType(EbmlUIntElement), "ChapterUID")
        semantic.AddSemantic(&H63C6, GetType(EbmlUIntElement), "AttachmentUID")
        semantic.AddSemantic(&H67C8, GetType(EbmlContainerElement), "SimpleTag")
        semantic.AddSemantic(&H45A3, GetType(EbmlStringElement), "TagName")
        semantic.AddSemantic(&H447A, GetType(EbmlStringElement), "TagLanguage")
        semantic.AddSemantic(&H4484, GetType(EbmlUIntElement), "TagDefault")
        semantic.AddSemantic(&H4487, GetType(EbmlStringElement), "TagString")
        semantic.AddSemantic(&H4485, GetType(EbmlBinaryElement), "Tagtypeof (EbmlBinaryElement)")
    End Sub

End Class
