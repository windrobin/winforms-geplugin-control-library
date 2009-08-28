﻿// <copyright file="GEHelpers.cs" company="FC">
// Copyright (c) 2008 Fraser Chapman
// </copyright>
// <author>Fraser Chapman</author>
// <email>fraser.chapman@gmail.com</email>
// <date>2009-03-02</date>
// <summary>This file is part of FC.GEPluginCtrls
// FC.GEPluginCtrls is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// You should have received a copy of the GNU General Public License
// along with this program. If not, see http://www.gnu.org/licenses/.
// </summary>
namespace FC.GEPluginCtrls
{
    using System;
    using System.Text;
    using GEPlugin;

    /// <summary>
    /// This class provides a very basic Google Earth plugin helpers
    /// It is based on the GEHelpers javasctipt library at:
    /// http://earth-api-samples.googlecode.com/svn/trunk/lib/geplugin-helpers.js
    /// </summary>
    public static class GEHelpers
    {
        /// <summary>
        /// Creates a kml placemark
        /// </summary>
        /// <param name="ge">The plugin instance</param>
        /// <param name="latitude">The placemark latitude in decimal degrees</param>
        /// <param name="longitude">The placemark longitude in decimal degrees</param>
        /// <returns>The placemark object</returns>
        public static IKmlPlacemark CreatePlacemark(IGEPlugin ge, double latitude, double longitude)
        {
            IKmlPoint p = ge.createPoint(String.Empty);
            p.setLatitude(latitude);
            p.setLongitude(longitude);
            p.setAltitudeMode(ge.ALTITUDE_RELATIVE_TO_GROUND);
            IKmlPlacemark placemark = ge.createPlacemark(String.Empty);
            placemark.setGeometry(p);

            return placemark;
        }

        /// <summary>
        /// Creates a kml placemark
        /// </summary>
        /// <param name="ge">The plugin instance</param>
        /// <param name="id">The placemark id</param>
        /// <param name="latitude">The placemark latitude in decimal degrees</param>
        /// <param name="longitude">The placemark longitude in decimal degrees</param>
        /// <returns>The placemark object</returns>
        public static IKmlPlacemark CreatePlacemark(IGEPlugin ge, string id, double latitude, double longitude)
        {
            IKmlPoint p = ge.createPoint(String.Empty);
            p.setLatitude(latitude);
            p.setLongitude(longitude);
            p.setAltitudeMode(ge.ALTITUDE_RELATIVE_TO_GROUND);
            IKmlPlacemark placemark = ge.createPlacemark(id);
            placemark.setGeometry(p);

            return placemark;
        }

        /// <summary>
        /// Draws a line string between the given points
        /// </summary>
        /// <param name="ge">The plugin instance</param>
        /// <param name="p1">The first point</param>
        /// <param name="p2">The second point</param>
        /// <returns>A linestring placemark</returns>
        public static IKmlPlacemark CreateLineString(IGEPlugin ge, IKmlPoint p1, IKmlPoint p2)
        {
            IKmlPlacemark lineStringPlacemark = ge.createPlacemark(String.Empty);
            IKmlLineString lineString = ge.createLineString(String.Empty);
            lineStringPlacemark.setGeometry(lineString);
            lineString.setTessellate(1);
            lineString.getCoordinates().pushLatLngAlt(p1.getLatitude(), p1.getLongitude(), 0);
            lineString.getCoordinates().pushLatLngAlt(p2.getLatitude(), p2.getLongitude(), 0);
            return lineStringPlacemark;
        }

        /// <summary>
        /// Get the current pluin view as a point object
        /// </summary>
        /// <param name="ge">the plugin</param>
        /// <returns>Point set to the current view</returns>
        public static IKmlPoint GetCurrentViewAsPoint(IGEPlugin ge)
        {
            IKmlLookAt lookat = ge.getView().copyAsLookAt(ge.ALTITUDE_RELATIVE_TO_GROUND);
            IKmlPoint point = ge.createPoint(String.Empty);
            point.set(
                lookat.getLatitude(),
                lookat.getLongitude(),
                lookat.getAltitude(),
                ge.ALTITUDE_RELATIVE_TO_GROUND,
                0,
                0);
            return point;
        }

        /// <summary>
        /// Get the type of an active scripting object from a generic runtime callable wrapper.
        /// </summary>
        /// <param name="wrapper">The com object wrapper</param>
        /// <returns>The managed type</returns>
        public static string GetTypeFromRcw(object wrapper)
        {
            string type = (string)wrapper.GetType().InvokeMember(
                "getType",
                System.Reflection.BindingFlags.InvokeMethod,
                null,
                wrapper,
                null);
            return type;
        }

        /// <summary>
        /// Look at the given coordinates
        /// </summary>
        /// <param name="ge">the plugin</param>
        /// <param name="latitude">latitude in decimal degrees</param>
        /// <param name="longitude">longitude in decimal degrees</param>
        public static void LookAt(IGEPlugin ge, double latitude, double longitude)
        {
            IKmlLookAt lookat = ge.createLookAt(String.Empty);
            lookat.set(
                latitude,
                longitude,
                100,
                ge.ALTITUDE_RELATIVE_TO_GROUND,
                0,
                0,
                1000);
            ge.getView().setAbstractView(lookat);
        }

        /// <summary>
        /// Look at the given feature
        /// </summary>
        /// <param name="ge">the plugin</param>
        /// <param name="feature">the feature to look at</param>
        public static void LookAt(IGEPlugin ge, IKmlFeature feature)
        {
            switch (feature.getType())
            {
                case "KmlFolder":
                case "KmlDocument":
                case "KmlNetworkLink":
                    if (feature.getAbstractView() != null)
                    {
                        ge.getView().setAbstractView(feature.getAbstractView());
                    }

                    break;
                case "KmlPlacemark":
                    if (feature.getAbstractView() != null)
                    {
                        ge.getView().setAbstractView(feature.getAbstractView());
                    }
                    else
                    {
                        IKmlPlacemark placemark = (IKmlPlacemark)feature;
                        LookAt(ge, placemark.getGeometry());
                    }

                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Look at the given geometry 
        /// </summary>
        /// <param name="ge">the plugin</param>
        /// <param name="geometry">the geomerty to look at</param>
        public static void LookAt(IGEPlugin ge, IKmlGeometry geometry)
        {
            if (null != ge && null != geometry)
            {
                switch (geometry.getType())
                {
                    case "KmlPoint":
                        LookAt(ge, (IKmlPoint)geometry);
                        break;
                    case "KmlPolygon":
                        IKmlPolygon polygon = (IKmlPolygon)geometry;
                        LookAt(
                            ge,
                            polygon.getOuterBoundary().getCoordinates().get(0).getLatitude(),
                            polygon.getOuterBoundary().getCoordinates().get(0).getLongitude());
                        break;
                    case "KmlLineString":
                        IKmlLineString lineString = (IKmlLineString)geometry;
                        LookAt(
                            ge,
                            lineString.getCoordinates().get(0).getLatitude(),
                            lineString.getCoordinates().get(0).getLongitude());
                        break;
                    case "KmlMultiGeometry":
                    ////IKmlMultiGeometry multiGeometry = (IKmlMultiGeometry)geometry;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Look at the given point
        /// </summary>
        /// <param name="ge">the plugin</param>
        /// <param name="point">the point to look at</param>
        public static void LookAt(IGEPlugin ge, IKmlPoint point)
        {
            LookAt(ge, point.getLatitude(), point.getLongitude());
        }

        /// <summary>
        /// Remove all features from the plugin 
        /// </summary>
        /// <param name="ge">The plugin instance</param>
        public static void RemoveAllFeatures(IGEPlugin ge)
        {
            IGEFeatureContainer features = ge.getFeatures();
            IKmlObject feature = features.getFirstChild();
            while (feature != null)
            {
                features.removeChild(feature);
            }
        }

        /// <summary>
        /// Remove the feature with the given id from the plugin
        /// </summary>
        /// <param name="ge">The plugin instance</param>
        /// <param name="id">The id of the element to remove</param>
        public static void RemoveFeatureById(IGEPlugin ge, string id)
        {
            while (Convert.ToBoolean(ge.getFeatures().hasChildNodes()))
            {
                if (ge.getFeatures().getFirstChild().getId() == id)
                {
                    ge.getFeatures().removeChild(ge.getFeatures().getFirstChild());
                }
            }
        }

        /// <summary>
        /// Displays the current plugin view in Google Maps using the default system browser
        /// </summary>
        /// <param name="ge">The plugin instance</param>
        public static void ShowCurrentViewInMaps(IGEPlugin ge)
        {
            // Get the current view 
            IKmlLookAt lookat = ge.getView().copyAsLookAt(ge.ALTITUDE_RELATIVE_TO_GROUND);
            double range = lookat.getRange();

            // calculate the equivelent zoom level from the given range
            double zoom = Math.Round(26 - (Math.Log(lookat.getRange()) / Math.Log(2)));

            // Google Maps have an integer "zoom level" which defines the resolution of the current view.
            // Zoom levels between 0 (entire world on map) to 21+ (down to individual buildings) are possible.
            if (zoom < 1)
            {
                zoom = 1;
            }
            else if (zoom > 21)
            {
                zoom = 21;
            }

            // Build the maps url
            StringBuilder url =
                new StringBuilder("http://maps.google.co.uk/maps?ll=");
            url.Append(lookat.getLatitude());
            url.Append(",");
            url.Append(lookat.getLongitude());
            url.Append("&z=");
            url.Append(zoom);

            // launch the default browser with the url
            System.Diagnostics.Process.Start(url.ToString());
        }
    }
}