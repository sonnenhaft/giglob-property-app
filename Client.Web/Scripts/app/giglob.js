angular.module('giglob-app',[
    'yaMap',
    'api.resource',
    'LocalStorageModule',
    'mm.foundation',
    'component.config.router',
    'component.config.filters',
    "component.gheader",
    'component.city-popup',
    'component.carousel',
    'component.login'
]).directive('giglob', function() {
    return {
        templateUrl: '/app/giglob.html',
        controller: function($scope) {},
        link: function($scope) {}
    };
});