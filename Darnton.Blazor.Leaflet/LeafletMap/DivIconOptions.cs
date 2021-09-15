using System.Text.Json.Serialization;

namespace Blazor.Leaflet.OpenStreetMap.LeafletMap
{
    /// <summary>
    /// The options used when creating a <see cref="DivIcon"/>.
    /// </summary>
    public class DivIconOptions : IconOptions
    {
        /// <summary>
        /// Custom HTML code to put inside the div element, empty by default. Alternatively, an instance of HTMLElement.
        /// </summary>
        [JsonPropertyName("html")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string Html { get; set; }    

        /// <summary>
        /// Optional relative position of the background, in pixels
        /// </summary>
        [JsonPropertyName("bgPos")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public Point BackgroundPosition { get; set; }

    }
}