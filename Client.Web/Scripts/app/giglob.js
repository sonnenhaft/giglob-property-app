angular.module('giglob-app',[
    'yaMap',
    'LocalStorageModule',
    'mm.foundation',
    'templates',
    'component.config.router',
    'component.config.filters',
    "component.gheader",
    "component.gfooter",
    'component.city-popup',
    'component.carousel'
]).directive('giglob', function() {
    return {
        templateUrl: 'app/giglob.html',
        controller: function($scope) {},
        link: function($scope) {}
    };
});