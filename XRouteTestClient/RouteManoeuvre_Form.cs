using System;
using System.Windows.Forms;
using XServer;

namespace XRouteTestClient
{
    public partial class RouteManoeuvre_Form : Form
    {
        public RouteManoeuvre_Form()
        {
            InitializeComponent();
        }

        public RouteManoeuvre_Form(Route route)
        {
            InitializeComponent();
            Update(route);
        }

        public void Update(Route route)
        {
            dgvRouteManoeuvre.DataSource = route.wrappedManoeuvres;

            if (route.wrappedTexts != null)
            {
                string[] arrCells = { "dirInfoIdxDataGridViewTextBoxColumn", "locInfoIdxDataGridViewTextBoxColumn" };
                for (int i = 0; i < dgvRouteManoeuvre.Rows.Count; i++)
                {
                    DataGridViewRow curDataGridViewRow = dgvRouteManoeuvre.Rows[i];
                    foreach (string curCellName in arrCells)
                    {
                        DataGridViewCell curCell = curDataGridViewRow.Cells[curCellName];
                        int index = Convert.ToInt32(curCell.Value);
                        if (index > -1)
                        {
                            curDataGridViewRow.Cells[curCellName + "_text"].Value = route.wrappedTexts[index];
                        }
                    }
                }
                dgvRouteManoeuvre.Update();
            }

            if (route.wrappedManoeuvres != null)
            {
                this.Text = "Manoeuvres / Length = " + route.wrappedManoeuvres.Length;
            }
        }

        private void RouteManoeuvre_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }
    }
}