angular.module('component.config.data-access').factory('cityDistrictFactory',
    function($resource, currentServer) {
    return $resource(currentServer + '/v1/home/getdata', null, {
        get: {
            method: 'GET',
            transformResponse: function (data) {
                var cities = {};
                data = JSON.parse(data);
                data.cities.forEach(function(item){
                    var dist = {};
                    item.districts.forEach(function(item2){
                        dist[item2.id] = item2.name;
                    });
                    cities[item.id] = {'name': item.name, 'districts': dist};
                });
                return cities;
            }
        }
    });
});