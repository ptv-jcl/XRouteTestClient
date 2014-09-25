using System.Diagnostics;
using System.Web.Services;
using System.ComponentModel;
using System.Web.Services.Protocols;
using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace XServer
{
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
