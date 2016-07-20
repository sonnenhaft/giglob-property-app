angular.module('giglob-app',[
    "component.gheader",
    'mm.foundation',
    'component.router',
    'component.carousel',
    'demo'
]).directive('giglob', function() {
    return {
        templateUrl: '/app/giglob.html',
        link: function($scope) {
            
        }
    };
});