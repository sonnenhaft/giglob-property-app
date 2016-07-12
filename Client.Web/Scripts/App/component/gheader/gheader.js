angular.module('component.gheader', []).directive('gheader', function() {
    return {
        restrict: 'E',
        templateUrl: 'component/gheader/gheader.html',
        scope: true,
        link: function($scope) {

        }
    }
});