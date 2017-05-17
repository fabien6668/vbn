Imports System.Data.Common
Imports System.Configuration
Imports _17_bibliothequeADO.NET_DLL.Biblio

Public Class BibliothequeDAO

#Region "Propriétés"
    Public Shared Property Cxt() As DbConnection
    Public Shared Property Factory() As DbProviderFactory


#End Region

    Public Shared Sub InitConnection()
        Dim settings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("VBN")
        Factory = DbProviderFactories.GetFactory(settings.ProviderName)
        Cxt = Factory.CreateConnection()
        Cxt.ConnectionString = settings.ConnectionString
    End Sub

#Region "Code nécessaire à la première utilisation du code UNIQUEMENT, pour init de la base"
    Public Shared Property InitFactory() As DbProviderFactory
    Public Shared Sub InitConnectionForFirstAccess()

        Dim initsettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings("VBNMASTER")
        InitFactory = DbProviderFactories.GetFactory(initsettings.ProviderName)
        Cxt = InitFactory.CreateConnection()
        Cxt.ConnectionString = initsettings.ConnectionString
    End Sub
    Public Shared Sub InitDb()

        InitConnectionForFirstAccess()
        Cxt.Open()
        DropDatabase()
        CreateDatabase()
        Cxt.Close()

        InitConnection()
        Cxt.Open()
        CreateDocTable()
        CreateDocuments()
        CreateIndexTable()
        CreateTopics()

        Cxt.Close()
    End Sub

    Private Shared Sub DropDatabase()

        Dim cmd As DbCommand = InitFactory.CreateCommand()
        cmd.CommandText = "IF EXISTS(SELECT name FROM sys.databases WHERE name = 'bibliotheque') DROP DATABASE bibliotheque"

        cmd.Connection = Cxt
        Dim resultat As Integer = cmd.ExecuteNonQuery()
        Debug.WriteLine("Résultat du drop : " & resultat)
    End Sub

    Private Shared Sub CreateDatabase()


        Dim cmd As DbCommand = InitFactory.CreateCommand()
        cmd.CommandText = "CREATE DATABASE bibliotheque"
        cmd.Connection = Cxt
        cmd.ExecuteNonQuery()

    End Sub

    Private Shared Sub CreateDocTable()


        Dim cmd As DbCommand = Factory.CreateCommand()
        cmd.Connection = Cxt
        cmd.CommandText = "CREATE TABLE documents(titre CHAR(50), pages INT, auteur CHAR(50), editeur CHAR(50), frequence CHAR(10), classe INT)"

        cmd.ExecuteNonQuery()

    End Sub
    Private Shared Sub CreateIndexTable()


        Dim cmd As DbCommand = Factory.CreateCommand()
        cmd.Connection = Cxt
        cmd.CommandText = "CREATE TABLE topics(titre CHAR(50),topic CHAR(50))"

        cmd.ExecuteNonQuery()

    End Sub
    Private Shared Sub CreateDocuments()

        Dim titre As String = "Le meilleur des mondes"
        Dim pages As Integer = 300
        Dim auteur As String = "A Huxley"
        Dim editeur As String = "O Reilly"

        CreateDocument(titre, pages, auteur, editeur)
        CreateDocument("WPF 4 Unleashed", 600, "Adam Nathan", "Sams")
        CreateDocument("ASP.NET", 400, "Stephen Walther", "Sams")
        CreateDocument("Windows Powershell", 350, "Laurent Bugnion", "Sams")

    End Sub
    Private Shared Sub CreateTopics()

        CreateTopic("Le meilleur des mondes", "Science")
        CreateTopic("WPF 4 Unleashed", "VB.NET")
        CreateTopic("ASP.NET", "VB.NET")
        CreateTopic("Windows Powershell", "Windows")

    End Sub

    Private Shared Sub CreateDocument(ByVal titre As String, ByVal pages As Integer, ByVal auteur As String, ByVal editeur As String)

        Dim str As String = "INSERT INTO  documents(titre,pages,auteur,editeur,frequence,classe) VALUES( @titre,@pages,@auteur,@editeur,'',1)"

        Dim cmd As DbCommand = Factory.CreateCommand()
        cmd.CommandText = str
        cmd.Connection = Cxt

        Dim p1 As DbParameter = cmd.CreateParameter()
        p1.DbType = DbType.String
        p1.ParameterName = "titre"
        p1.Value = titre

        'Dim p2 As DbParameter = cmd.CreateParameter()
        'p2.DbType = DbType.DateTime
        'p2.ParameterName = "date"
        'p2.Value = dat

        Dim p3 As DbParameter = cmd.CreateParameter()
        p3.DbType = DbType.Int32
        p3.ParameterName = "pages"
        p3.Value = pages

        Dim p4 As DbParameter = cmd.CreateParameter()
        p4.DbType = DbType.String
        p4.ParameterName = "auteur"
        p4.Value = auteur

        Dim p5 As DbParameter = cmd.CreateParameter()
        p5.DbType = DbType.String
        p5.ParameterName = "editeur"
        p5.Value = editeur

        cmd.Parameters.Add(p1)
        'cmd.Parameters.Add(p2)
        cmd.Parameters.Add(p3)
        cmd.Parameters.Add(p4)
        cmd.Parameters.Add(p5)

        cmd.ExecuteNonQuery()
    End Sub
    Private Shared Sub CreateTopic(ByVal titre As String, ByVal topic As String)

        Dim str As String = "INSERT INTO  topics(titre,topic) VALUES( @titre,@topic)"

        Dim cmd As DbCommand = Factory.CreateCommand()
        cmd.CommandText = str
        cmd.Connection = Cxt

        Dim p1 As DbParameter = cmd.CreateParameter()
        p1.DbType = DbType.String
        p1.ParameterName = "titre"
        p1.Value = titre


        Dim p2 As DbParameter = cmd.CreateParameter()
        p2.DbType = DbType.String
        p2.ParameterName = "topic"
        p2.Value = topic

        cmd.Parameters.Add(p1)
        cmd.Parameters.Add(p2)
     
        cmd.ExecuteNonQuery()
    End Sub
#End Region

    Public Shared Function GetAllDocuments() As IEnumerable(Of Object)

        InitConnection()
        Cxt.Open()

        Dim data As List(Of Document) = New List(Of Document)()

        Dim cmd As DbCommand = Factory.CreateCommand()
        cmd.Connection = Cxt
        cmd.CommandText = "SELECT * FROM documents"

        Dim rdr As DbDataReader = cmd.ExecuteReader()

        While (rdr.Read())

            Dim cat As Integer = rdr.GetInt32(5)

            If (cat = 1) Then
                data.Add(New Livre(rdr.GetString(0), rdr.GetString(2), rdr.GetString(3), rdr.GetInt32(1)))
            ElseIf (cat = 2) Then
                '   data.Add (new Revue(rdr.GetString (0),rdr.GetInt32(2),rdr.GetDateTime (1),rdr.GetString (3),rdr.GetString (4)))
            End If
        End While

        rdr.Close()

        Cxt.Close()
        Return data
    End Function
    Public Shared Function GetAllIndexes() As IEnumerable(Of Object)

        InitConnection()
        Cxt.Open()

        Dim data As List(Of String) = New List(Of String)()

        Dim cmd As DbCommand = Factory.CreateCommand()
        cmd.Connection = Cxt
        cmd.CommandText = "SELECT * FROM topics"

        Dim rdr As DbDataReader = cmd.ExecuteReader()

        While (rdr.Read())


            data.Add(rdr.GetString(1))
           
        End While

        rdr.Close()

        Cxt.Close()
        Return data
    End Function

    Public Shared Function CreateDataset() As DataSet

        InitConnection()

        Dim ds As DataSet = New DataSet()

        Dim cmd As DbCommand = Factory.CreateCommand()
        cmd.CommandText = "SELECT * FROM documents"
        cmd.Connection = Cxt

        Dim db As DbDataAdapter = Factory.CreateDataAdapter()
        db.SelectCommand = cmd

        db.Fill(ds)

        Return ds

    End Function

    Shared Sub AjouteDocument(ByVal p1 As String, ByVal p2 As String, ByVal p3 As String, ByVal p4 As String, ByVal p5 As Integer)
        Throw New NotImplementedException
    End Sub

    Shared Function GetAllDocumentsForIndex(ByVal selec As String) As Object
        InitConnection()
        Cxt.Open()

        Dim data As List(Of Document) = New List(Of Document)()

        Dim cmd As DbCommand = Factory.CreateCommand()
        cmd.Connection = Cxt
        cmd.CommandText = "SELECT * FROM documents, topics WHERE topics.titre=documents.titre AND topics.topic='" & selec & "'"

        Dim rdr As DbDataReader = cmd.ExecuteReader()

        While (rdr.Read())

            Dim cat As Integer = rdr.GetInt32(5)

            If (cat = 1) Then
                data.Add(New Livre(rdr.GetString(0), rdr.GetString(2), rdr.GetString(3), rdr.GetInt32(1)))
            ElseIf (cat = 2) Then
                '   data.Add (new Revue(rdr.GetString (0),rdr.GetInt32(2),rdr.GetDateTime (1),rdr.GetString (3),rdr.GetString (4)))
            End If
        End While

        rdr.Close()

        Cxt.Close()
        Return data
    End Function

End Class
