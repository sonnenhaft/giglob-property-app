angular.module('giglob-app',[
    'mm.foundation',
    "component.gheader",
    'component.router',
    'component.login',
    'passToText'
]).directive('giglob', function() {
    return {
        templateUrl: '/app/giglob.html',
        link: function($scope) {
            
        }
    };
});