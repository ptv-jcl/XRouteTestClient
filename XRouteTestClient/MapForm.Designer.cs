namespace XRouteTestClient
{
    partial class MapForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapForm));
            this.pbxMap = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.layersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.routeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.waypointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hasTollTruckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hasTollCarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boundingRectanglesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manoeuvresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manoeuvreGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ferriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.routePointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tollSectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lZVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.featureLayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pTVTrafficIncidentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pTVSpeedPatternsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pTVTruckSpeedPatternsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pTVTruckAttributesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pTVPrefferedRoutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pTVRestrictionZonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMap)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxMap
            // 
            this.pbxMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxMap.Location = new System.Drawing.Point(0, 24);
            this.pbxMap.Name = "pbxMap";
            this.pbxMap.Size = new System.Drawing.Size(635, 477);
            this.pbxMap.TabIndex = 0;
            this.pbxMap.TabStop = false;
            this.pbxMap.Click += new System.EventHandler(this.pbxMap_Click);
            this.pbxMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbxMap_MouseMove);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.layersToolStripMenuItem,
            this.lZVToolStripMenuItem,
            this.featureLayerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(635, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // layersToolStripMenuItem
            // 
            this.layersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.routeToolStripMenuItem,
            this.waypointsToolStripMenuItem,
            this.hasTollTruckToolStripMenuItem,
            this.hasTollCarToolStripMenuItem,
            this.boundingRectanglesToolStripMenuItem,
            this.manoeuvresToolStripMenuItem,
            this.manoeuvreGroupsToolStripMenuItem,
            this.timeEventsToolStripMenuItem,
            this.ferriesToolStripMenuItem,
            this.routePointToolStripMenuItem,
            this.segmentsToolStripMenuItem,
            this.tollSectionsToolStripMenuItem});
            this.layersToolStripMenuItem.Name = "layersToolStripMenuItem";
            this.layersToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.layersToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.layersToolStripMenuItem.Text = "Layers";
            this.layersToolStripMenuItem.ToolTipText = "Enables/disables visualization of TimeEvents (calcTour only)";
            this.layersToolStripMenuItem.Click += new System.EventHandler(this.layerToolStripMenuItem_Click);
            // 
            // routeToolStripMenuItem
            // 
            this.routeToolStripMenuItem.Name = "routeToolStripMenuItem";
            this.routeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.routeToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.routeToolStripMenuItem.Text = "Route";
            this.routeToolStripMenuItem.ToolTipText = "Enables/disables visualization of the routing polygon";
            this.routeToolStripMenuItem.Click += new System.EventHandler(this.layerToolStripMenuItem_Click);
            // 
            // waypointsToolStripMenuItem
            // 
            this.waypointsToolStripMenuItem.Name = "waypointsToolStripMenuItem";
            this.waypointsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.waypointsToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.waypointsToolStripMenuItem.Text = "Waypoints";
            this.waypointsToolStripMenuItem.ToolTipText = "Enables/disables visualization of the waypoints (start, via, destination)";
            this.waypointsToolStripMenuItem.Click += new System.EventHandler(this.layerToolStripMenuItem_Click);
            // 
            // hasTollTruckToolStripMenuItem
            // 
            this.hasTollTruckToolStripMenuItem.Name = "hasTollTruckToolStripMenuItem";
            this.hasTollTruckToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.hasTollTruckToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.hasTollTruckToolStripMenuItem.Text = "hasTollTruck";
            this.hasTollTruckToolStripMenuItem.ToolTipText = "Enables/disables visualization of truck toll sections";
            this.hasTollTruckToolStripMenuItem.Click += new System.EventHandler(this.layerToolStripMenuItem_Click);
            // 
            // hasTollCarToolStripMenuItem
            // 
            this.hasTollCarToolStripMenuItem.Name = "hasTollCarToolStripMenuItem";
            this.hasTollCarToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.hasTollCarToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.hasTollCarToolStripMenuItem.Text = "hasTollCar";
            this.hasTollCarToolStripMenuItem.ToolTipText = "Enables/disables visualization of truck toll sections";
            this.hasTollCarToolStripMenuItem.Click += new System.EventHandler(this.layerToolStripMenuItem_Click);
            // 
            // boundingRectanglesToolStripMenuItem
            // 
            this.boundingRectanglesToolStripMenuItem.Name = "boundingRectanglesToolStripMenuItem";
            this.boundingRectanglesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.boundingRectanglesToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.boundingRectanglesToolStripMenuItem.Text = "BoundingRectangles";
            this.boundingRectanglesToolStripMenuItem.ToolTipText = "Enables/disables visualization of bounding rectangles. \r\nThese rectangles are hel" +
    "pful for a corridor search.";
            this.boundingRectanglesToolStripMenuItem.Click += new System.EventHandler(this.layerToolStripMenuItem_Click);
            // 
            // manoeuvresToolStripMenuItem
            // 
            this.manoeuvresToolStripMenuItem.Name = "manoeuvresToolStripMenuItem";
            this.manoeuvresToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.manoeuvresToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.manoeuvresToolStripMenuItem.Text = "Manoeuvres";
            this.manoeuvresToolStripMenuItem.ToolTipText = "Enables/disables visualization of manoeuvres, i.e. the concrete coordinate \r\nwher" +
    "e the driver is expected to perform a specific manoeuvre.";
            this.manoeuvresToolStripMenuItem.Click += new System.EventHandler(this.layerToolStripMenuItem_Click);
            // 
            // manoeuvreGroupsToolStripMenuItem
            // 
            this.manoeuvreGroupsToolStripMenuItem.Name = "manoeuvreGroupsToolStripMenuItem";
            this.manoeuvreGroupsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.manoeuvreGroupsToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.manoeuvreGroupsToolStripMenuItem.Text = "ManoeuvreGroups";
            this.manoeuvreGroupsToolStripMenuItem.ToolTipText = resources.GetString("manoeuvreGroupsToolStripMenuItem.ToolTipText");
            this.manoeuvreGroupsToolStripMenuItem.Click += new System.EventHandler(this.layerToolStripMenuItem_Click);
            // 
            // timeEventsToolStripMenuItem
            // 
            this.timeEventsToolStripMenuItem.Name = "timeEventsToolStripMenuItem";
            this.timeEventsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.timeEventsToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.timeEventsToolStripMenuItem.Text = "TimeEvents";
            this.timeEventsToolStripMenuItem.Click += new System.EventHandler(this.layerToolStripMenuItem_Click);
            // 
            // ferriesToolStripMenuItem
            // 
            this.ferriesToolStripMenuItem.Name = "ferriesToolStripMenuItem";
            this.ferriesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.ferriesToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.ferriesToolStripMenuItem.Text = "Ferries";
            this.ferriesToolStripMenuItem.Click += new System.EventHandler(this.layerToolStripMenuItem_Click);
            // 
            // routePointToolStripMenuItem
            // 
            this.routePointToolStripMenuItem.Name = "routePointToolStripMenuItem";
            this.routePointToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.routePointToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.routePointToolStripMenuItem.Text = "RoutePoint";
            this.routePointToolStripMenuItem.Click += new System.EventHandler(this.layerToolStripMenuItem_Click);
            // 
            // segmentsToolStripMenuItem
            // 
            this.segmentsToolStripMenuItem.Name = "segmentsToolStripMenuItem";
            this.segmentsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.segmentsToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.segmentsToolStripMenuItem.Text = "Segments";
            this.segmentsToolStripMenuItem.Click += new System.EventHandler(this.layerToolStripMenuItem_Click);
            // 
            // tollSectionsToolStripMenuItem
            // 
            this.tollSectionsToolStripMenuItem.Name = "tollSectionsToolStripMenuItem";
            this.tollSectionsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.tollSectionsToolStripMenuItem.Size = new System.Drawing.Size(224, 22);
            this.tollSectionsToolStripMenuItem.Text = "TollSections";
            this.tollSectionsToolStripMenuItem.Click += new System.EventHandler(this.layerToolStripMenuItem_Click);
            // 
            // lZVToolStripMenuItem
            // 
            this.lZVToolStripMenuItem.Name = "lZVToolStripMenuItem";
            this.lZVToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.lZVToolStripMenuItem.Text = "LZV";
            this.lZVToolStripMenuItem.Click += new System.EventHandler(this.lZVToolStripMenuItem_Click);
            // 
            // featureLayerToolStripMenuItem
            // 
            this.featureLayerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pTVTrafficIncidentsToolStripMenuItem,
            this.pTVSpeedPatternsToolStripMenuItem,
            this.pTVTruckSpeedPatternsToolStripMenuItem,
            this.pTVTruckAttributesToolStripMenuItem,
            this.pTVPrefferedRoutesToolStripMenuItem,
            this.pTVRestrictionZonesToolStripMenuItem});
            this.featureLayerToolStripMenuItem.Name = "featureLayerToolStripMenuItem";
            this.featureLayerToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.featureLayerToolStripMenuItem.Text = "FeatureLayer";
            // 
            // pTVTrafficIncidentsToolStripMenuItem
            // 
            this.pTVTrafficIncidentsToolStripMenuItem.Name = "pTVTrafficIncidentsToolStripMenuItem";
            this.pTVTrafficIncidentsToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.pTVTrafficIncidentsToolStripMenuItem.Text = "PTV_TrafficIncidents";
            this.pTVTrafficIncidentsToolStripMenuItem.Click += new System.EventHandler(this.pTVTrafficIncidentsToolStripMenuItem_Click);
            // 
            // pTVSpeedPatternsToolStripMenuItem
            // 
            this.pTVSpeedPatternsToolStripMenuItem.Name = "pTVSpeedPatternsToolStripMenuItem";
            this.pTVSpeedPatternsToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.pTVSpeedPatternsToolStripMenuItem.Text = "PTV_SpeedPatterns";
            this.pTVSpeedPatternsToolStripMenuItem.Click += new System.EventHandler(this.pTVSpeedPatternsToolStripMenuItem_Click);
            // 
            // pTVTruckSpeedPatternsToolStripMenuItem
            // 
            this.pTVTruckSpeedPatternsToolStripMenuItem.Name = "pTVTruckSpeedPatternsToolStripMenuItem";
            this.pTVTruckSpeedPatternsToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.pTVTruckSpeedPatternsToolStripMenuItem.Text = "PTV_TruckSpeedPatterns";
            this.pTVTruckSpeedPatternsToolStripMenuItem.Click += new System.EventHandler(this.pTVTruckSpeedPatternsToolStripMenuItem_Click);
            // 
            // pTVTruckAttributesToolStripMenuItem
            // 
            this.pTVTruckAttributesToolStripMenuItem.Name = "pTVTruckAttributesToolStripMenuItem";
            this.pTVTruckAttributesToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.pTVTruckAttributesToolStripMenuItem.Text = "PTV_TruckAttributes";
            this.pTVTruckAttributesToolStripMenuItem.Click += new System.EventHandler(this.pTVTruckAttributesToolStripMenuItem_Click);
            // 
            // pTVPrefferedRoutesToolStripMenuItem
            // 
            this.pTVPrefferedRoutesToolStripMenuItem.Name = "pTVPrefferedRoutesToolStripMenuItem";
            this.pTVPrefferedRoutesToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.pTVPrefferedRoutesToolStripMenuItem.Text = "PTV_PreferredRoutes";
            this.pTVPrefferedRoutesToolStripMenuItem.Click += new System.EventHandler(this.pTVPrefferedRoutesToolStripMenuItem_Click);
            // 
            // pTVRestrictionZonesToolStripMenuItem
            // 
            this.pTVRestrictionZonesToolStripMenuItem.Name = "pTVRestrictionZonesToolStripMenuItem";
            this.pTVRestrictionZonesToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.pTVRestrictionZonesToolStripMenuItem.Text = "PTV_RestrictionZones";
            this.pTVRestrictionZonesToolStripMenuItem.Click += new System.EventHandler(this.pTVRestrictionZonesToolStripMenuItem_Click);
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 501);
            this.Controls.Add(this.pbxMap);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MapForm";
            this.Text = "MapForm";
            this.Load += new System.EventHandler(this.MapForm_Load);
            this.ResizeEnd += new System.EventHandler(this.MapForm_ResizeEnd);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MapForm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pbxMap)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxMap;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem layersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem routeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem waypointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hasTollTruckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hasTollCarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boundingRectanglesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manoeuvresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manoeuvreGroupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeEventsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ferriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem routePointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem segmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tollSectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lZVToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem featureLayerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pTVTrafficIncidentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pTVSpeedPatternsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pTVTruckSpeedPatternsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pTVTruckAttributesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pTVPrefferedRoutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pTVRestrictionZonesToolStripMenuItem;
    }
}