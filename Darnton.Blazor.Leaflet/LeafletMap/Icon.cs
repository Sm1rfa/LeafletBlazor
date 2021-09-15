using Microsoft.JSInterop;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System;

namespace Blazor.Leaflet.OpenStreetMap.LeafletMap
{    
 ///<summary>
    /// Represents an icon to provide when creating a marker.
    ///</summary>
    public class Icon : InteropObject
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
        //// <param name="elementId">The ID of the HTML element the Icon will be rendered in.</param>
        /// <param name="options">The <see cref="IconOptions"/> used to create the Icon.</param>
        public Icon(IconOptions options)
        {
            //ElementId = elementId;
            Options = options;
        }

        /// <inheritdoc/>
        protected override async Task<IJSObjectReference> CreateJsObjectRef()
        {
            Console.WriteLine("##################################");
            var result = await JSBinder.JSRuntime.InvokeAsync<IJSObjectReference>("L.icon", Options);
           
            Console.WriteLine(result);
            Console.WriteLine("************************************");
            return result;
        }        

        // public object CreateIcon(object obj)
        // {
        //     return await JSBinder.JSRuntime.InvokeAsync<object>("L.createIcon", obj);
        // }
    }
}
