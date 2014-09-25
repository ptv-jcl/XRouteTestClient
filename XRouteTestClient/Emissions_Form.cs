using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using XServer;


namespace XRouteTestClient
{
    public partial class Emissions_Form : Form
    {
        public Emissions_Form()
        {
            InitializeComponent();
        }


        public Emissions_Form(Emissions[] arrEmissions)
        {
            InitializeComponent();
            update(arrEmissions);
        }

        public void update(Emissions[] arrEmissions)
        {
            dgvEmissions.DataSource = arrEmissions;
            if (arrEmissions != null)
            {
                this.Text = "Emissions / Length = " + arrEmissions.Length;
            }
        }

        private void EmissionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
                this.Visible = false;
                e.Cancel = true;
        }

        private void EmissionsForm_Load(object sender, EventArgs e)
        {

        }

    }
}