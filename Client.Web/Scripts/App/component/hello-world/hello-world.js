angular.module('component.hello-world', []).directive('helloWorld', function() {
    return {
        restrict: 'E',
        templateUrl: 'component/hello-world/hello-world.html',
        scope: true,
        link: function($scope) {
            $scope.helloWorld = 'Hello world';
        }
    }
});