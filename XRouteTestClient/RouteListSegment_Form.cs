using System;
using System.Windows.Forms;
using XServer;

namespace XRouteTestClient
{
    public partial class RouteListSegment_Form : Form
    {
        public RouteListSegment_Form()
        {
            InitializeComponent();
        }

        public RouteListSegment_Form(Route route)
        {
            InitializeComponent();
            //dgvRouteListSegment.DataSource = route.wrappedSegments;
            updateDGV(route);
        }

        public void updateDGV(Route route)
        {
            dgvRouteListSegment.DataSource = route.wrappedSegments;
            if (route.wrappedTexts != null)
            {
                string[] arrCells = { "dirInfoIdxDataGridViewTextBoxColumn", "streetNameIdxDataGridViewTextBoxColumn", "streetNoIdxDataGridViewTextBoxColumn" };
                for (int i = 0; i < dgvRouteListSegment.Rows.Count; i++)
                {
                    DataGridViewRow curDataGridViewRow = dgvRouteListSegment.Rows[i];
                    foreach (string curCellName in arrCells)
                    {
                        DataGridViewCell curCell = curDataGridViewRow.Cells[curCellName];
                        int index = Convert.ToInt32(curCell.Value);
                        if (index > -1)
                        {
                          //  curDataGridViewRow.Cells[curCellName + "_text"].Value = route.wrappedTexts[index];
                        }
                    }
                }
            }
            if (route.wrappedSegments != null)
            {
                this.Text = "RouteListSegment / Length = " + route.wrappedSegments.Length;
            }
            foreach (DataGridViewRow row in dgvRouteListSegment.Rows)
            {
                row.HeaderCell.Value = row.Index.ToString();
            }
            dgvRouteListSegment.AutoResizeRows();
        }

        private void RouteListSegment_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }
    }
}