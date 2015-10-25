using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Net;
using System.Web;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;
using XServer;
using System.Globalization;



namespace XRouteTestClient
{
    enum MySegmentAttributes { hasTollTruck, hasTollCar };

    enum MyResultListOptions
    {
        Map,
        Segments,
        Nodes,
        RouteListManoeuvres,
        Texts,
        Waypoints,
        TourEvents,
        DynamicInfo,
        ManoeuvreGroups
    };

    public partial class MainForm : Form
    {
        TourPointDesc startTourPoint, destinationTourPoint;
        WaypointDesc viaWaypoint;
        CallerContext cc;
        CallerContextProperty ccpCoordFormat, ccpProfile, ccpResponseGeometry;
        public const string xmlSnippetNeutral = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><Profile><Routing majorVersion=\"2\" minorVersion=\"0\"></Routing></Profile>";
        XServer.CallerContextProperty ccpXmlSnippet = new XServer.CallerContextProperty()
        {
            key = "ProfileXMLSnippet",
            value = Properties.Settings.Default.XMLSNIPPET
        };

        XRouteWSService service;

        ResultListOptions rlo;
        // the extended forms
        RouteListSegment_Form routeListSegment_Form = null;
        TextsForm textForm = null;
        TourEventForm tourEventForm = null;
        NodesForm nodesForm = null;
        RouteManoeuvre_Form routeListManoeuvre_Form = null; // 2010-09-07
        //CountryInfoOptions countryInfoOptions; obsolete 2010-03-19
        CountryInfoVehicleOptions countryInfoVehicleOptions;
        //ExtendedRoute extendedRoute;
        AdvancedTour advancedTour = null;
        // 2010-08-26: Cost Computation
        double[] costVectorDistance = new double[8], costVectorPeriod = new double[8];
        // 2010-09-11 Waypoints
        Waypoint_Form waypoints_Form = null;
        // 2011-02.24 DynamicInfo
        DynamicInfoForm dynamicInfoForm = null;
        // 2011-12-29 Emissions
        Emissions_Form routeEmissions_Form = null;
        Emissions_Form segmentEmissions_Form = null;

        public MainForm()
        {
            InitializeComponent();

            if (File.Exists(@"d:\xservers\token.txt"))
                Static.credentials = new NetworkCredential("xtok", File.ReadAllText(@"d:\xservers\token.txt"));

            service = new XRouteWSService() { Credentials = Static.credentials };

            tbxXMLSnippet.Text = Properties.Settings.Default.XMLSNIPPET;

            tbxServiceMap.Text = Properties.Settings.Default.UrlMap;
            tbxServiceRoute.Text = Properties.Settings.Default.UrlRoute;

            foreach (XServer.CoordFormat curCoordFormat in Enum.GetValues(typeof(XServer.CoordFormat)))
            {
                cboCoordFormat.Items.Add(curCoordFormat.ToString());
            }
            cboCoordFormat.SelectedItem = Properties.Settings.Default.COORDFORMAT;

            foreach (LinkType curLinkType in Enum.GetValues(typeof(LinkType)))
            {
                cboLinkTypeStart.Items.Add(curLinkType.ToString());
                cboLinkTypeDest.Items.Add(curLinkType.ToString());
            }
            cboLinkTypeStart.SelectedItem = Properties.Settings.Default.LinkType_START;
            cboLinkTypeDest.SelectedItem = Properties.Settings.Default.LinkType_DESTINATION;

            cboDetailLevel.Items.Clear();
            foreach (string curDetailLevel in Enum.GetNames(typeof(DetailLevel)))
            {
                cboDetailLevel.Items.Add(curDetailLevel);
            }
            cboDetailLevel.SelectedItem = Properties.Settings.Default.DetailLevel;


            //wpdStart = new WaypointDesc();
            startTourPoint = new TourPointDesc()
            {
                wrappedCoords = new XServer.Point[]{new XServer.Point(){
                    point = new XServer.PlainPoint()
                }}
            };
            //wpdDestination = new WaypointDesc();
            destinationTourPoint = new TourPointDesc()
            {
                wrappedCoords = new XServer.Point[]{new XServer.Point(){
                    point = new XServer.PlainPoint()
                }}
            };

            ccpProfile = new XServer.CallerContextProperty()
            {
                key = "Profile"
            };
            ccpCoordFormat = new XServer.CallerContextProperty()
            {
                key = "CoordFormat"
            };
            ccpResponseGeometry = new XServer.CallerContextProperty()
            {
                key = "ResponseGeometry",
                value = "WKB,PLAIN"
            };
            cc = new XServer.CallerContext()
            {
                wrappedProperties = new CallerContextProperty[] { ccpProfile, ccpCoordFormat, ccpResponseGeometry, ccpXmlSnippet }
            };

            tbxAVOID_FERRIES.Text = Properties.Settings.Default.AVOID_FERRIES;
            tbxAVOID_HIGHWAYS.Text = Properties.Settings.Default.AVOID_HIGHWAYS;
            tbxAVOID_RAMPS.Text = Properties.Settings.Default.AVOID_RAMPS;
            tbxAVOID_RESIDENTS_ONLY.Text = Properties.Settings.Default.AVOID_RESIDENTS_ONLY;
            tbxAVOID_TOLLROADS.Text = Properties.Settings.Default.AVOID_TOLLROADS;
            tbxAVOID_URBAN_AREAS.Text = Properties.Settings.Default.AVOID_URBAN_AREAS;
            tbxAVOID_VIGNETTEROADS.Text = Properties.Settings.Default.AVOID_VIGNETTEROADS;
            tbxAVOID_LOW_EMISSION_ZONES.Text = Properties.Settings.Default.AVOID_LOW_EMISSION_ZONES;
            tbxOPTIMIZATION.Text = Properties.Settings.Default.OPTIMIZATION;
            tbxSPEEDPROFILE.Text = Properties.Settings.Default.SPEED_PROFILE;
            tbxEXCLUDE_COUNTRIES.Text = Properties.Settings.Default.EXCLUDE_COUNTRIES;
            tbxROUTING_COUNTRIES.Text = Properties.Settings.Default.ROUTING_COUNTRIES;
            tbxREQUEST_VERSION.Text = Properties.Settings.Default.REQUEST_VERSION;
            tbxCOUNTRY_ENCODING.Text = Properties.Settings.Default.COUNTRY_ENCODING;
            tbxROADEDITOR_ADDITIONAL_OPTIONS.Text = Properties.Settings.Default.ROADEDITOR_ADDITIONAL_OPTIONS;
            tbxSTART_TIME_ROADEDITOR.Text = Properties.Settings.Default.START_TIME_ROADEDITOR;
            tbxLOW_EMISSION_ZONE_TYPE.Text = Properties.Settings.Default.LOW_EMISSION_ZONE_TYPE;
            tbxROUTE_LANGUAGE.Text = Properties.Settings.Default.ROUTE_LANGUAGE;
            // 2010.12.15
            tbxGEODATASOURCE_LAYER.Text = Properties.Settings.Default.GEODATASOURCE_LAYER;
            // dynamic tbx's
            tbxENABLE_DYNAMIC.Text = Properties.Settings.Default.ENABLE_DYNAMIC;
            tbxDYNAMIC_PROFILE.Text = Properties.Settings.Default.DYNAMIC_PROFILE;
            tbxSTART_TIME.Text = Properties.Settings.Default.START_TIME;
            tbxIS_DESTTIME.Text = Properties.Settings.Default.IS_DESTTIME;
            tbxDYNAMIC_TIME_ON_STATICROUTE.Text = Properties.Settings.Default.DYNAMIC_TIME_ON_STATICROUTE;
            // new 2009-04-14
            tbxROUTING_RECTANGLE.Text = Properties.Settings.Default.ROUTING_RECTANGLE;
            tbxDISTANCE_MEASURE.Text = Properties.Settings.Default.DISTANCE_MEASURE;
            tbxROADEDITOR_LAYERNAME.Text = Properties.Settings.Default.ROADEDITOR_LAYERNAME;
            tbxEXPERT_OPTIONS.Text = Properties.Settings.Default.EXPERT_OPTIONS;
            tbxGENERATE_EXTWAYPOINTS.Text = Properties.Settings.Default.GENERATE_EXTWAYPOINTS;
            tbxENABLE_ROADEDITOR.Text = Properties.Settings.Default.ENABLE_ROADEDITOR;
            // 2011-12-29 SPEED_INFOS
            tbxSPEED_INFOS.Text = Properties.Settings.Default.SPEED_INFOS;
            // new 2009-04-17
            tbxStreet.Text = Properties.Settings.Default.ExceptionPath_Street;
            tbxBinaryPathDescriptionIn.Text = Properties.Settings.Default.ExceptionPath_BinaryPathDescription;
            tbxExtSegments.Text = Properties.Settings.Default.ExceptionPath_ExtSegments;
            tbxAbsMalus.Text = Properties.Settings.Default.ExceptionPath_AbsMalus.ToString();
            tbxRelMalus.Text = Properties.Settings.Default.ExceptionPath_RelMalus.ToString();
            // 2010-03-19 VehicleParameters
            tbxVP_AXLE_WEIGHT.Text = Properties.Settings.Default.vp_AXLE_WEIGTH;
            tbxVP_CYLINDER_CAPACITY.Text = Properties.Settings.Default.vp_CYLINDER_CAPACITY;
            tbxVP_EMISSION_CLASS.Text = Properties.Settings.Default.vp_EMISSION_CLASS;
            tbxVP_FUEL_TYPE.Text = Properties.Settings.Default.vp_FUEL_TYPE;
            tbxVP_HEIGHT.Text = Properties.Settings.Default.vp_HEIGHT;
            tbxVP_LENGTH.Text = Properties.Settings.Default.vp_LENGTH;
            tbxVP_NUMBER_OF_AXLES.Text = Properties.Settings.Default.vp_NUMBER_OF_AXLES;
            tbxVP_NUMBER_OF_PASSENGERS.Text = Properties.Settings.Default.vp_NUMBER_OF_PASSENGERS;
            tbxVP_TOTAL_WEIGHT.Text = Properties.Settings.Default.vp_TOTAL_WEIGHT;
            tbxVP_TRAILER_HAS_BREAKS.Text = Properties.Settings.Default.vp_TRAILER_HAS_BREAKS;
            tbxVP_TRAILER_WEIGHt.Text = Properties.Settings.Default.vp_TRAILER_WEIGHT;
            tbxVP_TYPE.Text = Properties.Settings.Default.vp_TYPE;
            tbxVP_WIDTH.Text = Properties.Settings.Default.vp_WIDTH;
            // 2011-12-29 additional vehicle properties
            tbxVP_EMPTY_WEIGHT.Text = Properties.Settings.Default.vp_EMPTY_WEIGHT;
            tbxVP_EMISSION_TECHNOLOGY.Text = Properties.Settings.Default.vp_EMISSION_TECHNOLOGY;
            tbxVP_LOAD_WEIGHT.Text = Properties.Settings.Default.vp_LOAD_WEIGHT;

            //
            tbxStartX.Text = Properties.Settings.Default.x1.ToString();
            tbxStartY.Text = Properties.Settings.Default.y1.ToString();
            tbxDestX.Text = Properties.Settings.Default.x2.ToString();
            tbxDestY.Text = Properties.Settings.Default.y2.ToString();
            tbxProfileRoute.Text = Properties.Settings.Default.ProfileRoute;
            tbxProfileMap.Text = Properties.Settings.Default.ProfileMap;
            // since 2009-04-17: fuzzy stop 
            tbxFuzzyRadius.Text = Properties.Settings.Default.ViaRadius.ToString();
            tbxViaX.Text = Properties.Settings.Default.ViaX.ToString();
            tbxViaY.Text = Properties.Settings.Default.ViaY.ToString();
            // since 20090525: BoundingRectangles + ManoeuvreGroups
            tbxBoundingRectanglesC.Text = Properties.Settings.Default.BoundingRectanglesC.ToString();
            tbxBoundingRectanglesOffset.Text = Properties.Settings.Default.BoundingRectanglesOffset.ToString();
            tbxManoeuvreGroupsRatio.Text = Properties.Settings.Default.ManoeuvreGroup_Ratio;
            //
            rlo = new ResultListOptions();
            rlo.binaryPathDesc = true;
            rlo.nodes = true;
            rlo.polygon = true;
            rlo.segments = true;
            rlo.texts = true;
            rlo.manoeuvres = true;
            rlo.segmentAttributes = true;
            rlo.extSegments = true;
            // 2012-10-18: SpeedLimits!
            rlo.speedLimitsSpecified = true;
            rlo.speedLimits = cbxSpeedLimits.Checked;
            //2014-09-26 FeatureLayerDescriptions
            rlo.featureDescriptionsSpecified = true;
            rlo.featureDescriptions = cbxFeatureLayerDescriptions.Checked;

            // radCalcExtRoute.Checked = Properties.Settings.Default.ExtendedRoute;
            // TODO find better way for default operation
            radCalcExtRoute.Checked = true;
            //2010-03-19 Retour
            cbxRetour.Checked = Properties.Settings.Default.RETOUR;

            cbxDisplayRoadeditorLayer.Checked = Properties.Settings.Default.DisplayRoadEditorLayer;
            countryInfoVehicleOptions = new CountryInfoVehicleOptions();
            countryInfoVehicleOptions.tollTotals = true;
            countryInfoVehicleOptions.tollTotalsSpecified = true;
            // 2010-08-25 Fuel costs
            tbxCostsDistance.Text = Properties.Settings.Default.CostsDistance;
            tbxCostsPeriod.Text = Properties.Settings.Default.CostsPeriod;
            // 2011-04-19 TollDate for Scenarios
            string tolldate = Properties.Settings.Default.Tolldate.ToString();
            tbxTolldate.Text = ((tolldate != (new System.DateTime().ToString())) ? (tolldate) : (""));
            // 2011-12-29 Result List Elements
            foreach (MyResultListOptions curMyResultListOptions in Enum.GetValues(typeof(MyResultListOptions)))
            {
                lbxResultListOptions.Items.Add(curMyResultListOptions);
            }
            //lbxResultListOptions.SelectedIndex = 0;
            lbxResultListOptions.SelectedIndices.Add(0);
            lbxResultListOptions.SelectedIndices.Add(1);

            // 2012-12-29 HBEFA and Emissions
            foreach (HBEFAVersion curHBEFAVersion in Enum.GetValues(typeof(HBEFAVersion)))
                cboHBEFAVersion.Items.Add(curHBEFAVersion);
            foreach (EmissionLevel curEmissionLevel in Enum.GetValues(typeof(EmissionLevel)))
                cboEmissionLevel.Items.Add(curEmissionLevel);
            cboEmissionLevel.SelectedIndex = 0;

        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                btnAction.BackColor = System.Drawing.Color.Yellow;
                btnAction.Update();

                // accepting both , and . as decimal separators for easier copy/past from other sources
                char decimalSeparator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                char notDecimalSeparator = decimalSeparator == '.' ? ',' : '.';

                //setting up waypointdesc
                startTourPoint.wrappedCoords[0].point.x = Convert.ToDouble(tbxStartX.Text.Replace(notDecimalSeparator, decimalSeparator));
                startTourPoint.wrappedCoords[0].point.y = Convert.ToDouble(tbxStartY.Text.Replace(notDecimalSeparator, decimalSeparator));
                startTourPoint.linkType = (LinkType)(Enum.Parse(typeof(LinkType), cboLinkTypeStart.SelectedItem.ToString()));
                destinationTourPoint.wrappedCoords[0].point.x = Convert.ToDouble(tbxDestX.Text.Replace(notDecimalSeparator, decimalSeparator));
                destinationTourPoint.wrappedCoords[0].point.y = Convert.ToDouble(tbxDestY.Text.Replace(notDecimalSeparator, decimalSeparator));
                destinationTourPoint.linkType = (LinkType)(Enum.Parse(typeof(LinkType), cboLinkTypeDest.SelectedItem.ToString()));

                List<WaypointDesc> lstWaypointDesc = new List<WaypointDesc>();
                lstWaypointDesc.Add(startTourPoint);

                //check if we need the via point or not. If so add it
                if (tbxFerryId.Text != "")
                {
                    WaypointDesc wpdFerry = new WaypointDesc()
                    {
                        combinedTransportID = tbxFerryId.Text,
                        viaType = new ViaType()
                        {
                            viaType = ViaTypeEnum.COMBINED_TRANSPORT
                        }
                    };
                    lstWaypointDesc.Add(wpdFerry);
                }
                else if ((tbxViaX.Text != "") && (tbxViaY.Text != "") && (tbxFuzzyRadius.Text != ""))
                {
                    viaWaypoint = new WaypointDesc()
                    {
                        fuzzyRadius = Convert.ToInt32(tbxFuzzyRadius.Text),
                        wrappedCoords = new XServer.Point[] 
                        { 
                            new XServer.Point()
                            {
                                point = new PlainPoint()
                                    {
                                        x = Convert.ToDouble(tbxViaX.Text.Replace(notDecimalSeparator,decimalSeparator)),
                                        y = Convert.ToDouble(tbxViaY.Text.Replace(notDecimalSeparator,decimalSeparator)),
                                    },
                            },
                        },
                        viaType = new ViaType()
                        {
                            viaType = ViaTypeEnum.FUZZY,
                        },
                    };
                    lstWaypointDesc.Add(viaWaypoint);
                }
                lstWaypointDesc.Add(destinationTourPoint);

                // 2010-03-19 Retour
                if (cbxRetour.Checked)
                {
                    for (int index = lstWaypointDesc.Count - 1; index >= 0; index--)
                    {
                        //2014-09-26 remove ferry from retour
                        if (lstWaypointDesc[index].combinedTransportID != null && lstWaypointDesc[index].combinedTransportID != "") continue;
                        lstWaypointDesc.Add(lstWaypointDesc[index]);
                    }
                }

                WaypointDesc[] waypointDesc = lstWaypointDesc.ToArray();

                ccpCoordFormat.value = cboCoordFormat.SelectedItem.ToString();
                ccpProfile.value = tbxProfileRoute.Text;
                // 2012-08-10 XmlSnippet 
                if (enableSnippetChckBx.Checked)
                {
                    ccpXmlSnippet.value = tbxXMLSnippet.Text;
                }
                else
                {
                    ccpXmlSnippet.value = xmlSnippetNeutral;
                }

                List<RoutingOption> listRoutingOption = new List<RoutingOption>();
                // Avoid
                if (tbxAVOID_FERRIES.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.AVOID_FERRIES, tbxAVOID_FERRIES.Text));
                if (tbxAVOID_HIGHWAYS.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.AVOID_HIGHWAYS, tbxAVOID_HIGHWAYS.Text));
                if (tbxAVOID_RAMPS.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.AVOID_RAMPS, tbxAVOID_RAMPS.Text));
                if (tbxAVOID_RESIDENTS_ONLY.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.AVOID_RESIDENTS_ONLY, tbxAVOID_RESIDENTS_ONLY.Text));
                if (tbxAVOID_TOLLROADS.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.AVOID_TOLLROADS, tbxAVOID_TOLLROADS.Text));
                if (tbxAVOID_URBAN_AREAS.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.AVOID_URBAN_AREAS, tbxAVOID_URBAN_AREAS.Text));
                if (tbxAVOID_VIGNETTEROADS.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.AVOID_VIGNETTEROADS, tbxAVOID_VIGNETTEROADS.Text));
                if (tbxAVOID_LOW_EMISSION_ZONES.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.AVOID_LOW_EMISSION_ZONES, tbxAVOID_LOW_EMISSION_ZONES.Text));
                //Common
                if (tbxOPTIMIZATION.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.OPTIMIZATION, tbxOPTIMIZATION.Text));
                if (tbxSPEEDPROFILE.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.SPEED_PROFILE, tbxSPEEDPROFILE.Text));
                if (tbxEXCLUDE_COUNTRIES.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.EXCLUDE_COUNTRIES, tbxEXCLUDE_COUNTRIES.Text));
                if (tbxROUTING_COUNTRIES.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.ROUTING_COUNTRIES, tbxROUTING_COUNTRIES.Text));
                if (tbxREQUEST_VERSION.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.REQUEST_VERSION, tbxREQUEST_VERSION.Text));
                if (tbxCOUNTRY_ENCODING.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.COUNTRY_ENCODING, tbxCOUNTRY_ENCODING.Text));
                if (tbxROUTE_LANGUAGE.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.ROUTE_LANGUAGE, tbxROUTE_LANGUAGE.Text));
                if (tbxLOW_EMISSION_ZONE_TYPE.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.LOW_EMISSION_ZONE_TYPE, tbxLOW_EMISSION_ZONE_TYPE.Text));
                if (tbxROUTING_RECTANGLE.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.ROUTING_RECTANGLE, tbxROUTING_RECTANGLE.Text));
                if (tbxDISTANCE_MEASURE.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.DISTANCE_MEASURE, tbxDISTANCE_MEASURE.Text));
                if (tbxGENERATE_EXTWAYPOINTS.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.GENERATE_EXTWAYPOINTS, tbxGENERATE_EXTWAYPOINTS.Text));
                if (tbxEXPERT_OPTIONS.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.EXPERT_OPTIONS, tbxEXPERT_OPTIONS.Text));
                if (tbxSPEED_INFOS.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.SPEED_INFOS, tbxSPEED_INFOS.Text));
                // Dynamic
                if (tbxENABLE_DYNAMIC.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.ENABLE_DYNAMIC, tbxENABLE_DYNAMIC.Text));
                if (tbxDYNAMIC_PROFILE.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.DYNAMIC_PROFILE, tbxDYNAMIC_PROFILE.Text));
                if (tbxSTART_TIME.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.START_TIME, tbxSTART_TIME.Text));
                if (tbxIS_DESTTIME.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.IS_DESTTIME, tbxIS_DESTTIME.Text));
                if (tbxDYNAMIC_TIME_ON_STATICROUTE.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.DYNAMIC_TIME_ON_STATICROUTE, tbxDYNAMIC_TIME_ON_STATICROUTE.Text));
                // RoadEditor
                if (tbxENABLE_ROADEDITOR.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.ENABLE_ROADEDITOR, tbxENABLE_ROADEDITOR.Text));
                if (tbxSTART_TIME_ROADEDITOR.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.START_TIME_ROADEDITOR, tbxSTART_TIME_ROADEDITOR.Text));
                if (tbxROADEDITOR_ADDITIONAL_OPTIONS.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.ROADEDITOR_ADDITIONAL_OPTIONS, tbxROADEDITOR_ADDITIONAL_OPTIONS.Text));
                if (tbxALLOW_SEGMENT_VIOLATIONS.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.ALLOW_SEGMENT_VIOLATIONS, tbxALLOW_SEGMENT_VIOLATIONS.Text));
                if (tbxCOST_OF_SEGMENT_VIOLATIONS.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.COST_OF_SEGMENT_VIOLATIONS, tbxCOST_OF_SEGMENT_VIOLATIONS.Text));
                if (tbxROADEDITOR_LAYERNAME.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.ROADEDITOR_LAYERNAME, tbxROADEDITOR_LAYERNAME.Text));
                // ExceptionPath
                if (tbxGEODATASOURCE_LAYER.Text != "") listRoutingOption.Add(getRoutingOption(RoutingParameter.GEODATASOURCE_LAYER, tbxGEODATASOURCE_LAYER.Text));
                // ExceptionPath only when streetname is available
                ExceptionPath[] arrExceptionpath;
                // if both properties
                // - streetname or binaryPathDescription or streetname or nodes
                // - relative malus or abs malus
                // are given, the ExceptionPath is created
                if (((tbxNodes.Text != "") || (tbxExtSegments.Text != "") || (tbxStreet.Text != "") || (tbxBinaryPathDescriptionIn.Text != "")) && ((tbxAbsMalus.Text != "") || (tbxRelMalus.Text != "")))
                {
                    ExceptionPath ep = new ExceptionPath();
                    // only the first non empty element is used by the server
                    if (tbxNodes.Text != "")
                    {
                        string[] lines = tbxNodes.Text.Split(';');
                        List<UniqueGeoID> lstUniqueGeoID = new List<UniqueGeoID>();
                        foreach (string curLine in lines)
                        {
                            string[] curLineSplitted = curLine.Split(',');
                            UniqueGeoID uniqueGeoId = new UniqueGeoID();
                            uniqueGeoId.iuCode = Convert.ToInt32(curLineSplitted[0]);
                            uniqueGeoId.n = Convert.ToInt32(curLineSplitted[1]);
                            uniqueGeoId.tID = Convert.ToInt64(curLineSplitted[2]);
                            uniqueGeoId.xOff = Convert.ToInt32(curLineSplitted[3]);
                            uniqueGeoId.yOff = Convert.ToInt32(curLineSplitted[4]);
                            lstUniqueGeoID.Add(uniqueGeoId);
                        }
                        ep.wrappedNodes = lstUniqueGeoID.ToArray();
                    }
                    ep.extSegments = tbxExtSegments.Text;
                    ep.street = tbxStreet.Text;
                    ep.binaryPathDesc = tbxBinaryPathDescriptionIn.Text;
                    // 2010.12.15: rel or abs malus is checked
                    if (tbxRelMalus.Text != "")
                    {
                        ep.relMalus = Convert.ToInt32(tbxRelMalus.Text);
                    }
                    if (tbxAbsMalus.Text != "")
                    {
                        ep.absTimeMalusSpecified = true;
                        ep.absTimeMalus = Convert.ToInt32(tbxAbsMalus.Text);
                    }
                    arrExceptionpath = new ExceptionPath[] { ep };
                }
                else
                {
                    arrExceptionpath = null;
                }

                //

                rlo.detailLevel = (DetailLevel)Enum.Parse(typeof(DetailLevel), cboDetailLevel.SelectedItem.ToString());

                // 20090525: BoundingRectangles
                if ((tbxBoundingRectanglesC.Text != "") && (tbxBoundingRectanglesOffset.Text != ""))
                {
                    rlo.boundingRectanglesC = Convert.ToInt32(tbxBoundingRectanglesC.Text);
                    rlo.boundingRectanglesOffset = Convert.ToInt32(tbxBoundingRectanglesOffset.Text);
                }
                else
                {
                    rlo.boundingRectanglesC = 0;
                    rlo.boundingRectanglesOffset = 0;
                }
                rlo.manoeuvreGroups = lbxResultListOptions.SelectedItems.Contains(MyResultListOptions.ManoeuvreGroups);
                if (tbxManoeuvreGroupsRatio.Text != "")
                {
                    rlo.manoeuvreGroupRatioSpecified = true;
                    rlo.manoeuvreGroupRatio = Convert.ToDouble(tbxManoeuvreGroupsRatio.Text);
                }
                // 2009-09-16 Texts 
                rlo.texts = lbxResultListOptions.SelectedItems.Contains(MyResultListOptions.Texts);
                //2010-05-31 Nodes available
                rlo.nodes = lbxResultListOptions.SelectedItems.Contains(MyResultListOptions.Nodes);

                // 2011-02-24 DynamicInfo?
                rlo.dynamicInfo = lbxResultListOptions.SelectedItems.Contains(MyResultListOptions.DynamicInfo);


                // 2011-12-27 PiggyBack invented with 1.14
                rlo.segmentAttributePiggybackSpecified = true;
                rlo.segmentAttributePiggyback = true;

                rlo.speedLimits = cbxSpeedLimits.Checked;

                rlo.featureDescriptionsSpecified = true;
                rlo.featureDescriptions = cbxFeatureLayerDescriptions.Checked;

                // 2010-03-19 CountryInfoVehicleOptions
                List<VehicleOption> lstVehicleOptions = new List<VehicleOption>();
                if (tbxVP_AXLE_WEIGHT.Text != "") lstVehicleOptions.Add(getVehicleOption(VehicleParameter.AXLE_WEIGHT, tbxVP_AXLE_WEIGHT.Text));
                if (tbxVP_CYLINDER_CAPACITY.Text != "") lstVehicleOptions.Add(getVehicleOption(VehicleParameter.CYLINDER_CAPACITY, tbxVP_CYLINDER_CAPACITY.Text));
                if (tbxVP_EMISSION_CLASS.Text != "") lstVehicleOptions.Add(getVehicleOption(VehicleParameter.EMISSION_CLASS, tbxVP_EMISSION_CLASS.Text));
                if (tbxVP_FUEL_TYPE.Text != "") lstVehicleOptions.Add(getVehicleOption(VehicleParameter.FUEL_TYPE, tbxVP_FUEL_TYPE.Text));
                if (tbxVP_HEIGHT.Text != "") lstVehicleOptions.Add(getVehicleOption(VehicleParameter.HEIGHT, tbxVP_HEIGHT.Text));
                if (tbxVP_LENGTH.Text != "") lstVehicleOptions.Add(getVehicleOption(VehicleParameter.LENGTH, tbxVP_LENGTH.Text));
                if (tbxVP_NUMBER_OF_AXLES.Text != "") lstVehicleOptions.Add(getVehicleOption(VehicleParameter.NUMBER_OF_AXLES, tbxVP_NUMBER_OF_AXLES.Text));
                if (tbxVP_NUMBER_OF_PASSENGERS.Text != "") lstVehicleOptions.Add(getVehicleOption(VehicleParameter.NUMBER_OF_PASSENGERS, tbxVP_NUMBER_OF_PASSENGERS.Text));
                if (tbxVP_TOTAL_WEIGHT.Text != "") lstVehicleOptions.Add(getVehicleOption(VehicleParameter.TOTAL_WEIGHT, tbxVP_TOTAL_WEIGHT.Text));
                if (tbxVP_TRAILER_HAS_BREAKS.Text != "") lstVehicleOptions.Add(getVehicleOption(VehicleParameter.TRAILER_HAS_BREAKS, tbxVP_TRAILER_HAS_BREAKS.Text));
                if (tbxVP_TRAILER_WEIGHt.Text != "") lstVehicleOptions.Add(getVehicleOption(VehicleParameter.TRAILER_WEIGHT, tbxVP_TRAILER_WEIGHt.Text));
                if (tbxVP_TYPE.Text != "") lstVehicleOptions.Add(getVehicleOption(VehicleParameter.TYPE, tbxVP_TYPE.Text));
                if (tbxVP_WIDTH.Text != "") lstVehicleOptions.Add(getVehicleOption(VehicleParameter.WIDTH, tbxVP_WIDTH.Text));
                // since 2012.08.27
                if (tbxVP_EMPTY_WEIGHT.Text != "") lstVehicleOptions.Add(getVehicleOption(VehicleParameter.EMPTY_WEIGHT, tbxVP_EMPTY_WEIGHT.Text));
                if (tbxVP_EMISSION_TECHNOLOGY.Text != "") lstVehicleOptions.Add(getVehicleOption(VehicleParameter.EMISSION_TECHNOLOGY, tbxVP_EMISSION_TECHNOLOGY.Text));
                if (tbxVP_LOAD_WEIGHT.Text != "") lstVehicleOptions.Add(getVehicleOption(VehicleParameter.LOAD_WEIGHT, tbxVP_LOAD_WEIGHT.Text));

                //
                countryInfoVehicleOptions.allEuro = cbxAllEuro.Checked;
                countryInfoVehicleOptions.namedToll = true;
                countryInfoVehicleOptions.namedTollSpecified = true;
                countryInfoVehicleOptions.detailedTollCosts = cbxDetailedTollCosts.Checked;
                countryInfoVehicleOptions.wrappedReductionIDs = null;
                if (tbxTolldate.Text != "")
                {
                    countryInfoVehicleOptions.tollDateSpecified = true;
                    countryInfoVehicleOptions.tollDate = DateTime.Parse(tbxTolldate.Text);
                }
                else
                    countryInfoVehicleOptions.tollDateSpecified = false;

                if (lstVehicleOptions.Count > 0)
                    countryInfoVehicleOptions.wrappedOptions = lstVehicleOptions.ToArray();
                else
                    countryInfoVehicleOptions.wrappedOptions = null;

                // 2012.12.29 Emissions
                if (cboEmissionLevel.SelectedIndex > 0)
                    rlo.emissions = new EmissionType()
                    {
                        emissionLevel = (EmissionLevel)(cboEmissionLevel.SelectedItem)
                    };
                if (cboHBEFAVersion.SelectedIndex >= 0)
                {
                    rlo.hbefaType = new HBEFAType()
                    {
                        version = (HBEFAVersion)(cboHBEFAVersion.SelectedItem)
                    };
                }

                service.Url = tbxServiceRoute.Text;
                DateTime dtStart = DateTime.Now;

                if (radCalcAdvTour.Checked)
                {
                    TourOptions tourOptions = null;

                    tourOptions = new TourOptions()
                    {
                        driverSettings = new DriverSettings()
                        {
                            breakRuleDisabled = !breakRuleChkBx.Checked,
                            breakRuleDisabledSpecified = true,
                            dailyRestRuleDisabled = !dailyRestRuleChkBx.Checked,
                            dailyRestRuleDisabledSpecified = true,
                            weeklyRestRuleDisabled = !weeklyRestRuleChkBx.Checked,
                            weeklyRestRuleDisabledSpecified = true,
                            workingRuleDisabled = !workingRuleChkBx.Checked,
                            workingRuleDisabledSpecified = true,
                        },
                        regulations = new DriverRegulations()
                        {

                            breakRule = new BreakRule()
                            {
                                breakPeriod1 = int.Parse(breakPeriod1TxtBx.Text),
                                breakPeriod2 = int.Parse(breakPeriod2TxtBx.Text),
                                drivingPeriod = int.Parse(drivingPeriodTxtBx.Text),
                            },
                            dailyRestRule = new DailyRestRule()
                            {
                                extendedDrivingPeriod = int.Parse(extendedDrivingPeriodTxtBx.Text),
                                firstSplitRestPeriod = int.Parse(firstSplitRestPeriodTxtbx.Text),
                                maximumPeriodBetweenEndOfDailyRests = int.Parse(maximumPeriodBetweenEndOfDailyRestsTxtBx.Text),
                                numberOfExtendedDrivingPeriods = int.Parse(numberOfExtendedDrivingPeriodsTxtBx.Text),
                                numberOfReducedRestPeriods = int.Parse(numberOfReducedRestPeriodsTxtBx.Text),
                                reducedRestPeriod = int.Parse(reducedRestPeriodTxtBx.Text),
                                regularDrivingPeriod = int.Parse(regularDrivingPeriodTxtBx.Text),
                                regularRestPeriod = int.Parse(regularRestPeriodTxtBx.Text),
                                secondSplitRestPeriod = int.Parse(secondSplitRestPeriodTxtBx.Text),
                            },
                            weeklyRestRule = new WeeklyRestRule()
                            {
                                maximumBiweeklyDrivingPeriod = int.Parse(maximumBiweeklyDrivingPeriodTxtBx.Text),
                                maximumPeriodBetweenWeeklyRests = int.Parse(maximumPeriodBetweenWeeklyRestsTxtBx.Text),
                                maximumWeeklyDrivingPeriod = int.Parse(maximumWeeklyDrivingPeriodTxtBx.Text),
                                weeklyRestPeriod = int.Parse(weeklyRestPeriodTxtBx.Text),
                            },
                            workingRule = new WorkingRule()
                            {
                                breakPeriod = int.Parse(breakPeriodTxtBx.Text),
                                extendedBreakPeriod = int.Parse(extendedBreakPeriodTxtBx.Text),
                                maxWorkingPeriodWithoutBreak = int.Parse(maxWorkingPeriodWithoutBreakTxtBx.Text),
                                maxWorkingPeriodWithoutExtendedBreak = int.Parse(maxWorkingPeriodWithoutExtendedBreakTxtBx.Text),
                                minPartialBreakLength = int.Parse(minPartialBreakLengthTxtBx.Text),
                                maxWorkingPeriodWithoutDailyRest = int.Parse(maxWorkingPeriodWithoutDailyRestTxtBx.Text),
                                maxWorkingPeriodPerWeek = int.Parse(maxWorkingPeriodPerWeekTxtBx.Text),
                                dailyRestPeriod = int.Parse(dailyRestPeriodTxtBx.Text),
                            },
                        },
                    };

                    advancedTour = service.calculateAdvancedTour(waypointDesc, tourOptions, listRoutingOption.ToArray(), arrExceptionpath, rlo, countryInfoVehicleOptions, cc);
                }
                else if (radCalcExtRoute.Checked)
                {
                    ExtendedRoute extRoute = service.calculateExtendedRoute(waypointDesc, listRoutingOption.ToArray(), arrExceptionpath, rlo, countryInfoVehicleOptions, cc); ;
                    advancedTour = new AdvancedTour();
                    advancedTour.route = extRoute.route;
                    advancedTour.wrappedCountryInfos = extRoute.wrappedCountryInfos;
                    advancedTour.wrappedTourEvents = null;
                    advancedTour.wrappedTourPointResults = null;
                }
                else if (radCalcRoute.Checked)
                {
                    advancedTour = new AdvancedTour();
                    advancedTour.route = service.calculateRoute(waypointDesc, listRoutingOption.ToArray(), arrExceptionpath, rlo, cc);
                    advancedTour.wrappedCountryInfos = null;
                    advancedTour.wrappedTourEvents = null;
                    advancedTour.wrappedTourPointResults = null;
                }

                DateTime dtStop = DateTime.Now;
                TimeSpan ts = dtStop.Subtract(dtStart);
                this.Text = ts.TotalMilliseconds.ToString();

                lbxOutCountry.Focus();

                //20090717: RouteListSegment Form?

                if (lbxResultListOptions.SelectedItems.Contains(MyResultListOptions.Segments))
                {
                    if (routeListSegment_Form == null)
                    {
                        routeListSegment_Form = new RouteListSegment_Form(advancedTour.route);
                        routeListSegment_Form.Show();
                    }
                    else
                    {
                        routeListSegment_Form.updateDGV(advancedTour.route);
                        routeListSegment_Form.Visible = true;
                    }
                }

                if ((advancedTour.wrappedCountryInfos != null) && (advancedTour.wrappedCountryInfos.Length > 1))
                {
                    bool checkAllEuro = true;
                    foreach (CountryInfo curCountryInfo in advancedTour.wrappedCountryInfos)
                    {
                        if ((curCountryInfo.currency != Currency.EUR) && (curCountryInfo.currency != Currency.NONE))
                        {
                            checkAllEuro = false;
                            break;
                        }
                    }
                    if (checkAllEuro)
                        advancedTour.wrappedCountryInfos = mergeCountryInfo(advancedTour.wrappedCountryInfos);
                }

                // since 2009-04.17: BinaryPath in output
                tbxBinaryPathDescription.Text = advancedTour.route.binaryPathDesc;

                // since 2009-09-17: Texts
                //if (cbxTexts.Checked)
                if (lbxResultListOptions.SelectedItems.Contains(MyResultListOptions.Texts))
                {
                    if (textForm == null)
                    {
                        textForm = new TextsForm(advancedTour.route.wrappedTexts);
                        textForm.Show();
                    }
                    else
                    {
                        textForm.update(advancedTour.route.wrappedTexts);
                        textForm.Visible = true;
                    }
                }
                // sind 2009-12-02: TimeEvents
                // 2014-10-02: disabling because calculateTour is being replaced by calculated Advanced Tour
                //if ((cbxTimeEvents.Checked) && (tour.wrappedTimeEvents != null))
                if ((lbxResultListOptions.SelectedItems.Contains(MyResultListOptions.TourEvents)) && (advancedTour.wrappedTourEvents != null))
                {
                    if (tourEventForm == null)
                    {
                        tourEventForm = new TourEventForm(advancedTour);
                        tourEventForm.Show();
                    }
                    else
                    {
                        tourEventForm.Update(advancedTour);
                        tourEventForm.Visible = true;
                    }
                }

                // 2010-05-31 Nodes Available
                //if ((cbxNodes.Checked) && (tour.route != null) && (tour.route.wrappedNodes != null))
                if ((lbxResultListOptions.SelectedItems.Contains(MyResultListOptions.Nodes)) && (advancedTour.route != null) && (advancedTour.route.wrappedNodes != null))
                {
                    if (nodesForm == null)
                    {
                        nodesForm = new NodesForm(advancedTour.route);
                        nodesForm.Show();
                    }
                    else
                    {
                        nodesForm.update(advancedTour.route);
                        nodesForm.Visible = true;
                    }
                }

                // 2010-09-07 RouteListManoeuvres
                //if ((cbxRouteListManoeuvres.Checked) && (tour.route != null) && (tour.route.wrappedManoeuvres != null))
                if ((lbxResultListOptions.SelectedItems.Contains(MyResultListOptions.RouteListManoeuvres)) && (advancedTour.route != null) && (advancedTour.route.wrappedManoeuvres != null))
                {
                    if (routeListManoeuvre_Form == null)
                    {
                        routeListManoeuvre_Form = new RouteManoeuvre_Form(advancedTour.route);
                        routeListManoeuvre_Form.Show();
                    }
                    else
                    {
                        routeListManoeuvre_Form.Update(advancedTour.route);
                        routeListManoeuvre_Form.Visible = true;

                    }
                }

                // 2010-09-10 Waypoints
                //if ((cbxWaypoints.Checked) && (tour.route != null) && (tour.route.wrappedStations != null))
                if ((lbxResultListOptions.SelectedItems.Contains(MyResultListOptions.Waypoints)) && (advancedTour.route != null) && (advancedTour.route.wrappedStations != null))
                {
                    if (waypoints_Form == null)
                    {
                        waypoints_Form = new Waypoint_Form(advancedTour.route);
                        waypoints_Form.Show();
                    }
                    else
                    {
                        waypoints_Form.update(advancedTour.route);
                        waypoints_Form.Visible = true;

                    }
                }

                // 2011-02-24 Dynmamic Info
                //if ((cbxDynamicInfo.Checked) && (tour.route.dynamicInfo != null))
                if ((lbxResultListOptions.SelectedItems.Contains(MyResultListOptions.DynamicInfo)) && (advancedTour.route.dynamicInfo != null))
                {
                    if (dynamicInfoForm == null)
                    {
                        dynamicInfoForm = new DynamicInfoForm(advancedTour.route);
                        dynamicInfoForm.Show();
                    }
                    else
                    {
                        dynamicInfoForm.update(advancedTour.route);
                        dynamicInfoForm.Visible = true;
                    }
                }

                // 2012-12-29 Emissions
                if (advancedTour.route.emissions != null)
                {
                    if (routeEmissions_Form == null)
                    {
                        routeEmissions_Form = new Emissions_Form(new Emissions[] { advancedTour.route.emissions });
                        routeEmissions_Form.Show();
                    }
                    else
                    {
                        routeEmissions_Form.update(new Emissions[] { advancedTour.route.emissions });
                        routeEmissions_Form.Visible = true;
                    }
                }
                if (advancedTour.route.wrappedSegments != null)
                {
                    if (advancedTour.route.wrappedSegments[0].emissions != null)
                    {
                        List<Emissions> lstEmissions = new List<Emissions>();
                        foreach (RouteListSegment curRouteListSegment in advancedTour.route.wrappedSegments)
                        {
                            lstEmissions.Add(curRouteListSegment.emissions);
                        }
                        if (segmentEmissions_Form == null)
                        {
                            segmentEmissions_Form = new Emissions_Form(lstEmissions.ToArray());
                            segmentEmissions_Form.Show();
                        }
                        else
                        {
                            segmentEmissions_Form.update(lstEmissions.ToArray());
                            segmentEmissions_Form.Visible = true;
                        }
                    }
                }



                if ((tbxServiceMap.Text != "") && (lbxResultListOptions.SelectedItems.Contains(MyResultListOptions.Map)) && (advancedTour.route.polygon != null))
                {
                    List<Layer> listLayer = new List<Layer>();
                    //
                    CustomLayer clRoute = getRouteLayer(advancedTour.route);
                    listLayer.Add(clRoute);
                    listLayer.Add(getRoutePointLayer(advancedTour.route));
                    //
                    CustomLayer clHasTollTruck = getTollLayer(advancedTour.route, MySegmentAttributes.hasTollTruck);
                    listLayer.Add(clHasTollTruck);
                    CustomLayer clHasTollCar = getTollLayer(advancedTour.route, MySegmentAttributes.hasTollCar);
                    listLayer.Add(clHasTollCar);

                    // since 2009-04-23 display RoadEditor layer
                    if ((cbxDisplayRoadeditorLayer.Checked) && (tbxROADEDITOR_LAYERNAME.Text != ""))
                    {
                        RoadEditorLayer roadeditorLayer = new RoadEditorLayer();
                        roadeditorLayer.name = tbxROADEDITOR_LAYERNAME.Text;
                        roadeditorLayer.objectInfos = ObjectInfoType.REFERENCEPOINT;
                        roadeditorLayer.visible = true;
                        listLayer.Add(roadeditorLayer);
                    }

                    // 20090525: Additional visualization of BoundingRectangles
                    if (advancedTour.route.wrappedBoundingRectangles != null)
                    {
                        CustomLayer clBoundingRectangles = getBoundingRectangles(advancedTour.route);
                        listLayer.Add(clBoundingRectangles);
                    }
                    // Additional visualization of ManoeuvreGroups
                    if (advancedTour.route.wrappedManoeuvreGroup != null)
                    {
                        CustomLayer clManoeuvreGroups = getManoeuvreGroupsLayer(advancedTour.route);
                        listLayer.Add(clManoeuvreGroups);
                    }

                    if (advancedTour.route.wrappedManoeuvres != null)
                    {
                        CustomLayer clManoeuvres = getManoeuvresLayer(advancedTour.route);
                        listLayer.Add(clManoeuvres);
                    }
                    //
                    CustomLayer clWaypoints = getWaypointsLayer(advancedTour.route);
                    listLayer.Add(clWaypoints);

                    // TimeEvents in map
                    // TODO rewrite timevents to tourevents
                    if (advancedTour.wrappedTourEvents != null)
                    {
                        //CustomLayer clTimeEvents = getTimeEventsLayer(advancedTour);
                        //listLayer.Add(clTimeEvents);
                    }

                    // 2009-07-23: ferry layer
                    listLayer.Add(getFerryLayer(advancedTour.route));

                    // 2010-03-23: SegmentAttributes
                    if (advancedTour.route.wrappedSegments != null)
                    {
                        CustomLayer clSegmentAttributesLayer = getSegmentAttributesLayer(advancedTour);
                        listLayer.Add(clSegmentAttributesLayer);
                    }

                    // 2010-11-05: TollSection FROM and TO

                    if ((advancedTour.wrappedCountryInfos != null) && (advancedTour.wrappedCountryInfos[0] != null))
                    {
                        if ((advancedTour.wrappedCountryInfos[0].wrappedTollCostInfos != null) && (advancedTour.wrappedCountryInfos[0].wrappedTollCostInfos.Length > 0))
                            if (advancedTour.wrappedCountryInfos[0].wrappedTollCostInfos[0] != null)
                            {
                                {
                                    CustomLayer clTollSections = getTollSectionLayer(advancedTour);
                                    listLayer.Add(clTollSections);
                                }
                            }
                    }

                    // 2010.12.15 SMO Layer for GEODATASOURCE
                    if (cbxGEODATASOURCE_LAYER.Checked && tbxGEODATASOURCE_LAYER.Text != "")
                    {
                        SMOLayer geodatasourceLayer = getGeodatasourceLayer();
                        listLayer.Add(geodatasourceLayer);
                    }

                    //
                    CallerContext ccMap = new CallerContext();
                    CallerContextProperty ccpProfileMap = new CallerContextProperty()
                    {
                        key = "Profile",
                        value = tbxProfileMap.Text
                    };
                    ccMap.wrappedProperties = new CallerContextProperty[] { ccpCoordFormat, ccpProfileMap };
                    MapForm mapForm = new MapForm(tbxServiceMap.Text, null, listLayer.ToArray(), ccMap);
                    mapForm.Show();
                }

                tbxCountries.Text = ((advancedTour.wrappedCountryInfos != null) ? (advancedTour.wrappedCountryInfos.Length.ToString()) : ("N/A"));
                tbxDistance.Text = advancedTour.route.info.distance.ToString();
                tbxTime.Text = displayTime(advancedTour.route.info.time);
                tbxCost.Text = advancedTour.route.info.cost.ToString();

                tbxPartCost.Text = "";
                tbxPartDistance.Text = "";
                tbxPartTime.Text = "";
                tbxPercCost.Text = "";
                tbxPercDistance.Text = "";
                tbxPercTime.Text = "";

                // 2010-08-26 Costs...

                string[] strCostVectorDistance = tbxCostsDistance.Text.Split(',');
                string[] strCostVectorPeriod = tbxCostsPeriod.Text.Split(',');
                for (int i = 0; i < 8; i++)
                {
                    costVectorDistance[i] = Convert.ToDouble(strCostVectorDistance[i]);
                    costVectorPeriod[i] = Convert.ToDouble(strCostVectorPeriod[i]);
                }

                lbxOutCountry.Items.Clear();
                if (advancedTour.wrappedCountryInfos != null)
                {
                    foreach (CountryInfo curCountryInfo in advancedTour.wrappedCountryInfos)
                    {
                        double currentToll = 0.0;
                        // ignore the initial SPECIALCHARGE aggregate, therefore
                        // index starts with 1 instead of 0 (=SPECIALCHARGE)
                        for (int i = 1; i < curCountryInfo.wrappedPerTypeTollPrice.Length; i++)
                        {
                            currentToll += curCountryInfo.wrappedPerTypeTollPrice[i] * 0.01;
                        }
                        // compute the "costs":
                        double costs = 0.0;
                        for (int i = 0; i < curCountryInfo.wrappedPerNCRouteInfo.Length; i++)
                        {
                            RouteInfo ri = curCountryInfo.wrappedPerNCRouteInfo[i];
                            costs += (double)(ri.distance) * costVectorDistance[i];
                            costs += (double)(ri.time) * costVectorPeriod[i];
                        }

                        // combine the info...
                        StringBuilder sbCountryInfo = new StringBuilder();
                        sbCountryInfo.Append(curCountryInfo.iuCode + "=" + curCountryInfo.countryCode);
                        sbCountryInfo.Append(": " + Enum.GetName(typeof(Currency), curCountryInfo.currency) + " " + currentToll.ToString());
                        sbCountryInfo.Append(" " + curCountryInfo.additionalInfo);
                        sbCountryInfo.Append(" / " + costs);
                        lbxOutCountry.Items.Add(sbCountryInfo);
                    }
                    lbxOutCountry.SelectedIndex = 0;
                }

                btnAction.BackColor = System.Drawing.Color.Green;
                btnAction.Update();

            }
            catch (System.Web.Services.Protocols.SoapException soapException)
            {
                System.Windows.Forms.MessageBox.Show(soapException.Detail.InnerXml.Replace(">", ">\r\n"));
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private CustomLayer getTimeEventsLayer(Tour tour)
        {
            CustomLayer clTimeEvents = new CustomLayer();
            clTimeEvents.centerObjects = true;
            clTimeEvents.drawPriority = Properties.Settings.Default.Priority_Timeevents;
            clTimeEvents.name = "TimeEvents";
            clTimeEvents.objectInfos = ObjectInfoType.REFERENCEPOINT;
            clTimeEvents.visible = Properties.Settings.Default.Visibility_Timeevents;
            List<XServer.Bitmap> lstTimeEventBmp = new List<XServer.Bitmap>();
            int indexTimeEvent = 0;
            foreach (TimeEvent timeEvent in tour.wrappedTimeEvents)
            {
                XServer.Bitmap bmp = new XServer.Bitmap();
                bmp.descr = (indexTimeEvent++).ToString() + " : " + displayTime(timeEvent.startTime) + " - " + timeEvent.type.ToString();
                bmp.name = Properties.Settings.Default.TimeEventIcon;
                bmp.position = new XServer.Point();
                if (timeEvent.type == TimeEventType.TOUR_END)
                    bmp.position.point = tour.route.polygon.lineString.wrappedPoints[tour.route.polygon.lineString.wrappedPoints.Length - 1];
                else
                    bmp.position.point = tour.route.polygon.lineString.wrappedPoints[tour.route.wrappedSegments[timeEvent.segmentIdx].firstPolyIdx];
                lstTimeEventBmp.Add(bmp);
            }
            Bitmaps bitmaps = new Bitmaps();
            bitmaps.wrappedBitmaps = lstTimeEventBmp.ToArray();
            clTimeEvents.wrappedBitmaps = new Bitmaps[] { bitmaps };
            return clTimeEvents;
        }

        private CustomLayer getWaypointsLayer(Route route)
        {
            CustomLayer clWaypoints = new CustomLayer();
            clWaypoints.centerObjects = true;
            clWaypoints.drawPriority = Properties.Settings.Default.Priority_Waypoints;
            clWaypoints.name = "Waypoints";
            clWaypoints.objectInfos = ObjectInfoType.REFERENCEPOINT;
            clWaypoints.visible = Properties.Settings.Default.Visibility_Waypoints;
            List<XServer.Bitmap> lstWaypointBitmap = new List<XServer.Bitmap>();
            int indexWaypoint = 0;
            foreach (WayPoint wp in advancedTour.route.wrappedStations)
            {
                XServer.Bitmap bmpWaypoint = new XServer.Bitmap();
                bmpWaypoint.descr = (indexWaypoint).ToString() + " : " + displayTime(wp.accTime) + " : " + wp.wayPointType.ToString();
                if (wp.wayPointType == WayPointType.START)
                    bmpWaypoint.name = Properties.Settings.Default.Waypoint_START;
                else if (wp.wayPointType == WayPointType.VIA)
                    bmpWaypoint.name = Properties.Settings.Default.Waypoint_VIA;
                else if (wp.wayPointType == WayPointType.DEST)
                    bmpWaypoint.name = Properties.Settings.Default.Waypoint_DEST;
                else
                    bmpWaypoint.name = Properties.Settings.Default.DefaultIcon;
                bmpWaypoint.position = wp.locationCoord;
                lstWaypointBitmap.Add(bmpWaypoint);
                // 2010-09-14: visualization of matchCoordinate
                XServer.Bitmap bmpMatchpoint = new XServer.Bitmap(Properties.Settings.Default.Icon_Matchpoint, wp.matchCoord, "MatchPoint-" + indexWaypoint);
                lstWaypointBitmap.Add(bmpMatchpoint);
                indexWaypoint++;
            }


            if (viaWaypoint != null)
            {
                lstWaypointBitmap.Add(new XServer.Bitmap(Properties.Settings.Default.Waypoint_FUZZY, viaWaypoint.wrappedCoords[0], "FuzzyLocation"));
            }

            clWaypoints.wrappedBitmaps = new Bitmaps[] { new Bitmaps() };
            clWaypoints.wrappedBitmaps[0].wrappedBitmaps = lstWaypointBitmap.ToArray();
            return clWaypoints;
        }

        //private CustomLayer getWaypointsLayer(Route route)
        //{

        //    CustomLayer clWaypoints = new CustomLayer();
        //    clWaypoints.centerObjects = true;
        //    clWaypoints.drawPriority = 
        //}

        private CustomLayer getManoeuvresLayer(Route route)
        {
            List<XServer.Bitmap> lstManoeuvreBitmap = new List<XServer.Bitmap>();
            int index = 0;
            foreach (RouteManoeuvre curManoeuvre in route.wrappedManoeuvres)
            {
                RouteListSegment curSegment = route.wrappedSegments[curManoeuvre.routeListSegmentIdx];
                XServer.Bitmap curBitmap = new XServer.Bitmap();

                string description = (index++).ToString() + " - " + displayTime(curSegment.accTime) + " : " + curManoeuvre.manoeuvreDesc;
                description += " (" + curManoeuvre.manoeuvreType.ToString() + ")";

                curBitmap.descr = description;

                curBitmap.name = "location.bmp";
                curBitmap.position = new XServer.Point();
                curBitmap.position.point = route.polygon.lineString.wrappedPoints[curSegment.firstPolyIdx + curSegment.polyC - 1];
                lstManoeuvreBitmap.Add(curBitmap);
            }
            CustomLayer clManoeuvres = new CustomLayer();
            clManoeuvres.centerObjects = true;
            clManoeuvres.drawPriority = Properties.Settings.Default.Priority_Manoeuvres;
            clManoeuvres.name = "Manoeuvres";
            clManoeuvres.objectInfos = ObjectInfoType.REFERENCEPOINT;
            clManoeuvres.visible = Properties.Settings.Default.Visibility_Manoeuvres;
            clManoeuvres.wrappedBitmaps = new Bitmaps[] { new Bitmaps() };
            clManoeuvres.wrappedBitmaps[0].wrappedBitmaps = lstManoeuvreBitmap.ToArray();
            return clManoeuvres;
        }

        private CustomLayer getManoeuvreGroupsLayer(Route route)
        {
            List<XServer.LineString> lstManoeuvreGroups = new List<XServer.LineString>();
            for (int i = 0; i < advancedTour.route.wrappedManoeuvreGroup.Length; i++)
            {
                BoundingRectangle boundingRectangle = advancedTour.route.wrappedManoeuvreGroup[i].extend;
                List<PlainPoint> lstPlainPoint = new List<PlainPoint>();
                lstPlainPoint.Add(new PlainPoint(boundingRectangle.leftBottom.point.x, boundingRectangle.leftBottom.point.y));
                lstPlainPoint.Add(new PlainPoint(boundingRectangle.leftBottom.point.x, boundingRectangle.rightTop.point.y));
                lstPlainPoint.Add(new PlainPoint(boundingRectangle.rightTop.point.x, boundingRectangle.rightTop.point.y));
                lstPlainPoint.Add(new PlainPoint(boundingRectangle.rightTop.point.x, boundingRectangle.leftBottom.point.y));
                lstPlainPoint.Add(new PlainPoint(boundingRectangle.leftBottom.point.x, boundingRectangle.leftBottom.point.y));
                PlainLineString plainLineString = new PlainLineString(lstPlainPoint.ToArray());
                XServer.LineString lineString = new XServer.LineString();
                lineString.lineString = plainLineString;
                lstManoeuvreGroups.Add(lineString);
            }
            Lines linesBoundingRect = new Lines();
            linesBoundingRect.wrappedLines = lstManoeuvreGroups.ToArray();

            LinePartOptions mainLinePartOptions = getLinePartOptions(new XServer.Color(Properties.Settings.Default.ManoeuvreGroup_Color), true, Properties.Settings.Default.ManoeuvreGroup_Width);
            //BasicDrawingOptions bdo = new BasicDrawingOptions();
            //bdo.visible = true;
            //bdo.color = getColor(System.Drawing.Color.White);

            LineOptions boundingLineOptions = getLineOptions(null, mainLinePartOptions, false, null, Properties.Settings.Default.ManoeuvreGroup_Transparent);
            linesBoundingRect.options = boundingLineOptions;

            CustomLayer clManoeuvreGroups = new CustomLayer();
            clManoeuvreGroups.centerObjects = true;
            clManoeuvreGroups.drawPriority = Properties.Settings.Default.Priority_ManoeuvreGroups;
            clManoeuvreGroups.name = "ManoeuvreGroups";
            clManoeuvreGroups.objectInfos = ObjectInfoType.NONE;
            clManoeuvreGroups.visible = Properties.Settings.Default.Visibility_ManoeuvreGroups;
            clManoeuvreGroups.wrappedLines = new Lines[] { linesBoundingRect };
            return clManoeuvreGroups;
        }

        private CustomLayer getBoundingRectangles(Route route)
        {
            List<XServer.LineString> lstBoundingRectangles = new List<XServer.LineString>();
            foreach (BoundingRectangle boundingRectangle in route.wrappedBoundingRectangles)
            {
                List<PlainPoint> lstPlainPoint = new List<PlainPoint>();
                lstPlainPoint.Add(new PlainPoint(boundingRectangle.leftBottom.point.x, boundingRectangle.leftBottom.point.y));
                lstPlainPoint.Add(new PlainPoint(boundingRectangle.leftBottom.point.x, boundingRectangle.rightTop.point.y));
                lstPlainPoint.Add(new PlainPoint(boundingRectangle.rightTop.point.x, boundingRectangle.rightTop.point.y));
                lstPlainPoint.Add(new PlainPoint(boundingRectangle.rightTop.point.x, boundingRectangle.leftBottom.point.y));
                lstPlainPoint.Add(new PlainPoint(boundingRectangle.leftBottom.point.x, boundingRectangle.leftBottom.point.y));
                PlainLineString plainLineString = new PlainLineString(lstPlainPoint.ToArray());
                XServer.LineString lineString = new XServer.LineString();
                lineString.lineString = plainLineString;
                lstBoundingRectangles.Add(lineString);
            }
            Lines linesBoundingRect = new Lines();
            linesBoundingRect.wrappedLines = lstBoundingRectangles.ToArray();

            LinePartOptions mainLinePartOptions = getLinePartOptions(new XServer.Color(Properties.Settings.Default.BoundingRectangles_Color), true, Properties.Settings.Default.BoundingRectangles_Width);
            LineOptions boundingLineOptions = getLineOptions(null, mainLinePartOptions, false, null, Properties.Settings.Default.BoundingRectangles_Transparent);
            linesBoundingRect.options = boundingLineOptions;

            CustomLayer clBoundingRectangles = new CustomLayer();
            clBoundingRectangles.centerObjects = true;
            clBoundingRectangles.drawPriority = Properties.Settings.Default.Priority_BoundingRect;
            clBoundingRectangles.name = "BoundingRectangles";
            clBoundingRectangles.objectInfos = ObjectInfoType.REFERENCEPOINT;
            clBoundingRectangles.visible = Properties.Settings.Default.Visibility_BoundingRect;
            clBoundingRectangles.wrappedLines = new Lines[] { linesBoundingRect };
            return clBoundingRectangles;
        }

        private CustomLayer getTollLayer(Route route, MySegmentAttributes segmentAttributes)
        {
            CustomLayer clToll = new CustomLayer();
            clToll.centerObjects = true;
            clToll.drawPriority = Properties.Settings.Default.Priority_Toll;
            //clToll.name = "Toll";
            clToll.name = Enum.GetName(typeof(MySegmentAttributes), segmentAttributes);
            clToll.objectInfos = ObjectInfoType.REFERENCEPOINT;
            clToll.visible = Properties.Settings.Default.Visibility_Toll;
            bool transparency_toll = Properties.Settings.Default.Transparency_Toll;
            Lines linesWithoutToll = new Lines();
            linesWithoutToll.options = getLineOptions(null, getLinePartOptions(getColor(Properties.Settings.Default.SegmentWithoutTruckToll_Color), true, Properties.Settings.Default.SegmentToll_Width), false, null, transparency_toll);
            Lines linesWithToll = new Lines();
            linesWithToll.options = getLineOptions(null, getLinePartOptions(getColor(Properties.Settings.Default.SegmentWithTruckToll_Color), true, Properties.Settings.Default.SegmentToll_Width), false, null, transparency_toll);

            List<XServer.Bitmap> lstBitmap = new List<XServer.Bitmap>();
            int indexBmp = 0;

            List<XServer.LineString> listLineStringWithToll = new List<XServer.LineString>();
            List<XServer.LineString> listLineStringWithoutToll = new List<XServer.LineString>();
            // identify the first segment and its toll attributes:
            RouteListSegment firstSegment = route.wrappedSegments[0];
            // true : has Toll
            // false: has no toll
            bool oldTollState = segmentHasToll(firstSegment, segmentAttributes); //((firstSegment.segmentAttr != null) && (firstSegment.segmentAttr.hasTollTruck));
            List<PlainPoint> listPlainPoint = new List<PlainPoint>();
            foreach (RouteListSegment curRouteListSegment in route.wrappedSegments)
            {
                bool curTollState = segmentHasToll(curRouteListSegment, segmentAttributes);  //((curRouteListSegment.segmentAttr != null) && (curRouteListSegment.segmentAttr.hasTollTruck));
                if (curTollState == oldTollState)
                {
                    if (listPlainPoint.Count > 0)
                        listPlainPoint.RemoveAt(listPlainPoint.Count - 1);
                    if (lstBitmap.Count == 0)
                    {
                        XServer.Bitmap bmp = new XServer.Bitmap();
                        bmp.descr = (indexBmp++).ToString();
                        bmp.name = "location.bmp";
                        bmp.position = new XServer.Point();
                        bmp.position.point = route.polygon.lineString.wrappedPoints[0];
                        lstBitmap.Add(bmp);
                    }
                }
                else
                {   // a new toll intervall is identified, the currently collected plain points have to be joined to one toll PlainLineString
                    PlainLineString plainLineString = new PlainLineString();
                    plainLineString.wrappedPoints = listPlainPoint.ToArray();
                    XServer.LineString lineString = new XServer.LineString();
                    lineString.lineString = plainLineString;
                    // depending on the current toll state it is assigned the corresponding Lines-list...
                    if (oldTollState)
                        listLineStringWithToll.Add(lineString);
                    else
                        listLineStringWithoutToll.Add(lineString);
                    listPlainPoint.Clear();
                    // at the first point of the intervall we want to paint a bitmap...
                    XServer.Bitmap bmp = new XServer.Bitmap();
                    bmp.descr = (indexBmp++).ToString();
                    bmp.name = "location.bmp";
                    bmp.position = new XServer.Point();
                    bmp.position.point = route.polygon.lineString.wrappedPoints[curRouteListSegment.firstPolyIdx];
                    lstBitmap.Add(bmp);
                    oldTollState = curTollState;
                }
                for (int polyIndex = curRouteListSegment.firstPolyIdx; polyIndex < curRouteListSegment.firstPolyIdx + curRouteListSegment.polyC; polyIndex++)
                    listPlainPoint.Add(route.polygon.lineString.wrappedPoints[polyIndex]);
            }
            // letzte Linie
            if (listPlainPoint.Count > 0)
            {
                XServer.LineString finalLineString = new XServer.LineString();
                finalLineString.lineString = new PlainLineString();
                finalLineString.lineString.wrappedPoints = listPlainPoint.ToArray();
                if (oldTollState)
                    listLineStringWithToll.Add(finalLineString);
                else
                    listLineStringWithoutToll.Add(finalLineString);
            }
            // last Bitmap
            XServer.Bitmap lastBitmap = new XServer.Bitmap();
            lastBitmap.descr = (indexBmp++).ToString();
            lastBitmap.name = "location.bmp";
            lastBitmap.position = new XServer.Point();
            lastBitmap.position.point = route.polygon.lineString.wrappedPoints[route.polygon.lineString.wrappedPoints.Length - 1];
            lstBitmap.Add(lastBitmap);
            clToll.wrappedBitmaps = new Bitmaps[] { new Bitmaps() };
            clToll.wrappedBitmaps[0].wrappedBitmaps = lstBitmap.ToArray();

            linesWithoutToll.wrappedLines = listLineStringWithoutToll.ToArray();
            linesWithToll.wrappedLines = listLineStringWithToll.ToArray();
            List<Lines> listLines = new List<Lines>();
            listLines.Add(linesWithoutToll);
            listLines.Add(linesWithToll);
            clToll.wrappedLines = listLines.ToArray();
            return clToll;
        }

        // since 5.11.2010: visualization of tollsection FROM and TO
        private CustomLayer getTollSectionLayer(ExtendedRoute exRoute)
        {
            if ((exRoute.wrappedCountryInfos != null) && (exRoute.wrappedCountryInfos.Length > 0))
            {
                CustomLayer clTollSections = new CustomLayer();
                clTollSections.centerObjects = false;
                clTollSections.drawPriority = Properties.Settings.Default.Priority_TollSections;
                clTollSections.name = "TollSections";
                clTollSections.objectInfos = ObjectInfoType.REFERENCEPOINT;
                clTollSections.visible = Properties.Settings.Default.Visibility_TollSections;

                List<XServer.Bitmap> lstBmp = new List<XServer.Bitmap>();
                foreach (CountryInfo ci in exRoute.wrappedCountryInfos)
                {
                    if ((ci.wrappedTollCostInfos != null) && (ci.wrappedTollCostInfos.Length > 0) && (ci.iuCode != -1))
                    {
                        foreach (TollCostInfo tci in ci.wrappedTollCostInfos)
                        {
                            if (tci.tollSectionID != -1)
                            {
                                int indexTollStationFrom = tci.tollStationFrom.routeListIndex;
                                if ((0 <= indexTollStationFrom) && (indexTollStationFrom < exRoute.route.wrappedSegments.Length))
                                {
                                    RouteListSegment rlsFrom = exRoute.route.wrappedSegments[tci.tollStationFrom.routeListIndex];
                                    int indexFrom = rlsFrom.firstPolyIdx;
                                    XServer.Bitmap bmpFrom = new XServer.Bitmap();
                                    bmpFrom.descr = "From: " + tci.tollStationFrom.ToString();
                                    bmpFrom.name = Properties.Settings.Default.Icon_TollSection_From;
                                    bmpFrom.position = new XServer.Point();
                                    bmpFrom.position.point = exRoute.route.polygon.lineString.wrappedPoints[indexFrom];
                                    lstBmp.Add(bmpFrom);
                                }

                                int indexTollStationTo = tci.tollStationTo.routeListIndex;
                                if ((0 <= indexTollStationTo) && (indexTollStationTo < exRoute.route.wrappedSegments.Length))
                                {
                                    RouteListSegment rlsTo = exRoute.route.wrappedSegments[tci.tollStationTo.routeListIndex];
                                    int indexTo = rlsTo.firstPolyIdx;
                                    XServer.Bitmap bmpTo = new XServer.Bitmap();
                                    bmpTo.descr = "To: " + tci.tollStationTo.ToString();
                                    bmpTo.name = Properties.Settings.Default.Icon_TollSection_To;
                                    bmpTo.position = new XServer.Point();
                                    bmpTo.position.point = exRoute.route.polygon.lineString.wrappedPoints[indexTo];
                                    lstBmp.Add(bmpTo);
                                }
                            }
                        }
                    }
                }
                Bitmaps bmps = new Bitmaps();
                bmps.wrappedBitmaps = lstBmp.ToArray();
                clTollSections.wrappedBitmaps = new Bitmaps[] { bmps };
                return clTollSections;
            }
            else
                return null;
        }

        private SMOLayer getGeodatasourceLayer()
        {
            SMOLayer smoLayer = new SMOLayer();
            smoLayer.configuration = "";
            smoLayer.name = tbxGEODATASOURCE_LAYER.Text;
            smoLayer.objectInfos = ObjectInfoType.REFERENCEPOINT;
            smoLayer.smoData = null;
            smoLayer.visible = true;
            return smoLayer;
        }

        private CustomLayer getRouteLayer(Route route)
        {
            CustomLayer cl = new CustomLayer();
            cl.centerObjects = true;
            cl.drawPriority = Properties.Settings.Default.Priority_Route;
            cl.name = "Route";
            cl.objectInfos = ObjectInfoType.FULLGEOMETRY;
            cl.visible = Properties.Settings.Default.Visibility_Route;
            cl.wrappedLines = new Lines[] { new Lines() };
            XServer.LineString wkbRoute = new XServer.LineString();
            wkbRoute.wkb = route.polygon.wkb;
            cl.wrappedLines[0].wrappedLines = new XServer.LineString[] { wkbRoute };
            LinePartOptions mainLine = getLinePartOptions(new XServer.Color(Properties.Settings.Default.Route_Color), true, Properties.Settings.Default.Route_Width);
            LineOptions lineOptions = new LineOptions();
            lineOptions.mainLine = mainLine;
            lineOptions.showFlags = false;
            lineOptions.transparent = false;
            cl.wrappedLines[0].options = lineOptions;
            return cl;
        }

        private CustomLayer getRoutePointLayer(Route route)
        {
            CustomLayer cl = new CustomLayer();
            cl.centerObjects = true;
            cl.drawPriority = Properties.Settings.Default.Priority_RoutePoint;
            cl.name = "RoutePoint";
            cl.objectInfos = ObjectInfoType.REFERENCEPOINT;
            cl.visible = Properties.Settings.Default.Visibility_Routepoint;
            List<XServer.Bitmap> lstBMP = new List<XServer.Bitmap>();
            int index = 0;
            foreach (PlainPoint pp in route.polygon.lineString.wrappedPoints)
            {
                XServer.Bitmap bmp = new XServer.Bitmap();
                bmp.descr = "" + (index++) + ":" + pp.ToString();
                bmp.name = Properties.Settings.Default.Icon_Routepoint;
                bmp.position = new XServer.Point();
                bmp.position.point = pp;
                lstBMP.Add(bmp);
            }
            Bitmaps bmps = new Bitmaps();
            bmps.wrappedBitmaps = lstBMP.ToArray();
            cl.wrappedBitmaps = new Bitmaps[] { bmps };
            return cl;
        }

        private CustomLayer getFerryLayer(Route route)
        {
            CustomLayer cl = new CustomLayer();
            cl.visible = Properties.Settings.Default.Visibility_Ferries; ;
            cl.objectInfos = ObjectInfoType.REFERENCEPOINT;
            cl.name = "Ferries";
            cl.drawPriority = Properties.Settings.Default.Priority_Ferries;
            cl.centerObjects = true;
            List<XServer.LineString> lstLineString = new List<XServer.LineString>();
            List<XServer.Bitmap> lstBItmap = new List<XServer.Bitmap>();
            foreach (RouteManoeuvre routeManoeuvre in route.wrappedManoeuvres)
            {
                if ((routeManoeuvre.manoeuvreType == ManoeuvreType.ENTER_FERRY) || (routeManoeuvre.manoeuvreType == ManoeuvreType.EXIT_FERRY))
                {
                    List<XServer.PlainPoint> lstPoint = new List<XServer.PlainPoint>();
                    int firstPolyIdx = route.wrappedSegments[routeManoeuvre.predSegmentIdx].firstPolyIdx;
                    // 2011.12.27: correction: lastPoly reduced by 1! Affects location of EXIT_FERRY icon
                    int lastPolyIdx = route.wrappedSegments[routeManoeuvre.succSegmentIdx].firstPolyIdx + route.wrappedSegments[routeManoeuvre.succSegmentIdx].nodeC - 1;
                    for (int idx = firstPolyIdx; idx <= lastPolyIdx; idx++)
                    {
                        lstPoint.Add(route.polygon.lineString.wrappedPoints[idx]);
                    }
                    XServer.LineString lineString = new XServer.LineString()
                    {
                        lineString = new PlainLineString()
                        {
                            wrappedPoints = lstPoint.ToArray()
                        }
                    };
                    lstLineString.Add(lineString);
                    if (routeManoeuvre.manoeuvreType == ManoeuvreType.ENTER_FERRY)
                    {
                        lstBItmap.Add(new XServer.Bitmap()
                        {
                            descr = "enter ferry (" + routeManoeuvre.routeListSegmentIdx.ToString() + ")",
                            name = "flaggreen.bmp",
                            position = new XServer.Point()
                            {
                                point = route.polygon.lineString.wrappedPoints[firstPolyIdx]
                            }
                        });
                    }
                    else if (routeManoeuvre.manoeuvreType == ManoeuvreType.EXIT_FERRY)
                    {
                        lstBItmap.Add(new XServer.Bitmap()
                        {
                            descr = "exit ferry (" + routeManoeuvre.routeListSegmentIdx.ToString() + ")",
                            name = "flagred.bmp",
                            position = new XServer.Point()
                            {
                                point = route.polygon.lineString.wrappedPoints[lastPolyIdx]
                            }
                        });
                    }

                }
                if (lstLineString.Count > 0)
                {
                    Lines lines = new Lines();
                    LineOptions lineOptions = getLineOptions(null, getLinePartOptions(new XServer.Color(Properties.Settings.Default.Color_Ferries), true, Properties.Settings.Default.Width_Ferries), false, null, true);
                    lines.options = lineOptions;
                    lines.wrappedLines = lstLineString.ToArray();
                    cl.wrappedLines = new Lines[] { lines };
                }
                if (lstBItmap.Count > 0)
                {
                    Bitmaps bitmaps = new Bitmaps();
                    bitmaps.wrappedBitmaps = lstBItmap.ToArray();
                    cl.wrappedBitmaps = new Bitmaps[] { bitmaps };
                }

            }
            return cl;
        }

        private CustomLayer getSegmentAttributesLayer(AdvancedTour advancedTour)
        {
            CustomLayer cl = new CustomLayer();
            cl.centerObjects = true;
            cl.drawPriority = Properties.Settings.Default.Priority_Segments;
            cl.name = "Segments";
            cl.objectInfos = ObjectInfoType.REFERENCEPOINT;
            cl.visible = Properties.Settings.Default.Visibility_Segments;
            List<XServer.Bitmap> lstBmp = new List<XServer.Bitmap>();
            bool textsAvailable = (advancedTour.route.wrappedTexts != null);
            foreach (RouteListSegment rls in advancedTour.route.wrappedSegments)
            {
                List<string> lstDescr = new List<string>();
                lstDescr.Add("Segment");
                lstDescr.Add("Time : " + displayTime(rls.accTime));
                lstDescr.Add("Dist : " + rls.accDist);
                lstDescr.Add("NC=" + rls.nC.ToString());

                if ((rls.streetNameIdx >= 0) && (textsAvailable))
                    lstDescr.Add("streetName = '" + advancedTour.route.wrappedTexts[rls.streetNameIdx] + "'");
                if ((rls.dirInfoIdx >= 0) && (textsAvailable))
                    lstDescr.Add("dirInfo = '" + advancedTour.route.wrappedTexts[rls.dirInfoIdx] + "'");
                string icon;
                if (rls.segmentAttr != null)
                {
                    SegmentAttributes segmentAttributes = rls.segmentAttr;
                    List<string> lstSegmentAttributes = new List<string>();
                    if (segmentAttributes.hasExtraToll)
                        lstSegmentAttributes.Add("hasExtraToll");
                    if (segmentAttributes.hasSeparator)
                        lstSegmentAttributes.Add("hasSeparator");
                    if (segmentAttributes.hasTollCar)
                        lstSegmentAttributes.Add("hasTollCar");
                    if (segmentAttributes.hasTollTruck)
                        lstSegmentAttributes.Add("hasTollTruck");
                    if (segmentAttributes.hasVignetteCar)
                        lstSegmentAttributes.Add("hasVignetteCar");
                    if (segmentAttributes.hasVignetteTruck)
                        lstSegmentAttributes.Add("hasVignetteTruck");
                    if (segmentAttributes.isBlockedCar)
                        lstSegmentAttributes.Add("isBlockedCar");
                    if (segmentAttributes.isBlockedTruck)
                        lstSegmentAttributes.Add("isBlockedTruck");
                    if (segmentAttributes.isFerry)
                        lstSegmentAttributes.Add("isFerry");
                    // 2011.12.27: PiggyBack invented in 1.14
                    if (segmentAttributes.isPiggybackSpecified && segmentAttributes.isPiggyback)
                        lstSegmentAttributes.Add("isPiggyback");
                    //
                    if (segmentAttributes.isPedestrianZone)
                        lstSegmentAttributes.Add("isPedestrianZone");
                    if ((segmentAttributes.lowEmissionZoneType != null) && (segmentAttributes.lowEmissionZoneType.Trim() != ""))
                        lstSegmentAttributes.Add("lowEmissionZoneType='" + segmentAttributes.lowEmissionZoneType + "'");
                    if ((segmentAttributes.additionalRE != null) && (segmentAttributes.additionalRE.Trim() != ""))
                    {
                        lstSegmentAttributes.Add("additionalRE='" + segmentAttributes.additionalRE + "'");
                        icon = Properties.Settings.Default.Icon_Segments_NoStandard_Add;
                    }
                    else
                    {
                        icon = Properties.Settings.Default.Icon_Segments_NoStandard_NoAdd;
                    }
                    if (lstSegmentAttributes.Count > 0)
                        lstDescr.Add(String.Join(",", lstSegmentAttributes.ToArray()));

                }
                else
                {
                    icon = Properties.Settings.Default.Icon_Segments_Standard;
                }
                if(rls.speedLimits != null )
                {
                    lstDescr.Add("SpeedLimits = '" + rls.speedLimits.ToString() + "'");
                }
                string descr = String.Join("\r\n", lstDescr.ToArray());
                XServer.Point point = new XServer.Point();
                point.point = advancedTour.route.polygon.lineString.wrappedPoints[rls.firstPolyIdx];
                XServer.Bitmap bmp = new XServer.Bitmap(icon, point, descr);
                lstBmp.Add(bmp);
            }
            cl.wrappedBitmaps = new Bitmaps[1];
            cl.wrappedBitmaps[0] = new Bitmaps();
            cl.wrappedBitmaps[0].wrappedBitmaps = lstBmp.ToArray();
            return cl;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private String displayCountryInfo(CountryInfo countryInfo)
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Append(countryInfo.countryCode);
            return strBuilder.ToString();
        }


        private string displayTime(int seconds)
        {
            string result = "";
            if (seconds == 0)
                result = "0 days 0 h 0 m 0 s";
            else
            {
                if (seconds >= 86400)
                    result += (seconds / 86400) + "days";
                seconds = (seconds % 86400);
                if (seconds >= 3600)
                    result += " " + (seconds / 3600) + "h";
                seconds = (seconds % 3600);
                if (seconds >= 60)
                    result += " " + (seconds / 60) + "m";
                seconds = (seconds % 60);
                if (seconds > 0)
                    result += " " + seconds + "s";
            }
            return result;
        }

        private void lbxOutCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = ((ListBox)sender).SelectedIndex;
            CountryInfo countryInfo = advancedTour.wrappedCountryInfos[i];
            dgvTollCostInfo.DataSource = countryInfo.wrappedTollCostInfos;
            dgv_perNCRouteInfo.DataSource = countryInfo.wrappedPerNCRouteInfo;
            lbx_PerTypeTollPrice.DataSource = countryInfo.wrappedPerTypeTollPrice;
            lbx_PerTypeTollDistance.DataSource = countryInfo.wrappedPerTypeTollDistance;

            labPerTypeTollPrice.Text = "Price in \n" + countryInfo.currency + "/100";
            RouteInfo partRouteInfo = countryInfo.partRouteInfo;
            tbxPartTime.Text = displayTime(partRouteInfo.time);
            tbxPartDistance.Text = partRouteInfo.distance.ToString();
            tbxPartCost.Text = partRouteInfo.cost.ToString();
            RouteInfo routeInfo = advancedTour.route.info;
            tbxPercTime.Text = Convert.ToInt16(100.0 * Convert.ToDouble(partRouteInfo.time) / Convert.ToDouble(routeInfo.time)).ToString();
            tbxPercDistance.Text = Convert.ToInt16(100.0 * Convert.ToDouble(partRouteInfo.distance) / Convert.ToDouble(routeInfo.distance)).ToString();
            tbxPercCost.Text = Convert.ToInt16(100.0 * Convert.ToDouble(partRouteInfo.cost) / Convert.ToDouble(routeInfo.cost)).ToString();

            //if ((tollCostInfo_form == null) || (tollCostInfo_form.IsDisposed))
            //    tollCostInfo_form = new TollCostInfo_Form(countryInfo.wrappedTollCostInfos);
            //else
            //    tollCostInfo_form.updateDGV(countryInfo.wrappedTollCostInfos);
            //if (!tollCostInfo_form.Visible)
            //    tollCostInfo_form.Show(this);

            // 2010-08-27: Cost aggregation based on cost vectors...
            List<RouteInfo> lstRouteInfo = new List<RouteInfo>();
            for (int j = 0; j < countryInfo.wrappedPerNCRouteInfo.Length; j++)
            {
                RouteInfo riNC = countryInfo.wrappedPerNCRouteInfo[j];
                RouteInfo riCosts = new RouteInfo();
                riCosts.distance = (int)(costVectorDistance[j] * (double)(riNC.distance));
                riCosts.time = (int)(costVectorPeriod[j] * (double)(riNC.time));
                riCosts.cost = riCosts.distance + riCosts.time;
                lstRouteInfo.Add(riCosts);
            }
            dgvOutputCosts.DataSource = lstRouteInfo;


        }

        private LineOptions getLineOptions(BasicDrawingOptions arrows, LinePartOptions mainLine, bool showFlags, LinePartOptions sideLine, bool transparent)
        {
            LineOptions lineOptions = new LineOptions();
            lineOptions.arrows = arrows;
            lineOptions.mainLine = mainLine;
            lineOptions.showFlags = showFlags;
            lineOptions.sideLine = sideLine;
            lineOptions.transparent = transparent;
            return lineOptions;
        }
        private LinePartOptions getLinePartOptions(XServer.Color color, bool visible, int width)
        {
            LinePartOptions linePartOptions = new LinePartOptions();
            linePartOptions.color = color;
            linePartOptions.visible = visible;
            linePartOptions.width = width;
            return linePartOptions;
        }
        private XServer.Color getColor(System.Drawing.Color rgb_color)
        {
            XServer.Color color = new XServer.Color();
            color.blue = rgb_color.B;
            color.green = rgb_color.G;
            color.red = rgb_color.R;
            return color;
        }

        private void labROADEDITOR_ATTRIBUTESET_Click(object sender, EventArgs e)
        {

        }

        private bool segmentHasToll(RouteListSegment rls, MySegmentAttributes segmentAttributes)
        {
            bool result = (rls.segmentAttr != null);
            if (result)
            {
                if (segmentAttributes == MySegmentAttributes.hasTollCar && rls.segmentAttr.hasTollCar)
                    result = true;
                else if (segmentAttributes == MySegmentAttributes.hasTollTruck && rls.segmentAttr.hasTollTruck)
                    result = true;
                else
                    result = false;
            }
            return (result);
        }

        private CountryInfo[] mergeCountryInfo(CountryInfo[] pre)
        {
            List<CountryInfo> lstCountryInfo = new List<CountryInfo>(pre);
            CountryInfo countryInfoTotal = new CountryInfo();
            countryInfoTotal.additionalInfo = "NOT STANDARD";
            countryInfoTotal.countryCode = "--";
            countryInfoTotal.currency = Currency.EUR;
            countryInfoTotal.currencyName = "";
            countryInfoTotal.iuCode = -1;

            countryInfoTotal.partRouteInfo = new RouteInfo();
            //
            countryInfoTotal.wrappedPerNCRouteInfo = new RouteInfo[8];
            for (int NC = 0; NC < 8; NC++)
                countryInfoTotal.wrappedPerNCRouteInfo[NC] = new RouteInfo();
            //
            countryInfoTotal.wrappedPerTypeTollDistance = new int[8];
            countryInfoTotal.wrappedPerTypeTollPrice = new int[8];
            List<TollCostInfo> lstTollCostInfo = new List<TollCostInfo>();
            foreach (CountryInfo ci in pre)
            {
                // PartRouteInfo
                countryInfoTotal.partRouteInfo.cost += ci.partRouteInfo.cost;
                countryInfoTotal.partRouteInfo.distance += ci.partRouteInfo.distance;
                countryInfoTotal.partRouteInfo.time += ci.partRouteInfo.time;
                // PerNCRouteInfo
                for (int NC = 0; NC < 8; NC++)
                {
                    countryInfoTotal.wrappedPerNCRouteInfo[NC].cost += ci.wrappedPerNCRouteInfo[NC].cost;
                    countryInfoTotal.wrappedPerNCRouteInfo[NC].time += ci.wrappedPerNCRouteInfo[NC].time;
                    countryInfoTotal.wrappedPerNCRouteInfo[NC].distance += ci.wrappedPerNCRouteInfo[NC].distance;
                }
                //countryInfoTotal.wrappedPerTypeTollDistance
                for (int tt = 0; tt < 8; tt++)
                {
                    countryInfoTotal.wrappedPerTypeTollDistance[tt] += ci.wrappedPerTypeTollDistance[tt];
                    countryInfoTotal.wrappedPerTypeTollPrice[tt] += ci.wrappedPerTypeTollPrice[tt];
                }
                //
                lstTollCostInfo.AddRange(ci.wrappedTollCostInfos);
            }
            countryInfoTotal.wrappedTollCostInfos = lstTollCostInfo.ToArray();
            lstCountryInfo.Add(countryInfoTotal);
            return lstCountryInfo.ToArray();
        }

        private RoutingOption getRoutingOption(RoutingParameter parameter, string value)
        {
            RoutingOption ro = new RoutingOption();
            ro.parameter = parameter;
            ro.value = value;
            return ro;
        }

        // 2010-03-19
        private VehicleOption getVehicleOption(VehicleParameter vp, string value)
        {
            VehicleOption vehicle_option = new VehicleOption();
            vehicle_option.parameter = vp;
            vehicle_option.value = value;
            return vehicle_option;
        }

        private void labStart_Click(object sender, EventArgs e)
        {
            swapStations();
        }
        // simple swap of start and destination
        private void swapStations()
        {
            string backupStartX = tbxStartX.Text;
            string backupStartY = tbxStartY.Text;
            tbxStartX.Text = tbxDestX.Text;
            tbxStartY.Text = tbxDestY.Text;
            tbxDestX.Text = backupStartX;
            tbxDestY.Text = backupStartY;
        }

        private void labDest_Click(object sender, EventArgs e)
        {
            swapStations();
        }

        private void tbxCostsDistance_TextChanged(object sender, EventArgs e)
        {
            string[] strCosts = tbxCostsDistance.Text.Split(',');
            try
            {
                for (int i = 0; i < 8; i++)
                    costVectorDistance[i] = Convert.ToDouble(strCosts[i]);
            }
            catch (Exception)
            {
            }
        }

        private void tbxCostsPeriod_TextChanged(object sender, EventArgs e)
        {
            string[] strCosts = tbxCostsPeriod.Text.Split(',');
            try
            {
                for (int i = 0; i < 8; i++)
                    costVectorPeriod[i] = Convert.ToDouble(strCosts[i]);
            }
            catch (Exception)
            {
            }
        }

        private void load1DriverRegulationsBtn_Click(object sender, EventArgs e)
        {
            // break rule
            drivingPeriodTxtBx.Text = "16200";
            breakPeriod1TxtBx.Text = "900";
            breakPeriod2TxtBx.Text = "1800";

            // daily rest rule
            regularRestPeriodTxtBx.Text = "39600";
            firstSplitRestPeriodTxtbx.Text = "10800";
            secondSplitRestPeriodTxtBx.Text = "32400";
            reducedRestPeriodTxtBx.Text = "32400";
            numberOfReducedRestPeriodsTxtBx.Text = "3";
            regularDrivingPeriodTxtBx.Text = "32400";
            extendedDrivingPeriodTxtBx.Text = "36000";
            numberOfExtendedDrivingPeriodsTxtBx.Text = "2";
            maximumPeriodBetweenEndOfDailyRestsTxtBx.Text = "86400";

            // weekly rest rule
            maximumPeriodBetweenWeeklyRestsTxtBx.Text = "518400";
            maximumWeeklyDrivingPeriodTxtBx.Text = "201600";
            maximumBiweeklyDrivingPeriodTxtBx.Text = "324000";
            weeklyRestPeriodTxtBx.Text = "162000";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // break rule
            drivingPeriodTxtBx.Text = "16200";
            breakPeriod1TxtBx.Text = "900";
            breakPeriod2TxtBx.Text = "1800";

            // daily rest rule
            regularRestPeriodTxtBx.Text = "32400";
            firstSplitRestPeriodTxtbx.Text = "10800";
            secondSplitRestPeriodTxtBx.Text = "32400";
            reducedRestPeriodTxtBx.Text = "32400";
            numberOfReducedRestPeriodsTxtBx.Text = "3";
            regularDrivingPeriodTxtBx.Text = "64800";
            extendedDrivingPeriodTxtBx.Text = "72000";
            numberOfExtendedDrivingPeriodsTxtBx.Text = "2";
            maximumPeriodBetweenEndOfDailyRestsTxtBx.Text = "108000";

            // weekly rest rule
            maximumPeriodBetweenWeeklyRestsTxtBx.Text = "518400";
            maximumWeeklyDrivingPeriodTxtBx.Text = "403200";
            maximumBiweeklyDrivingPeriodTxtBx.Text = "648000";
            weeklyRestPeriodTxtBx.Text = "162000";
        }

        private void enableSnippetChckBx_CheckedChanged(object sender, EventArgs e)
        {
            tbxXMLSnippet.Enabled = enableSnippetChckBx.Checked;
        }
    }
}