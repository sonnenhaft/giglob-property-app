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
    'component.metro-station-multiselect',
    'passToText',
    'component.city-popup'
]).directive('giglob', function () {
    return {
        templateUrl: 'app/giglob.html',
        controller: function($scope,$rootScope) {
            $rootScope.$on( "$locationChangeSuccess", function() {
                $scope.curState = window.location.hash;
            });
        },
        link: function($scope) {}
    };
}).run(function ($http, localStorageService,$rootScope) {
    $rootScope._city = 'Москва';
    var token = localStorageService.get('access-token');
    if(token){
        $http.defaults.headers.common.Authorization = 'Bearer ' + token;
    }

});