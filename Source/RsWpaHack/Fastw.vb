Imports System.Security.Cryptography
Imports System.Text

Public Class Fastw

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim DBytes_string As String = "223311340281FA22114168111201052271421066"
        Dim union = String.Concat(textbox1.Text, DBytes_string)
        Dim Unionbyte = getBytesFromHexStr(union)
        Dim FinalWpa As String

        Dim m5 As New Security.Cryptography.MD5CryptoServiceProvider
        m5.Initialize()
        Unionbyte = m5.ComputeHash(Unionbyte)
       
        Dim finalstring As String = Nothing
        For Each bt As Byte In Unionbyte
            finalstring &= bt.ToString("x2")
        Next

        finalstring = finalstring.ToUpper()

        ' Rs Comment: Converto i primi 4 caratt. della stringa Md5 in binario
        Dim count As Integer = 0
        Dim hexarray As String() = New String(3) {}
        Dim decarray As String() = New String(3) {}
        Dim binarray As String() = New String(3) {}
        Dim stringabinaria As String
        Dim bin5bits As String() = New String(4) {}
        Dim index = 0

        For i = 0 To 6 Step 2
            hexarray(count) = finalstring.Substring(i, 2)
            count += 1
        Next

        For i = 0 To 3
            decarray(i) = esadecimale(hexarray(i))
        Next

        For i = 0 To 3
            binarray(i) = ToBinary(decarray(i))
            While (binarray(i).Length.ToString < 8)
                binarray(i) = "0" & binarray(i)
            End While
        Next

        For i = 0 To 3
            stringabinaria = stringabinaria & binarray(i)
        Next

        For i = 0 To 4
            bin5bits(i) = stringabinaria.Substring(index, 5)
            index += 5

        Next

        For i = 0 To 4
            bin5bits(i) = BinToDec(bin5bits(i))
           
        Next

        For i = 0 To 4
            If bin5bits(i) > 10 Then
                bin5bits(i) = bin5bits(i) + 87
            End If
            bin5bits(i) = Conversion.Hex(bin5bits(i))
            While (bin5bits(i).Length.ToString < 2)
                bin5bits(i) = "0" & bin5bits(i)
            End While
        Next

        For i = 0 To 4
            FinalWpa = FinalWpa & bin5bits(i)
        Next

        MsgBox(FinalWpa.ToLower)
        Clipboard.SetDataObject(FinalWpa.ToLower)
        MsgBox("Chiave Wpa copiata , è possibile eseguire il copia/incolla")



    End Sub


    Public Function getBytesFromHexStr(ByVal tStr As String) As Byte()
        Dim i As Integer = 0
        Dim tBytes As New List(Of Byte)

        For i = 0 To (tStr.Length - 1) Step 2
            tBytes.Add(CByte("&H" & tStr.Substring(i, 2)))
        Next

        Return tBytes.ToArray
    End Function


    Function ToBinary(ByVal Num As Decimal) As String
        Dim sbBinary As New System.Text.StringBuilder

        Do
            sbBinary.Insert(0, If(Num / 2 <> Int(Num / 2), 1, 0))
            Num = Int(Num / 2)
        Loop Until Num = 0

        Return sbBinary.ToString()
    End Function

    Function esadecimale(ByVal numero)
        Dim n, i, cifra, decimale
        decimale = 0
        n = Len(numero)
        For i = 1 To n
            decimale = decimale * 16
            cifra = Mid(numero, i, 1)
            decimale = decimale + InStr("0123456789ABCDEF", cifra) - 1
        Next
        esadecimale = decimale
    End Function

    Function BinToDec(ByVal value As String) As Long
        Dim result As Long, i As Integer, exponent As Integer
        For i = Len(value) To 1 Step -1
            Select Case Asc(Mid$(value, i, 1))
                Case 48   ' "0", do nothing
                Case 49   ' "1", add the corresponding power of 2
                    result = result Or Power2(exponent)
                Case Else
                    Err.Raise(5)   ' Invalid procedure call or argument
            End Select
            exponent = exponent + 1
        Next
        BinToDec = result
    End Function

    Function Power2(ByVal exponent As Long) As Long
        Static res(0 To 31) As Long
        Dim i As Long

        ' rule out errors
        If exponent < 0 Or exponent > 31 Then Err.Raise(5)

        ' initialize the array at the first call
        If res(0) = 0 Then
            res(0) = 1
            For i = 1 To 30
                res(i) = res(i - 1) * 2
            Next
            ' this is a special case
            res(31) = &H80000000
        End If

        ' return the result
        Power2 = res(exponent)

    End Function


    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        MessageBox.Show("Programma sviluppato da Rs9000" & vbNewLine & "per info: Rs9000.dc@gmail.com" & vbNewLine & vbNewLine & "www.rs9000.eu", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button3)

    End Sub

  
  
    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        Form1.Show()
    End Sub
End Class