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
            var LEFT_ARROW_CODE = 37, RIGHT_ARROW_CODE = 39;

            function changeImageOnClick(e) {
                if(e.which === LEFT_ARROW_CODE) {
                    $scope.setNextImage(-1);
                } else if(e.which === RIGHT_ARROW_CODE) {
                    $scope.setNextImage(1);
                }
                $scope.$digest();
            }

            document.addEventListener('keydown', changeImageOnClick);

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

            $scope.$on('$destroy', function() {
                document.removeEventListener('keydown', changeImageOnClick);
            });

            $scope.setActiveImage(2);
        }
    };
});