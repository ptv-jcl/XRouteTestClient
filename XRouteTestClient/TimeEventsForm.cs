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
    public partial class TimeEventsForm : Form
    {
        Tour tour = null;
        public TimeEventsForm()
        {
            InitializeComponent();

        }
        public TimeEventsForm(Tour tour)
            :this()
        {
            update(tour);
        }
        public void update(Tour tour)
        {
            this.tour = tour;
            this.dgvTimeEvents.DataSource = tour.wrappedTimeEvents;
            this.dgvTourPoints.DataSource = tour.wrappedTourPoints;
            this.tbxDrivingPeriod.Text = tour.tourSummary.drivingPeriod.ToString();
            this.tbxIdlePeriod.Text = tour.tourSummary.idlePeriod.ToString();
            this.tbxLatestTourStart.Text = tour.tourSummary.latestTourStart.ToString();
            this.tbxServicePeriod.Text = tour.tourSummary.servicePeriod.ToString();
            this.tbxTotalPeriod.Text = tour.tourSummary.totalPeriod.ToString();
            this.tbxWaitingPeriod.Text = tour.tourSummary.waitingPeriod.ToString();
            this.tbxEarliness.Text = tour.tourSummary.earliness.ToString();
            if (tour.wrappedTimeEvents != null)
            {
                this.Text = "Events / Length = " + tour.wrappedTimeEvents.Length;
            }
        }

        private void TimeEventsForm_Load(object sender, EventArgs e)
        {

        }

        private void TimeEventsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }

        //private void tbxDrivingPeriod_TextChanged(object sender, EventArgs e)
        //{

        //}

        //private void tbxTotalPeriod_TextChanged(object sender, EventArgs e)
        //{

        //}

    }
}