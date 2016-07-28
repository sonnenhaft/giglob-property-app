angular.module('api.httpRequestInterceptor',[]).factory('httpRequestInterceptor', function (localStorageService) {
    return {
        request: function (config) {

            config.headers.Authorization = 'Bearer';

            return config;
        }
    };
});
