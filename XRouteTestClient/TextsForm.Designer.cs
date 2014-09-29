namespace XRouteTestClient
{
    partial class TextsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextsForm));
            this.dgvTexts = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTexts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTexts
            // 
            this.dgvTexts.AllowUserToAddRows = false;
            this.dgvTexts.AllowUserToDeleteRows = false;
            this.dgvTexts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTexts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTexts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTexts.Location = new System.Drawing.Point(0, 0);
            this.dgvTexts.Name = "dgvTexts";
            this.dgvTexts.ReadOnly = true;
            this.dgvTexts.Size = new System.Drawing.Size(756, 256);
            this.dgvTexts.TabIndex = 0;
            // 
            // TextsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 256);
            this.Controls.Add(this.dgvTexts);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TextsForm";
            this.Text = "TextsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TextsForm_FormClosing);
            this.Load += new System.EventHandler(this.TextsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTexts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTexts;

    }
}