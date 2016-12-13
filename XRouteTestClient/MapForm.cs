using Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using XServer;

namespace XRouteTestClient
{
    public partial class MapForm : Form
    {
        private System.Drawing.Point lastTooltip = new System.Drawing.Point(-1, -1);

        private List<MapSection> lstMapSection = new List<MapSection>();
        private MapSection mapSection = null;
        private Map map = null;
        private ImageInfo imageInfo = new ImageInfo();
        private MapParams mapParams = new MapParams();
        private Layer[] arrLayer = null;

        private const string profileSnippetTemplate =
@"<?xml version='1.0' encoding='UTF-8'?>
<Profile xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>
  <FeatureLayer majorVersion='1' minorVersion='0'>
    <GlobalSettings enableTimeDependency='true'/>
    <Themes>
      <Theme id='PTV_TrafficIncidents' enabled='{0}'>
        <FeatureDescription includeTimeDomain='true'>
          <Property id='*' included='true'/>
        </FeatureDescription>
      </Theme>
      <Theme id='PTV_SpeedPatterns' enabled='{1}'>
        <FeatureDescription includeTimeDomain='true'>
          <Property id='*' included='true'/>
        </FeatureDescription>
      </Theme>
      <Theme id='PTV_TruckSpeedPatterns' enabled='{2}'>
        <FeatureDescription includeTimeDomain='true'>
          <Property id='*' included='true'/>
        </FeatureDescription>
      </Theme>
      <Theme id='PTV_TruckAttributes' enabled='{3}'>
        <FeatureDescription includeTimeDomain='true'>
          <Property id='*' included='true'/>
        </FeatureDescription>
      </Theme>
      <Theme id='PTV_PreferredRoutes' enabled='{4}'>
        <FeatureDescription includeTimeDomain='true'>
          <Property id='*' included='true'/>
        </FeatureDescription>
      </Theme>
    </Themes>
  </FeatureLayer>
</Profile>";

        private CallerContextProperty profileSnippetProperty = new CallerContextProperty() { key = "ProfileXMLSnippet", };

        private XMapWSService svcMap = new XMapWSService()
        {
            Credentials = StaticClass.credentials,
        };

        private XServer.CallerContext callerContext = null;

        public MapForm(string url, MapSection mapSection, Layer[] arrLayer, XServer.CallerContext callerContext, string timeStamp)
        {
            InitializeComponent();
            this.svcMap.Url = url;
            if (mapSection == null)
            {
                XServer.Point dummy = new XServer.Point();
                dummy.wkt = "POINT (0 0)";
                mapSection = new MapSection(dummy, 0, 0, 1000, 0);
            }
            this.mapSection = mapSection;
            this.mapParams.showScale = Properties.Settings.Default.ShowScale;
            this.mapParams.referenceTime = timeStamp;
            this.imageInfo.format = ImageFileFormat.PNG;
            this.arrLayer = arrLayer;

            var tempPropertyList = callerContext.wrappedProperties.ToList();
            tempPropertyList.Add(profileSnippetProperty);
            callerContext.wrappedProperties = tempPropertyList.ToArray();
            this.callerContext = callerContext;

            renderMap();
            centerLayer(false);
            // check the status of layers
            foreach (Layer curLayer in arrLayer)
            {
                foreach (ToolStripMenuItem tsmi in layersToolStripMenuItem.DropDownItems)
                    if (curLayer.name == tsmi.Text)
                        tsmi.Checked = curLayer.visible;
            }
        }

        public MapForm(string url, MapSection mapSection, Layer[] arrLayer, XServer.CallerContext callerContext) :
            this(url, mapSection, arrLayer, callerContext, DateTime.Now.ToString("o"))
        { }

        public void centerLayer(bool center)
        {
            foreach (Layer curLayer in arrLayer)
            {
                if (curLayer.GetType() == typeof(CustomLayer))
                    ((CustomLayer)curLayer).centerObjects = center;
            }
        }

        public void renderMap()
        {
            try
            {
                if ((pbxMap.Width > 0) && (pbxMap.Height > 0))
                {
                    imageInfo.width = pbxMap.Width;
                    imageInfo.height = pbxMap.Height;
                    List<Layer> lstVisibleLayers = new List<Layer>();
                    foreach (Layer curLayer in arrLayer)
                    {
                        if (curLayer.visible)
                            lstVisibleLayers.Add(curLayer);
                    }

                    DateTime dtStart = DateTime.Now;
                    map = svcMap.renderMap(mapSection, mapParams, imageInfo, lstVisibleLayers.ToArray(), true, callerContext);
                    DateTime dtStop = DateTime.Now;
                    TimeSpan ts = dtStop.Subtract(dtStart);
                    this.Text = ts.TotalMilliseconds.ToString() + " ms";
                    pbxMap.Image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(map.image.rawImage));
                    pbxMap.Visible = true;
                    pbxMap.Update();
                    mapSection = new MapSection(map.visibleSection.center, 0, 0, map.visibleSection.scale, 0);
                    lstMapSection.Add(new MapSection(map.visibleSection.center, 0, 0, map.visibleSection.scale, 0));
                    centerLayer(false);
                }
            }
            catch (System.Web.Services.Protocols.SoapException soapException)
            {
                System.Windows.Forms.MessageBox.Show(soapException.Detail.InnerXml);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void MapForm_Load(object sender, EventArgs e)
        {
        }

        private void pbxMap_Click(object sender, EventArgs e)
        {
            MouseEventArgs a = (MouseEventArgs)e;
            if (a.Button != MouseButtons.Right)
            {
                double dx = -100.0 + 200.0 * Convert.ToDouble(a.X) / Convert.ToDouble(pbxMap.Width);
                double dy = 100.0 - 200 * Convert.ToDouble(a.Y) / Convert.ToDouble(pbxMap.Height);
                mapSection.scrollHorizontal = Convert.ToInt32(dx);
                mapSection.scrollVertical = Convert.ToInt32(dy);
                renderMap();
            }
            else
            {
            }
        }

        private void MapForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool keyPressed = true;
            int scroll = Properties.Settings.Default.scroll;
            if (e.KeyChar == '+')
                mapSection.zoom = 1;
            else if (e.KeyChar == '-')
                mapSection.zoom = -1;
            else if (e.KeyChar == '4')
                mapSection.scrollHorizontal = -scroll;
            else if (e.KeyChar == '6')
                mapSection.scrollHorizontal = scroll;
            else if (e.KeyChar == '2')
                mapSection.scrollVertical = -scroll;
            else if (e.KeyChar == '8')
                mapSection.scrollVertical = scroll;
            else if (e.KeyChar == '1')
            {
                mapSection.scrollHorizontal = -scroll;
                mapSection.scrollVertical = -scroll;
            }
            else if (e.KeyChar == '3')
            {
                mapSection.scrollHorizontal = scroll;
                mapSection.scrollVertical = -scroll;
            }
            else if (e.KeyChar == '7')
            {
                mapSection.scrollHorizontal = -scroll;
                mapSection.scrollVertical = scroll;
            }
            else if (e.KeyChar == '9')
            {
                mapSection.scrollHorizontal = scroll;
                mapSection.scrollVertical = scroll;
            }
            else if (e.KeyChar == '5')
            {
                centerLayer(true);
            }
            else if (e.KeyChar == '0')
            {
                // repaint();
            }
            else if ((e.KeyChar == 'm') || (e.KeyChar == 'M'))
            {
                switchVisibility("Manoeuvres");
            }
            else if ((e.KeyChar == 'g') || (e.KeyChar == 'G'))
            {
                switchVisibility("ManoeuvreGroups");
            }
            else if ((e.KeyChar == 'b') || (e.KeyChar == 'B'))
            {
                switchVisibility("BoundingRectangles");
            }
            else if ((e.KeyChar == 'w') || (e.KeyChar == 'W'))
            {
                switchVisibility("Waypoints");
            }
            else if ((e.KeyChar == 't') || (e.KeyChar == 'T'))
            {
                switchVisibility("hasTollTruck");
            }
            else if ((e.KeyChar == 'c') || (e.KeyChar == 'C'))
            {
                switchVisibility("hasTollCar");
            }
            else if ((e.KeyChar == 'r') || (e.KeyChar == 'R'))
            {
                switchVisibility("Route");
            }
            else if ((e.KeyChar == 'e') || (e.KeyChar == 'E'))
            {
                switchVisibility("TimeEvents");
            }
            else if ((e.KeyChar == 'f') || (e.KeyChar == 'F'))
            {
                switchVisibility("Ferries");
            }
            else if ((e.KeyChar == 's') || (e.KeyChar == 'S'))
            {
                mapParams.showScale = !mapParams.showScale;
            }
            else if ((e.KeyChar == 'a') || (e.KeyChar == 'A'))
            {
                switchVisibility("TollSections");
            }
            else if ((e.KeyChar == 'h') || (e.KeyChar == 'H'))
            {
                if (lstMapSection.Count > 1)
                {
                    int count = lstMapSection.Count;
                    // jump to the previous mapsection
                    mapSection = lstMapSection[count - 2];
                    // remove the last two entries
                    lstMapSection.RemoveRange(count - 2, 2);
                }
                else
                {
                    keyPressed = false;
                }
            }
            else
                keyPressed = false;
            if (keyPressed)
                renderMap();
        }

        private void switchVisibility(string name)
        {
            foreach (Layer layer in arrLayer)
            {
                if (layer.name == name)
                    layer.visible = !(layer.visible);
            }
        }

        private void MapForm_ResizeEnd(object sender, EventArgs e)
        {
            renderMap();
        }

        private void pbxMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (map == null) return;
            if (lastTooltip == e.Location)
                return;
            else
                lastTooltip = e.Location;

            double mx = (double)(e.X), my = (double)(e.Y);
            List<string> lstDescr = new List<string>();
            foreach (ObjectInfos oi in map.wrappedObjects)
            {
                foreach (LayerObject lo in oi.wrappedObjects)
                {
                    if (pixDistance(mx, my, lo.pixel.x, lo.pixel.y) < 10.0)
                    {
                        lstDescr.Add(oi.name + " : " + lo.descr);
                    }
                }
            }
            if (lstDescr.Count > 0)
            {
                string descr = String.Join("\r\n", lstDescr.ToArray());
                toolTip1.ToolTipTitle = "ObjectInfos : LayerObjects";
                toolTip1.Show(descr, this, e.X, e.Y);
            }
            else
            {
                toolTip1.Hide(this);
            }
        }

        private double pixDistance(double x1, double y1, double x2, double y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }

        private void layerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            tsmi.Checked = !(tsmi.Checked);
            switchVisibility(tsmi.Text);
            renderMap();
        }

        private void lZVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int len = arrLayer.Length + 1;
            Layer[] tempArray = new Layer[len];
            Array.Copy(arrLayer, tempArray, arrLayer.Length);
            arrLayer = tempArray;
            arrLayer[arrLayer.Length - 1] = new FeatureLayer() { name = "PTV_PreferredRoutes", visible = true };
            lZVToolStripMenuItem.Checked = true;
            lZVToolStripMenuItem.Enabled = false;
        }

        private void SetVisibilityFeatureLayer(string layerName, ToolStripMenuItem toolStripMenuItem)
        {
            var featureLayer = arrLayer.FirstOrDefault(l => l.name == layerName);
            if (featureLayer == null)
            {
                featureLayer = new FeatureLayer() { name = layerName };
                if (layerName == "PTV_TruckAttributes" || layerName == "PTV_TrafficIncidents") (featureLayer as FeatureLayer).objectInfos = ObjectInfoType.REFERENCEPOINT;
                var layerList = arrLayer.ToList();
                layerList.Add(featureLayer);
                arrLayer = layerList.ToArray();
            }
            toolStripMenuItem.Checked = !(toolStripMenuItem.Checked);
            featureLayer.visible = toolStripMenuItem.Checked;

            profileSnippetProperty.value = String.Format(
                profileSnippetTemplate,
                pTVTrafficIncidentsToolStripMenuItem.Checked.ToString(),
                pTVSpeedPatternsToolStripMenuItem.Checked.ToString(),
                pTVTruckSpeedPatternsToolStripMenuItem.Checked.ToString(),
                pTVTruckAttributesToolStripMenuItem.Checked.ToString(),
                pTVPrefferedRoutesToolStripMenuItem.Checked.ToString()
                );

            renderMap();
        }

        private void pTVTruckAttributesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetVisibilityFeatureLayer("PTV_TruckAttributes", (ToolStripMenuItem)sender);
        }

        private void pTVTrafficIncidentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetVisibilityFeatureLayer("PTV_TrafficIncidents", (ToolStripMenuItem)sender);
        }

        private void pTVSpeedPatternsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetVisibilityFeatureLayer("PTV_SpeedPatterns", (ToolStripMenuItem)sender);
        }

        private void pTVTruckSpeedPatternsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetVisibilityFeatureLayer("PTV_TruckSpeedPatterns", (ToolStripMenuItem)sender);
        }

        private void pTVPrefferedRoutesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetVisibilityFeatureLayer("PTV_PreferredRoutes", (ToolStripMenuItem)sender);
        }
    }
}