using Blazor.Leaflet.OpenStreetMap.LeafletMap;
using LeafletBlazorTestRig.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace LeafletBlazorTestRig.Pages
{
    public class IndexBase : ComponentBase, IAsyncDisposable
    {
        protected Map PositionMap;
        protected TileLayer OpenStreetMapsTileLayer;
        protected MapStateViewModel MapStateViewModel;
        protected MarkerViewModel MarkerViewModel;


        public IndexBase() : base()
        {
            var mapCentre = new LatLng(-42, 175); // Centred on New Zealand
            MapStateViewModel = new MapStateViewModel
            {
                MapCentreLatitude = mapCentre.Lat,
                MapCentreLongitude = mapCentre.Lng,
                Zoom = 4
            };
            PositionMap = new Map("testMap", new MapOptions
            {
                Center = mapCentre,
                Zoom = MapStateViewModel.Zoom
            });
            OpenStreetMapsTileLayer = new TileLayer(
                "https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
                new TileLayerOptions
                {
                    Attribution = @"Map data &copy; <a href=""https://www.openstreetmap.org/"">OpenStreetMap</a> contributors, " +
                        @"<a href=""https://creativecommons.org/licenses/by-sa/2.0/"">CC-BY-SA</a>"
                }
            );

            MarkerViewModel = new MarkerViewModel();

        }

        protected async void GetMapState()
        {
            var mapCentre = await PositionMap.GetCenter();
            MapStateViewModel.MapCentreLatitude = mapCentre.Lat;
            MapStateViewModel.MapCentreLongitude = mapCentre.Lng;
            MapStateViewModel.Zoom = await PositionMap.GetZoom();
            MapStateViewModel.MapContainerSize = await PositionMap.GetSize();
            MapStateViewModel.MapViewPixelBounds = await PositionMap.GetPixelBounds();
            MapStateViewModel.MapLayerPixelOrigin = await PositionMap.GetPixelOrigin();
            StateHasChanged();
        }

        protected async void SetMapState()
        {
            var mapCentre = new LatLng(MapStateViewModel.MapCentreLatitude, MapStateViewModel.MapCentreLongitude);
            await PositionMap.SetView(mapCentre, MapStateViewModel.Zoom);
        }

        protected async void AddMarkerAtMapCenter()
        {
            var mapCentre = await PositionMap.GetCenter();
            
            var icon = new Icon(new IconOptions()
            {
                IconUrl = "logo.png",
                IconSize = new Point(32, 32)
            });
            await icon.AddTo(PositionMap);

            var marker = new Marker(mapCentre, new MarkerOptions
            {                
                Icon = icon,
                Keyboard = MarkerViewModel.Keyboard,
                Title = MarkerViewModel.Title,
                Alt = MarkerViewModel.Alt,
                ZIndexOffset = MarkerViewModel.ZIndexOffset,
                Opacity = MarkerViewModel.Opacity,
                RiseOnHover = MarkerViewModel.RiseOnHover,
                RiseOffset = MarkerViewModel.RiseOffset,
            });
            await marker.AddTo(PositionMap);
        }

        public async ValueTask DisposeAsync()
        {
            await OpenStreetMapsTileLayer.DisposeAsync();
            await PositionMap.DisposeAsync();
        }
    }
}
