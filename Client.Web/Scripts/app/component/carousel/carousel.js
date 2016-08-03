angular.module('component.carousel', [
]).directive('carousel', function ( $window ) {
    return {
        restrict: 'E',
        templateUrl: 'app/component/carousel/carousel.html',
        scope: {
            images: '=',
            disableThumbnails: '=?',
            disableArrows: '=?'
        },
        link: function ( $scope, $element, $attrs ) {
            var LEFT_ARROW_CODE = 37, RIGHT_ARROW_CODE = 39, DEFAULT_THUMBNAIL_WIDTH = 111;
            var thumbnailWrapper = $element[ 0 ].getElementsByClassName('carousel-thumbnail-wrapper')[ 0 ];

            $scope.carouselStyle = {
                width: $scope.images.length > 6 ? $scope.images.length * DEFAULT_THUMBNAIL_WIDTH + 5 + 'px' : 'auto',
                'padding-left': $scope.images.length > 6 ? '5px' : 0
            };

            if ( $scope.images.length <= 1 ) {
                $scope.disableThumbnails = $scope.disableArrows = true;
            }

            function setImageOnKeydown( e ) {
                if ( e.which === LEFT_ARROW_CODE ) {
                    $scope.setNextImage(-1, e);
                } else if ( e.which === RIGHT_ARROW_CODE ) {
                    $scope.setNextImage(1, e);
                }
                $scope.$digest();
            }

            $window.document.addEventListener('keydown', setImageOnKeydown);

            $scope.setActiveImage = function ( index ) {
                $scope.images[ $scope.currentIndex || 0 ].active = false;
                $scope.currentIndex = $scope.images[ index ] ? index : 0;
                $scope.images[ $scope.currentIndex ].active = true;
                thumbnailWrapper.scrollLeft = ($scope.currentIndex - 2) * DEFAULT_THUMBNAIL_WIDTH;
            };

            $scope.setNextImage = function ( index, e ) {
                e.stopPropagation();

                
                var currIndex = $scope.currentIndex + index;
                if ( currIndex < 0 ) {
                    currIndex = $scope.images.length - 1;
                } else if ( currIndex >= $scope.images.length ) {
                    currIndex = 0;
                }
                $scope.setActiveImage(currIndex);
            };

            $scope.setActiveImage(0);

            $scope.$on('$destroy', function () {
                $window.document.removeEventListener('keydown', setImageOnKeydown);
            });
        }
    };
});