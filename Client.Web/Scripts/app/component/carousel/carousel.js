angular.module('component.carousel', []).directive('carousel', function() {
    return {
        restrict: 'E',
        templateUrl: 'app/component/carousel/carousel.html',
        scope: true,
        link: function($scope) {
            $scope.header = 'Hello ';
        }
    };
});