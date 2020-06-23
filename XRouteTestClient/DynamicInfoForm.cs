using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using XServer;

namespace XRouteTestClient
{
    public partial class DynamicInfoForm : Form
    {
        private readonly DateTime baseDate = new DateTime(1970, 1, 1, 0, 0, 0);
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
            var trends = route.info.wrappedTravelTrend;
            if (trends != null && trends.Length > 0)
            {
                commuterTravelTrendBindingSource.DataSource = trends;
            }
            else
                commuterTravelTrendBindingSource.DataSource = null;

            chart1.Series.Clear();
            chart1.Series.Add("travel trend");
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[0].Color = System.Drawing.Color.Blue;
            chart1.Series[0].BorderWidth = 3;
            chart1.Series[0].XValueType = ChartValueType.DateTime;
            chart1.ChartAreas[0].AxisX.LabelStyle.Format = "ddd HH:mm";
            chart1.Series[0].YValueType = ChartValueType.Time;
            var serieSource = trends.Select(trend => new { departureTime = trend.departureTime, travelTime = baseDate.AddSeconds(trend.travelTime) });
            chart1.Series[0].Points.DataBind(serieSource, "departureTime", "travelTime", "");
            //foreach (var trend in trends)
            //{  
            //    chart1.Series[0].Points.AddXY(trend.departureTime, baseDate.AddSeconds(trend.travelTime));
            //}
            chart1.Series[0].ToolTip = "#VALX{ddd HH:mm} - #VALY";
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