using System.Diagnostics;
using System.Web.Services;
using System.ComponentModel;
using System.Web.Services.Protocols;
using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace XServer
{


    // 2014-09-16
    // make segment attrbitues directly vieable from routelistsegment so we can easily populuate datagrid
    public partial class RouteListSegment
    {
        [XmlIgnore]
        public BrunnelCode brunnelCode { get { if (this.segmentAttr != null) return this.segmentAttr.brunnelCode; else return BrunnelCode.NOTHING; } private set { } }
        [XmlIgnore]
        public bool isFerry { get { if (this.segmentAttr != null) return this.segmentAttr.isFerry; else return false; } private set { } }
        [XmlIgnore]
        public bool isBlockedCar { get { if (this.segmentAttr != null) return this.segmentAttr.isBlockedCar; else return false; } private set { } }
        [XmlIgnore]
        public bool isBlockedTruck { get { if (this.segmentAttr != null) return this.segmentAttr.isBlockedTruck; else return false; } private set { } }
        [XmlIgnore]
        public bool hasTollCar { get { if (this.segmentAttr != null) return this.segmentAttr.hasTollCar; else return false; } private set { } }
        [XmlIgnore]
        public bool hasTollTruck { get { if (this.segmentAttr != null) return this.segmentAttr.hasTollTruck; else return false; } private set { } }
        [XmlIgnore]
        public bool hasVignetteCar { get { if (this.segmentAttr != null) return this.segmentAttr.hasVignetteCar; else return false; } private set { } }
        [XmlIgnore]
        public bool hasVignetteTruck { get { if (this.segmentAttr != null) return this.segmentAttr.hasVignetteTruck; else return false; } private set { } }
        [XmlIgnore]
        public bool hasExtraToll { get { if (this.segmentAttr != null) return this.segmentAttr.hasExtraToll; else return false; } private set { } }
        [XmlIgnore]
        public bool hasNamedToll { get { if (this.segmentAttr != null) return this.segmentAttr.hasNamedToll; else return false; } private set { } }
        [XmlIgnore]
        public bool hasSeparator { get { if (this.segmentAttr != null) return this.segmentAttr.hasSeparator; else return false; } private set { } }
        [XmlIgnore]
        public bool isPedestrianZone { get { if (this.segmentAttr != null) return this.segmentAttr.isPedestrianZone; else return false; } private set { } }
        [XmlIgnore]
        public bool isPiggyback { get { if (this.segmentAttr != null) return this.segmentAttr.isPiggyback; else return false; } private set { } }
        [XmlIgnore]
        public string additionalRE { get { if (this.segmentAttr != null) return this.segmentAttr.additionalRE; else return ""; } private set { } }
        [XmlIgnore]
        public string additionalInfo { get { if (this.segmentAttr != null) return this.segmentAttr.additionalRE; else return ""; } private set { } }
        [XmlIgnore]
        public string lowEmissionZoneType { get { if (this.segmentAttr != null) return this.segmentAttr.additionalRE; else return ""; } private set { } }
    }

    // 2012.10.18 - SpeedLimit (invented with 1.14.1)
    public partial class SpeedLimit
    {
        public override string ToString()
        {
            return this.condition.Replace("|"," | ");
        }
    }
    // 2012.10.18 - SpeedLimits
    public partial class SpeedLimits
    {
        public override string ToString()
        {
            List<string> lstSpeedLimit = new List<string>();
            foreach (SpeedLimit curSpeeedLimit in this.wrappedSpeedLimit)
                lstSpeedLimit.Add(curSpeeedLimit.ToString());
            return String.Join(",",lstSpeedLimit.ToArray());
        }
    }
    
    
    // 2011.12.29
    public partial class NormSpeed
    {
        public override string ToString()
        {
            return this.normSpeedType.ToString() + "=" + this.normSpeed;
        }
    }

    public partial class Point : EncodedGeometry
    {

        public override string ToString()
        {
            if (this.point != null)
                return this.point.ToString();
            else if (this.wkb != null)
                return this.wkb.ToString();
            else if (this.wkt != null)
                return this.wkt.ToString();
            else
                return "n/a";
        }
    }
    
    partial class Color
    {
        public Color() : base() { }

        public Color(System.Drawing.Color color)
            : base()
        {
            this.blue = color.B;
            this.red = color.R;
            this.green = color.G;
        }

        public Color(int r, int g, int b)
            : base()
        {
            this.blue = b;
            this.green = g;
            this.red = r;
        }

    }

    partial class TollStationDescription : TransientVO
    {
        public override string ToString()
        {
            string result = "";
            result += routeListIndex.ToString();
            result += "-" + tollStationName;
            result += " (ID=" + tollStationID.ToString();
            if ((time != null) && (time != ""))
                result += "/" + time;
            result += ")";
            return result;
        }
    }

    partial class PlainPoint
    {
        public override string ToString()
        {
            return "["+ x + ";" + y + "]";
        }
        
        public PlainPoint()
            : base()
        { }

        public PlainPoint(double arg_x, double arg_y)
            : base()
        {
            this.x = arg_x;
            this.y = arg_y;
        }
    }

    partial class PlainLineString
    {
        public PlainLineString() : base() { }

        public PlainLineString(PlainPoint[] arrPlainPoint):base()
        {
            this.wrappedPoints = arrPlainPoint;
        }
    }

    partial class MapSection
    {
        public MapSection() : base() { }
        public MapSection(XServer.Point center, int scrollH, int ScrollV, int scale, int zoom)
            : base()
        {
            this.center = center;
            this.scale = scale;
            this.scrollHorizontal = scrollH;
            this.scrollVertical = ScrollV;
            this.zoom = zoom;
        }
    }
    partial class Bitmap
    {
        public Bitmap() : base() { }
        public Bitmap(string name, Point position, string descr):base()
        {
            this.descr = descr;
            this.name = name;
            this.position = position;
        }
    }

    public partial class RouteListSegment
    {
        public string Violations {
            get {
                if (this.wrappedViolations == null) return null;
                return string.Join(" ; ",this.wrappedViolations);
            }
            set {}
        }
    }
}
