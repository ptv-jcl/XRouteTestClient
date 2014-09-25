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
    public partial class Waypoint_Form : Form
    {
        Route route = null;
        
        public Waypoint_Form()
        {
            InitializeComponent();
        }

        public Waypoint_Form(Route route)
        {
            InitializeComponent();
            update(route);
        }

        private void Waypoint_Form_Load(object sender, EventArgs e)
        {

        }

        public void update(Route route)
        {
            this.route = route;
            if (route.wrappedStations[0].GetType() == typeof(ExtWayPoint))
            {
                dgvWaypoints.DataSource = null;
                List<ExtWayPoint> lstExtWP = new List<ExtWayPoint>();
                foreach (WayPoint wp in route.wrappedStations)
                {
                    lstExtWP.Add((ExtWayPoint)wp);
                }
                dgvExtWaypoints.DataSource = lstExtWP.ToArray();
                dgvExtWaypoints.Visible = true;
                dgvWaypoints.Visible = false;
            }
            else
            {
                dgvWaypoints.DataSource = route.wrappedStations;
                dgvExtWaypoints.DataSource = null;
                dgvExtWaypoints.Visible = false;
                dgvWaypoints.Visible = true;
            }
            
            
            
            if (route.wrappedStations != null)
            {
                this.Text = "Waypoints / Length = " + route.wrappedStations.Length;
            }
        }

        private void Waypoint_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }
    }
}