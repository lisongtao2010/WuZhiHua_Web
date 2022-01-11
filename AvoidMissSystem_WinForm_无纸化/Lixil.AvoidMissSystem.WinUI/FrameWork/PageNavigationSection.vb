Imports System.Configuration

''' <summary>
''' アプリケーション構成ファイル内の画面定義
''' </summary>
''' <remarks></remarks>
Public Class PageNavigationSection
    Inherits ConfigurationSection
    Public Sub New()
    End Sub

    <ConfigurationProperty("pages")> _
    Public ReadOnly Property Pages() As PageDefinitionCollection
        Get
            Return CType(Me("pages"), PageDefinitionCollection)
        End Get
    End Property
End Class

<ConfigurationCollection(GetType(PageDefinition))> _
Public Class PageDefinitionCollection
    Inherits ConfigurationElementCollection
    Protected Overrides Function CreateNewElement() As ConfigurationElement
        Return New PageDefinition()
    End Function

    Protected Overrides Function GetElementKey(ByVal element As ConfigurationElement) As Object
        Dim page As PageDefinition = CType(element, PageDefinition)
        Return page.Name
    End Function

    Protected Overrides ReadOnly Property ElementName() As String
        Get
            Return "page"
        End Get
    End Property

    Public Overrides ReadOnly Property CollectionType() As ConfigurationElementCollectionType
        Get
            Return ConfigurationElementCollectionType.BasicMap
        End Get
    End Property

    Default Public Shadows ReadOnly Property Item(ByVal name As String) As PageDefinition
        Get
            Return CType(BaseGet(name), PageDefinition)
        End Get
    End Property
End Class

Public Class PageDefinition
    Inherits ConfigurationElement
    <ConfigurationProperty("name", IsRequired:=True)> _
    Public Property Name() As String
        Get
            Return CStr(Me("name"))
            '            Return CType(Me("name"), String)
        End Get
        Set(ByVal Value As String)
            Me("name") = Value
        End Set
    End Property

    <ConfigurationProperty("form", IsRequired:=True)> _
    Public Property FormName() As String
        Get
            Return CStr(Me("form"))
            '            Return CType(Me("form"), String)
        End Get
        Set(ByVal Value As String)
            Me("form") = Value
        End Set
    End Property

    <ConfigurationProperty("assembly", IsRequired:=False)> _
    Public Property AssemblyName() As String
        Get
            Return CStr(Me("assembly"))
            '            Return CType(Me("assembly"), String)
        End Get
        Set(ByVal Value As String)
            Me("assembly") = Value
        End Set
    End Property
End Class
