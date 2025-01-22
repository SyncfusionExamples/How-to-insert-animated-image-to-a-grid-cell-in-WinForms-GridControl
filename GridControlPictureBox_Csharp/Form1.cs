using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Grid;

namespace GridControlPictureBox
{
    public partial class Form1 : Form
    {
        PictureBox pb;
        public Form1()
        {
            InitializeComponent();
            pb = new PictureBox();
            pb.Image = Image.FromFile("D:/T682565 and T682861/GridControlPictureBox/Data/Lock.gif");
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            Timer t = new Timer() { Interval = 50 };
            t.Tick += T_Tick;
            t.Start();
            PopulateData();
            gridControl1.QueryCellInfo += GridControl1_QueryCellInfo;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            if (gridControl1.CurrentCell != null && !gridControl1.CurrentCell.HasCurrentCellAt(1, 1))
            {
                gridControl1.RefreshRange(GridRangeInfo.Cell(1, 1));
            }
        }

        private void GridControl1_QueryCellInfo(object sender, Syncfusion.Windows.Forms.Grid.GridQueryCellInfoEventArgs e)
        {
            if (e.ColIndex == 1 && e.RowIndex == 1)
            {
                // Sets Cell Type.
                e.Style.CellType = GridCellTypeName.Control;
                // sets image to the cell.
                e.Style.Control = pb;
            }
        }

        private void PopulateData()
        {
           gridControl1.RowHeights.SetSize(1, 50);  
            gridControl1.RowCount = 10;

            gridControl1.ColCount = 4;

            //Looping through the cells and assigning the values based on row and column index
            for (int row = 1; row <= gridControl1.RowCount; row++)
            {
                for (int col = 1; col <= gridControl1.ColCount; col++)
                {
                    gridControl1.Model[row, col].CellValue = string.Format("{0}/{1}", row, col);
                }
            }
        }
    }
}
