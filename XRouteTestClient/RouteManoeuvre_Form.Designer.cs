namespace XRouteTestClient
{
    partial class RouteManoeuvre_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RouteManoeuvre_Form));
            this.dgvRouteManoeuvre = new System.Windows.Forms.DataGridView();
            this.brunnelManoeuvreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manoeuvreAttrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.urbanlManoeuvreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.detailLevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dirInfoIdxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dirInfoIdxDataGridViewTextBoxColumn_text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dirInfoNodeTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exitAngleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exitAngleNorthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.exitNrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locInfoIdxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locInfoIdxDataGridViewTextBoxColumn_text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locInfoNodeTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manoeuvreDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manoeuvreGroupIdxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manoeuvreTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.predSegmentIdxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routeListSegmentIdxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.succSegmentIdxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turnOrientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.turnWeightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.viaIdxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routeManoeuvreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRouteManoeuvre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeManoeuvreBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRouteManoeuvre
            // 
            this.dgvRouteManoeuvre.AutoGenerateColumns = false;
            this.dgvRouteManoeuvre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRouteManoeuvre.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.brunnelManoeuvreDataGridViewTextBoxColumn,
            this.manoeuvreAttrDataGridViewTextBoxColumn,
            this.urbanlManoeuvreDataGridViewTextBoxColumn,
            this.detailLevelDataGridViewTextBoxColumn,
            this.dirInfoIdxDataGridViewTextBoxColumn,
            this.dirInfoIdxDataGridViewTextBoxColumn_text,
            this.dirInfoNodeTypeDataGridViewTextBoxColumn,
            this.exitAngleDataGridViewTextBoxColumn,
            this.exitAngleNorthDataGridViewTextBoxColumn,
            this.exitNrDataGridViewTextBoxColumn,
            this.locInfoIdxDataGridViewTextBoxColumn,
            this.locInfoIdxDataGridViewTextBoxColumn_text,
            this.locInfoNodeTypeDataGridViewTextBoxColumn,
            this.manoeuvreDescDataGridViewTextBoxColumn,
            this.manoeuvreGroupIdxDataGridViewTextBoxColumn,
            this.manoeuvreTypeDataGridViewTextBoxColumn,
            this.predSegmentIdxDataGridViewTextBoxColumn,
            this.routeListSegmentIdxDataGridViewTextBoxColumn,
            this.succSegmentIdxDataGridViewTextBoxColumn,
            this.turnOrientDataGridViewTextBoxColumn,
            this.turnWeightDataGridViewTextBoxColumn,
            this.viaIdxDataGridViewTextBoxColumn});
            this.dgvRouteManoeuvre.DataSource = this.routeManoeuvreBindingSource;
            this.dgvRouteManoeuvre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRouteManoeuvre.Location = new System.Drawing.Point(0, 0);
            this.dgvRouteManoeuvre.Name = "dgvRouteManoeuvre";
            this.dgvRouteManoeuvre.Size = new System.Drawing.Size(941, 266);
            this.dgvRouteManoeuvre.TabIndex = 0;
            // 
            // brunnelManoeuvreDataGridViewTextBoxColumn
            // 
            this.brunnelManoeuvreDataGridViewTextBoxColumn.DataPropertyName = "brunnelManoeuvre";
            this.brunnelManoeuvreDataGridViewTextBoxColumn.HeaderText = "brunnelManoeuvre";
            this.brunnelManoeuvreDataGridViewTextBoxColumn.Name = "brunnelManoeuvreDataGridViewTextBoxColumn";
            this.brunnelManoeuvreDataGridViewTextBoxColumn.ToolTipText = "Optional manoevre description for manoevres generated when entering or leaving a " +
    "tunnel or a bridge (brunnel)";
            // 
            // manoeuvreAttrDataGridViewTextBoxColumn
            // 
            this.manoeuvreAttrDataGridViewTextBoxColumn.DataPropertyName = "manoeuvreAttr";
            this.manoeuvreAttrDataGridViewTextBoxColumn.HeaderText = "manoeuvreAttr";
            this.manoeuvreAttrDataGridViewTextBoxColumn.Name = "manoeuvreAttrDataGridViewTextBoxColumn";
            this.manoeuvreAttrDataGridViewTextBoxColumn.ToolTipText = "Optional manoeuvre attributes";
            // 
            // urbanlManoeuvreDataGridViewTextBoxColumn
            // 
            this.urbanlManoeuvreDataGridViewTextBoxColumn.DataPropertyName = "urbanlManoeuvre";
            this.urbanlManoeuvreDataGridViewTextBoxColumn.HeaderText = "urbanlManoeuvre";
            this.urbanlManoeuvreDataGridViewTextBoxColumn.Name = "urbanlManoeuvreDataGridViewTextBoxColumn";
            this.urbanlManoeuvreDataGridViewTextBoxColumn.ToolTipText = "Optional manoevre description for manoeuvres generated when entering or leaving a" +
    " city";
            // 
            // detailLevelDataGridViewTextBoxColumn
            // 
            this.detailLevelDataGridViewTextBoxColumn.DataPropertyName = "detailLevel";
            this.detailLevelDataGridViewTextBoxColumn.HeaderText = "detailLevel";
            this.detailLevelDataGridViewTextBoxColumn.Name = "detailLevelDataGridViewTextBoxColumn";
            this.detailLevelDataGridViewTextBoxColumn.ToolTipText = "detail level to which this manoeuvre belongs to";
            // 
            // dirInfoIdxDataGridViewTextBoxColumn
            // 
            this.dirInfoIdxDataGridViewTextBoxColumn.DataPropertyName = "dirInfoIdx";
            this.dirInfoIdxDataGridViewTextBoxColumn.HeaderText = "dirInfoIdx";
            this.dirInfoIdxDataGridViewTextBoxColumn.Name = "dirInfoIdxDataGridViewTextBoxColumn";
            this.dirInfoIdxDataGridViewTextBoxColumn.ToolTipText = "array-index of the direction info text";
            // 
            // dirInfoIdxDataGridViewTextBoxColumn_text
            // 
            this.dirInfoIdxDataGridViewTextBoxColumn_text.HeaderText = "dirInfoIdx_text";
            this.dirInfoIdxDataGridViewTextBoxColumn_text.Name = "dirInfoIdxDataGridViewTextBoxColumn_text";
            // 
            // dirInfoNodeTypeDataGridViewTextBoxColumn
            // 
            this.dirInfoNodeTypeDataGridViewTextBoxColumn.DataPropertyName = "dirInfoNodeType";
            this.dirInfoNodeTypeDataGridViewTextBoxColumn.HeaderText = "dirInfoNodeType";
            this.dirInfoNodeTypeDataGridViewTextBoxColumn.Name = "dirInfoNodeTypeDataGridViewTextBoxColumn";
            this.dirInfoNodeTypeDataGridViewTextBoxColumn.ToolTipText = "type of the direction info at this manoeuvre";
            // 
            // exitAngleDataGridViewTextBoxColumn
            // 
            this.exitAngleDataGridViewTextBoxColumn.DataPropertyName = "exitAngle";
            this.exitAngleDataGridViewTextBoxColumn.HeaderText = "exitAngle";
            this.exitAngleDataGridViewTextBoxColumn.Name = "exitAngleDataGridViewTextBoxColumn";
            this.exitAngleDataGridViewTextBoxColumn.ToolTipText = "angle of the outgoing road of the manoeuvre relative to the incoming road in degr" +
    "ee (counter-clockwise)";
            // 
            // exitAngleNorthDataGridViewTextBoxColumn
            // 
            this.exitAngleNorthDataGridViewTextBoxColumn.DataPropertyName = "exitAngleNorth";
            this.exitAngleNorthDataGridViewTextBoxColumn.HeaderText = "exitAngleNorth";
            this.exitAngleNorthDataGridViewTextBoxColumn.Name = "exitAngleNorthDataGridViewTextBoxColumn";
            this.exitAngleNorthDataGridViewTextBoxColumn.ToolTipText = "angle of the outgoing road of the manoeuvre related to north in degree (clockwise" +
    ")";
            // 
            // exitNrDataGridViewTextBoxColumn
            // 
            this.exitNrDataGridViewTextBoxColumn.DataPropertyName = "exitNr";
            this.exitNrDataGridViewTextBoxColumn.HeaderText = "exitNr";
            this.exitNrDataGridViewTextBoxColumn.Name = "exitNrDataGridViewTextBoxColumn";
            this.exitNrDataGridViewTextBoxColumn.ToolTipText = "exit number when the manoeuvre is located at a roundabout";
            // 
            // locInfoIdxDataGridViewTextBoxColumn
            // 
            this.locInfoIdxDataGridViewTextBoxColumn.DataPropertyName = "locInfoIdx";
            this.locInfoIdxDataGridViewTextBoxColumn.HeaderText = "locInfoIdx";
            this.locInfoIdxDataGridViewTextBoxColumn.Name = "locInfoIdxDataGridViewTextBoxColumn";
            this.locInfoIdxDataGridViewTextBoxColumn.ToolTipText = "array-index of the location info text";
            // 
            // locInfoIdxDataGridViewTextBoxColumn_text
            // 
            this.locInfoIdxDataGridViewTextBoxColumn_text.HeaderText = "locInfoIdx_text";
            this.locInfoIdxDataGridViewTextBoxColumn_text.Name = "locInfoIdxDataGridViewTextBoxColumn_text";
            // 
            // locInfoNodeTypeDataGridViewTextBoxColumn
            // 
            this.locInfoNodeTypeDataGridViewTextBoxColumn.DataPropertyName = "locInfoNodeType";
            this.locInfoNodeTypeDataGridViewTextBoxColumn.HeaderText = "locInfoNodeType";
            this.locInfoNodeTypeDataGridViewTextBoxColumn.Name = "locInfoNodeTypeDataGridViewTextBoxColumn";
            this.locInfoNodeTypeDataGridViewTextBoxColumn.ToolTipText = "type of the location info at this manoeuvre";
            // 
            // manoeuvreDescDataGridViewTextBoxColumn
            // 
            this.manoeuvreDescDataGridViewTextBoxColumn.DataPropertyName = "manoeuvreDesc";
            this.manoeuvreDescDataGridViewTextBoxColumn.HeaderText = "manoeuvreDesc";
            this.manoeuvreDescDataGridViewTextBoxColumn.Name = "manoeuvreDescDataGridViewTextBoxColumn";
            this.manoeuvreDescDataGridViewTextBoxColumn.ToolTipText = "the manoevre description text in the requested route language (see RoutingOptions" +
    ")";
            // 
            // manoeuvreGroupIdxDataGridViewTextBoxColumn
            // 
            this.manoeuvreGroupIdxDataGridViewTextBoxColumn.DataPropertyName = "manoeuvreGroupIdx";
            this.manoeuvreGroupIdxDataGridViewTextBoxColumn.HeaderText = "manoeuvreGroupIdx";
            this.manoeuvreGroupIdxDataGridViewTextBoxColumn.Name = "manoeuvreGroupIdxDataGridViewTextBoxColumn";
            this.manoeuvreGroupIdxDataGridViewTextBoxColumn.ToolTipText = "array-index of the corresponding ManoeuvreGroup";
            // 
            // manoeuvreTypeDataGridViewTextBoxColumn
            // 
            this.manoeuvreTypeDataGridViewTextBoxColumn.DataPropertyName = "manoeuvreType";
            this.manoeuvreTypeDataGridViewTextBoxColumn.HeaderText = "manoeuvreType";
            this.manoeuvreTypeDataGridViewTextBoxColumn.Name = "manoeuvreTypeDataGridViewTextBoxColumn";
            this.manoeuvreTypeDataGridViewTextBoxColumn.ToolTipText = "manoeuvre type";
            // 
            // predSegmentIdxDataGridViewTextBoxColumn
            // 
            this.predSegmentIdxDataGridViewTextBoxColumn.DataPropertyName = "predSegmentIdx";
            this.predSegmentIdxDataGridViewTextBoxColumn.HeaderText = "predSegmentIdx";
            this.predSegmentIdxDataGridViewTextBoxColumn.Name = "predSegmentIdxDataGridViewTextBoxColumn";
            this.predSegmentIdxDataGridViewTextBoxColumn.ToolTipText = "array index of the predecessing RouteListSegment RouteManoeuvre";
            // 
            // routeListSegmentIdxDataGridViewTextBoxColumn
            // 
            this.routeListSegmentIdxDataGridViewTextBoxColumn.DataPropertyName = "routeListSegmentIdx";
            this.routeListSegmentIdxDataGridViewTextBoxColumn.HeaderText = "routeListSegmentIdx";
            this.routeListSegmentIdxDataGridViewTextBoxColumn.Name = "routeListSegmentIdxDataGridViewTextBoxColumn";
            this.routeListSegmentIdxDataGridViewTextBoxColumn.ToolTipText = "index of the corresponding RouteListSegment";
            // 
            // succSegmentIdxDataGridViewTextBoxColumn
            // 
            this.succSegmentIdxDataGridViewTextBoxColumn.DataPropertyName = "succSegmentIdx";
            this.succSegmentIdxDataGridViewTextBoxColumn.HeaderText = "succSegmentIdx";
            this.succSegmentIdxDataGridViewTextBoxColumn.Name = "succSegmentIdxDataGridViewTextBoxColumn";
            this.succSegmentIdxDataGridViewTextBoxColumn.ToolTipText = "array index of the successing RouteListSegment";
            // 
            // turnOrientDataGridViewTextBoxColumn
            // 
            this.turnOrientDataGridViewTextBoxColumn.DataPropertyName = "turnOrient";
            this.turnOrientDataGridViewTextBoxColumn.HeaderText = "turnOrient";
            this.turnOrientDataGridViewTextBoxColumn.Name = "turnOrientDataGridViewTextBoxColumn";
            this.turnOrientDataGridViewTextBoxColumn.ToolTipText = "turn orientation of the manoeuvre";
            // 
            // turnWeightDataGridViewTextBoxColumn
            // 
            this.turnWeightDataGridViewTextBoxColumn.DataPropertyName = "turnWeight";
            this.turnWeightDataGridViewTextBoxColumn.HeaderText = "turnWeight";
            this.turnWeightDataGridViewTextBoxColumn.Name = "turnWeightDataGridViewTextBoxColumn";
            this.turnWeightDataGridViewTextBoxColumn.ToolTipText = "turn weight of the manoeuvre";
            // 
            // viaIdxDataGridViewTextBoxColumn
            // 
            this.viaIdxDataGridViewTextBoxColumn.DataPropertyName = "viaIdx";
            this.viaIdxDataGridViewTextBoxColumn.HeaderText = "viaIdx";
            this.viaIdxDataGridViewTextBoxColumn.Name = "viaIdxDataGridViewTextBoxColumn";
            this.viaIdxDataGridViewTextBoxColumn.ToolTipText = "array-index of the corresponding WayPoint if any";
            // 
            // routeManoeuvreBindingSource
            // 
            this.routeManoeuvreBindingSource.DataSource = typeof(XServer.RouteManoeuvre);
            // 
            // RouteManoeuvre_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 266);
            this.Controls.Add(this.dgvRouteManoeuvre);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RouteManoeuvre_Form";
            this.Text = "RouteManoeuvre_Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RouteManoeuvre_Form_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRouteManoeuvre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeManoeuvreBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRouteManoeuvre;
        private System.Windows.Forms.BindingSource routeManoeuvreBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn brunnelManoeuvreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manoeuvreAttrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn urbanlManoeuvreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn detailLevelDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dirInfoIdxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dirInfoIdxDataGridViewTextBoxColumn_text;
        private System.Windows.Forms.DataGridViewTextBoxColumn dirInfoNodeTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exitAngleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exitAngleNorthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn exitNrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locInfoIdxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locInfoIdxDataGridViewTextBoxColumn_text;
        private System.Windows.Forms.DataGridViewTextBoxColumn locInfoNodeTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manoeuvreDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manoeuvreGroupIdxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manoeuvreTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn predSegmentIdxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn routeListSegmentIdxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn succSegmentIdxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn turnOrientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn turnWeightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn viaIdxDataGridViewTextBoxColumn;

    }
}