Imports System.Drawing.Imaging
Imports System.IO
Imports Syncfusion.Windows.Forms.Grid

Public Class Form1

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        PopulateData()


        Dim t As Timer
        ' Initialize the PictureBox and load an image into it
        pb = New PictureBox()
        pb.Image = Image.FromFile("D:\T682565 and T682861\GridControl_PictureBox_VB\Data\Lock.gif")
        pb.SizeMode = PictureBoxSizeMode.StretchImage ' Set the size mode for the picture box image

        ' Initialize and start the Timer
        t = New Timer()
        t.Interval = 1000 ' Set the interval for the timer (in milliseconds)
        AddHandler t.Tick, AddressOf t_Tick
        t.Start()

        AddHandler Me.Load, AddressOf Form1_Load
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs)
        ' Hook the QueryCellInfo event
        AddHandler GridControl1.QueryCellInfo, AddressOf GridControl1_QueryCellInfo
    End Sub

    Private Sub GridControl1_QueryCellInfo(sender As Object, e As GridQueryCellInfoEventArgs)
        ' Check if it's the correct cell (1,1)
        If e.ColIndex = 1 AndAlso e.RowIndex = 1 Then
            ' Set the cell type to Control to allow custom control insertion (PictureBox)
            e.Style.CellType = GridCellTypeName.Control
            ' Assign the PictureBox control to the cell
            e.Style.Control = pb
        End If
    End Sub

    Private Sub PopulateData()

        GridControl1.RowHeights.SetSize(1, 50)

        'Specifying row and column count
        GridControl1.RowCount = 10
        GridControl1.ColCount = 4

        'Looping through the cells and assigning the values based on row and column index
        For row As Integer = 1 To GridControl1.RowCount
            For col As Integer = 1 To GridControl1.ColCount
                GridControl1.Model(row, col).CellValue = String.Format("{0}/{1}", row, col)
            Next col
        Next row
    End Sub

    Private Sub t_Tick(sender As Object, e As EventArgs)
        ' Ensure the correct cell (1,1) is visible
        If GridControl1.CurrentCell IsNot Nothing AndAlso Not GridControl1.CurrentCell.HasCurrentCellAt(1, 1) Then
            GridControl1.RefreshRange(GridRangeInfo.Cell(1, 1)) ' Refresh the specific cell (1,1)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        ' Add your save functionality here
        MessageBox.Show("Button clicked! Implement save functionality.")
    End Sub

End Class

