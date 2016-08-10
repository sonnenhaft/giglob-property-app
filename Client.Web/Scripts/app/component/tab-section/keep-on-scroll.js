angular.module('component.keep-on-scroll', [
]).directive('keepOnScroll', function ($window) {
    var $$window = angular.element($window);
    return function ($scope, $element) {
        var clone;
        var offsetTop;
        var initialMargin = $element.css('margin-left') || '0px';
        var moveElement = function () {
            if (!clone) {
                offsetTop = $element[0].getBoundingClientRect().top;
            }
            if ($window.scrollY > offsetTop) {
                if (!clone) {
                    clone = $element.clone().css('visibility', 'hidden');
                    $element.css({position: 'fixed', 'z-index': 10, top: '8px'}).after(clone);
                }
                $element.css('margin-left', initialMargin - $window.scrollX + 'px');
            } else {
                if (clone) {
                    clone.remove();
                    clone = null;
                }
                $element.css({position: 'relative', 'margin-left': initialMargin});
            }
        };

        $$window.bind('scroll', moveElement);
        $scope.$on('$destoy', function () {
            if (clone) {
                clone.remove();
            }
            clone = null;
            $$window.unbind(moveElement)
        })
    }
});