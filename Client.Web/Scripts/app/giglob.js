angular.module('giglob-app', [
    'yaMap',
    'api.resource',
    'LocalStorageModule',
    'mm.foundation',
    'templates',
    'component.config.router',
    'component.config.filters',
    "component.gheader",
    "component.gfooter",
    'component.city-popup',
    'component.carousel',
]).directive('giglob', function() {
    'component.flat-filter'
]).directive('giglob', function() {
    'component.login'
]).directive('giglob', function(localStorageService) {
    return {
        templateUrl: 'app/giglob.html',
        link: function($scope,$rootScope) {
            if(localStorageService.get('access-token')){
                $rootScope.accessToken =  localStorageService.get('access-token');
            }
        }
    };
});