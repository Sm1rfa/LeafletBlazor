using Microsoft.JSInterop;
using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Blazor.Leaflet.OpenStreetMap.LeafletMap
{
    /// <summary>
    /// A clickable, draggable icon that can be added to a <see cref="Map"/>
    /// <see href="https://leafletjs.com/reference-1.7.1.html#marker"/>
    /// </summary>
    public class Marker : InteractiveLayer
    {
        /// <summary>
        /// The initial position of the marker.
        /// </summary>
        [JsonIgnore] public LatLng LatLng { get; private set; }
        /// <summary>
        /// The <see cref="MarkerOptions"/> used to create the marker.
        /// </summary>
        [JsonIgnore] public MarkerOptions Options { get; }

        /// <summary>
        /// Constructs a marker
        /// </summary>
        /// <param name="latlng">The initial position of the marker.</param>
        /// <param name="options">The <see cref="MarkerOptions"/> used to create the marker.</param>
        public Marker(LatLng latlng, MarkerOptions options)
        {
            LatLng = latlng;
            Options = options;
        }

        /// <summary>
        /// Changes the marker position to the given point.
        /// </summary>
        /// <param name="latlng">Coordinates of the new position of the marker.</param>
        public async Task SetLatLng(LatLng latlng)
        {
            GuardAgainstNullBinding("Cannot set marker position. No JavaScript binding has been set up.");
            var module = await JSBinder.GetLeafletMapModule();
            await module.InvokeVoidAsync("LeafletMap.Marker.setLatLng", latlng, JSObjectReference);
            LatLng = latlng;
        }

        /// <inheritdoc/>
        protected override async Task<IJSObjectReference> CreateJsObjectRef()
        {
            return await JSBinder.JSRuntime.InvokeAsync<IJSObjectReference>("L.marker", LatLng, Options);
        }
    }
}
