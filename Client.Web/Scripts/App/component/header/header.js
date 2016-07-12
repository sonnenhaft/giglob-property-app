angular.module('component.header', []).directive('gheader', function() {
    return {
        restrict: 'E',
        templateUrl: 'component/header/header.html',
        scope: true,
        link: function($scope) {
            $scope.header = 'Hello ';
        }
    }
});