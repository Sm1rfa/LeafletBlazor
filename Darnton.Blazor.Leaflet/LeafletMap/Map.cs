using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Blazor.Leaflet.OpenStreetMap.LeafletMap
{
    /// <summary>
    /// A leaflet Map object, used to create a Map on a page.
    /// <see href="https://leafletjs.com/reference-1.7.1.html#map-methods-for-getting-map-state"/>
    /// and <see href="https://leafletjs.com/reference-1.7.1.html#map-methods-for-modifying-map-state"/>.
    /// </summary>
    public class Map : InteropObject
    {
        private bool subscribedToEvents = false;
        private DotNetObjectReference<Map> objectReference;

        /// <summary>
        /// Fired when the center of the map stops changing (e.g. user stopped dragging the map).
        /// </summary>
        public event EventHandler OnMoveEnd;

        /// <summary>
        /// Fired when the user clicks (or taps) the map.
        /// </summary>
        public EventHandler<LeafletMouseEventArgs> OnClick;

        /// <summary>
        /// Fired when the user double-clicks (or double-taps) the map.
        /// </summary>
        public EventHandler<LeafletMouseEventArgs> OnDoubleClick;

        /// <summary>
        /// Fired when the user pushes the mouse button on the map.
        /// </summary>
        public EventHandler<LeafletMouseEventArgs> OnMouseDown;

        /// <summary>
        /// Fired when the user releases the mouse button on the map.
        /// </summary>
        public EventHandler<LeafletMouseEventArgs> OnMouseUp;

        /// <summary>
        /// Fired when the mouse enters the map.
        /// </summary>
        public EventHandler<LeafletMouseEventArgs> OnMouseOver;

        /// <summary>
        /// Fired when the mouse leaves the map.
        /// </summary>
        public EventHandler<LeafletMouseEventArgs> OnMouseOut;

        /// <summary>
        /// Fired while the mouse moves over the map.
        /// </summary>
        public EventHandler<LeafletMouseEventArgs> OnMouseMove;

        /// <summary>
        /// Fired when the user pushes the right mouse button on the map, prevents default browser context menu from showing if there are listeners on this event. Also fired on mobile when the user holds a single touch for a second (also called long press).
        /// </summary>
        public EventHandler<LeafletMouseEventArgs> OnContextMenu;

        /// <summary>
        /// Fired before mouse click on the map (sometimes useful when you want something to happen on click before any existing click handlers start running).
        /// </summary>
        public EventHandler<LeafletMouseEventArgs> OnPreClick;


        /// <summary>
        /// The ID of the HTML element the map will be rendered in.
        /// </summary>
        public string ElementId { get; }
        /// <summary>
        /// The <see cref="MapOptions"/> used to create the Map.
        /// </summary>
        public MapOptions Options { get; }

        /// <summary>
        /// Constructs a Map.
        /// </summary>
        /// <param name="elementId">The ID of the HTML element the map will be rendered in.</param>
        /// <param name="options">The <see cref="MapOptions"/> used to create the Map.</param>
        public Map(string elementId, MapOptions options)
        {
            ElementId = elementId;
            Options = options;            
        }

        /// <inheritdoc/>
        protected override async Task<IJSObjectReference> CreateJsObjectRef()
        {
            return await JSBinder.JSRuntime.InvokeAsync<IJSObjectReference>("L.map", ElementId, Options);
        }

        #region Get map state
        /// <summary>
        /// Gets the point at the centre of the map view.
        /// </summary>
        /// <returns>A <see cref="LatLng"/> representing the geographical centre of the map.</returns>
        public async Task<LatLng> GetCenter()
        {
            return await JSObjectReference.InvokeAsync<LatLng>("getCenter");
        }

        /// <summary>
        /// Gets the geographical bounds of the map view.
        /// </summary>
        /// <returns>A <see cref="LatLngBounds"/> object representing the geographical bounds of the map.</returns>
        public async Task<LatLngBounds> GetBounds()
        {
            return await JSObjectReference.InvokeAsync<LatLngBounds>("getBounds");
        }

        /// <summary>
        /// Gets the zoom level of the map view.
        /// </summary>
        /// <returns>The zoom level.</returns>
        public async Task<int> GetZoom()
        {
            return await JSObjectReference.InvokeAsync<int>("getZoom");
        }

        /// <summary>
        /// Gets the minimum zoom level of the map view.
        /// </summary>
        /// <returns>The minimum zoom level.</returns>
        public async Task<int> GetMinZoom()
        {
            return await JSObjectReference.InvokeAsync<int>("getMinZoom");
        }

        /// <summary>
        /// Gets the maximum zoom level of the map view.
        /// </summary>
        /// <returns>The maximum zoom level.</returns>
        public async Task<int> GetMaxZoom()
        {
            return await JSObjectReference.InvokeAsync<int>("getMaxZoom");
        }

        /// <summary>
        /// Gets the maximum zoom level on which the bounds fit the map view.
        /// </summary>
        /// <param name="bounds">The <see cref="LatLngBounds"/> to fit to the map.</param>
        /// <param name="inside">A flag indicating the fit direction. If true, method returns minimum zoom level
        /// on which the map fits into the bounds.</param>
        /// <param name="padding">The padding in pixels.</param>
        /// <returns></returns>
        public async Task<int> GetBoundsZoom(LatLngBounds bounds, bool inside = false, Point padding = null)
        {
            if (bounds.JSBinder is null)
            {
                await bounds.BindJsObjectReference(JSBinder);
            }
            bounds.GuardAgainstNullBinding("Cannot get bounds zoom. No JavaScript binding has been set up for the bounds parameter.");
            if (padding is not null)
            {
                if (padding.JSBinder is null)
                {
                    await padding.BindJsObjectReference(JSBinder);
                }
                padding.GuardAgainstNullBinding("Cannot get bounds zoom. No JavaScript binding has been set up for the padding parameter.");
            }
            return await JSObjectReference.InvokeAsync<int>("getBoundsZoom", bounds.JSObjectReference, inside, padding?.JSObjectReference);
        }

        /// <summary>
        /// Gets the size of the map container in pixels.
        /// </summary>
        /// <returns>A <see cref="Point"/> representing the size of the map container in pixels.</returns>
        public async Task<Point> GetSize()
        {
            return await JSObjectReference.InvokeAsync<Point>("getSize");
        }

        /// <summary>
        /// Gets the bounds of the map view in projected pixel coordinates.
        /// </summary>
        /// <returns>A <see cref="Bounds"/> representing the size of the map container in pixels.</returns>
        public async Task<Bounds> GetPixelBounds()
        {
            return await JSObjectReference.InvokeAsync<Bounds>("getPixelBounds");
        }

        /// <summary>
        /// Gets the projected pixel coordinates of the top left point of the map layer.
        /// </summary>
        /// <returns>A <see cref="Point"/> representing top left point of the map in pixels.</returns>
        public async Task<Point> GetPixelOrigin()
        {
            return await JSObjectReference.InvokeAsync<Point>("getPixelOrigin");
        }

        /// <summary>
        /// Gets the world's bounds in pixel coordinates.
        /// </summary>
        /// <param name="zoom">The zoom level used to calculate the bounds. Current map zoom level is used if null or omitted.</param>
        /// <returns>A <see cref="Bounds"/> representing the size of the map container in pixels.</returns>
        public async Task<Bounds> GetPixelWorldBounds(int? zoom = null)
        {
            return await JSObjectReference.InvokeAsync<Bounds>("getPixelWorldBounds", zoom);
        }
        #endregion

        #region Set map state
        /// <summary>
        /// Sets the view of the map with the given centre and zoom.
        /// </summary>
        /// <param name="center">A <see cref="LatLng"/> representing the geogrpahical centre of the map.</param>
        /// <param name="zoom">The zoom level of the map.</param>
        /// <returns>The Map.</returns>
        public async Task<Map> SetView(LatLng center, int zoom)
        {
            if (center.JSBinder is null)
            {
                await center.BindJsObjectReference(JSBinder);
            }
            center.GuardAgainstNullBinding("Cannot set map view. No JavaScript binding has been set up for the center argument.");
            var module = await JSBinder.GetLeafletMapModule();
            await module.InvokeVoidAsync("LeafletMap.Map.setView", JSObjectReference, center.JSObjectReference, zoom);
            return this;
        }

        #endregion

        /// <summary>
        /// Subscribe to an event of the leaflet map
        /// <param name="eventName">Name of the leaflet map event to subscribe to</param>
        /// <param name="handlerName">Name of the dotnet method to be called when the event is raised</param>
        /// </summary>
        private async Task SubscribeToEvent(string eventName, string handlerName)
        {
            objectReference = objectReference ?? DotNetObjectReference.Create(this);
            var module = await JSBinder.GetLeafletMapModule();
            await module.InvokeVoidAsync("LeafletMap.Map.subscribeToEvent", JSObjectReference, objectReference, eventName, handlerName);            
        }

        private async Task SubscribeToMouseEvent(string eventName, string handlerName)
        {
            objectReference = objectReference ?? DotNetObjectReference.Create(this);
            var module = await JSBinder.GetLeafletMapModule();
            await module.InvokeVoidAsync("LeafletMap.Map.subscribeToMouseEvent", JSObjectReference, objectReference, eventName, handlerName);            
        }

        /// <summary>
        /// Subscribe to the map events. Unless this is called the map will not raise events.
        /// </summary>
        public async Task SubscribeToEvents()
        {
            if (!subscribedToEvents)
            {
                Console.WriteLine("Subscribing to events");
                await SubscribeToEvent("moveend", nameof(InvokeOnMoveEnd));                    
                await SubscribeToMouseEvent("click", nameof(InvokeOnClick)); 
                await SubscribeToMouseEvent("dblclick", nameof(InvokeOnDoubleClick));
                await SubscribeToMouseEvent("mousedown", nameof(InvokeOnMouseDown));
                await SubscribeToMouseEvent("mouseup", nameof(InvokeOnMouseUp));
                await SubscribeToMouseEvent("mouseover", nameof(InvokeOnMouseOver));
                await SubscribeToMouseEvent("mouseout", nameof(InvokeOnMouseOut));
                await SubscribeToMouseEvent("mousemove", nameof(InvokeOnMouseMove));
                await SubscribeToMouseEvent("contextmenu", nameof(InvokeOnContextMenu));
                
                //This one causes a DOM Exception:
                //await SubscribeToMouseEvent("preclick", nameof(InvokeOnPreClick));

                subscribedToEvents = true;
            }
        }

        ///<summary>
        /// This method is public for Javascript interop, do not invoke manally
        ///</summary>
        [JSInvokable]
        public void InvokeOnMoveEnd() => OnMoveEnd?.Invoke(this, new EventArgs());       

        ///<summary>
        /// This method is public for Javascript interop, do not invoke manally
        ///</summary>
        [JSInvokable]
        public void InvokeOnClick(LeafletMouseEventArgs args) => OnClick?.Invoke(this, args);

        ///<summary>
        /// This method is public for Javascript interop, do not invoke manally
        ///</summary>
        [JSInvokable]
        public void InvokeOnDoubleClick(LeafletMouseEventArgs args) => OnDoubleClick?.Invoke(this, args);

        ///<summary>
        /// This method is public for Javascript interop, do not invoke manally
        ///</summary>
        [JSInvokable]
        public void InvokeOnMouseDown(LeafletMouseEventArgs args) => OnMouseDown?.Invoke(this, args);

        ///<summary>
        /// This method is public for Javascript interop, do not invoke manally
        ///</summary>
        [JSInvokable]
        public void InvokeOnMouseUp(LeafletMouseEventArgs args) => OnMouseUp?.Invoke(this, args);

        ///<summary>
        /// This method is public for Javascript interop, do not invoke manally
        ///</summary>
        [JSInvokable]
        public void InvokeOnMouseOver(LeafletMouseEventArgs args) => OnMouseOver?.Invoke(this, args);

        ///<summary>
        /// This method is public for Javascript interop, do not invoke manally
        ///</summary>
        [JSInvokable]
        public void InvokeOnMouseOut(LeafletMouseEventArgs args) => OnMouseOut?.Invoke(this, args);

        ///<summary>
        /// This method is public for Javascript interop, do not invoke manally
        ///</summary>
        [JSInvokable]
        public void InvokeOnMouseMove(LeafletMouseEventArgs args) => OnMouseMove?.Invoke(this, args);

        ///<summary>
        /// This method is public for Javascript interop, do not invoke manally
        ///</summary>
        [JSInvokable]
        public void InvokeOnContextMenu(LeafletMouseEventArgs args) => OnContextMenu?.Invoke(this, args);

        ///<summary>
        /// This method is public for Javascript interop, do not invoke manally
        ///</summary>
        [JSInvokable]
        public void InvokeOnPreClick(LeafletMouseEventArgs args) => OnPreClick?.Invoke(this, args);

        /// <summary>
        /// Dispose
        /// </summary>
        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            objectReference?.Dispose();
        }
    }
}
