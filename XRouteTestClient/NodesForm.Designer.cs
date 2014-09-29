namespace XRouteTestClient
{
    partial class NodesForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NodesForm));
            this.dgvUniqueGeoIDs = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUniqueGeoIDs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvUniqueGeoIDs
            // 
            this.dgvUniqueGeoIDs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUniqueGeoIDs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUniqueGeoIDs.Location = new System.Drawing.Point(0, 0);
            this.dgvUniqueGeoIDs.Name = "dgvUniqueGeoIDs";
            this.dgvUniqueGeoIDs.Size = new System.Drawing.Size(700, 256);
            this.dgvUniqueGeoIDs.TabIndex = 0;
            // 
            // NodesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 256);
            this.Controls.Add(this.dgvUniqueGeoIDs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NodesForm";
            this.Text = "Nodes / UniqueGeoIDs";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NodesForm_FormClosing);
            this.Load += new System.EventHandler(this.NodesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUniqueGeoIDs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUniqueGeoIDs;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}