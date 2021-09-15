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
        public IconOptions Options {get;}

        /// <summary>
        /// Constructs an Icon.
        /// </summary>        
        /// <param name="options">The <see cref="IconOptions"/> used to create the Icon.</param>
        public Icon(IconOptions options)
        {            
            Options = options;            
            
        }

        /// <inheritdoc/>
        protected override async Task<IJSObjectReference> CreateJsObjectRef()
        {            
            return await JSBinder.JSRuntime.InvokeAsync<IJSObjectReference>("L.icon", Options);
        }        

    }
}
