using System.Text.Json.Serialization;

namespace Blazor.Leaflet.OpenStreetMap.LeafletMap
{
    /// <summary>
    /// The options used when creating a <see cref="Map"/>.
    /// </summary>
    public class MapOptions
    {
        /// <summary>
        /// The initial centre point of the <see cref="Map"/>.
        /// </summary>
        [JsonPropertyName("center")]
        public LatLng Center { get; set; }
        /// <summary>
        /// The initial zoom level of the <see cref="Map"/>.
        /// </summary>
        [JsonPropertyName("zoom")]
        public int Zoom { get; set; }
    }
}
