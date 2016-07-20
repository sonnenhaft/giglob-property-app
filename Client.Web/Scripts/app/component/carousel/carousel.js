angular.module('component.carousel', []).directive('carousel', function() {
    return {
        restrict: 'E',
        templateUrl: 'app/component/carousel/carousel.html',
        scope: {
            images: '=',
            disableThumbnails: '=?',
            disableArrows: '=?'
        },
        link: function($scope) {
            $scope.setActiveImage = function(index) {
                $scope.images[$scope.currentIndex || 0].active = false;
                $scope.currentIndex = index;
                $scope.images[index].active = true;
            };

            $scope.setNextImage = function(index) {
                var currIndex = $scope.currentIndex + index;

                if(currIndex < 0) {
                    currIndex = $scope.images.length - 1;
                } else if(currIndex >= $scope.images.length) {
                    currIndex = 0;
                }
                $scope.setActiveImage(currIndex);
            };

            $scope.setActiveImage(2);
        }
    };
});