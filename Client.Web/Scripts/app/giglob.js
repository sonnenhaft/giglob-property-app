angular.module('giglob-app', [
    'yaMap',
    'LocalStorageModule',
    'mm.foundation',
    'templates',
    'component.config.router',
    'component.config.filters',
    "component.gheader",
    "component.gfooter",
    'component.city-popup',
    'component.carousel',
    'component.flat-filter',
    'component.add.location',
    'component.add.details',
    'component.add.photos',
    'component.add.docs',
    'component.add.change'
]).directive('giglob', function() {
    return {
        templateUrl: 'app/giglob.html',
        link: function($scope) {}
    };
});