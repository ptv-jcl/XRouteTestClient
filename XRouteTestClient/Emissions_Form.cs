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
    }
}