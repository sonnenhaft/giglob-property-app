angular.module("api.resource", ["ngResource"])
    .factory('giglobApi', function ($resource) {
        var API_URL = document.getElementById('apiUrl').dataset.url;
        return  $resource(API_URL + '/v1/:type/:action', {});
    })
    .factory("register", function ($resource) {
        var API_URL = document.getElementById('apiUrl').dataset.url;
        return $resource(API_URL + '/v1/user/register',
            null,
            {
                'save': {method: 'POST'}
            });
    })
    .factory('login', function ($resource) {
        var API_URL = document.getElementById('apiUrl').dataset.url;
        return $resource(API_URL + '/v1/user/signin',
            null,
            {
                'save': {method: 'POST'}
            });
    })
    .factory('confirm', function ($resource) {
        var API_URL = document.getElementById('apiUrl').dataset.url;
        return $resource(API_URL + '/v1/user/confirmemail',
            null,
            {
                'save': {method: 'POST'}
            });
    })
    .factory('getProperty', function ($resource, $rootScope) {
        var API_URL = document.getElementById('apiUrl').dataset.url;
        return $resource(API_URL + '/v1/propertyoffer/get/:id',
            null,
            {
                'save': {method: 'POST'},
                'query': {
                    method: 'GET',
                    headers: {'Authorization':'Bearer ' + $rootScope.accessToken},
                    params: {id: '@id'}
                }
            });
    });
