﻿// <copyright file="KmlTreeViewNode.cs" company="FC">
// Copyright (c) 2011 Fraser Chapman
// </copyright>
// <author>Fraser Chapman</author>
// <email>fraser.chapman@gmail.com</email>
// <date>2011-03-06</date>
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
// </summary>namespace FC.GEPluginCtrls.Enumerations
namespace FC.GEPluginCtrls
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using Microsoft.CSharp.RuntimeBinder;

    /// <summary>
    /// Custom node class for the <see cref="KmlTreeView"/>
    /// </summary>
    [SerializableAttribute]
    public sealed class KmlTreeViewNode : TreeNode
    {
        /// <summary>
        /// Initializes a new instance of the KmlTreeViewNode class.
        /// </summary>
        internal KmlTreeViewNode()
            : base()
        {
            this.ApiObject = null;
            this.ApiType = ApiType.None;
            this.ImageKey = this.SelectedImageKey = "linkFolderClosed_0";
            this.Name = ApiType.None.ToString();
            this.StateImageIndex = 0;
            this.Text = "Loading...";
        }

        /// <summary>
        /// Initializes a new instance of the KmlTreeViewNode class.
        /// </summary>
        /// <param name="kmlObject">A kml object to base the treenode on</param>
        internal KmlTreeViewNode(dynamic kmlObject)
            : base()
        {
            this.ApiObject = kmlObject;
            try
            {
                // The 'Name' of a TreeNode is also the 'Key'
                // If the node does not have a name, 'Name' and 'Key' return an empty string
                // It makes sense to bind the 'Name' to the 'id' of the underlying kml object.
                // Api 'id's' are unique and this means that the 'Keys' should be unique within the tree.
                this.Name = kmlObject.getId();
                this.ApiType = GEHelpers.GetApiType(kmlObject);
                this.Text = kmlObject.getName();
                this.ApiObjectVisible = Convert.ToBoolean(kmlObject.getVisibility());
                this.StateImageIndex = this.ApiObjectVisible ? 1 : 0;
                this.Checked = this.ApiObjectVisible;
            }
            catch (RuntimeBinderException)
            {
            }

            this.SetStyle();
        }

        #region Public Properties 

        /// <summary>
        /// Gets or sets the value of the node tool tip text.
        /// </summary>
        public new string ToolTipText
        {
            get { return base.ToolTipText; }
            set { base.ToolTipText = TidyToolTip(value); }
        }
        
        /// <summary>
        /// Gets the underlying kml object that the node represents.
        /// </summary>
        public dynamic ApiObject { get; private set; }

        /// <summary>
        /// Gets a value indicating the api type (e.g. KmlPlacemark, KmlDocument)
        /// of the underlying <see cref="ApiObject">feature</see> the node represents.
        /// </summary>
        public ApiType ApiType { get; private set; }

        #endregion

        #region Internal Properties

        /// <summary>
        /// Gets or sets a value indicating whether networklink content has been fetched.
        /// </summary>
        internal bool Fetched { get; set; }

        /// <summary>
        /// Gets a value indicating whether networklink content is loading.
        /// </summary>
        internal bool IsLoading { get; private set; }

        /// <summary>
        /// Gets the url of the underlying kml object.
        /// </summary>
        /// <remarks>
        /// The url is obtained via kmlHelpers which adds support for legacy kml spcifications.
        /// </remarks>
        internal string KmlUrl
        {
            get
            {
                if (this.ApiObject != null)
                {
                    return KmlHelpers.GetUrl(this.ApiObject);
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Gets the list style of the underlying kml object. Default is ListItemStyle.Check
        /// </summary>
        internal ListItemStyle KmlListStyle
        {
            get
            {
                if (this.ApiObject != null)
                {
                    return KmlHelpers.GetListItemType(this.ApiObject);
                }
                else
                {
                    return ListItemStyle.Check;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the node is cheked and the kml object is visible
        /// </summary>
        internal bool ApiObjectVisible
        {
            get
            {
                try
                {
                    return Convert.ToBoolean(this.ApiObject.getVisibility());
                }
                catch (COMException)
                {
                    ////Debug.WriteLine("ApiObjectVisible: " + cex.Message, "KmlTreeViewNode");
                    return false;
                }
            }

            set
            {
                try
                {
                    this.ApiObject.setVisibility(Convert.ToUInt16(value));
                }
                catch (COMException)
                {
                }
            }
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Sets the icon style for the node
        /// </summary>
        internal void SetStyle()
        {
            switch (this.ApiType)
            {
                case ApiType.KmlDocument:
                case ApiType.KmlFolder:
                    {
                        if (this.IsExpanded)
                        {
                            this.ImageKey = "folderOpen";
                            this.SelectedImageKey = "folderOpen";
                        }
                        else
                        {
                            this.ImageKey = "folderClosed";
                            this.SelectedImageKey = "folderClosed";
                        }
                    }

                    break;

                case ApiType.KmlNetworkLink:
                    {
                        if (this.IsExpanded)
                        {
                            this.ImageKey = "linkFolderOpen";
                            this.SelectedImageKey = "linkFolderOpen";
                        }
                        else
                        {
                            this.ImageKey = "linkFolderClosed";
                            this.SelectedImageKey = "linkFolderClosed";
                        }
                    }

                    break;

                case ApiType.KmlPlacemark:
                    {
                        this.ImageKey = "flag";
                        this.SelectedImageKey = "flag";
                    }

                    break;

                case ApiType.KmlGroundOverlay:
                case ApiType.KmlScreenOverlay:
                    {
                        this.ImageKey = "overlay";
                        this.SelectedImageKey = "overlay";
                    }

                    break;

                case ApiType.KmlPhotoOverlay:
                    {
                        this.ImageKey = "photo";
                        this.SelectedImageKey = "photo";
                    }

                    break;

                case ApiType.KmlTour:
                    {
                        this.ImageKey = "tour";
                        this.SelectedImageKey = "tour";
                    }

                    break;

                case ApiType.KmlLayer:
                    {
                        this.ImageKey = "tour";
                        this.SelectedImageKey = "tour";
                    }

                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Animates the icon style for the node.
        /// </summary>
        internal void Animate()
        {
            this.IsLoading = true;

            Timer t = new Timer();
            t.Interval = 500;
            t.Enabled = true;
            int i = 2;

            t.Tick += (o, e) =>
            {
                if (i >= 0)
                {
                    this.ImageKey = "linkFolderClosed_" + i;
                    this.SelectedImageKey = "linkFolderClosed_" + i;
                    i -= 1;
                }
                else
                {
                    i = 2;
                    this.ImageKey = "linkFolderClosed_" + i;
                    this.SelectedImageKey = "linkFolderClosed_" + i;
                }
            };
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Clean any html and add linebreaks for use with tooltips.
        /// TODO : make this a lot better....
        /// </summary>
        /// <param name="source">a html string</param>
        /// <returns>plain text with linebreaks</returns>
        private static string TidyToolTip(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];

                if (let == '<')
                {
                    inside = true;
                    continue;
                }

                if (let == '>')
                {
                    inside = false;
                    continue;
                }

                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }

            return new string(array, 0, arrayIndex);
        }

        #endregion
    }
}