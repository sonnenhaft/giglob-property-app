angular.module('api.httpRequestInterceptor',[]).factory('httpRequestInterceptor', function (localStorageService,$rootScope) {
    return {
        request: function (config) {

            config.headers.Authorization = 'Bearer ' + $rootScope.accessToken;

            return config;
        }
    };
});
