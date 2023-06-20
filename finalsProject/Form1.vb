Imports System.Reflection.Emit
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView

Public Class Form1

    Dim assInput As Double = 0  'asign input
    Dim op As String
    Dim a As Double
    Dim f_e As Boolean = False 'FOUND EXPRESSION
    Dim exp As Boolean
    Dim numberTwo, q As String
    Dim OBJ As New Form2
    Dim number As Double
    Private result As Double




    Private Sub onclick_Op(sender As Object, e As EventArgs) Handles btnPlus.Click, btnMultiply.Click, btnMinus.Click, btnDivide.Click
        Dim b As Button = sender
        If (assInput <> 0) Then
            btnEqual.PerformClick()
            f_e = True
            op = b.Text
            equalEquation.Text = assInput & "    " & op
        Else
            op = b.Text
            assInput = Double.Parse(inputDisplay.Text)
            f_e = True
            equalEquation.Text = assInput & "    " & op

        End If
        q = equalEquation.Text

    End Sub

    Private Sub btnModulus_Click(sender As Object, e As EventArgs) Handles btnModulus.Click
        Dim a As Double
        a = Convert.ToDouble(inputDisplay.Text) / Convert.ToDouble(100)
        inputDisplay.Text = System.Convert.ToString(a)
    End Sub

    Private Sub btnEqual_Click(sender As Object, e As EventArgs) Handles btnEqual.Click
        numberTwo = inputDisplay.Text
        OBJ.Show()

        equalEquation.Text = ""
        Select Case op
            Case "+"
                inputDisplay.Text = (assInput + Double.Parse(inputDisplay.Text)).ToString()
            Case "-"
                inputDisplay.Text = (assInput - Double.Parse(inputDisplay.Text)).ToString()
            Case "x"
                inputDisplay.Text = (assInput * Double.Parse(inputDisplay.Text)).ToString()
            Case "/"
                inputDisplay.Text = (assInput / Double.Parse(inputDisplay.Text)).ToString()

        End Select

        assInput = inputDisplay.Text
        op = ""




        '+++++++++++++--------------***************/////////////////////////////
        ' Display calculation history in Form2
        NewMethod()

    End Sub

    Private Sub NewMethod()
        OBJ.historyLabel.AppendText(q & "    " & numberTwo & "  =  " & vbNewLine)
        OBJ.historyLabel.AppendText(vbNewLine & vbTab & inputDisplay.Text & vbNewLine & vbNewLine)

    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        inputDisplay.Text = "0"
        equalEquation.Text = ""

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If inputDisplay.Text.Length > 0 Then
            inputDisplay.Text = inputDisplay.Text.Remove(inputDisplay.Text.Length - 1, 1)

        End If
        If (inputDisplay.Text = "") Then
            inputDisplay.Text = "0"

        End If
    End Sub

    

    Private Sub onclick_Numbers(sender As Object, e As EventArgs) Handles btnZero.Click, btnTwo.Click, btnThree.Click, btnSix.Click, btnSeven.Click, btnOne.Click, btnNine.Click, btnFour.Click, btnFive.Click, btnEight.Click, btnDot.Click
        Dim b As Button = sender
        If ((inputDisplay.Text = "0") Or (f_e)) Then
            inputDisplay.Text = b.Text
            f_e = False
        ElseIf (b.Text = ".") Then
            If (Not inputDisplay.Text.Contains(".")) Then
                inputDisplay.Text = inputDisplay.Text + b.Text
            End If
        Else
            ' Check if adding the number would exceed the maximum length for displaying
            If (inputDisplay.Text.Replace(",", "").Length < 15) Then
                inputDisplay.Text = inputDisplay.Text + b.Text
                Dim number As Double = Double.Parse(inputDisplay.Text.Replace(",", ""))
                inputDisplay.Text = number.ToString("N0") ' Format with commas for display
            End If
        End If


    End Sub
End Class
