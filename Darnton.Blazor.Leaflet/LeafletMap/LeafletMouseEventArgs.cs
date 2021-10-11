using System;

namespace Blazor.Leaflet.OpenStreetMap.LeafletMap
{
    /// <summary>
    /// Represents a mouse interaction event
    /// </summary>
    public class LeafletMouseEventArgs : LeafletEventArgs
    {
        /// <summary>
        /// The geographical point where the mouse event occurred.
        /// </summary>
        public LatLng LatLng { get; set; }

        /// <summary>
        /// Pixel coordinates of the point where the mouse event occurred relative to the map layer.
        /// </summary>
        public Point LayerPoint { get; set; }

        /// <summary>
        /// Pixel coordinates of the point where the mouse event occurred relative to the map сontainer.
        /// </summary>
        public Point ContainerPoint { get; set; }

        /// <summary>
        ///	The original DOM MouseEvent or DOM TouchEvent that triggered this Leaflet event.
        /// </summary>
        public object OriginalEvent {get; set;}
    }
}