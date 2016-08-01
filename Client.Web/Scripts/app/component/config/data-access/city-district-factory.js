angular.module('component.config.data-access').factory('cityDistrictFactory',
    function($resource) {
    var apiUrl = document.getElementById('apiUrl').dataset.url;
    return $resource(apiUrl + '/v1/home/getdata');
});