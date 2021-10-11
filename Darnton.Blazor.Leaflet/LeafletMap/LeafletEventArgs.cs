using System;

namespace Blazor.Leaflet.OpenStreetMap.LeafletMap
{
    /// <summary>
    /// The base leaflet event object. All other leaflet event objects contain these properties too.
    /// </summary>
    public class LeafletEventArgs : EventArgs
    {
        /// <summary>
        /// The event type (e.g. 'click').
        /// </summary>
        public string Type { get; set; }   
    }
}