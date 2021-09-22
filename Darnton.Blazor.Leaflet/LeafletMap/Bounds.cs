using Microsoft.JSInterop;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blazor.Leaflet.OpenStreetMap.LeafletMap
{
    /// <summary>
    /// A rectangular area in pixel coordinates.
    /// </summary>
    public class Bounds : InteropObject
    {
        /// <summary>
        /// The top left corner of the bounds.
        /// </summary>
        [JsonPropertyName("min")]
        public Point Min { get; set; }
        /// <summary>
        /// The bottom right corner of the bounds.
        /// </summary>
        [JsonPropertyName("max")]
        public Point Max { get; set; }

        /// <summary>
        /// Constructs a Bounds instance.
        /// </summary>
        /// <param name="min">The top left corner of the bounds.</param>
        /// <param name="max">The bottom right corner of the bounds.</param>        
        public Bounds(Point min, Point max)
        {
            Min = min;
            Max = max;
        }

        /// <inheritdoc/>
        protected override async Task<IJSObjectReference> CreateJsObjectRef()
        {
            if (Min.JSBinder is null)
            {
                await Min.BindJsObjectReference(JSBinder);
            }
            Min.GuardAgainstNullBinding("Cannot create Bounds object. No JavaScript binding has been set up for the Min property.");
            if (Max.JSBinder is null)
            {
                await Max.BindJsObjectReference(JSBinder);
            }
            Max.GuardAgainstNullBinding("Cannot create Bounds object. No JavaScript binding has been set up for the Max property.");
            return await JSBinder.JSRuntime.InvokeAsync<IJSObjectReference>("L.bounds", Min.JSObjectReference, Max.JSObjectReference);
        }

        /// <inheritsdoc/>
        public override string ToString()
        {
            return $"[{Min}, {Max}]";
        }
    }
}