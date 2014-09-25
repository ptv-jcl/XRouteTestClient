namespace XRouteTestClient
{
    partial class SegmentAttributesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SegmentAttributesForm));
            this.dgvSegmentAttributes = new System.Windows.Forms.DataGridView();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.segmentAttributesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.additionalInfoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.additionalREDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.brunnelCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hasExtraTollDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.hasSeparatorDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.hasTollCarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.hasTollTruckDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.hasVignetteCarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.hasVignetteTruckDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isBlockedCarDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isBlockedTruckDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isFerryDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isPiggyback = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isPedestrianZoneDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lowEmissionZoneTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSegmentAttributes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.segmentAttributesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSegmentAttributes
            // 
            this.dgvSegmentAttributes.AllowUserToAddRows = false;
            this.dgvSegmentAttributes.AllowUserToDeleteRows = false;
            this.dgvSegmentAttributes.AllowUserToResizeRows = false;
            this.dgvSegmentAttributes.AutoGenerateColumns = false;
            this.dgvSegmentAttributes.CausesValidation = false;
            this.dgvSegmentAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSegmentAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.additionalInfoDataGridViewTextBoxColumn,
            this.additionalREDataGridViewTextBoxColumn,
            this.brunnelCodeDataGridViewTextBoxColumn,
            this.hasExtraTollDataGridViewCheckBoxColumn,
            this.hasSeparatorDataGridViewCheckBoxColumn,
            this.hasTollCarDataGridViewCheckBoxColumn,
            this.hasTollTruckDataGridViewCheckBoxColumn,
            this.hasVignetteCarDataGridViewCheckBoxColumn,
            this.hasVignetteTruckDataGridViewCheckBoxColumn,
            this.isBlockedCarDataGridViewCheckBoxColumn,
            this.isBlockedTruckDataGridViewCheckBoxColumn,
            this.isFerryDataGridViewCheckBoxColumn,
            this.isPiggyback,
            this.isPedestrianZoneDataGridViewCheckBoxColumn,
            this.lowEmissionZoneTypeDataGridViewTextBoxColumn});
            this.dgvSegmentAttributes.DataSource = this.segmentAttributesBindingSource;
            this.dgvSegmentAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSegmentAttributes.Location = new System.Drawing.Point(0, 0);
            this.dgvSegmentAttributes.Name = "dgvSegmentAttributes";
            this.dgvSegmentAttributes.ReadOnly = true;
            this.dgvSegmentAttributes.Size = new System.Drawing.Size(783, 322);
            this.dgvSegmentAttributes.TabIndex = 0;
            // 
            // segmentAttributesBindingSource
            // 
            this.segmentAttributesBindingSource.DataSource = typeof(XServer.SegmentAttributes);
            // 
            // additionalInfoDataGridViewTextBoxColumn
            // 
            this.additionalInfoDataGridViewTextBoxColumn.DataPropertyName = "additionalInfo";
            this.additionalInfoDataGridViewTextBoxColumn.HeaderText = "additionalInfo";
            this.additionalInfoDataGridViewTextBoxColumn.Name = "additionalInfoDataGridViewTextBoxColumn";
            this.additionalInfoDataGridViewTextBoxColumn.ReadOnly = true;
            this.additionalInfoDataGridViewTextBoxColumn.ToolTipText = "Represents optional additional - not documented - Information for project purpose" +
    "s";
            // 
            // additionalREDataGridViewTextBoxColumn
            // 
            this.additionalREDataGridViewTextBoxColumn.DataPropertyName = "additionalRE";
            this.additionalREDataGridViewTextBoxColumn.HeaderText = "additionalRE";
            this.additionalREDataGridViewTextBoxColumn.Name = "additionalREDataGridViewTextBoxColumn";
            this.additionalREDataGridViewTextBoxColumn.ReadOnly = true;
            this.additionalREDataGridViewTextBoxColumn.ToolTipText = "indicates optional road editor information given as comma separated key-value pai" +
    "rs according to the RoadEditor properties set for the corresponding segment in t" +
    "he additional road editor database.";
            // 
            // brunnelCodeDataGridViewTextBoxColumn
            // 
            this.brunnelCodeDataGridViewTextBoxColumn.DataPropertyName = "brunnelCode";
            this.brunnelCodeDataGridViewTextBoxColumn.HeaderText = "brunnelCode";
            this.brunnelCodeDataGridViewTextBoxColumn.Name = "brunnelCodeDataGridViewTextBoxColumn";
            this.brunnelCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.brunnelCodeDataGridViewTextBoxColumn.ToolTipText = "describes if this segment belongs to a tunnel or bridge and if so it describes th" +
    "e type";
            // 
            // hasExtraTollDataGridViewCheckBoxColumn
            // 
            this.hasExtraTollDataGridViewCheckBoxColumn.DataPropertyName = "hasExtraToll";
            this.hasExtraTollDataGridViewCheckBoxColumn.HeaderText = "hasExtraToll";
            this.hasExtraTollDataGridViewCheckBoxColumn.Name = "hasExtraTollDataGridViewCheckBoxColumn";
            this.hasExtraTollDataGridViewCheckBoxColumn.ReadOnly = true;
            this.hasExtraTollDataGridViewCheckBoxColumn.ToolTipText = "describes if this segment has extra toll";
            // 
            // hasSeparatorDataGridViewCheckBoxColumn
            // 
            this.hasSeparatorDataGridViewCheckBoxColumn.DataPropertyName = "hasSeparator";
            this.hasSeparatorDataGridViewCheckBoxColumn.HeaderText = "hasSeparator";
            this.hasSeparatorDataGridViewCheckBoxColumn.Name = "hasSeparatorDataGridViewCheckBoxColumn";
            this.hasSeparatorDataGridViewCheckBoxColumn.ReadOnly = true;
            this.hasSeparatorDataGridViewCheckBoxColumn.ToolTipText = "describes if the road this segment belongs to has a devider";
            // 
            // hasTollCarDataGridViewCheckBoxColumn
            // 
            this.hasTollCarDataGridViewCheckBoxColumn.DataPropertyName = "hasTollCar";
            this.hasTollCarDataGridViewCheckBoxColumn.HeaderText = "hasTollCar";
            this.hasTollCarDataGridViewCheckBoxColumn.Name = "hasTollCarDataGridViewCheckBoxColumn";
            this.hasTollCarDataGridViewCheckBoxColumn.ReadOnly = true;
            this.hasTollCarDataGridViewCheckBoxColumn.ToolTipText = "describes if this segment is a toll road for cars";
            // 
            // hasTollTruckDataGridViewCheckBoxColumn
            // 
            this.hasTollTruckDataGridViewCheckBoxColumn.DataPropertyName = "hasTollTruck";
            this.hasTollTruckDataGridViewCheckBoxColumn.HeaderText = "hasTollTruck";
            this.hasTollTruckDataGridViewCheckBoxColumn.Name = "hasTollTruckDataGridViewCheckBoxColumn";
            this.hasTollTruckDataGridViewCheckBoxColumn.ReadOnly = true;
            this.hasTollTruckDataGridViewCheckBoxColumn.ToolTipText = "describes if this segment is a toll road for trucks";
            // 
            // hasVignetteCarDataGridViewCheckBoxColumn
            // 
            this.hasVignetteCarDataGridViewCheckBoxColumn.DataPropertyName = "hasVignetteCar";
            this.hasVignetteCarDataGridViewCheckBoxColumn.HeaderText = "hasVignetteCar";
            this.hasVignetteCarDataGridViewCheckBoxColumn.Name = "hasVignetteCarDataGridViewCheckBoxColumn";
            this.hasVignetteCarDataGridViewCheckBoxColumn.ReadOnly = true;
            this.hasVignetteCarDataGridViewCheckBoxColumn.ToolTipText = "describes if this segment is a vignette road for cars";
            // 
            // hasVignetteTruckDataGridViewCheckBoxColumn
            // 
            this.hasVignetteTruckDataGridViewCheckBoxColumn.DataPropertyName = "hasVignetteTruck";
            this.hasVignetteTruckDataGridViewCheckBoxColumn.HeaderText = "hasVignetteTruck";
            this.hasVignetteTruckDataGridViewCheckBoxColumn.Name = "hasVignetteTruckDataGridViewCheckBoxColumn";
            this.hasVignetteTruckDataGridViewCheckBoxColumn.ReadOnly = true;
            this.hasVignetteTruckDataGridViewCheckBoxColumn.ToolTipText = "describes if this segment is a vignette road for trucks";
            // 
            // isBlockedCarDataGridViewCheckBoxColumn
            // 
            this.isBlockedCarDataGridViewCheckBoxColumn.DataPropertyName = "isBlockedCar";
            this.isBlockedCarDataGridViewCheckBoxColumn.HeaderText = "isBlockedCar";
            this.isBlockedCarDataGridViewCheckBoxColumn.Name = "isBlockedCarDataGridViewCheckBoxColumn";
            this.isBlockedCarDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isBlockedCarDataGridViewCheckBoxColumn.ToolTipText = "describes if this segment is blocked for cars";
            // 
            // isBlockedTruckDataGridViewCheckBoxColumn
            // 
            this.isBlockedTruckDataGridViewCheckBoxColumn.DataPropertyName = "isBlockedTruck";
            this.isBlockedTruckDataGridViewCheckBoxColumn.HeaderText = "isBlockedTruck";
            this.isBlockedTruckDataGridViewCheckBoxColumn.Name = "isBlockedTruckDataGridViewCheckBoxColumn";
            this.isBlockedTruckDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isBlockedTruckDataGridViewCheckBoxColumn.ToolTipText = "describes if this segment is blocked fo trucks";
            // 
            // isFerryDataGridViewCheckBoxColumn
            // 
            this.isFerryDataGridViewCheckBoxColumn.DataPropertyName = "isFerry";
            this.isFerryDataGridViewCheckBoxColumn.HeaderText = "isFerry";
            this.isFerryDataGridViewCheckBoxColumn.Name = "isFerryDataGridViewCheckBoxColumn";
            this.isFerryDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isFerryDataGridViewCheckBoxColumn.ToolTipText = "Describes if this segment belongs to a ferry resp. piggy-back NOTE: This paramete" +
    "r also represents segment information regarding piggy-back";
            // 
            // isPiggyback
            // 
            this.isPiggyback.DataPropertyName = "isPiggyback";
            this.isPiggyback.HeaderText = "isPiggyback (1.14)";
            this.isPiggyback.Name = "isPiggyback";
            this.isPiggyback.ReadOnly = true;
            this.isPiggyback.ToolTipText = "Describes if this segment represents a piggyback.";
            // 
            // isPedestrianZoneDataGridViewCheckBoxColumn
            // 
            this.isPedestrianZoneDataGridViewCheckBoxColumn.DataPropertyName = "isPedestrianZone";
            this.isPedestrianZoneDataGridViewCheckBoxColumn.HeaderText = "isPedestrianZone";
            this.isPedestrianZoneDataGridViewCheckBoxColumn.Name = "isPedestrianZoneDataGridViewCheckBoxColumn";
            this.isPedestrianZoneDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isPedestrianZoneDataGridViewCheckBoxColumn.ToolTipText = "describes if the road this segment belongs is a pedestrian zone";
            // 
            // lowEmissionZoneTypeDataGridViewTextBoxColumn
            // 
            this.lowEmissionZoneTypeDataGridViewTextBoxColumn.DataPropertyName = "lowEmissionZoneType";
            this.lowEmissionZoneTypeDataGridViewTextBoxColumn.HeaderText = "lowEmissionZoneType";
            this.lowEmissionZoneTypeDataGridViewTextBoxColumn.Name = "lowEmissionZoneTypeDataGridViewTextBoxColumn";
            this.lowEmissionZoneTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.lowEmissionZoneTypeDataGridViewTextBoxColumn.ToolTipText = resources.GetString("lowEmissionZoneTypeDataGridViewTextBoxColumn.ToolTipText");
            // 
            // SegmentAttributesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 322);
            this.Controls.Add(this.dgvSegmentAttributes);
            this.Name = "SegmentAttributesForm";
            this.Text = "SegmentAttributes";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SegmentAttributesForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSegmentAttributes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.segmentAttributesBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSegmentAttributes;
        private System.Windows.Forms.BindingSource segmentAttributesBindingSource;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn additionalInfoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn additionalREDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn brunnelCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hasExtraTollDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hasSeparatorDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hasTollCarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hasTollTruckDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hasVignetteCarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hasVignetteTruckDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isBlockedCarDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isBlockedTruckDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isFerryDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isPiggyback;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isPedestrianZoneDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowEmissionZoneTypeDataGridViewTextBoxColumn;
    }
}