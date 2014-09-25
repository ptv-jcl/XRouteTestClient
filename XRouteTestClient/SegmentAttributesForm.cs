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
    public partial class SegmentAttributesForm : Form
    {
        public SegmentAttributesForm()
        {
            InitializeComponent();
        }

        public SegmentAttributesForm(Route route)
        {
            InitializeComponent();
            updateDGV(route);
        }

        private SegmentAttributes[] extendSegmentAttributes(Route route)
        {
            List<SegmentAttributes> lstSegmentAttributes = new List<SegmentAttributes>();
            foreach (RouteListSegment curRouteListSegment in route.wrappedSegments)
            {
                
                if (curRouteListSegment.segmentAttr != null)
                {
                    lstSegmentAttributes.Add(curRouteListSegment.segmentAttr);
                }
                else
                {
                    lstSegmentAttributes.Add(new SegmentAttributes());
                }
            }
            return lstSegmentAttributes.ToArray();     
        }

        public void updateDGV(Route route)
        {
            SegmentAttributes[] segAttributes = extendSegmentAttributes(route);
            dgvSegmentAttributes.DataSource = segAttributes;
            this.Text = "SegmentAttributes / Length = " + segAttributes.Length;
        }

        private void SegmentAttributesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }
    }
}