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
    public partial class DynamicInfoForm : Form
    {
        public DynamicInfoForm()
        {
            InitializeComponent();
        }

        public DynamicInfoForm(Route route)
        {
            InitializeComponent();
            update(route);
        }

        public void update(Route route)
        {
            if (route.dynamicInfo != null)
            {
                DynamicInfo di = route.dynamicInfo;
                tbxDistanceDiff.Text = ((di.distanceDiffSpecified) ? (di.distanceDiff.ToString()) : ("n.a."));
                tbxTimeBenefit.Text = di.timeBenefit.ToString();
                tbxTimeLoss.Text = di.timeLoss.ToString();
                tbxTimeLoss2.Text = di.timeLoss2.ToString();
            }
        }

        private void DynamicInfoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
                this.Visible = false;
                e.Cancel = true;      
        }
        
        private void DynamicInfoForm_Load(object sender, EventArgs e)
        {

        }

        private void DynamicInfo_Enter(object sender, EventArgs e)
        {

        }
    }
}