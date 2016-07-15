angular.module('component.gheader', []).directive('gheader', function() {
    return {
        restrict: 'E',
        templateUrl: 'app/component/gheader/gheader.html',
        scope: true,
        link: function($scope) {
            $scope.header = 'Hello ';
        }
    };
});