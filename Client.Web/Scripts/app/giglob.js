angular.module('giglob-app',[
    'yaMap',
    'LocalStorageModule',
    'mm.foundation',
    "component.gheader",
    'component.router',
    'component.city-popup',
    'component.carousel'
]).directive('giglob', function() {
    return {
        templateUrl: '/app/giglob.html',
        controller: function($scope) {},
        link: function($scope) {}
    };
});