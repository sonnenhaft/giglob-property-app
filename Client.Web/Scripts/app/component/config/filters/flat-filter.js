angular.module('component.config.filters', []).filter('flatFilter', function ($filter) {
    return function (allFlats, roomsCount, stations, priceRange) {
        var filteredFlats = [];
        angular.forEach(allFlats, function(flat) {
            var hasSameRoomsCount = !roomsCount.length || roomsCount.some(function (item) {
                return item.value === flat.roomCount.toString() ||
                    item.value === '4+' && flat.roomsCount > 3;
            });
            var hasSameStation = !stations.length || stations.some(function (station) {
                return station.name === flat.streetName;
            });
            var hasLessPriceThanMax = priceRange.max === '' || flat.cost < priceRange.max;
            var hasGreaterPriceThanMin = priceRange.min === '' || flat.cost > priceRange.min;
            if(hasSameRoomsCount && hasSameStation && hasLessPriceThanMax && hasGreaterPriceThanMin) {
                filteredFlats.push(flat);
            }
        });
        return $filter('orderBy')(filteredFlats, 'summary.publishDate');
    };
}).filter('coverPhotoUrl', function () {
    return function (photos) {
        if(photos && photos.length > 0)
        return photos.some(function (item) {
            return item.isCover;
        }).url;
    }
});