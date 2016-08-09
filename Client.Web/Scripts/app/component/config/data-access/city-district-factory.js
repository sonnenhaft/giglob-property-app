angular.module('component.config.data-access').factory('cityDistrictFactory', function ($resource, currentServer) {
    return $resource(currentServer + '/v1/home/getdata', null, {
        get: {
            method: 'GET',
            transformResponse: function (data) {
                var cities = JSON.parse(data).cities;
                return {
                    asArray: cities,
                    asMap: cities.reduce(function (cities, city) {
                        cities[city.id] = {
                            id: city.id,
                            name: city.name,
                            districtsAsArray: city.districts,
                            districts: city.districts.reduce(function (dist, district) {
                                dist[district.id] = district.name;
                                return dist;
                            }, {})
                        };
                        return cities;
                    }, {})
                }
            }
        }
    });
});