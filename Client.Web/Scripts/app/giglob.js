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
    'component.login',
    'component.flat-filter',
    'component.tab-section'
]).directive('giglob', function(localStorageService) {
    return {
        templateUrl: 'app/giglob.html',
        controller: function($scope) {},
        link: function($scope,$rootScope) {
            if(localStorageService.get('access-token')){
                $rootScope.accessToken =  localStorageService.get('access-token');
            }
        }
    };
});