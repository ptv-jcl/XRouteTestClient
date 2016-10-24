using System;
using System.Windows.Forms;

namespace XRouteTestClient
{
    public partial class TextsForm : Form
    {
        public TextsForm()
        {
            InitializeComponent();
        }

        public TextsForm(string[] texts)
        {
            InitializeComponent();
            dgvTexts.ColumnCount = 2;
            dgvTexts.Columns[0].Name = "index";
            dgvTexts.Columns[1].Name = "text";
            update(texts);
        }

        private void TextsForm_Load(object sender, EventArgs e)
        {
            this.Text = "Texts";
        }

        public void update(string[] texts)
        {
            dgvTexts.Rows.Clear();
            for (int i = 0; i < texts.Length; i++)
            {
                dgvTexts.Rows.Add(new string[] { i.ToString(), texts[i] });
            }
            if (texts != null)
            {
                this.Text = "Texts / Length = " + texts.Length;
            }
        }

        private void TextsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }
    }
}