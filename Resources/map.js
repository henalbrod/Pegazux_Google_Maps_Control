
// MAP PROPERTIES

var map = null;
var map_canvas = null;
                        
var mouseLocation = null;
var bounds = null;

var backgroundColor = "<|BACK_COLOR|>";
var center = new google.maps.LatLng(11, -74);
var disableDefaultUI = true;
var disableDoubleClickZoom = false;
var draggable = false;
var draggableCursor = null;
var draggingCursor = null;
var keyboardShortcuts = true;
var mapTypeControl = false;
var mapTypeControlOptions = null;
var mapTypeId = google.maps.MapTypeId.ROADMAP;
var navigationControl = false;
var navigationControlOptions = null;
var noClear = false;
var scaleControl = false;
var scaleControlOptions = null;
var scrollwheel = true;
var streetView = null;
var streetViewControl = false;
var zoom = 8;



$(document).ready(function () {

    initialize();

    window.external.OnReady();

});



// INITIALIZE MAP
function initialize() {
    
    // Add index property to markers
    extend({ Index: 0 }, google.maps.Marker);
    markerIndex = 0;

    map_canvas = document.getElementById("map_canvas");

    map = new google.maps.Map(map_canvas, {
        backgroundColor: backgroundColor,
        center: center,
        disableDefaultUI: disableDefaultUI,
        draggable: draggable,
        draggableCursor:draggableCursor,
        keyboardShortcuts: keyboardShortcuts,
        mapTypeControl: mapTypeControl,
        mapTypeId: mapTypeId,
        navigationControl: navigationControl,
        noClear: noClear,
        scaleControl: scaleControl,
        scrollwheel: scrollwheel,
        streetViewControl: streetViewControl,
        zoom: zoom
    });


    // EVENT HANDLING

    $(map_canvas).bind("resize", function () {
        google.maps.event.trigger(map, 'resize');
        return false;
    });

    google.maps.event.addListener(map, 'bounds_changed', function () {
        bounds = map.getBounds();
        window.external.OnBounds_Changed(bounds);
    });

    google.maps.event.addListener(map, 'center_changed', function () {
        center = map.getCenter();
        window.external.OnCenter_changed(center);
    });

    google.maps.event.addListener(map, 'click', function (event) {
        mouseLocation = event.latLng;
        window.external.OnClick(mouseLocation);
    });

    google.maps.event.addListener(map, 'dblclick', function (event) {
        mouseLocation = event.latLng;
        window.external.OnDblclick(mouseLocation);
    });

    google.maps.event.addListener(map, 'drag', function () {
        window.external.OnDrag();
    });

    google.maps.event.addListener(map, 'dragend', function () {
       window.external.OnDragEnd();
    });

    google.maps.event.addListener(map, 'dragstart', function () {
        window.external.OnDragStart();
    });

    google.maps.event.addListener(map, 'idle', function () {
        window.external.OnIdle();
    });

    google.maps.event.addListener(map, 'maptypeid_changed', function () {
        mapTypeId = map.getMapTypeId();
        window.external.OnMapTypeId_Changed(mapTypeId);
    });

    google.maps.event.addListener(map, 'mousemove', function (event) {
        mouseLocation = event.latLng;
        window.external.OnMouseMove(mouseLocation);
    });

    google.maps.event.addListener(map, 'mouseout', function (event) {
        mouseLocation = event.latLng;
        window.external.OnMouseOut(mouseLocation);
    });

    google.maps.event.addListener(map, 'mouseover', function (event) {
        MouseLocation = event.latLng;
        window.external.OnMouseover(mouseLocation);
    });

    google.maps.event.addListener(map, 'projection_changed', function () {
        window.external.OnProjection_Changed();
    });

    google.maps.event.addListener(map, 'resize', function () {
        window.external.OnResize();
    });

    google.maps.event.addListener(map, 'tilesloaded', function () {
        window.external.OnTilesLoaded();
    });

    google.maps.event.addListener(map, 'rightclick', function (event) {
        MouseLocation = event.latLng;
        window.external.OnRightClick(MouseLocation);
    });

    google.maps.event.addListener(map, 'zoom_changed', function () {
        zoom = map.getZoom();
        window.external.OnZoom_Changed(zoom);
    });


};


//MAP FUNCTIONS
function panBy(x, y) {
    map.panBy(x, y);
};

function panTo(item) {
    map.panTo(CastToJsLatLng(item));
};

function panToBounds(item) {
    map.panToBounds(CatsToJsLngBounds(item));
};

function setStreetViewControl(value) {
    streetViewControl = value;
        var options = {
        streetViewControl: streetViewControl
    };
    map.setOptions(options);
};

function getStreetViewControl() {
    return streetViewControl;
};

//-- scrollwheel --
function setScrollwheel(value) {
    scrollwheel = value;
    var options = {
        scrollwheel: scrollwheel
    };
    map.setOptions(options);
};

function getScrollwheel() {
    return scrollwheel;
};

//-- scaleControl --
function setScaleControl(value) {
    scaleControl = value;
    var options = {
        scaleControl: scaleControl
    };
    map.setOptions(options);
};

function getScaleControl() {
    return scaleControl;
};

function setScaleControlOptions(value) {

    scaleControlOptions = ({
        //style: CatsToJsNavigationControlStyle(value.Style),
        position: CatsToJsControlPosition(value.Position)
    });

    var options = {
        scaleControlOptions: scaleControlOptions
    };

    map.setOptions(options);

};

//--navigationControl--
function setNavigationControl(value) {
    navigationControl = value;
    var options = {
        navigationControl: navigationControl
    };
    map.setOptions(options);
};

function getNavigationControl() {
    return navigationControl;
};

function setNavigationControlOptions(value) {

    navigationControlOptions = ({
        style: CatsToJsNavigationControlStyle(value.Style),
        position: CatsToJsControlPosition(value.Position)
    });

    var options = {
        navigationControlOptions: navigationControlOptions
    };

    map.setOptions(options);

};


function setMapTypeControl(value) {
    mapTypeControl = value;
    var options = {
        mapTypeControl: mapTypeControl
    };
    map.setOptions(options);
};

function getMapTypeControl() {
    return mapTypeControl;
};


function setMapTypeControlOptions(value,count) {

//    var t_mapTypeIds = [];

//    for (i = 0; i <= (count-1); i++) {
//        t_mapTypeIds.push(CatsToJsMapTypeId(value.MapTypeIds[i]));
//    };


    mapTypeControlOptions = ({
        style: CatsToJsMapTypeControlStyle(value.Style),
        position: CatsToJsControlPosition(value.Position)
        //,mapTypeIds: t_mapTypeIds
    });

     var options = {
        mapTypeControlOptions: mapTypeControlOptions
    };

    map.setOptions(options);

};


function setMapTypeId(value) {
    mapTypeId = CatsToJsMapTypeId(value);
    map.setMapTypeId(CatsToJsMapTypeId(value));
};

function getMapTypeId() {
    return mapTypeId;
};


//--disableDefaultUI--
function setDisableDefaultUI(value) {
    disableDefaultUI = value;
    var options = {
        disableDefaultUI: disableDefaultUI
    };
    map.setOptions(options);
};

function getDisableDefaultUI() {
    return disableDefaultUI;
};

//--disableDefaultUI--
function setDisableDoubleClickZoom(value) {
    disableDoubleClickZoom = value;
    var options = {
        disableDoubleClickZoom: disableDoubleClickZoom
    };
    map.setOptions(options);
};

function getDisableDoubleClickZoom() {
    return disableDoubleClickZoom;
};

//--draggable--
function setDraggable(value) {
    draggable = value;
    var options = {
        draggable: draggable
    };
    map.setOptions(options);
};

function getDraggable() {
    return draggable;
};

//--draggableCursor--
function setDraggableCursor(value) {
    draggableCursor = value;
    var options = {
        draggableCursor: draggableCursor
    };
    map.setOptions(options);
};

function getDraggableCursor() {
    return draggableCursor;
};

//--draggingCursor--
function setDraggingCursor(value) {
    draggingCursor = value;
    var options = {
        draggingCursor: draggingCursor
    };
    map.setOptions(options);
};

function getDraggingCursor() {
    return draggingCursor;
};



//--noClear--
function setNoClear(value) {
    noClear = value;
    var options = {
        noClear: noClear
    };
    map.setOptions(options);
};

function getNoClear() {
    return noClear;
};


//--keyboardShortcuts--
function setKeyboardShortcuts(value) {
    keyboardShortcuts = value;
    var options = {
        keyboardShortcuts: keyboardShortcuts
    };
    map.setOptions(options);
};

function getKeyboardShortcuts() {
    return keyboardShortcuts;
}; 

//--fitBounds--
function fitBounds(item) {
    map.fitBounds(CatsToJsLngBounds(item));
};


//--bounds (Read Only)--
function getBounds() {
    return bounds;
};

//--center--
function setCenter(value) {
    map.setCenter(CastToJsLatLng(value));
};

function getCenter() {
    return center;
};

//--zoom--
function setZoom(value) {
    map.setZoom(value);
};

function getZoom() {
    return zoom;
};

