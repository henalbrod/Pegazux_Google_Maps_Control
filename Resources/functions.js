






function getOverlayView(map) {
    var ov = new google.maps.OverlayView();
    ov.onAdd = function () { };
    ov.draw = function () { };
    ov.onRemove = function () { };
    ov.setMap(map);
    return ov;
};


// EXTEND FUNCTION

function extend(m, e) {
    var e = e || this;
    for (var x in m) e[x] = m[x];
    return e;
};

// GENERAL FUNCTIONS

function CastToJsLatLng(item) {
    if (item != null) {
        return new google.maps.LatLng(item.lat, item.lng, item.NoWrap);
    }
    else {
        return null;
    };    
};

function CastToJsSize(item) {
    if (item != null) {
        return new google.maps.Size(item.width, item.height, item.widthUnit, item.heightUnit);
    }
    else {
        return null;        
    };        
};

function CastToJsPoint(item) {
    if (item != null) {
        return new google.maps.Point(item.x, item.y);
    }
    else {
        return null;
    };
};

function CatsToJsLngBounds(item) {
    return new google.maps.LatLngBounds(CastToJsLatLng(item.SouthWest),	CastToJsLatLng(item.NorthEast));
};


// MAP FUNCTIONS

function CatsToJsMapTypeId(item) {

    switch (item) {
        case 0: { return google.maps.MapTypeId.ROADMAP; break }
        case 1: { return google.maps.MapTypeId.SATELLITE; break }
        case 2: { return google.maps.MapTypeId.HYBRID; break }
        case 3: { return google.maps.MapTypeId.TERRAIN; break }
        default: { return google.maps.MapTypeId.ROADMAP; break }
    };

};

function CatsToJsMapTypeControlStyle(item) {

    switch (item) {
        case 2: { return google.maps.MapTypeControlStyle.DROPDOWN_MENU; break }
        case 1: { return google.maps.MapTypeControlStyle.HORIZONTAL_MENU; break }
    };

};

function CatsToJsNavigationControlStyle(item) {

    switch (item) {
        case 0: { return google.maps.NavigationControlStyle.ANDROID; break }
        case 2: { return google.maps.NavigationControlStyle.SMALL; break }
        case 3: { return google.maps.NavigationControlStyle.ZOOM_PAN; break }
    };

};

function CatsToJsControlPosition(item) {

    switch (item) {
        case 1: { return google.maps.ControlPosition.BOTTOM_CENTER; break }
        case 2: { return google.maps.ControlPosition.BOTTOM_LEFT; break }
        case 3: { return google.maps.ControlPosition.BOTTOM_RIGHT; break }
        case 4: { return google.maps.ControlPosition.LEFT_BOTTOM; break }
        case 5: { return google.maps.ControlPosition.LEFT_CENTER; break }
        case 6: { return google.maps.ControlPosition.LEFT_TOP; break }
        case 7: { return google.maps.ControlPosition.RIGHT_BOTTOM; break }
        case 8: { return google.maps.ControlPosition.RIGHT_CENTER; break }
        case 9: { return google.maps.ControlPosition.RIGHT_TOP; break }
        case 10: { return google.maps.ControlPosition.TOP_CENTER; break }
        case 11: { return google.maps.ControlPosition.TOP_LEFT; break }
        case 12: { return google.maps.ControlPosition.TOP_RIGHT; break }   
    };

};

//MARKERS FUNCTIONS

function CastToJsMarkerImage(item) {

    return new google.maps.MarkerImage(
         item.url,
         CastToJsSize(item.size),
         CastToJsPoint(item.origin),
         CastToJsPoint(item.anchor),
         CastToJsSize(item.scaledSize)
   );
};

function CastToJsMarkerShape(item) {
    var shape = {
        coord: item.coord,
        type: item.type.toString
    };
    return shape;
};

function CatsToJsMarker(item) {
    
    var t_marker = new google.maps.Marker({
        //map: map,
        clickable: item.clickable, 
        cursor: item.cursor.toString(),
        draggable: item.draggable,
        flat: item.flat,
        position: CastToJsLatLng(item.position),        
        shape: CastToJsMarkerShape(item.shape),
        title: item.title,
        visible: item.visible
        //zIndex: item.zIndex
    });

    if (item.icon.url != '') {
        t_marker.setIcon(CastToJsMarkerImage(item.icon));
    };

    if (item.shadow.url != '') {
        t_marker.setShadow(CastToJsMarkerImage(item.shadow));
    };

    return t_marker

};

