angular.module('component.gfooter', []).directive('gfooter', function() {
    return {
        restrict: 'E',
        templateUrl: 'app/component/gfooter/gfooter.html',
        scope: false
    };
});