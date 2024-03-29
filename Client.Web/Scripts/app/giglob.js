angular.module('giglob-app', [
    'yaMap',
    'api.resource',
    'api.currentServer',
    'LocalStorageModule',
    'mm.foundation',
    'templates',
    'component.config.data-access',
    'component.config.filters',
    'component.config.router',
    "component.header",
    "component.gfooter",
    'component.carousel',
    'component.login',
    'component.flat-filter',
    'component.tab-section',
    'component.multiselect-dropdown-g',
    'passToText',
    'component.city-popup'
]).directive('giglob', function (localStorageService) {
    return {
        templateUrl: 'app/giglob.html',
        controller: function($scope) {},
        link: function($scope) {}
    };
}).run(function ($rootScope, localStorageService) {
    if(localStorageService.get('access-token')){
        $rootScope.accessToken =  localStorageService.get('access-token');
    }
});