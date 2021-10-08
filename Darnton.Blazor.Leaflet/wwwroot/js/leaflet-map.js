export let LeafletMap = {

    Map: {

        setView: function (map, center, zoom) {
            map.setView(center, zoom);
        },

        subscribeToEvent(map, dotNetReference, eventName, handlerName) {            
            map.on(eventName, function(e) {                
                dotNetReference.invokeMethodAsync(handlerName);
            });
        }   

    },

    Layer: {

        addTo: function (layer, map) {
            layer.addTo(map);
        },

        remove: function (layer) {
            layer.remove();
        }

    },

    Polyline: {

        addLatLng: function (polyline, latlng, latlngs) {
            polyline.addLatLng(latlng, latlngs);
        }

    },

    Marker: {
        setIcon(icon, marker) {
            marker.setIcon(icon);
        }
    },

}