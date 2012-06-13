
var markers = [];
var markerClusterer = null;
var usingClusterer = //<|USECLUSTERER|>;
var markerIndex = null;

function addMarker(item) {
    
    try{


        var t_marker = CatsToJsMarker(item);

        markers.push(t_marker);

        markerIndex += 1;

        t_marker.index = markerIndex;
    

         for (marker in getOverlayView(map).getPanes().overlayMouseTarget.getElementsByTagName("div")) {

    //        alert(marker.class);
    //       

                        if (marker.index == 1) {          
                            marker.setTitle('Te tengo!!!');
                        };

          };

    

        //refreshMarkers();
    } catch(err) {alert(err);};

};


function setUsingClusterer(value) {

    usingClusterer = value;
    refreshMarkers();

};


////--setClickable--
//function setMarkerClickable(index,value) {
//    
//    markers[index].setClickable(value);

//};




function refreshMarkers() {

    if (markerClusterer) {
        markerClusterer.clearMarkers();
    };

    if (usingClusterer == true) {        
        markerClusterer = new MarkerClusterer(map, markers);
    }
    else {
        var i
        for (i = 0; i <= markers.length; i++) {
            markers[i].setMap(map);
        };
    };

}

function deleteMarkers() {

    if (markerClusterer) {
        markerClusterer.clearMarkers();
    };

    if (markers) {
        for (i in markers) {
            markers[i].setMap(null);
        }
    };

    markers = new Array();
   
};


 

