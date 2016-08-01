angular.module('component.config.filters', []).filter('flatFilter', function ($filter) {
    return function (allFlats, roomsCount, stations, priceRange) {
        var filteredFlats = [];
        angular.forEach(allFlats, function(flat) {
            var hasSameRoomsCount = !roomsCount.length || roomsCount.some(function (item) {
                return item.value === flat.summary.roomsCount.toString() ||
                    item.value === '4+' && flat.summary.roomsCount > 3;
            });
            var hasSameStation = !stations.length || stations.some(function (station) {
                return station.name === flat.summary.station;
            });
            var hasLessPriceThanMax = priceRange.max === '' || flat.summary.price < priceRange.max;
            var hasGreaterPriceThanMin = priceRange.min === '' || flat.summary.price > priceRange.min;
            if(hasSameRoomsCount && hasSameStation && hasLessPriceThanMax && hasGreaterPriceThanMin) {
                filteredFlats.push(flat);
            }
        });
        return $filter('orderBy')(filteredFlats, 'summary.publishDate');
    };
});