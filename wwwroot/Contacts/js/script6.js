ymaps.ready(init);



function init() {
    var myMap = new ymaps.Map("map", {
        center: coordinateOne,
        zoom: 17
    });


    myMap.controls.remove('geolocationControl');
    myMap.controls.remove('searchControl');
    myMap.controls.remove('trafficControl');
    myMap.controls.remove('typeSelector');
    myMap.controls.remove('fullscreenControl');
    myMap.controls.remove('rulerControl');

    var myPlacemark = new ymaps.Placemark(coordinateOne, {}, {
        iconLayout: 'default#image',
        iconImageHref: '../Contacts/img/Subtract.png'
    });

    myMap.geoObjects.add(myPlacemark);
}

