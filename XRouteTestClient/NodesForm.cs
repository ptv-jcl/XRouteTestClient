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
    public partial class NodesForm : Form
    {
        public NodesForm()
        {
            InitializeComponent();
        }

        public NodesForm(Route route)
        {
            InitializeComponent();
            update(route);
        }

        public void update(Route route)
        {
            dgvUniqueGeoIDs.DataSource = route.wrappedNodes;
            if (route.wrappedNodes != null)
            {
                this.Text = "Nodes / Length = " + route.wrappedNodes.Length;
            }
        }

        private void NodesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
                this.Visible = false;
                e.Cancel = true;
        }

        private void NodesForm_Load(object sender, EventArgs e)
        {

        }



    }
}