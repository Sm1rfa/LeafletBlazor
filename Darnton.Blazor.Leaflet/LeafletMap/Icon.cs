using Microsoft.JSInterop;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Components;

namespace Blazor.Leaflet.OpenStreetMap.LeafletMap
{
    ///<summary>
    /// Represents an icon to provide when creating a marker.
    ///</summary>
    public class Icon : InteractiveLayer
    {
        // /// <summary>
        // /// The ID of the HTML element the icon will be rendered in.
        // /// </summary>
        // public string ElementId { get; }

        /// <summary>
        /// The <see cref="IconOptions"/> used to create the Icon.
        /// </summary>
        [JsonPropertyName("options")]
        public IconOptions Options { get; protected set; }

        /// <summary>
        /// Constructs an Icon.
        /// </summary>        
        /// <param name="options">The <see cref="IconOptions"/> used to create the Icon.</param>
        public Icon(IconOptions options)
        {
            Options = options;

        }

        /// <summary>
        /// <param name="marker">The <see cref="Marker"/> to which to add the Icon.</param>        
        /// </summary>
        public async Task<Layer> AddTo(Marker marker)
        {
            if (JSBinder is null)
            {
                await BindJsObjectReference(marker.JSBinder);
            }
            GuardAgainstNullBinding("Cannot add layer to map. No JavaScript binding has been set up.");
            var module = await JSBinder.GetLeafletMapModule();
            await module.InvokeVoidAsync("LeafletMap.Marker.setIcon", JSObjectReference, marker.JSObjectReference);

            return this;
        }
        
        /// <inheritdoc/>
        protected override async Task<IJSObjectReference> CreateJsObjectRef()
        {
            return await JSBinder.JSRuntime.InvokeAsync<IJSObjectReference>("L.icon", Options);
        }
    }
}
