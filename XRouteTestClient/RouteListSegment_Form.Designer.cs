namespace XRouteTestClient
{
    partial class RouteListSegment_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RouteListSegment_Form));
            this.dgvRouteListSegment = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routeListSegmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accDistDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iuCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vCalcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vNormDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.speedLimitsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.violationsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstPolyIdxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.polyCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNodeIdxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nodeCDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dirInfoIdxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.streetNameIdxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.streetNoIdxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRouteListSegment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeListSegmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRouteListSegment
            // 
            this.dgvRouteListSegment.AutoGenerateColumns = false;
            this.dgvRouteListSegment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRouteListSegment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.accDistDataGridViewTextBoxColumn,
            this.accTimeDataGridViewTextBoxColumn,
            this.countryCodeDataGridViewTextBoxColumn,
            this.iuCodeDataGridViewTextBoxColumn,
            this.nCDataGridViewTextBoxColumn,
            this.vCalcDataGridViewTextBoxColumn,
            this.vNormDataGridViewTextBoxColumn,
            this.speedLimitsDataGridViewTextBoxColumn,
            this.violationsDataGridViewTextBoxColumn,
            this.firstPolyIdxDataGridViewTextBoxColumn,
            this.polyCDataGridViewTextBoxColumn,
            this.firstNodeIdxDataGridViewTextBoxColumn,
            this.nodeCDataGridViewTextBoxColumn,
            this.dirInfoIdxDataGridViewTextBoxColumn,
            this.streetNameIdxDataGridViewTextBoxColumn,
            this.streetNoIdxDataGridViewTextBoxColumn});
            this.dgvRouteListSegment.DataSource = this.routeListSegmentBindingSource;
            this.dgvRouteListSegment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRouteListSegment.Location = new System.Drawing.Point(0, 0);
            this.dgvRouteListSegment.Name = "dgvRouteListSegment";
            this.dgvRouteListSegment.Size = new System.Drawing.Size(732, 256);
            this.dgvRouteListSegment.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "normSpeed";
            this.dataGridViewTextBoxColumn1.HeaderText = "normSpeed";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "normSpeed";
            this.dataGridViewTextBoxColumn2.HeaderText = "normSpeed";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "speedLimits";
            this.dataGridViewTextBoxColumn3.HeaderText = "speedLimits";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "normSpeed";
            this.dataGridViewTextBoxColumn4.HeaderText = "normSpeed";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ToolTipText = resources.GetString("dataGridViewTextBoxColumn4.ToolTipText");
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "speedLimits";
            this.dataGridViewTextBoxColumn5.HeaderText = "speedLimits";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ToolTipText = resources.GetString("dataGridViewTextBoxColumn5.ToolTipText");
            // 
            // routeListSegmentBindingSource
            // 
            this.routeListSegmentBindingSource.DataSource = typeof(XServer.RouteListSegment);
            // 
            // accDistDataGridViewTextBoxColumn
            // 
            this.accDistDataGridViewTextBoxColumn.DataPropertyName = "accDist";
            this.accDistDataGridViewTextBoxColumn.HeaderText = "accDist";
            this.accDistDataGridViewTextBoxColumn.Name = "accDistDataGridViewTextBoxColumn";
            // 
            // accTimeDataGridViewTextBoxColumn
            // 
            this.accTimeDataGridViewTextBoxColumn.DataPropertyName = "accTime";
            this.accTimeDataGridViewTextBoxColumn.HeaderText = "accTime";
            this.accTimeDataGridViewTextBoxColumn.Name = "accTimeDataGridViewTextBoxColumn";
            // 
            // countryCodeDataGridViewTextBoxColumn
            // 
            this.countryCodeDataGridViewTextBoxColumn.DataPropertyName = "countryCode";
            this.countryCodeDataGridViewTextBoxColumn.HeaderText = "countryCode";
            this.countryCodeDataGridViewTextBoxColumn.Name = "countryCodeDataGridViewTextBoxColumn";
            // 
            // iuCodeDataGridViewTextBoxColumn
            // 
            this.iuCodeDataGridViewTextBoxColumn.DataPropertyName = "iuCode";
            this.iuCodeDataGridViewTextBoxColumn.HeaderText = "iuCode";
            this.iuCodeDataGridViewTextBoxColumn.Name = "iuCodeDataGridViewTextBoxColumn";
            // 
            // nCDataGridViewTextBoxColumn
            // 
            this.nCDataGridViewTextBoxColumn.DataPropertyName = "nC";
            this.nCDataGridViewTextBoxColumn.HeaderText = "nC";
            this.nCDataGridViewTextBoxColumn.Name = "nCDataGridViewTextBoxColumn";
            // 
            // vCalcDataGridViewTextBoxColumn
            // 
            this.vCalcDataGridViewTextBoxColumn.DataPropertyName = "vCalc";
            this.vCalcDataGridViewTextBoxColumn.HeaderText = "vCalc";
            this.vCalcDataGridViewTextBoxColumn.Name = "vCalcDataGridViewTextBoxColumn";
            // 
            // vNormDataGridViewTextBoxColumn
            // 
            this.vNormDataGridViewTextBoxColumn.DataPropertyName = "vNorm";
            this.vNormDataGridViewTextBoxColumn.HeaderText = "vNorm";
            this.vNormDataGridViewTextBoxColumn.Name = "vNormDataGridViewTextBoxColumn";
            // 
            // speedLimitsDataGridViewTextBoxColumn
            // 
            this.speedLimitsDataGridViewTextBoxColumn.DataPropertyName = "speedLimits";
            this.speedLimitsDataGridViewTextBoxColumn.HeaderText = "speedLimits";
            this.speedLimitsDataGridViewTextBoxColumn.Name = "speedLimitsDataGridViewTextBoxColumn";
            // 
            // violationsDataGridViewTextBoxColumn
            // 
            this.violationsDataGridViewTextBoxColumn.DataPropertyName = "Violations";
            this.violationsDataGridViewTextBoxColumn.HeaderText = "Violations";
            this.violationsDataGridViewTextBoxColumn.Name = "violationsDataGridViewTextBoxColumn";
            // 
            // firstPolyIdxDataGridViewTextBoxColumn
            // 
            this.firstPolyIdxDataGridViewTextBoxColumn.DataPropertyName = "firstPolyIdx";
            this.firstPolyIdxDataGridViewTextBoxColumn.HeaderText = "firstPolyIdx";
            this.firstPolyIdxDataGridViewTextBoxColumn.Name = "firstPolyIdxDataGridViewTextBoxColumn";
            // 
            // polyCDataGridViewTextBoxColumn
            // 
            this.polyCDataGridViewTextBoxColumn.DataPropertyName = "polyC";
            this.polyCDataGridViewTextBoxColumn.HeaderText = "polyC";
            this.polyCDataGridViewTextBoxColumn.Name = "polyCDataGridViewTextBoxColumn";
            // 
            // firstNodeIdxDataGridViewTextBoxColumn
            // 
            this.firstNodeIdxDataGridViewTextBoxColumn.DataPropertyName = "firstNodeIdx";
            this.firstNodeIdxDataGridViewTextBoxColumn.HeaderText = "firstNodeIdx";
            this.firstNodeIdxDataGridViewTextBoxColumn.Name = "firstNodeIdxDataGridViewTextBoxColumn";
            // 
            // nodeCDataGridViewTextBoxColumn
            // 
            this.nodeCDataGridViewTextBoxColumn.DataPropertyName = "nodeC";
            this.nodeCDataGridViewTextBoxColumn.HeaderText = "nodeC";
            this.nodeCDataGridViewTextBoxColumn.Name = "nodeCDataGridViewTextBoxColumn";
            // 
            // dirInfoIdxDataGridViewTextBoxColumn
            // 
            this.dirInfoIdxDataGridViewTextBoxColumn.DataPropertyName = "dirInfoIdx";
            this.dirInfoIdxDataGridViewTextBoxColumn.HeaderText = "dirInfoIdx";
            this.dirInfoIdxDataGridViewTextBoxColumn.Name = "dirInfoIdxDataGridViewTextBoxColumn";
            // 
            // streetNameIdxDataGridViewTextBoxColumn
            // 
            this.streetNameIdxDataGridViewTextBoxColumn.DataPropertyName = "streetNameIdx";
            this.streetNameIdxDataGridViewTextBoxColumn.HeaderText = "streetNameIdx";
            this.streetNameIdxDataGridViewTextBoxColumn.Name = "streetNameIdxDataGridViewTextBoxColumn";
            // 
            // streetNoIdxDataGridViewTextBoxColumn
            // 
            this.streetNoIdxDataGridViewTextBoxColumn.DataPropertyName = "streetNoIdx";
            this.streetNoIdxDataGridViewTextBoxColumn.HeaderText = "streetNoIdx";
            this.streetNoIdxDataGridViewTextBoxColumn.Name = "streetNoIdxDataGridViewTextBoxColumn";
            // 
            // RouteListSegment_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 256);
            this.Controls.Add(this.dgvRouteListSegment);
            this.Name = "RouteListSegment_Form";
            this.Text = "RouteListSegment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RouteListSegment_Form_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRouteListSegment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeListSegmentBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRouteListSegment;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.BindingSource routeListSegmentBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn accDistDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iuCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vCalcDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vNormDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn speedLimitsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn violationsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstPolyIdxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn polyCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNodeIdxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nodeCDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dirInfoIdxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn streetNameIdxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn streetNoIdxDataGridViewTextBoxColumn;
    }
}