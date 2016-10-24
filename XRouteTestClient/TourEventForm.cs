using System.Windows.Forms;

using XServer;

namespace XRouteTestClient
{
    public partial class TourEventForm : Form
    {
        public TourEventForm()
        {
            InitializeComponent();
        }

        public TourEventForm(AdvancedTour advancedTour) : this()
        {
            Update(advancedTour);
        }

        public void Update(AdvancedTour advancedTour)
        {
            isViolatedTxtBx.Text = advancedTour.isViolated.ToString();
            startTimeTxtBx.Text = advancedTour.startTime.ToString();
            tourPeriodTxtBx.Text = advancedTour.tourPeriod.ToString();
            remainingPeriodsTxtBx.Text = advancedTour.remainingPeriods;
            defermentPotentialTxtBx.Text = advancedTour.defermentPotential.ToString();
            genuineWaitingPeriodTxtBx.Text = advancedTour.genuineWaitingPeriod.ToString();

            tourEventDtGrdVw.DataSource = advancedTour.wrappedTourEvents;
            tourEventDtGrdVw.Update();
            tourPointResultsDtGrdVw.DataSource = advancedTour.wrappedTourPointResults;
            tourPointResultsDtGrdVw.Update();

            breakPeriodTxtBx.Text = advancedTour.recreationPeriods.breakPeriod.ToString();
            dailyRestPeriodTxtBx.Text = advancedTour.recreationPeriods.dailyRestPeriod.ToString();
            weeklyRestPeriodTxtBx.Text = advancedTour.recreationPeriods.weeklyRestPeriod.ToString();
        }

        private void TourEventForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Visible = false;
            e.Cancel = true;
        }
    }
}