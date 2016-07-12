angular.module('giglob-app',[
    "component.gheader",
    'mm.foundation',
    'component.router'
]).directive('giglob', function() {
    return {
        templateUrl: '/app/giglob.html',
        link: function($scope) {
            
        }
    }
});