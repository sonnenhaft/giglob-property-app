angular.module('component.header', []).directive('gheader', function() {
    return {
        restrict: 'E',
        templateUrl: 'component/gheader/gheader.html',
        scope: true,
        link: function($scope) {
            $scope.header = 'Hello ';
        }
    }
});