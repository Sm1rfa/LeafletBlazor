using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Blazor.Leaflet.OpenStreetMap
{
    internal class LeafletMapJSBinder : IAsyncDisposable
    {
        internal IJSRuntime JSRuntime;
        private Task<IJSObjectReference> _leafletMapModule;

        public LeafletMapJSBinder(IJSRuntime jsRuntime)
        {
            JSRuntime = jsRuntime;
        }

        internal async Task<IJSObjectReference> GetLeafletMapModule()
        {
            return await (_leafletMapModule ??= JSRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Blazor.Leaflet.OpenStreetMap/js/leaflet-map.js").AsTask());
        }

        /// <inheritdoc/>
        public async ValueTask DisposeAsync()
        {
            if (_leafletMapModule != null)
            {
                var mapModule = await _leafletMapModule;
                await mapModule.DisposeAsync();
            }
        }
    }
}
