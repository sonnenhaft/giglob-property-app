angular.module('giglob-app',[
    'yaMap',
    'mm.foundation',
    "component.gheader",
    'component.router',
    'component.flat-filter',
    'component.carousel'
]).directive('giglob', function() {
    return {
        templateUrl: '/app/giglob.html',
        link: function($scope) {
            
        }
    };
});