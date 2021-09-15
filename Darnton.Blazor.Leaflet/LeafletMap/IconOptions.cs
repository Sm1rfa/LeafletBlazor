using System.Text.Json.Serialization;

namespace Blazor.Leaflet.OpenStreetMap.LeafletMap
{

    /// <summary>
    /// The options used when creating a <see cref="Icon"/>.
    /// </summary>
    public class IconOptions
    {
        /// <summary>
        /// (required) The URL to the icon image (absolute or relative to your script path).
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("iconUrl")]
        public string IconUrl { get; set; }

        /// <summary>
        /// The URL to a retina sized version of the icon image (absolute or relative to your script path). Used for Retina screen devices.
        /// </summary>
        [JsonPropertyName("iconRetinaUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string IconRetinaUrl { get; set; }

        /// <summary>
        /// Size of the icon image in pixels.
        /// </summary>
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [JsonPropertyName("iconSize")]
        public Point IconSize { get; set; }

        /// <summary>
        /// The coordinates of the "tip" of the icon (relative to its top left corner). The icon will be aligned so that this point is at the marker's geographical location. Centered by default if size is specified, also can be set in CSS with negative margins.
        /// </summary>
        [JsonPropertyName("iconAnchor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Point IconAnchor { get; set; } = new Point(0,0);

        /// <summary>
        /// The coordinates of the point from which popups will "open", relative to the icon anchor.
        /// </summary>
        [JsonPropertyName("popupAnchor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Point PopupAnchor { get; set; } = new Point(0, 0);

        /// <summary>
        /// The coordinates of the point from which tooltips will "open", relative to the icon anchor.
        /// </summary>
        [JsonPropertyName("tooltipAnchor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Point TooltipAnchor { get; set; } = new Point(0, 0);

        /// <summary>
        /// The URL to the icon shadow image. If not specified, no shadow image will be created.
        /// </summary>

        [JsonPropertyName("shadowUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ShadowUrl { get; set; }

        /// <summary>
        /// The URL to the retina sized version of the icon shadow image. If not specified, no shadow image will be created.
        /// </summary>
        [JsonPropertyName("shadowRetinaUrl")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ShadowRetinaUrl { get; set; }

        /// <summary>
        /// Size of the shadow image in pixels.
        /// </summary>
        [JsonPropertyName("shadowSize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Point ShadowSize { get; set; }

        /// <summary>
        /// The coordinates of the "tip" of the shadow (relative to its top left corner) (the same as iconAnchor if not specified).
        /// </summary>
        [JsonPropertyName("shadowAnchor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Point ShadowAnchor { get; set; }

        /// <summary>
        /// A custom class name to assign to both icon and shadow images. Empty by default.
        /// </summary>
        [JsonPropertyName("className")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string ClassName { get; set; } = "";
    }
}