
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blazor.Leaflet.OpenStreetMap.LeafletMap
{
    /// <summary>
    /// Represents a lightweight icon for markers that uses a simple div element instead of an image. Inherits from Icon but ignores the iconUrl and shadow options.
    /// </summary>
    public class DivIcon : Icon
    {
        /// <summary>
        /// Constructs a DivIcon.
        /// </summary>        
        /// <param name="options">The <see cref="DivIconOptions"/> used to create the DivIcon.</param>
        public DivIcon(DivIconOptions options)
            : base(options)
        {             
        }

        /// <inheritdoc/>
        protected override async Task<IJSObjectReference> CreateJsObjectRef()
        {
            return await JSBinder.JSRuntime.InvokeAsync<IJSObjectReference>("L.divIcon", Options);
        }
    }
}