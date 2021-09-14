using System.Text.Json.Serialization;

namespace Blazor.Leaflet.OpenStreetMap.LeafletMap
{
    /// <summary>
    /// The options used when creating a <see cref="Marker"/>.
    /// </summary>
    public class MarkerOptions
    {
        /// <summary>
        /// Icon instance to use for rendering the marker. See Icon documentation for details on how to customize the marker icon. If not specified, a common instance of L.Icon.Default is used.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Icon Icon { get; set; }  

        /// <summary>
        /// Whether the marker can be tabbed to with a keyboard and clicked by pressing enter.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? Keyboard { get; set; }

        /// <summary>
        /// Text for the browser tooltip that appear on marker hover (no tooltip by default).
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Text for the alt attribute of the icon image (useful for accessibility).
        /// </summary>
        public string Alt { get; set; }

        /// <summary>
        /// By default, marker images zIndex is set automatically based on its latitude. Use this option if you want to
        /// put the marker on top of all others (or below), specifying a high value like 1000 (or high negative value, respectively)
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int? ZIndexOffset { get; set; }

        /// <summary>
        /// The opacity of the marker.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public double? Opacity { get; set; }

        /// <summary>
        /// If true, the marker will get on top of others when you hover the mouse over it.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? RiseOnHover { get; set; } = true;

        /// <summary>
        /// The z-index offset used for the riseOnHover feature.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int? RiseOffset { get; set; }

        /// <summary>
        /// Map pane where the markers icon will be added.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Pane { get; set; }

        /// <summary>
        /// Map pane where the markers shadow will be added.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ShadowPane { get; set; }

        /// <summary>
        /// When true, a mouse event on this marker will trigger the same event on the map
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public bool? BubblingMouseEvents { get; set; }
    }
}