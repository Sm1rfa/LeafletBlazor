using System.Collections.Generic;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace Blazor.Leaflet.OpenStreetMap.LeafletMap
{
    /// <summary>
    /// A rectangular geographical area on a map.
    /// <see href="https://leafletjs.com/reference-1.7.1.html#latlngbounds"/>
    /// </summary>
    public class LatLngBounds : InteropObject
    {
        public LatLngBounds()
        {
        }

        public LatLngBounds(LatLng southwest, LatLng northeast)
        {
            _southWest = southwest;
            _northEast = northeast;
        }

        public LatLng _southWest { get; set; }
        public LatLng _northEast { get; set; }

        public IEnumerable<LatLng> ToLatLng()
        {
            return new List<LatLng>() { _southWest, _northEast };
        }

        /// <inheritdoc/>
        protected override async Task<IJSObjectReference> CreateJsObjectRef()
        {
            return await JSBinder.JSRuntime.InvokeAsync<IJSObjectReference>("L.latLngBounds", _southWest.JSObjectReference, _northEast.JSObjectReference);
        }
    }
}