Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports System.Reflection

Public Class Form1
    <DllImport("user32.dll")>
    Public Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As UInteger) As Boolean
    End Function

    Public Const SWP_NOSIZE As UInteger = &H1
    Public Const SWP_NOZORDER As UInteger = &H4
    Public Const SWP_SHOWWINDOW As UInteger = &H40

    Private timerCount As Integer = 0
    Private timerTarget As Integer = 100
    Private Sub MoveWindow()
        Dim x As Integer = 0
        Dim y As Integer = 0
        Dim xDirection As Integer = 10
        Dim yDirection As Integer = 10

        Do While True
            SetWindowPos(Me.Handle, IntPtr.Zero, x, y, 0, 0, SWP_NOSIZE Or SWP_NOZORDER Or SWP_SHOWWINDOW)

            x += xDirection
            y += yDirection

            If x + Me.Width >= Screen.PrimaryScreen.Bounds.Width OrElse x <= 0 Then
                xDirection *= -1
            End If

            If y + Me.Height >= Screen.PrimaryScreen.Bounds.Height OrElse y <= 0 Then
                yDirection *= -1
            End If

            Threading.Thread.Sleep(9) ' Adjust the delay as desired
        Loop
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim t As New Thread(AddressOf MoveWindow)
        Dim tempFilePath As String = Path.GetTempFileName()
        WebBrowser1.Url = New Uri(Path.GetFullPath("youare.swf"))



        ' Load the SWF file into the WebBrowser control




        ' Adjust the form properties
        Me.FormBorderStyle = FormBorderStyle.None
        t.Start()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        timerCount += 1

        If timerCount = timerTarget Then
            Dim newForm As New Form1()
            newForm.Show()
        End If
    End Sub
End Class













