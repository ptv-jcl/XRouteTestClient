namespace XRouteTestClient
{
    partial class Emissions_Form
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
            this.dgvEmissions = new System.Windows.Forms.DataGridView();
            this.fuelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carbonDioxideDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carbonMonoxideDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ammoniaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.benzeneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hydrocarbonsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hydrocarbonsExMethaneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.leadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.methaneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nitrogenOxidesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nitrousOxideDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.particlesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sulphurDioxideDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tolueneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xyleneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emissionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmissions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emissionsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmissions
            // 
            this.dgvEmissions.AutoGenerateColumns = false;
            this.dgvEmissions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmissions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fuelDataGridViewTextBoxColumn,
            this.carbonDioxideDataGridViewTextBoxColumn,
            this.carbonMonoxideDataGridViewTextBoxColumn,
            this.ammoniaDataGridViewTextBoxColumn,
            this.benzeneDataGridViewTextBoxColumn,
            this.hydrocarbonsDataGridViewTextBoxColumn,
            this.hydrocarbonsExMethaneDataGridViewTextBoxColumn,
            this.leadDataGridViewTextBoxColumn,
            this.methaneDataGridViewTextBoxColumn,
            this.nitrogenOxidesDataGridViewTextBoxColumn,
            this.nitrousOxideDataGridViewTextBoxColumn,
            this.particlesDataGridViewTextBoxColumn,
            this.sulphurDioxideDataGridViewTextBoxColumn,
            this.tolueneDataGridViewTextBoxColumn,
            this.xyleneDataGridViewTextBoxColumn});
            this.dgvEmissions.DataSource = this.emissionsBindingSource;
            this.dgvEmissions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmissions.Location = new System.Drawing.Point(0, 0);
            this.dgvEmissions.Name = "dgvEmissions";
            this.dgvEmissions.Size = new System.Drawing.Size(617, 164);
            this.dgvEmissions.TabIndex = 0;
            // 
            // fuelDataGridViewTextBoxColumn
            // 
            this.fuelDataGridViewTextBoxColumn.DataPropertyName = "fuel";
            this.fuelDataGridViewTextBoxColumn.HeaderText = "fuel";
            this.fuelDataGridViewTextBoxColumn.Name = "fuelDataGridViewTextBoxColumn";
            this.fuelDataGridViewTextBoxColumn.ToolTipText = "petrol/fuel [in kg]";
            // 
            // carbonDioxideDataGridViewTextBoxColumn
            // 
            this.carbonDioxideDataGridViewTextBoxColumn.DataPropertyName = "carbonDioxide";
            this.carbonDioxideDataGridViewTextBoxColumn.HeaderText = "carbonDioxide";
            this.carbonDioxideDataGridViewTextBoxColumn.Name = "carbonDioxideDataGridViewTextBoxColumn";
            this.carbonDioxideDataGridViewTextBoxColumn.ToolTipText = "carbon dioxide [in kg] (total value)";
            // 
            // carbonMonoxideDataGridViewTextBoxColumn
            // 
            this.carbonMonoxideDataGridViewTextBoxColumn.DataPropertyName = "carbonMonoxide";
            this.carbonMonoxideDataGridViewTextBoxColumn.HeaderText = "carbonMonoxide";
            this.carbonMonoxideDataGridViewTextBoxColumn.Name = "carbonMonoxideDataGridViewTextBoxColumn";
            this.carbonMonoxideDataGridViewTextBoxColumn.ToolTipText = "carbon monoxide [in g]";
            // 
            // ammoniaDataGridViewTextBoxColumn
            // 
            this.ammoniaDataGridViewTextBoxColumn.DataPropertyName = "ammonia";
            this.ammoniaDataGridViewTextBoxColumn.HeaderText = "ammonia";
            this.ammoniaDataGridViewTextBoxColumn.Name = "ammoniaDataGridViewTextBoxColumn";
            this.ammoniaDataGridViewTextBoxColumn.ToolTipText = "ammonia [in g]";
            // 
            // benzeneDataGridViewTextBoxColumn
            // 
            this.benzeneDataGridViewTextBoxColumn.DataPropertyName = "benzene";
            this.benzeneDataGridViewTextBoxColumn.HeaderText = "benzene";
            this.benzeneDataGridViewTextBoxColumn.Name = "benzeneDataGridViewTextBoxColumn";
            this.benzeneDataGridViewTextBoxColumn.ToolTipText = "benzene [in g]";
            // 
            // hydrocarbonsDataGridViewTextBoxColumn
            // 
            this.hydrocarbonsDataGridViewTextBoxColumn.DataPropertyName = "hydrocarbons";
            this.hydrocarbonsDataGridViewTextBoxColumn.HeaderText = "hydrocarbons";
            this.hydrocarbonsDataGridViewTextBoxColumn.Name = "hydrocarbonsDataGridViewTextBoxColumn";
            this.hydrocarbonsDataGridViewTextBoxColumn.ToolTipText = "hydrocarbons, total [in g]";
            // 
            // hydrocarbonsExMethaneDataGridViewTextBoxColumn
            // 
            this.hydrocarbonsExMethaneDataGridViewTextBoxColumn.DataPropertyName = "hydrocarbonsExMethane";
            this.hydrocarbonsExMethaneDataGridViewTextBoxColumn.HeaderText = "hydrocarbonsExMethane";
            this.hydrocarbonsExMethaneDataGridViewTextBoxColumn.Name = "hydrocarbonsExMethaneDataGridViewTextBoxColumn";
            this.hydrocarbonsExMethaneDataGridViewTextBoxColumn.ToolTipText = "hydrocarbons except for methane [in g]";
            // 
            // leadDataGridViewTextBoxColumn
            // 
            this.leadDataGridViewTextBoxColumn.DataPropertyName = "lead";
            this.leadDataGridViewTextBoxColumn.HeaderText = "lead";
            this.leadDataGridViewTextBoxColumn.Name = "leadDataGridViewTextBoxColumn";
            this.leadDataGridViewTextBoxColumn.ToolTipText = "lead [in g]";
            // 
            // methaneDataGridViewTextBoxColumn
            // 
            this.methaneDataGridViewTextBoxColumn.DataPropertyName = "methane";
            this.methaneDataGridViewTextBoxColumn.HeaderText = "methane";
            this.methaneDataGridViewTextBoxColumn.Name = "methaneDataGridViewTextBoxColumn";
            this.methaneDataGridViewTextBoxColumn.ToolTipText = "methane [in g]";
            // 
            // nitrogenOxidesDataGridViewTextBoxColumn
            // 
            this.nitrogenOxidesDataGridViewTextBoxColumn.DataPropertyName = "nitrogenOxides";
            this.nitrogenOxidesDataGridViewTextBoxColumn.HeaderText = "nitrogenOxides";
            this.nitrogenOxidesDataGridViewTextBoxColumn.Name = "nitrogenOxidesDataGridViewTextBoxColumn";
            this.nitrogenOxidesDataGridViewTextBoxColumn.ToolTipText = "nitrogen oxides [in g]";
            // 
            // nitrousOxideDataGridViewTextBoxColumn
            // 
            this.nitrousOxideDataGridViewTextBoxColumn.DataPropertyName = "nitrousOxide";
            this.nitrousOxideDataGridViewTextBoxColumn.HeaderText = "nitrousOxide";
            this.nitrousOxideDataGridViewTextBoxColumn.Name = "nitrousOxideDataGridViewTextBoxColumn";
            this.nitrousOxideDataGridViewTextBoxColumn.ToolTipText = "nitrous oxide [in g]";
            // 
            // particlesDataGridViewTextBoxColumn
            // 
            this.particlesDataGridViewTextBoxColumn.DataPropertyName = "particles";
            this.particlesDataGridViewTextBoxColumn.HeaderText = "particles";
            this.particlesDataGridViewTextBoxColumn.Name = "particlesDataGridViewTextBoxColumn";
            this.particlesDataGridViewTextBoxColumn.ToolTipText = "particular mass [in g]";
            // 
            // sulphurDioxideDataGridViewTextBoxColumn
            // 
            this.sulphurDioxideDataGridViewTextBoxColumn.DataPropertyName = "sulphurDioxide";
            this.sulphurDioxideDataGridViewTextBoxColumn.HeaderText = "sulphurDioxide";
            this.sulphurDioxideDataGridViewTextBoxColumn.Name = "sulphurDioxideDataGridViewTextBoxColumn";
            this.sulphurDioxideDataGridViewTextBoxColumn.ToolTipText = "sulphur dioxide [in g]";
            // 
            // tolueneDataGridViewTextBoxColumn
            // 
            this.tolueneDataGridViewTextBoxColumn.DataPropertyName = "toluene";
            this.tolueneDataGridViewTextBoxColumn.HeaderText = "toluene";
            this.tolueneDataGridViewTextBoxColumn.Name = "tolueneDataGridViewTextBoxColumn";
            this.tolueneDataGridViewTextBoxColumn.ToolTipText = "toluene [in g] (only HBEFA_2_1)";
            // 
            // xyleneDataGridViewTextBoxColumn
            // 
            this.xyleneDataGridViewTextBoxColumn.DataPropertyName = "xylene";
            this.xyleneDataGridViewTextBoxColumn.HeaderText = "xylene";
            this.xyleneDataGridViewTextBoxColumn.Name = "xyleneDataGridViewTextBoxColumn";
            this.xyleneDataGridViewTextBoxColumn.ToolTipText = "xylene [in g] (only HBEFA_2_1)";
            // 
            // emissionsBindingSource
            // 
            this.emissionsBindingSource.DataSource = typeof(XServer.Emissions);
            // 
            // Emissions_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 164);
            this.Controls.Add(this.dgvEmissions);
            this.Name = "Emissions_Form";
            this.Text = "Emissions_Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EmissionsForm_FormClosing);
            this.Load += new System.EventHandler(this.EmissionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmissions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emissionsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmissions;
        private System.Windows.Forms.BindingSource emissionsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn fuelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn carbonDioxideDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn carbonMonoxideDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ammoniaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn benzeneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hydrocarbonsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hydrocarbonsExMethaneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn leadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn methaneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nitrogenOxidesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nitrousOxideDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn particlesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sulphurDioxideDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tolueneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn xyleneDataGridViewTextBoxColumn;
    }
}