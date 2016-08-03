angular.module("api.resource", ["ngResource","api.currentServer"])
    .factory('giglobApi', function ($resource, currentServer, $rootScope) {
        return  $resource(currentServer+'/v1/:type/:action',  null, {
            'getMyOffers': {
                method: 'GET',
                headers: {'Authorization':'Bearer ' + $rootScope.accessToken}
            },
            'save': {
                method: 'POST',
                headers: {'Authorization':'Bearer ' + $rootScope.accessToken}
            }
        });
    })
    .factory("register", function ($resource,currentServer) {

        return $resource(currentServer + '/v1/user/register',
            null,
            {
                'save': {method: 'POST'}
            });
    })
    .factory('login', function ($resource,currentServer) {
        return $resource(currentServer + '/v1/user/signin',
            null,
            {
                'save': {method: 'POST'}
            });
    })
    .factory('confirm', function ($resource,currentServer) {
        return $resource(currentServer + '/v1/user/confirmemail',
            null,
            {
                'save': {method: 'POST'}
            });
    })
    .factory('getProperty', function ($resource, $rootScope,currentServer) {
        return $resource(currentServer + '/v1/propertyoffer/get/:id',
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
